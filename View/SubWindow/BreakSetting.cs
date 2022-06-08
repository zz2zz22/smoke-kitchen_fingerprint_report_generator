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
            SqlSoft sqlSoft = new SqlSoft();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" select a.[09txCode] as ID, a.NameVN as Ten_Bo_Phan, g.NameVN as Bo_Phan_Lon, c.RangeDesc as Trua, d.RangeDesc as Chieu, e.RangeDesc as Toi,  f.RangeDesc as Khuya
  from SmokeReport_Department as a
  LEFT JOIN SmokeReport_DepartmentBreakTime b on b.DeptID = a.[09txCode]
  LEFT JOIN KitchenReport_BreakTimeRange c on b.BreakID1 = c.ID 
  LEFT JOIN KitchenReport_BreakTimeRange d on b.BreakID2 = d.ID 
  LEFT JOIN KitchenReport_BreakTimeRange e on b.BreakID3 = e.ID 
  LEFT JOIN KitchenReport_BreakTimeRange f on b.BreakID4 = f.ID 
  LEFT JOIN SmokeReport_Department as g on SUBSTRING(a.[09txCode],1,3) = g.[09txCode]
  where a.[09txCode] not like '%999%' and  a.[09txCode] not like '%888%' and a.[09txCode] not like '%100%'");
            sqlSoft.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
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
            if (Properties.Settings.Default.isRemoveBT == true)
            {
                chbx_isRemoveBT.Checked = true;
            }
            else
            {
                chbx_isRemoveBT.Checked = false;
            }
        }

        private void cbx_introSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.introFile = cbx_introSelect.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void chbx_isRemoveBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_isRemoveBT.Checked == true)
            {
                Properties.Settings.Default.isRemoveBT = true;
            }
            else
            {
                Properties.Settings.Default.isRemoveBT = false;
            }
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
    }
}
