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
    public partial class ConfigBreakTimeRange : Form
    {
        public ConfigBreakTimeRange()
        {
            InitializeComponent();
        }
        public string IDBreak;

        public DataTable GetDatatoComboBox()
        {
            DataTable dt = new DataTable();
            SqlSoft sqlSoft = new SqlSoft();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID, RangeDesc from KitchenReport_BreakTimeRange");
            sqlSoft.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        private void ConfigBreakTimeRange_Load(object sender, EventArgs e)
        {
            cbx_chooseRange.DisplayMember = "RangeDesc";
            cbx_chooseRange.ValueMember = "ID";
            cbx_chooseRange.DataSource = GetDatatoComboBox();
            cbx_chooseRange.SelectedIndex = -1;

            cbx_breakType.SelectedIndex = -1;
        }

        private void cbx_chooseRange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlSoft sqlSoft = new SqlSoft();
            IDBreak = cbx_chooseRange.SelectedValue.ToString();
            txb_time1From2.Text = sqlSoft.sqlExecuteScalarString("select InTime from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
            txb_time1To2.Text = sqlSoft.sqlExecuteScalarString("select OutTime from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
            txb_Desc.Text = sqlSoft.sqlExecuteScalarString("select RangeDesc from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'");
            cbx_breakType.SelectedIndex = int.Parse(sqlSoft.sqlExecuteScalarString("select Type from KitchenReport_BreakTimeRange where ID = '" + IDBreak + "'")) - 1;
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (txb_time1From2.Text.Trim() != "" && txb_time1To2.Text.Trim() != "" && txb_Desc.Text.Trim() != "" && cbx_breakType.SelectedIndex != -1)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu dữ liệu vừa chỉnh ?", " Xác nhận", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        SqlSoft sqlSoft = new SqlSoft();
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("update KitchenReport_BreakTimeRange set InTime = '" + txb_time1From2.Text.Trim() + "', OutTime = '" + txb_time1To2.Text.Trim() + "', RangeDesc = '" + txb_Desc.Text + "', Type = '" + (cbx_breakType.SelectedIndex + 1) + "' where ID = '" + IDBreak + "'");
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
                    MessageBox.Show("Xóa thành công \"" + Desc + "!");
                    IDBreak = null;

                    txb_time1From2.Text = "";
                    txb_time1To2.Text = "";
                    txb_Desc.Text = "";
                    cbx_chooseRange.DisplayMember = "RangeDesc";
                    cbx_chooseRange.ValueMember = "ID";
                    cbx_chooseRange.DataSource = GetDatatoComboBox();
                    cbx_chooseRange.SelectedIndex = -1;
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
                        if (cbx_breakType.SelectedIndex != -1)
                        {
                            SqlSoft sqlSoft = new SqlSoft();
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("Insert into KitchenReport_BreakTimeRange (ID, InTime, OutTime, RangeDesc, Type) ");
                            stringBuilder.Append("values ('" + GetMinMissingID() + "', '" + txb_time1From2.Text + "', '" + txb_time1To2.Text + "', '" + txb_Desc.Text + "', '" + (cbx_breakType.SelectedIndex + 1) + "' )");
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
                            
                            cbx_breakType.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn loại giờ nghỉ");
                        }

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

        private void xuibtn_closeSetting_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
