using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetSmokingData_Techlink
{
    public class ToolSupport
    {
        private void reOject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Export to excel fail: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
        public void ExportSmoking(List<EmployeeSmoking> employeeSmoking, string pathSave, string pathForm)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(pathForm, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.   
                xlWorkSheet.Cells[4, "A"] = "TIMEKEEPING REPORT"; // Thêm ngày vào title
                for (int i = 0; i < employeeSmoking.Count; i++)
                {
                    xlWorkSheet.Cells[7 + i, "A"] = (i + 1).ToString();
                    xlWorkSheet.Cells[7 + i, "B"] = employeeSmoking[i].Code;
                    xlWorkSheet.Cells[7 + i, "C"] = employeeSmoking[i].Name;
                    xlWorkSheet.Cells[7 + i, "D"] = employeeSmoking[i].BigDept;
                    xlWorkSheet.Cells[7 + i, "E"] = employeeSmoking[i].Dept;
                    xlWorkSheet.Cells[7 + i, "F"] = employeeSmoking[i].Date;
                    xlWorkSheet.Cells[7 + i, "G"] = employeeSmoking[i].sIn;
                    xlWorkSheet.Cells[7 + i, "H"] = employeeSmoking[i].sOut;
                    xlWorkSheet.Cells[7 + i, "I"] = employeeSmoking[i].TotalMinute;
                }

                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
