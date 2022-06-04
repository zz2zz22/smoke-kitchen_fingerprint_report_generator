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
                string dateIn = dtpk_dateIn.Value.ToString("yyyy-MM-dd");
                string dateOut = dtpk_dateOut.Value.ToString("yyyy-MM-dd");
                string dateNext = (dtpk_dateOut.Value.AddDays(1)).ToString("yyyy-MM-dd");
                if (dateOut == DateTime.Now.ToString("yyyy-MM-dd") || dtpk_dateOut.Value > DateTime.Now || dateIn == DateTime.Now.ToString("yyyy-MM-dd") || dtpk_dateIn.Value > DateTime.Now)
                {
                    MessageBox.Show("Hãy chọn lại ngày!");
                    dtpk_dateIn.Value = DateTime.Now.AddDays(-1);
                    dtpk_dateOut.Value = DateTime.Now.AddDays(-1);
                }
                else
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
                        List<EmployeeSmoking> employeeSmokings = getDataLogic.GetSmokingData(dateNext, dateIn, dateOut);

                        SmokingReport smokingReport = new SmokingReport();
                        pathsave = saveFileDialog.FileName;
                        saveFileDialog.RestoreDirectory = true;
                        smokingReport.ExportExcelSmokingReport(pathsave, employeeSmokings);
                        var resultMessage = MessageBox.Show("Smoking Report export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (resultMessage == DialogResult.Yes)
                        {

                            FileInfo fi = new FileInfo(pathsave);
                            if (fi.Exists)
                            {
                                System.Diagnostics.Process.Start(pathsave);
                            }
                            else
                            {
                                MessageBox.Show("File doestn't exist !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
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
            dtpk_dateIn.Value = DateTime.Now.AddDays(-1);
            dtpk_dateOut.Value = DateTime.Now.AddDays(-1);
        }
    }
}
