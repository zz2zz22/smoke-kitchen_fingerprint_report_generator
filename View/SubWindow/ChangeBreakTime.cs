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

            cbx_chooseRange.DisplayMember = "RangeDesc";
            cbx_chooseRange.ValueMember = "ID";
            cbx_chooseRange.DataSource = GetDatatoComboBox();
            cbx_chooseRange.SelectedIndex = -1;
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
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID1 from SmokeReport_DepartmentBreakTime where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 1:
                    SaveVariables.ID = "2";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID2 from SmokeReport_DepartmentBreakTime where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 2:
                    SaveVariables.ID = "3";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID3 from SmokeReport_DepartmentBreakTime where DeptID = '" + SaveVariables.Dept + "'");
                    txb_time1From.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    txb_time1To.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + breakID + "'");
                    break;
                case 3:
                    SaveVariables.ID = "4";
                    breakID = sqlSoft.sqlExecuteScalarString("select BreakID4 from SmokeReport_DepartmentBreakTime where DeptID = '" + SaveVariables.Dept + "'");
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
                    sqlSoft.sqlExecuteNonQuery("update SmokeReport_DepartmentBreakTime set BreakID" + SaveVariables.ID + " = " + SaveVariables.TempID + " where DeptID = '" + SaveVariables.Dept + "'", false);
                    MessageBox.Show("Lưu thành công!");
                    SaveVariables.ResetVariables();
                    cbx_chooseTime.SelectedIndex = -1;
                    cbx_breakRange.SelectedIndex = -1;
                    txb_time1From.Text = "";
                    txb_time1To.Text = "";
                    
                }
            }
        }

        private void cbx_chooseRange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlSoft sqlSoft = new SqlSoft();
            IDBreak = cbx_chooseRange.SelectedValue.ToString();
            txb_time1From2.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
            txb_time1To2.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
            txb_Desc.Text = sqlSoft.sqlExecuteScalarString("select RangeDesc from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (txb_time1From2.Text.Trim() != "" && txb_time1To2.Text.Trim() != "" && txb_Desc.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu dữ liệu vừa chỉnh ?", " Xác nhận", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        SqlSoft sqlSoft = new SqlSoft();
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("update KitchenReport_BreakTimeRange set InTime = '" + txb_time1From2.Text.Trim() + "', OutTime = '" + txb_time1To2.Text.Trim() + "', RangeDesc = '" + txb_Desc.Text + "' where ID = '" + IDBreak + "'");
                        sqlSoft.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                        MessageBox.Show("Chỉnh sửa thành công!");
                        IDBreak = null;
                        
                        txb_time1From2.Text = "";
                        txb_time1To2.Text = "";
                        txb_Desc.Text = "";
                        cbx_chooseRange.DisplayMember = "RangeDesc";
                        cbx_chooseRange.ValueMember = "ID";
                        cbx_chooseRange.DataSource = GetDatatoComboBox();
                        cbx_chooseRange.SelectedIndex = -1;
                        cbx_chooseTime.DisplayMember = "RangeDesc";
                        cbx_chooseTime.ValueMember = "ID";
                        cbx_chooseTime.DataSource = GetDatatoComboBox();
                        cbx_chooseTime.SelectedIndex = -1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Thiếu dữ liệu, Vui lòng không để trống  !");
            }
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu đang chọn ?", " Xác nhận", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    SqlSoft sqlSoft = new SqlSoft();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("delete from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
                    sqlSoft.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                    string Desc = sqlSoft.sqlExecuteScalarString("select RangeDesc from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
                    MessageBox.Show("Xóa thành công \""+ Desc +"!");
                    IDBreak = null;
                    
                    txb_time1From2.Text = "";
                    txb_time1To2.Text = "";
                    txb_Desc.Text = "";
                    cbx_chooseRange.DisplayMember = "RangeDesc";
                    cbx_chooseRange.ValueMember = "ID";
                    cbx_chooseRange.DataSource = GetDatatoComboBox();
                    cbx_chooseRange.SelectedIndex = -1;
                    cbx_chooseTime.DisplayMember = "RangeDesc";
                    cbx_chooseTime.ValueMember = "ID";
                    cbx_chooseTime.DataSource = GetDatatoComboBox();
                    cbx_chooseTime.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetMinMissingID()
        {
            SqlSoft sqlSoft = new SqlSoft();
            ComboBox cbx = new ComboBox();
            int min = 0;
            sqlSoft.getComboBoxData("select ID from KitchenReport_BreakTimeRange", ref cbx);
            List<int> myList = new List<int>();
            for (int i = 0; i < cbx.Items.Count; i++)
            {
                myList.Add(Convert.ToInt32(cbx.Items[i]));
            }

            int a = myList.OrderBy(x => x).First();
            int b = (myList.OrderBy(x => x).Last() + 1);
            List<int> myList2 = Enumerable.Range(a, b - a + 1).ToList();
            List<int> remaining = myList2.Except(myList).ToList();

            min = remaining.OrderBy(x => x).Last();

            return min.ToString();
        }
        private void xuiButton4_Click(object sender, EventArgs e)
        {
            if (txb_time1From2.Text.Trim() != "" && txb_time1To2.Text.Trim() != "" && txb_Desc.Text.Trim() != "")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có thêm mới dữ liệu ?", " Xác nhận", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        SqlSoft sqlSoft = new SqlSoft();
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("Insert into KitchenReport_BreakTimeRange (ID, InTime, OutTime, RangeDesc) ");
                        stringBuilder.Append("values ('" + GetMinMissingID() + "', '" + txb_time1From2.Text + "', '" + txb_time1To2.Text + "', '" + txb_Desc.Text + "' )");
                        sqlSoft.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                        MessageBox.Show("Thêm mới thành công!");
                        IDBreak = null;
                        
                        txb_time1From2.Text = "";
                        txb_time1To2.Text = "";
                        txb_Desc.Text = "";
                        cbx_chooseRange.DisplayMember = "RangeDesc";
                        cbx_chooseRange.ValueMember = "ID";
                        cbx_chooseRange.DataSource = GetDatatoComboBox();
                        cbx_chooseRange.SelectedIndex = -1;
                        cbx_chooseTime.DisplayMember = "RangeDesc";
                        cbx_chooseTime.ValueMember = "ID";
                        cbx_chooseTime.DataSource = GetDatatoComboBox();
                        cbx_chooseTime.SelectedIndex = -1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ dữ liệu khi thêm mới !");
            }
        }
    }
}
