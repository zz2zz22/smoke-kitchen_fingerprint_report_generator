using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GetSmokingData_Techlink
{
    public partial class SmokeExport : Form
    {
        
        public SmokeExport()
        {
            InitializeComponent();
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
                string pathsave = "";
                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GetDataLogic getDataLogic = new GetDataLogic();
                    List<EmployeeSmoking> employeeSmokings = getDataLogic.GetSmokingData(dtpk_dateIn.Value, dtpk_dateOut.Value);

                    SmokingReport smokingReport = new SmokingReport();
                    pathsave = saveFileDialog.FileName;
                    saveFileDialog.RestoreDirectory = true;
                    smokingReport.ExportExcelSmokingReport(pathsave, employeeSmokings);
                    var resultMessage = MessageBox.Show("Lưu file báo cáo thành công ! \n\r Bạn có muốn mở file không ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultMessage == DialogResult.Yes)
                    {

                        FileInfo fi = new FileInfo(pathsave);
                        if (fi.Exists)
                        {
                            System.Diagnostics.Process.Start(pathsave);
                        }
                        else
                        {
                            MessageBox.Show("File không tồn tại !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SmokeExport_Load(object sender, EventArgs e)
        {
            dtpk_dateIn.Format = DateTimePickerFormat.Custom;
            dtpk_dateIn.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            dtpk_dateIn.Value = DateTime.Today.AddDays(-1);
            dtpk_dateOut.Format = DateTimePickerFormat.Custom;
            dtpk_dateOut.CustomFormat = "dd-MM-yyyy HH:mm:ss";
            dtpk_dateOut.Value = DateTime.Today.AddSeconds(-1);
        }

    }
}
