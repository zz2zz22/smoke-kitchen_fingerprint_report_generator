using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public class GetDataLogic
    {
        
        public string GetEmpDataFromCodeInt(string code)
        {
            SqlHR sqlHR = new SqlHR();
            StringBuilder sqlGetDataEmp = new StringBuilder();
            sqlGetDataEmp.Append("select e.Code + ';' + e.Name + ';' + d.Code + ';' + d2.Code ");
            sqlGetDataEmp.Append("from ZlEmployee as e, ");
            sqlGetDataEmp.Append("ZlDept as d, ");
            sqlGetDataEmp.Append("ZlDept as d2 ");
            sqlGetDataEmp.Append("where e.Code like '%-%' and CAST(SUBSTRING(e.Code, CHARINDEX('-', e.Code) + 1, LEN(e.Code)) AS int) = " + code + " ");
            sqlGetDataEmp.Append("and e.Dept = d.Code and  d2.Code = SUBSTRING(e.Dept, 1, 3)");
            string data = sqlHR.sqlExecuteScalarString(sqlGetDataEmp.ToString());
            return data;
        }
        public string GetDeptDataFromCodeInt(string code, string bigCode)
        {
            SqlSoft sqlSoft = new SqlSoft();
            StringBuilder sqlGetDataDept = new StringBuilder();
            sqlGetDataDept.Append(@"select a.NameVN + ';' + b.NameVN
  from SmokeReport_Department as a,
  SmokeReport_Department as b
  where a.[09txCode] = '" + code + "' and b.[09txCode] = '" + bigCode + "' ");
            string data = sqlSoft.sqlExecuteScalarString(sqlGetDataDept.ToString());
            return data;
        }

        #region smokeReport
        public List<EmployeeSmoking> GetSmokingData(string next, string from, string to) //Mot them dieu kien loc gio nghi
        {
            List<EmployeeSmoking> employeeSmokings = new List<EmployeeSmoking>();
            try
            {
                SqlAtt sqlAtt = new SqlAtt();
                ComboBox comboBox = new ComboBox();
                StringBuilder sqlGetCode = new StringBuilder();
                sqlGetCode.Append("select distinct pers_person_pin from att_transaction where att_date >= '" + from + "' and att_date <= '" + to + "'");
                sqlAtt.getComboBoxData(sqlGetCode.ToString(), ref comboBox);
                DataTable dt = new DataTable();

                ProgressDialog progressDialog = new ProgressDialog();

                Thread backgroundThreadFetchData = new Thread(
                    new ThreadStart(() =>
                    {
                        
                         // Update progress in progressDialog
                        for (int x = 0; x < comboBox.Items.Count; x++)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(@"with cte as (
SELECT a.id, a.pers_person_pin, a.att_datetime, a.device_sn
  FROM [ZKBioAccess].[dbo].[att_transaction] a
  JOIN [ZKBioAccess].[dbo].[att_transaction] b ON b.id =
  (
  select TOP 1 id from att_transaction
  where pers_person_pin = '" + comboBox.Items[x] + "' and att_datetime > '" + next + " 00:00:00' order by att_datetime asc ) where a.pers_person_pin = '" + comboBox.Items[x] + "' and a.att_datetime >= '" + from + " 00:00:00' and a.att_datetime <= '" + next + " 01:30:00') ");
                            stringBuilder.Append(@" select row_number() OVER (ORDER BY att_datetime asc) ID, pers_person_pin, att_datetime, device_sn, lead(device_sn) OVER (order by att_datetime) as nextDevice, lag(device_sn) OVER (order by att_datetime) as prevDevice 
    into #MyTemp 
	from cte;
	select * 
	into #MyTemp2
	from (
  select ID, pers_person_pin, att_datetime, device_sn
  from #MyTemp
  where device_sn = '4879202300002' and nextDevice = '4879202300009' 
  UNION ALL
  select ID, pers_person_pin, att_datetime, device_sn
  from #MyTemp
  where device_sn = '4879202300009' and prevDevice = '4879202300002'
  ) t;

  select a.pers_person_pin as Code, a.att_datetime as TimeIN, b.att_datetime as TimeOUT
  from #MyTemp2 a,
  #MyTemp2 b where a.device_sn = '4879202300002' and b.device_sn = '4879202300009' and b.ID = (a.ID + 1) and a.pers_person_pin = b.pers_person_pin
  order by a.att_datetime desc

  drop table #MyTemp
  drop table #MyTemp2");

                            sqlAtt.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                            Thread.Sleep(50);
                            progressDialog.UpdateProgress(100 * x / comboBox.Items.Count, "Fetching data from database ... ");
                        }
                        
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }
                ));
                Thread backgroundThreadReportAdd = new Thread(
                    new ThreadStart(() =>
                    {
                        dt.DefaultView.Sort = "TimeIN";
                        dt = dt.DefaultView.ToTable();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["Code"].ToString()) < 30000)
                            {
                                EmployeeSmoking smoke = new EmployeeSmoking();
                                string[] info = GetEmpDataFromCodeInt(dt.Rows[i]["Code"].ToString()).Split(';');

                                string[] deptInfo = GetDeptDataFromCodeInt(info[2], info[3]).Split(';');



                                string tempIn = Convert.ToDateTime(dt.Rows[i]["TimeIN"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                string tempOut = Convert.ToDateTime(dt.Rows[i]["TimeOUT"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                string[] splitDateIn = tempIn.Split(' ');

                                string[] splitDateOut = tempOut.ToString().Split(' ');
                                string[] timeIn = splitDateIn[1].Split(':');
                                string[] timeOut = splitDateOut[1].Split(':');
                                DateTime tIn = Convert.ToDateTime(splitDateIn[0] + " " + timeIn[0] + ":" + timeIn[1] + ":00");
                                DateTime tOut = Convert.ToDateTime(splitDateOut[0] + " " + timeOut[0] + ":" + timeOut[1] + ":00");
                                TimeSpan sub = tOut - tIn;
                                if (splitDateIn[0] == to) //add dieu kien breaktime sau
                                {
                                    smoke.Code = info[0];
                                    smoke.Name = info[1];
                                    smoke.BigDept = deptInfo[1];
                                    smoke.Dept = deptInfo[0];
                                    smoke.TotalMinute = sub.TotalMinutes.ToString();
                                    smoke.sIn = Convert.ToDateTime(dt.Rows[i]["TimeIN"].ToString()).ToString("HH:mm");
                                    smoke.sOut = Convert.ToDateTime(dt.Rows[i]["TimeOUT"].ToString()).ToString("HH:mm");
                                    smoke.Date = splitDateIn[0];

                                    employeeSmokings.Add(smoke);
                                }
                            }
                            Thread.Sleep(50);
                            progressDialog.UpdateProgress(100 * i / dt.Rows.Count, "Insert values into excel file ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }
                ));

                backgroundThreadFetchData.Start();
                progressDialog.ShowDialog();
                backgroundThreadReportAdd.Start();
                progressDialog.ShowDialog();

            }
            catch (Exception)
            {
                throw;
            }
            return employeeSmokings;
        }
        #endregion

        #region kitchenReport
        public int GetTotalRangeCount ()
        {
            SqlSoft sqlSoft = new SqlSoft();
            string count = sqlSoft.sqlExecuteScalarString("select COUNT(ID) from KitchenReport_BreakTimeRange");
            if ( count != String.Empty)
            {
                return int.Parse(count);
            }
            else
            {
                return 0;
            }
        }
        public List<KitchenEmployee> GetKitchenData(string date)
        {
            List<KitchenEmployee> kitchenEmployees = new List<KitchenEmployee>();
            try
            {
                SqlAtt sqlAtt = new SqlAtt();
                SqlSoft sqlSoft = new SqlSoft();
                int totalRange = GetTotalRangeCount();

                ProgressDialog progressDialog = new ProgressDialog();
                DataTable sum = new DataTable();
                Thread backgroundThreadFetchKitchenData = new Thread(
                    new ThreadStart(() =>
                    { 
                        for (int i = 1; i < totalRange + 1; i ++ )
                        {

                        }
                    }));

                        return kitchenEmployees;
            }catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }

}
