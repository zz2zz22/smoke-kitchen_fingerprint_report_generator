using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public partial class BreakSetting : Form
    {
        public BreakSetting()
        {
            InitializeComponent();
        }
        
        
        public DataTable GetDataToDTGVDept()
        {
            DataTable dt = new DataTable();
            ComboBox cbxCode = new ComboBox();
            SqlSoft sqlSoft = new SqlSoft();
            SqlHR sqlHR = new SqlHR();
            StringBuilder getAllDeptCode = new StringBuilder();
            getAllDeptCode.Append("select distinct Code from ZlDept where TreeLevel = '2'");
            sqlHR.getComboBoxData(getAllDeptCode.ToString(), ref cbxCode);
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select a.DeptID as ID, a.DeptName as Ten_Bo_Phan, a.BigDeptName as Bo_Phan_Lon, c.RangeDesc as Trua, d.RangeDesc as Chieu, e.RangeDesc as Toi,  f.RangeDesc as Khuya
  from BreakTimeRange as a 
  LEFT JOIN KitchenReport_BreakTimeRange c on a.BreakID1 = c.ID 
  LEFT JOIN KitchenReport_BreakTimeRange d on a.BreakID2 = d.ID 
  LEFT JOIN KitchenReport_BreakTimeRange e on a.BreakID3 = e.ID 
  LEFT JOIN KitchenReport_BreakTimeRange f on a.BreakID4 = f.ID 
  where a.DeptID not like '%999%' and  a.DeptID not like '%888%'");
            sqlSoft.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            for ( int j = 0; j < dt.Rows.Count; j++)
            {
                bool checkCode = cbxCode.Items.Contains(dt.Rows[j]["ID"].ToString());
                if (checkCode == false)
                {
                    sqlSoft.sqlExecuteNonQuery("delete from BreakTimeRange where DeptID = '" + dt.Rows[j]["ID"].ToString() + "'", false);
                    dt.Rows[j].Delete();
                }
            }
            dt.AcceptChanges();
            return dt;
        }


        private void xuibtn_closeSetting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BreakSetting_Load(object sender, EventArgs e)
        {
            dtgv_deptBreak.DataSource = GetDataToDTGVDept();
            this.dtgv_deptBreak.Columns["ID"].Visible = false;
            this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
            this.dtgv_deptBreak.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
            cbx_introSelect.Text = Properties.Settings.Default.introFile;
        }

        private void cbx_introSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.introFile = cbx_introSelect.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            this.dtgv_deptBreak.ClearSelection();
            lb_choseDeptName.Text = null;
            if (txb_search.Text.Trim() != "")
            {
                DataTable dt = new DataTable();
                dtgv_deptBreak.DataSource = null;
                string selectExpression = "Ten_Bo_Phan LIKE '%"+ txb_search.Text.Trim() + "%' OR Bo_Phan_Lon like '%"+ txb_search.Text.Trim() + "%'";
                DataRow[] rows = GetDataToDTGVDept().Select(selectExpression);
                if (rows.Count() > 0)
                {
                    dt = rows.CopyToDataTable();
                    dtgv_deptBreak.DataSource = dt;
                    this.dtgv_deptBreak.Columns["ID"].Visible = false;
                    this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
                    this.dtgv_deptBreak.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
                } 
            }
            else
            {
                dtgv_deptBreak.DataSource = GetDataToDTGVDept();
                this.dtgv_deptBreak.Columns["ID"].Visible = false;
                this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
                this.dtgv_deptBreak.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
            }
            
        }

        private void dtgv_deptBreak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_deptBreak.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgv_deptBreak.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgv_deptBreak.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["ID"].Value);
                SaveVariables.Dept = cellValue;
                lb_choseDeptName.Text = Convert.ToString(selectedRow.Cells["Ten_Bo_Phan"].Value);
                SaveVariables.DeptName = Convert.ToString(selectedRow.Cells["Ten_Bo_Phan"].Value);
            }
        }

        private void xuibtn_editDept_Click(object sender, EventArgs e)
        {
            if (SaveVariables.Dept == null)
            {
                MessageBox.Show("Vui lòng chọn một bộ phận để chỉnh sửa !");
            }
            else
            {
                ChangeBreakTime changeBreakTime = new ChangeBreakTime();
                changeBreakTime.ShowDialog();
            }
        }

        private void xuibtn_addDeptBreak_Click(object sender, EventArgs e)
        {
            AddBreak2Dept addBreak2Dept = new AddBreak2Dept();
            addBreak2Dept.ShowDialog();
        }

        private void BreakSetting_Activated(object sender, EventArgs e)
        {
            if (SaveVariables.Dept == null)
            {
                lb_choseDeptName.Text = String.Empty;
            }
            dtgv_deptBreak.DataSource = GetDataToDTGVDept();
            this.dtgv_deptBreak.Columns["ID"].Visible = false;
            this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dtgv_deptBreak.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
            this.dtgv_deptBreak.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            ConfigBreakTimeRange configBreakTimeRange = new ConfigBreakTimeRange();
            configBreakTimeRange.ShowDialog();
        }
    }
}
