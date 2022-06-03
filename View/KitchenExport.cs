using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public partial class KitchenExport : Form
    {
        public KitchenExport()
        {
            InitializeComponent();
        }

        private void KitchenExport_Load(object sender, EventArgs e)
        {
            dtpk_date.Value = DateTime.Now.AddDays(-1);
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string dateIn = dtpk_date.Value.ToString("yyyy-MM-dd");
                string dateNext = (dtpk_date.Value.AddDays(1)).ToString("yyyy-MM-dd");
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
                string pathsave = "";
                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GetDataLogic getDataLogic = new GetDataLogic();
                    List<KitchenEmployee> kitchenEmployees = getDataLogic.GetKitchenData(dateIn, dateNext);

                    SmokingReport smokingReport = new SmokingReport();
                    pathsave = saveFileDialog.FileName;
                    saveFileDialog.RestoreDirectory = true;
                    smokingReport.ExportExcelKitchenReport(pathsave, kitchenEmployees);
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
            }catch(Exception)
            {
                throw;
            }
           
        }
    }
}
