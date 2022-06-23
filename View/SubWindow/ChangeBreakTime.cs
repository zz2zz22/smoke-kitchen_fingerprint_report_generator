using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public partial class ChangeBreakTime : Form
    {
        public ChangeBreakTime()
        {
            InitializeComponent();
        }
        public string IDBreak;
        private void xuibtn_closeSetting_Click(object sender, EventArgs e)
        {
            this.Close();
            SaveVariables.ResetVariables();
            SaveVariables.ResetDept();
        }
        public DataTable GetDatatoComboBox()
        {
            DataTable dt = new DataTable();
            SqlSoft sqlSoft = new SqlSoft();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID, RangeDesc from KitchenReport_BreakTimeRange");
            sqlSoft.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        private void ChangeBreakTime_Load(object sender, EventArgs e)
        {
            lb_deptNameInfo.Text = SaveVariables.DeptName;
            cbx_chooseTime.DisplayMember = "RangeDesc";
            cbx_chooseTime.ValueMember = "ID";
            cbx_chooseTime.DataSource = GetDatatoComboBox();
            cbx_chooseTime.SelectedIndex = -1;
        }

        private void cbx_breakRange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlSoft sqlSoft = new SqlSoft();
            int i = cbx_breakRange.SelectedIndex;
            string breakID;
            switch(i)
            {
                case 0:
                    SaveVariables.ID = "1";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID1 from BreakTimeRange where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 1:
                    SaveVariables.ID = "2";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID2 from BreakTimeRange where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 2:
                    SaveVariables.ID = "3";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID3 from BreakTimeRange where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 3:
                    SaveVariables.ID = "4";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID4 from BreakTimeRange where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                default:
                    break;
            }
            
        }

        private void cbx_chooseTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveVariables.TempID = cbx_chooseTime.SelectedValue.ToString();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu dữ liệu vừa chỉnh ?", " Xác nhận", MessageBoxButtons.OKCancel);
            if ( dialogResult == DialogResult.OK)
            {
                if (SaveVariables.TempID == null || SaveVariables.ID == null)
                {
                    MessageBox.Show("Vui lòng chọn đủ các dữ liệu để chỉnh sửa");
                }
                else
                {
                    SqlSoft sqlSoft = new SqlSoft();
                    sqlSoft.sqlExecuteNonQuery("update BreakTimeRange set BreakID" + SaveVariables.ID + " = " + SaveVariables.TempID + " where DeptID = '" + SaveVariables.Dept + "'", false);
                    MessageBox.Show("Lưu thành công!");
                    SaveVariables.ResetVariables();
                    cbx_chooseTime.SelectedIndex = -1;
                    cbx_breakRange.SelectedIndex = -1;
                    txb_time1From.Text = "";
                    txb_time1To.Text = "";
                    
                }
            }
        }
    }
}
