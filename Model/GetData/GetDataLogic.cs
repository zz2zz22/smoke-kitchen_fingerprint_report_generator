using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            sqlGetDataEmp.Append(@"select e.Code + ';' + e.Name + ';' + d.Code + ';' + d.UpCode 
 from ZlEmployee as e, ZlDept as d 
 where e.Code like '%-%' and CAST(SUBSTRING(e.Code, CHARINDEX('-', e.Code) + 1, LEN(e.Code)) AS int) = '" + code + "' and e.Dept = d.Code ");
            
            string data = sqlHR.sqlExecuteScalarString(sqlGetDataEmp.ToString());
            if (data != String.Empty)
            {
                string[] temp = data.Split(';');
                if (temp[3] == "999")
                {
                    string tempDept = sqlHR.sqlExecuteScalarString("select Memo from ZlEmployee where Code like '" + temp[0] + "'");
                    string replacement = Regex.Replace(tempDept, @"\t|\n|\r", "");
                    string deptCode = sqlHR.sqlExecuteScalarString("select Code from ZlDept where LongName like '%" + replacement + "%'");
                    if (deptCode != String.Empty)
                    {
                        temp[3] = deptCode.Substring(0, 3);
                        temp[2] = deptCode;
                    }
                }
                data = String.Join(";", temp);
            }
            return data;
        }

        public string GetDeptDataFromCodeInt(string code, string bigCode)
        {
            SqlHR sqlHR = new SqlHR();
            StringBuilder sqlGetDataDept = new StringBuilder();
            sqlGetDataDept.Append(@"select a.Note + ';' + b.Note from ZlDept as a, ZlDept as b where a.Code = '" + code + "' and b.Code = '" + bigCode + "'");
            string data = sqlHR.sqlExecuteScalarString(sqlGetDataDept.ToString());
            return data;
        } // Chỉnh sửa lại logic lấy tù txcard

        public string GetDeptDataFromCodeIntFail(string code, string bigCode)
        {
            SqlHR sqlSoft = new SqlHR();
            StringBuilder sqlGetDataDept = new StringBuilder();
            sqlGetDataDept.Append(@"select a.Note + ';' + b.Note
  from ZlDept as a,
  ZlDept as b
  where a.Code = '" + code + "' and b.Code = '" + bigCode + "' ");
            string data = sqlSoft.sqlExecuteScalarString(sqlGetDataDept.ToString());
            return data;
        }

        #region smokeReport
        public List<EmployeeSmoking> GetSmokingData(DateTime from, DateTime to) //Mot them dieu kien loc gio nghi
        {
            List<EmployeeSmoking> employeeSmokings = new List<EmployeeSmoking>();
            try
            {
                SqlAtt sqlAtt = new SqlAtt();
                SqlHR sqlHR = new SqlHR();
                SqlSoft sqlSoft = new SqlSoft();

                ComboBox comboBox = new ComboBox();
                StringBuilder sqlGetCode = new StringBuilder();
                sqlGetCode.Append("select distinct pers_person_pin from att_transaction where att_datetime >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "' and att_datetime <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                sqlAtt.getComboBoxData(sqlGetCode.ToString(), ref comboBox);
                DataTable dt = new DataTable();
                
                ProgressDialog progressDialog = new ProgressDialog();

                DateTime next = to.AddHours(1);

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
  LEFT JOIN [ZKBioAccess].[dbo].[att_transaction] b ON b.id =
  (
  select TOP 1 id from att_transaction
  where pers_person_pin = '" + comboBox.Items[x] + "' and att_datetime > '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "' and device_sn = '4879202300009' order by att_datetime asc ) where a.pers_person_pin = '" + comboBox.Items[x] + "' ) ");
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
and a.att_datetime >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "' and a.att_datetime <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.att_datetime >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.att_datetime <= '" + next.ToString("yyyy-MM-dd HH:mm:ss") + "' order by a.att_datetime desc drop table #MyTemp drop table #MyTemp2");
                            sqlAtt.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                            

                progressDialog.UpdateProgress(100 * x / comboBox.Items.Count, "Đang lấy dữ liệu từ server ... ");
                        }

                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }));

                Thread backgroundBreakRemove = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt.Rows[i]["Code"].ToString()) < 30000)
                            {
                                string[] deptCode = GetEmpDataFromCodeInt(dt.Rows[i]["Code"].ToString()).Split(';');
                                string breaksTime = sqlSoft.sqlExecuteScalarString("select BreakID1 + ';' + BreakID2 + ';' + BreakID3 +';'+ BreakID4 from BreakTimeRange where DeptID = '" + deptCode[2] + "'");
                                if (breaksTime != String.Empty)
                                {
                                    string[] breakIDs = breaksTime.Split(';');
                                    DateTime time = Convert.ToDateTime(dt.Rows[i]["TimeIN"].ToString());
                                    for (int j = 0; j < breakIDs.Count(); j ++)
                                    {
                                        string timeIn = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakIDs[j] + "'");
                                        string timeOut = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakIDs[j] + "'");
                                        
                                        DateTime dIN = Convert.ToDateTime(time.ToString("yyyy-MM-dd") + " " + timeIn);
                                        DateTime dOut = Convert.ToDateTime(time.ToString("yyyy-MM-dd") + " " + timeOut);
                                        if (timeIn != String.Empty && timeOut != String.Empty)
                                        {
                                            if (time >= dIN && time <= dOut)
                                            {
                                                dt.Rows[i].Delete();
                                            }
                                        }
                                        progressDialog.UpdateProgress(100 * i / dt.Rows.Count, "Xóa các dữ liệu trong giờ nghỉ ... ");
                                    }
                                }
                            }
                        }
                        dt.AcceptChanges();
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
                                if (deptInfo.Length < 2)
                                {
                                    deptInfo = GetDeptDataFromCodeIntFail(info[2], info[3]).Split(';');
                                }
                                
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
                            progressDialog.UpdateProgress(100 * i / dt.Rows.Count, "Thêm dữ liệu vào file excel ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }
                ));

                backgroundThreadFetchData.Start();
                progressDialog.ShowDialog();
                if (Properties.Settings.Default.isRemoveBT == true)
                {
                    backgroundBreakRemove.Start();
                    progressDialog.ShowDialog();
                }  
                backgroundThreadReportAdd.Start();
                progressDialog.ShowDialog();
                return employeeSmokings;
            }
            catch (Exception)
            {
                throw;
            } 
        }
        #endregion


        #region kitchenReport
        public List<KitchenEmployee> GetKitchenData(DateTime dateIn, DateTime dateOut)
        {
            List<KitchenEmployee> kitchenEmployees = new List<KitchenEmployee>();
            try
            {
                SqlAtt sqlAtt = new SqlAtt();
                SqlSoft sqlSoft = new SqlSoft();

                DataTable sumEmp = new DataTable();
                DataColumn dtColumn;
                dtColumn = new DataColumn();
                dtColumn.DataType = Type.GetType("System.String");
                dtColumn.ColumnName = "Code";
                sumEmp.Columns.Add(dtColumn);
                dtColumn = new DataColumn();
                dtColumn.DataType = Type.GetType("System.DateTime");
                dtColumn.ColumnName = "inTime";
                sumEmp.Columns.Add(dtColumn);
                DataTable temp2 = new DataTable();
                DataColumn dtColumnTemp;
                dtColumnTemp = new DataColumn();
                dtColumnTemp.DataType = Type.GetType("System.String");
                dtColumnTemp.ColumnName = "Code";
                temp2.Columns.Add(dtColumnTemp);
                dtColumnTemp = new DataColumn();
                dtColumnTemp.DataType = Type.GetType("System.DateTime");
                dtColumnTemp.ColumnName = "inTime";
                temp2.Columns.Add(dtColumnTemp);

                ComboBox cbxEmp = new ComboBox();
                sqlAtt.getComboBoxData("select distinct pin from acc_transaction where LEN(pin) > 0 and UPPER(area_name) like 'KITCHEN' and event_time >= '" + dateIn.ToString("yyyy-MM-dd HH:mm:ss") + "' and event_time <= '" + dateOut.ToString("yyyy-MM-dd HH:mm:ss") + "' ", ref cbxEmp);

                ProgressDialog progressDialog = new ProgressDialog();
                Thread backgroundThreadFetchKitchenData = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < cbxEmp.Items.Count; i ++)
                        {
                            DataTable temp = new DataTable();
                            StringBuilder getDataKitchenonEmpID = new StringBuilder();
                            getDataKitchenonEmpID.Append(@"select pin as Code, event_time as inTime 
from acc_transaction where UPPER(area_name) like 'KITCHEN'
and pin = '"+cbxEmp.Items[i]+"' and event_time >= '" + dateIn.ToString("yyyy-MM-dd HH:mm:ss") + "' and event_time <= '" + dateOut.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                            sqlAtt.sqlDataAdapterFillDatatable(getDataKitchenonEmpID.ToString(), ref temp);
                            int reRow = 0;
                            temp.DefaultView.Sort = "inTime";
                            temp = temp.DefaultView.ToTable();
                            for (int j = 0; j < temp.Rows.Count; j ++)
                            {
                                if (temp.Rows.Count > 1)
                                {
                                    DateTime curRowDate = Convert.ToDateTime(temp.Rows[reRow]["inTime"]);
                                    DateTime nextRowDate = Convert.ToDateTime(temp.Rows[j]["inTime"]);
                                    if (j != temp.Rows.Count - 1)
                                    {
                                        if ((nextRowDate - curRowDate).TotalMinutes > 10)
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                            reRow = j;
                                        }
                                    }
                                    else
                                    {
                                        if ((nextRowDate - curRowDate).TotalMinutes > 10)
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                            DataRow dr2 = temp2.NewRow();
                                            dr2["Code"] = temp.Rows[j]["Code"].ToString();
                                            dr2["inTime"] = temp.Rows[j]["inTime"].ToString();
                                            temp2.Rows.Add(dr2);
                                        }
                                        else
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                        }
                                    }
                                }
                                else
                                {
                                    if (temp.Rows.Count == 1)
                                    {
                                        DataRow dr = temp2.NewRow();
                                        dr["Code"] = temp.Rows[j]["Code"].ToString();
                                        dr["inTime"] = temp.Rows[j]["inTime"].ToString();
                                        temp2.Rows.Add(dr);
                                    }
                                }
                            }
                            progressDialog.UpdateProgress(100 * i / cbxEmp.Items.Count, "Đang lấy dữ liệu từ server ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }));

                Thread backgroundThreadDataFilter = new Thread(
                new ThreadStart(() =>
                {
                    for (int a = 0; a < temp2.Rows.Count; a++)
                    {
                        if (Convert.ToInt32(temp2.Rows[a]["Code"].ToString()) < 30000)
                        {
                            string[] tempDeptcode = GetEmpDataFromCodeInt(temp2.Rows[a]["Code"].ToString()).Split(';');
                            if (tempDeptcode.Length > 1)
                            {
                                string deptBreaksTime = sqlSoft.sqlExecuteScalarString("select BreakID1 + ';' + BreakID2 + ';' + BreakID3 +';'+ BreakID4 from BreakTimeRange where DeptID = '" + tempDeptcode[2] + "'");
                                if (deptBreaksTime != String.Empty)
                                {
                                    string[] breakDeptIDs = deptBreaksTime.Split(';');
                                    DateTime timeKitchen = Convert.ToDateTime(temp2.Rows[a]["inTime"].ToString());
                                    bool checkBetween = false;
                                    for (int j = 0; j < breakDeptIDs.Count(); j++)
                                    {
                                        string timeIn = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");
                                        string timeOut = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");

                                        DateTime dIN = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeIn);
                                        DateTime dOut = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeOut);
                                        if (timeIn != String.Empty && timeOut != String.Empty)
                                        {
                                            if (timeKitchen >= dIN && timeKitchen <= dOut)
                                            {
                                                checkBetween = true;
                                            }
                                        }
                                    }
                                    if (checkBetween == false)
                                        temp2.Rows[a].Delete();
                                }
                            }
                            
                        }
                        progressDialog.UpdateProgress(100 * a / temp2.Rows.Count, "Thêm dữ liệu vào file excel ... ");
                    }
                    progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    temp2.AcceptChanges();
                }));

                Thread backgroundThreadKitchenReportAdd = new Thread(
                    new ThreadStart(() =>
                    {
                        sumEmp.Merge(temp2);
                        sumEmp.DefaultView.Sort = "inTime";
                        sumEmp = sumEmp.DefaultView.ToTable();
                        for (int i = 0; i < sumEmp.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(sumEmp.Rows[i]["Code"].ToString()) < 30000)
                            {
                                KitchenEmployee kitchen = new KitchenEmployee();
                                string[] info = GetEmpDataFromCodeInt(sumEmp.Rows[i]["Code"].ToString()).Split(';');
                                if (info.Length > 1)
                                {
                                    string[] deptInfo = GetDeptDataFromCodeInt(info[2], info[3]).Split(';');

                                    string tempIn = Convert.ToDateTime(sumEmp.Rows[i]["inTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    string[] splitDateIn = tempIn.Split(' ');

                                    if (deptInfo.Length < 2)
                                    {
                                        deptInfo = GetDeptDataFromCodeIntFail(info[2], info[3]).Split(';');
                                    }
                                    int breakType = 0;
                                    kitchen.Code = info[0];
                                    kitchen.Name = info[1];
                                    kitchen.BigDept = deptInfo[1];
                                    kitchen.Dept = deptInfo[0];
                                    kitchen.sIn = Convert.ToDateTime(sumEmp.Rows[i]["inTime"].ToString()).ToString("HH:mm");
                                    string deptBreaks = sqlSoft.sqlExecuteScalarString("select BreakID1 + ';' + BreakID2 + ';' + BreakID3 +';'+ BreakID4 from BreakTimeRange where DeptID = '" + info[2] + "'");
                                    if (deptBreaks != String.Empty)
                                    {
                                        string[] breakDeptIDs = deptBreaks.Split(';');
                                        DateTime timeKitchen = Convert.ToDateTime(sumEmp.Rows[i]["inTime"].ToString());

                                        for (int j = 0; j < breakDeptIDs.Count(); j++)
                                        {
                                            string timeIn = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");
                                            string timeOut = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");

                                            DateTime dIN = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeIn);
                                            DateTime dOut = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeOut);
                                            if (timeIn != String.Empty && timeOut != String.Empty)
                                            {
                                                if (timeKitchen >= dIN && timeKitchen <= dOut)
                                                {
                                                    breakType = int.Parse(sqlSoft.sqlExecuteScalarString("select distinct Type from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'"));
                                                }
                                            }
                                        }
                                    }
                                    kitchen.Date = splitDateIn[0];
                                    kitchen.type = breakType;
                                    kitchenEmployees.Add(kitchen);
                                }
                            }
                            progressDialog.UpdateProgress(100 * i / sumEmp.Rows.Count, "Thêm dữ liệu vào file excel ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }
                ));

                backgroundThreadFetchKitchenData.Start();
                progressDialog.ShowDialog();
                if (Properties.Settings.Default.isAddFilter == true)
                {
                    backgroundThreadDataFilter.Start();
                    progressDialog.ShowDialog();
                }
                backgroundThreadKitchenReportAdd.Start();
                progressDialog.ShowDialog();
                return kitchenEmployees;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<KitchenEmployee> GetKitchenDataWrong(DateTime dateIn, DateTime dateOut)
        {
            List<KitchenEmployee> kitchenEmployees = new List<KitchenEmployee>();
            try
            {
                SqlAtt sqlAtt = new SqlAtt();
                SqlSoft sqlSoft = new SqlSoft();

                DataTable sumEmp = new DataTable();
                DataColumn dtColumn;
                dtColumn = new DataColumn();
                dtColumn.DataType = Type.GetType("System.String");
                dtColumn.ColumnName = "Code";
                sumEmp.Columns.Add(dtColumn);
                dtColumn = new DataColumn();
                dtColumn.DataType = Type.GetType("System.DateTime");
                dtColumn.ColumnName = "inTime";
                sumEmp.Columns.Add(dtColumn);
                DataTable temp2 = new DataTable();
                DataColumn dtColumnTemp;
                dtColumnTemp = new DataColumn();
                dtColumnTemp.DataType = Type.GetType("System.String");
                dtColumnTemp.ColumnName = "Code";
                temp2.Columns.Add(dtColumnTemp);
                dtColumnTemp = new DataColumn();
                dtColumnTemp.DataType = Type.GetType("System.DateTime");
                dtColumnTemp.ColumnName = "inTime";
                temp2.Columns.Add(dtColumnTemp);

                ComboBox cbxEmp = new ComboBox();
                sqlAtt.getComboBoxData("select distinct pin from acc_transaction where LEN(pin) > 0 and UPPER(area_name) like 'KITCHEN' and event_time >= '" + dateIn.ToString("yyyy-MM-dd HH:mm:ss") + "' and event_time <= '" + dateOut.ToString("yyyy-MM-dd HH:mm:ss") + "' ", ref cbxEmp);

                ProgressDialog progressDialog = new ProgressDialog();
                Thread backgroundThreadFetchKitchenData = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < cbxEmp.Items.Count; i++)
                        {
                            DataTable temp = new DataTable();
                            
                            StringBuilder getDataKitchenonEmpID = new StringBuilder();
                            getDataKitchenonEmpID.Append(@"select pin as Code, event_time as inTime 
from acc_transaction where UPPER(area_name) like 'KITCHEN'
and pin = '" + cbxEmp.Items[i] + "' and event_time >= '" + dateIn.ToString("yyyy-MM-dd HH:mm:ss") + "' and event_time <= '" + dateOut.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                            sqlAtt.sqlDataAdapterFillDatatable(getDataKitchenonEmpID.ToString(), ref temp);
                            int reRow = 0;

                            for (int j = 0; j < temp.Rows.Count; j++)
                            {
                                if (temp.Rows.Count > 1)
                                {
                                    DateTime curRowDate = Convert.ToDateTime(temp.Rows[reRow]["inTime"]);
                                    DateTime nextRowDate = Convert.ToDateTime(temp.Rows[j]["inTime"]);
                                    if (j != temp.Rows.Count - 1)
                                    {
                                        if ((nextRowDate - curRowDate).TotalMinutes > 10)
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                            reRow = j;
                                        }
                                    }
                                    else
                                    {
                                        if ((nextRowDate - curRowDate).TotalMinutes > 10)
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                            DataRow dr2 = temp2.NewRow();
                                            dr2["Code"] = temp.Rows[j]["Code"].ToString();
                                            dr2["inTime"] = temp.Rows[j]["inTime"].ToString();
                                            temp2.Rows.Add(dr2);
                                        }
                                        else
                                        {
                                            DataRow dr = temp2.NewRow();
                                            dr["Code"] = temp.Rows[reRow]["Code"].ToString();
                                            dr["inTime"] = temp.Rows[reRow]["inTime"].ToString();
                                            temp2.Rows.Add(dr);
                                        }
                                    }
                                }
                                else
                                {
                                    if (temp.Rows.Count == 1)
                                    {
                                        DataRow dr = temp2.NewRow();
                                        dr["Code"] = temp.Rows[j]["Code"].ToString();
                                        dr["inTime"] = temp.Rows[j]["inTime"].ToString();
                                        temp2.Rows.Add(dr);
                                    }
                                }
                            }

                            progressDialog.UpdateProgress(100 * i / cbxEmp.Items.Count, "Đang lấy dữ liệu từ server ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }));
                Thread backgroundThreadKitchenGetWrongData = new Thread(
                    new ThreadStart(() =>
                    {
                        for (int a = 0; a < temp2.Rows.Count; a++)
                        {
                            if (Convert.ToInt32(temp2.Rows[a]["Code"].ToString()) < 30000)
                            {
                                string[] tempDeptcode = GetEmpDataFromCodeInt(temp2.Rows[a]["Code"].ToString()).Split(';');
                                if (tempDeptcode.Length > 1)
                                {
                                    string deptBreaksTime = sqlSoft.sqlExecuteScalarString("select BreakID1 + ';' + BreakID2 + ';' + BreakID3 +';'+ BreakID4 from BreakTimeRange where DeptID = '" + tempDeptcode[2] + "'");
                                    if (deptBreaksTime != String.Empty)
                                    {
                                        string[] breakDeptIDs = deptBreaksTime.Split(';');
                                        DateTime timeKitchen = Convert.ToDateTime(temp2.Rows[a]["inTime"].ToString());
                                        bool checkBetween = false;
                                        for (int j = 0; j < breakDeptIDs.Count(); j++)
                                        {
                                            string timeIn = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");
                                            string timeOut = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakDeptIDs[j] + "'");

                                            DateTime dIN = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeIn);
                                            DateTime dOut = Convert.ToDateTime(timeKitchen.ToString("yyyy-MM-dd") + " " + timeOut);
                                            if (timeIn != String.Empty && timeOut != String.Empty)
                                            {
                                                if (timeKitchen >= dIN && timeKitchen <= dOut)
                                                {
                                                    checkBetween = true;
                                                }
                                            }
                                        }
                                        if (checkBetween == true)
                                        {
                                            temp2.Rows[a].Delete();
                                        }
                                    }
                                }

                            }
                            progressDialog.UpdateProgress(100 * a / temp2.Rows.Count, "Lọc dữ liệu nhân viên đi sai giờ ... ");
                        }
                        temp2.AcceptChanges();
                        sumEmp.Merge(temp2);
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }));
                Thread backgroundThreadKitchenReportAdd = new Thread(
                    new ThreadStart(() =>
                    {
                        sumEmp.DefaultView.Sort = "inTime";
                        sumEmp = sumEmp.DefaultView.ToTable();
                        for (int i = 0; i < sumEmp.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(sumEmp.Rows[i]["Code"].ToString()) < 30000)
                            {
                                KitchenEmployee kitchen = new KitchenEmployee();
                                string[] info = GetEmpDataFromCodeInt(sumEmp.Rows[i]["Code"].ToString()).Split(';');
                                if (info.Length > 1)
                                {
                                    string[] deptInfo = GetDeptDataFromCodeInt(info[2], info[3]).Split(';');
                                    string tempIn = Convert.ToDateTime(sumEmp.Rows[i]["inTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                    string[] splitDateIn = tempIn.Split(' ');
                                    if (deptInfo.Length < 2)
                                    {
                                        deptInfo = GetDeptDataFromCodeIntFail(info[2], info[3]).Split(';');
                                    }
                                    kitchen.Code = info[0];
                                    kitchen.Name = info[1];
                                    kitchen.BigDept = deptInfo[1];
                                    kitchen.Dept = deptInfo[0];
                                    kitchen.sIn = Convert.ToDateTime(sumEmp.Rows[i]["inTime"].ToString()).ToString("HH:mm");
                                    kitchen.Date = splitDateIn[0];

                                    kitchenEmployees.Add(kitchen);
                                }
                            }
                            progressDialog.UpdateProgress(100 * i / sumEmp.Rows.Count, "Thêm dữ liệu vào file excel ... ");
                        }
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    }
                ));

                backgroundThreadFetchKitchenData.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenGetWrongData.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenReportAdd.Start();
                progressDialog.ShowDialog();
                return kitchenEmployees;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }

}
