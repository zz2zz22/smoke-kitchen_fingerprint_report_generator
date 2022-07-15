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
    public partial class AddBreak2Dept : Form
    {
        public string ID = "";
        public string IDRemove = "";
        public DataTable temp = new DataTable();
        public AddBreak2Dept()
        {
            InitializeComponent();
        }
        public DataTable GetDatatoComboBox(int type)
        {
            DataTable dt = new DataTable();
            SqlSoft sqlSoft = new SqlSoft();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID, RangeDesc from KitchenReport_BreakTimeRange where Type = '" + type + "'");
            sqlSoft.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetUnSetDept()
        {
            DataTable dt = new DataTable();
            SqlSoft sqlSoft = new SqlSoft();
            SqlHR sqlHR = new SqlHR();
            List<string> tempDept = new List<string>();
            ComboBox cbxSoftDepts = new ComboBox();
            ComboBox cbxHRDepts = new ComboBox();
            sqlSoft.getComboBoxData("select distinct DeptID from BreakTimeRange", ref cbxSoftDepts);
            sqlHR.getComboBoxData("select distinct Code from ZlDept where TreeLevel = '2'", ref cbxHRDepts);
            for (int i = 0; i < cbxHRDepts.Items.Count; i ++)
            {
                if (!cbxSoftDepts.Items.Contains(cbxHRDepts.Items[i].ToString()))
                {
                    tempDept.Add(cbxHRDepts.Items[i].ToString());
                }
            }
            for (int j = 0; j < tempDept.Count; j++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select a.Code as ID, a.Note as Ten_Bo_Phan, b.Note as Bo_Phan_Lon 
  from ZlDept as a
  LEFT JOIN ZlDept b ON b.Code = a.UpCode where a.Code = '" + tempDept[j]+"'");
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            return dt;
        }
        private void xuibtn_closeAddBreak2Dept_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            temp = null;
            ID = "";
            IDRemove = "";
        }

        private void AddBreak2Dept_Load(object sender, EventArgs e)
        {
            dtgv_UnsetDept.DataSource = GetUnSetDept();
            dtgv_UnsetDept.Columns["ID"].Visible = false;

            cbx_afternoonBreak.DisplayMember = "RangeDesc";
            cbx_afternoonBreak.ValueMember = "ID";
            cbx_afternoonBreak.DataSource = GetDatatoComboBox(1);
            cbx_afternoonBreak.SelectedIndex = -1;

            cbx_dinnerBreak.DisplayMember = "RangeDesc";
            cbx_dinnerBreak.ValueMember = "ID";
            cbx_dinnerBreak.DataSource = GetDatatoComboBox(3);
            cbx_dinnerBreak.SelectedIndex = -1;

            cbx_noonBreak.DisplayMember = "RangeDesc";
            cbx_noonBreak.ValueMember = "ID";
            cbx_noonBreak.DataSource = GetDatatoComboBox(2);
            cbx_noonBreak.SelectedIndex = -1;

            cbx_nightBreak.DisplayMember = "RangeDesc";
            cbx_nightBreak.ValueMember = "ID";
            cbx_nightBreak.DataSource = GetDatatoComboBox(4);
            cbx_nightBreak.SelectedIndex = -1;
        }

        private void dtgv_UnsetDept_MultiSelectChanged(object sender, EventArgs e)
        {
            dtgv_chooseDept.DataSource = dtgv_UnsetDept.SelectedRows;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.dtgv_UnsetDept.ClearSelection();
            if (textBox1.Text.Trim() != "")
            {
                DataTable dt = new DataTable();
                dtgv_UnsetDept.DataSource = null;
                string selectExpression = "Ten_Bo_Phan LIKE '%" + textBox1.Text.Trim() + "%' OR Bo_Phan_Lon like '%" + textBox1.Text.Trim() + "%'";
                DataRow[] rows = GetUnSetDept().Select(selectExpression);
                if (rows.Count() > 0)
                {
                    dt = rows.CopyToDataTable();
                    dtgv_UnsetDept.DataSource = dt;
                    this.dtgv_UnsetDept.Columns["ID"].Visible = false;
                    this.dtgv_UnsetDept.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.dtgv_UnsetDept.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
                    this.dtgv_UnsetDept.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
                }
            }
            else
            {
                dtgv_UnsetDept.DataSource = GetUnSetDept();
                this.dtgv_UnsetDept.Columns["ID"].Visible = false;
                this.dtgv_UnsetDept.Columns["Ten_Bo_Phan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dtgv_UnsetDept.Columns["Ten_Bo_Phan"].HeaderText = "Tên bộ phận";
                this.dtgv_UnsetDept.Columns["Bo_Phan_Lon"].HeaderText = "Bộ phận lớn";
            }
        }
        
        private void dtgv_UnsetDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_UnsetDept.SelectedCells.Count > 0)
            {
                int selectedrowindex = dtgv_UnsetDept.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgv_UnsetDept.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["ID"].Value);
                ID = cellValue;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            bool checkContainID = false;
            if (ID != "")
            {
                if (temp.Rows.Count >= 1)
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if(temp.Rows[i]["ID"].ToString() == ID)
                        {
                            checkContainID = true;
                        }
                    }
                }
                if (!checkContainID)
                {
                    SqlHR sqlHR = new SqlHR();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(@"select a.Code as ID, a.Note as Ten_Bo_Phan, b.Note as Bo_Phan_Lon 
  from ZlDept as a
  LEFT JOIN ZlDept b ON b.Code = a.UpCode where a.Code = '" + ID + "'");
                    sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref temp);
                    dtgv_chooseDept.DataSource = temp;
                    dtgv_chooseDept.Columns["ID"].Visible = false;
                    ID = "";
                    dtgv_chooseDept.ClearSelection();
                    dtgv_UnsetDept.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Bộ phận đã được chọn!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bộ phận!");
            }
            
        }

        private void dtgv_chooseDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_chooseDept.SelectedCells.Count > 0)
            {

                int selectedrowindex = dtgv_chooseDept.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dtgv_chooseDept.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["ID"].Value);
                IDRemove = cellValue;
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (IDRemove != "")
            {
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (temp.Rows[i]["ID"].ToString() == IDRemove)
                    {
                        temp.Rows[i].Delete();
                    }
                }
                temp.AcceptChanges();
                dtgv_chooseDept.DataSource = temp;
                dtgv_chooseDept.Columns["ID"].Visible = false;
                IDRemove = "";
                dtgv_chooseDept.ClearSelection();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bộ phận để bỏ đi");
            }
        }

        private void cbx_afternoonBreak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveVariables.TempBreakID1 = cbx_afternoonBreak.SelectedValue.ToString();
        }

        private void cbx_noonBreak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveVariables.TempBreakID2 = cbx_noonBreak.SelectedValue.ToString();
        }

        private void cbx_dinnerBreak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveVariables.TempBreakID3 = cbx_dinnerBreak.SelectedValue.ToString();
        }

        private void cbx_nightBreak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SaveVariables.TempBreakID4 = cbx_nightBreak.SelectedValue.ToString();
        }

        private void btn_saveBreakTime_Click(object sender, EventArgs e)
        {
            if (SaveVariables.TempBreakID1 != null && SaveVariables.TempBreakID2 != null && SaveVariables.TempBreakID3 != null && SaveVariables.TempBreakID4 != null)
            {
                ProgressDialog progressDialog = new ProgressDialog();
                if (temp.Rows.Count > 0)
                {
                    Thread addData = new Thread(
                        new ThreadStart(() =>
                        {
                            for (int i = 0; i < temp.Rows.Count; i++)
                            {
                                SqlSoft sqlSoft = new SqlSoft();
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(@"insert into BreakTimeRange (DeptID, DeptName, BigDeptName, BreakID1, BreakID2, BreakID3, BreakID4 )
  values ('" + temp.Rows[i]["ID"].ToString() + "', '" + temp.Rows[i]["Ten_Bo_Phan"].ToString() + "', '" + temp.Rows[i]["Bo_Phan_Lon"].ToString() + "', '" + SaveVariables.TempBreakID1 + "', '" + SaveVariables.TempBreakID2 + "', '" + SaveVariables.TempBreakID3 + "', '" + SaveVariables.TempBreakID4 + "')");
                                sqlSoft.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                                progressDialog.UpdateProgress(100 * i / temp.Rows.Count, "Lưu thông tin các bộ phận lên server... ");
                            }
                            temp = null;
                            dtgv_chooseDept.DataSource = null;
                            dtgv_UnsetDept.DataSource = GetUnSetDept();
                            SaveVariables.ResetTempValue();
                            progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                        }));
                    addData.Start();
                    progressDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một bộ phận để tiến hành thêm!");
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Giờ nghỉ chưa được chọn đủ, bạn có muốn lưu ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    ProgressDialog progressDialog = new ProgressDialog();
                    if (temp.Rows.Count > 0)
                    {
                        Thread addData = new Thread(
                            new ThreadStart(() =>
                            {
                                for (int i = 0; i < temp.Rows.Count; i++)
                                {
                                    SqlSoft sqlSoft = new SqlSoft();
                                    StringBuilder stringBuilder = new StringBuilder();
                                    stringBuilder.Append(@"insert into BreakTimeRange (DeptID, DeptName, BigDeptName, BreakID1, BreakID2, BreakID3, BreakID4 )
  values ('" + temp.Rows[i]["ID"].ToString() + "', '" + temp.Rows[i]["Ten_Bo_Phan"].ToString() + "', '" + temp.Rows[i]["Bo_Phan_Lon"].ToString() + "', '" + SaveVariables.TempBreakID1 + "', '" + SaveVariables.TempBreakID2 + "', '" + SaveVariables.TempBreakID3 + "', '" + SaveVariables.TempBreakID4 + "')");
                                    sqlSoft.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                                    progressDialog.UpdateProgress(100 * i / temp.Rows.Count, "Lưu thông tin các bộ phận lên server... ");
                                }
                                temp = null;
                                SaveVariables.ResetTempValue();
                                progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                            }));
                        addData.Start();
                        progressDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một bộ phận để tiến hành thêm!");
                    }
                }
            }
           
        }
    }
}
