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
using System.Threading;

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
                ProgressDialog progressDialog = new ProgressDialog();
                Thread backgroundThreadSmokeExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       xlWorkSheet.Name = "MainReport";
                       xlWorkSheet.Cells[4, "A"] = "SMOKING REPORT"; // Thêm ngày vào title
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

                           progressDialog.UpdateProgress(100 * i / employeeSmoking.Count, "Đang tạo sheet tổng ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                Thread get3TimeSmoking = new Thread(
                   new ThreadStart(() =>
                   {
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                       xlWorkSheet.Name = "OverSmoking";
                       xlWorkSheet.Cells[4, "A"] = "OVER SMOKING REPORT"; // Thêm ngày vào title
                       ComboBox _cbxExist = new ComboBox();
                       for (int i = 0; i < employeeSmoking.Count; i++)
                       {
                           int count = employeeSmoking.Count(n => n.Code == employeeSmoking[i].Code);
                           if (count > 3)
                           {
                               if (!_cbxExist.Items.Contains(employeeSmoking[i].Code))
                               {
                                   int j = 0;
                                   _cbxExist.Items.Add(employeeSmoking[i].Code);
                                   xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                                   xlWorkSheet.Cells[7 + j, "B"] = employeeSmoking[i].Code;
                                   xlWorkSheet.Cells[7 + j, "C"] = employeeSmoking[i].Name;
                                   xlWorkSheet.Cells[7 + j, "D"] = employeeSmoking[i].BigDept;
                                   xlWorkSheet.Cells[7 + j, "E"] = employeeSmoking[i].Dept;
                                   xlWorkSheet.Cells[7 + j, "F"] = employeeSmoking[i].Date;
                                   xlWorkSheet.Cells[7 + j, "G"] = count;
                                   j++;
                               }
                           }

                           progressDialog.UpdateProgress(100 * i / employeeSmoking.Count, "Đang tạo sheet hút thuốc quá 3 lần ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                backgroundThreadSmokeExcel.Start();
                progressDialog.ShowDialog();
                get3TimeSmoking.Start();
                progressDialog.ShowDialog();
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
        public void ExportKitchen(List<KitchenEmployee> kitchenEmployees, string pathSave, string pathForm)
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
                ProgressDialog progressDialog = new ProgressDialog();
                Thread backgroundThreadKitchenExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       xlWorkSheet.Name = "TongKetQua";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           xlWorkSheet.Cells[7 + i, "A"] = (i + 1).ToString();
                           xlWorkSheet.Cells[7 + i, "B"] = kitchenEmployees[i].Code;
                           xlWorkSheet.Cells[7 + i, "C"] = kitchenEmployees[i].Name;
                           xlWorkSheet.Cells[7 + i, "D"] = kitchenEmployees[i].BigDept;
                           xlWorkSheet.Cells[7 + i, "E"] = kitchenEmployees[i].Dept;
                           xlWorkSheet.Cells[7 + i, "F"] = kitchenEmployees[i].Date;
                           xlWorkSheet.Cells[7 + i, "G"] = kitchenEmployees[i].sIn;

                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo file excel ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));

                Thread backgroundThreadKitchenAfternoonExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                       xlWorkSheet.Name = "Trua";//Get the name of worksheet.
                       int j = 0;
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           if (kitchenEmployees[i].type == 1)
                           {
                               xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                               xlWorkSheet.Cells[7 + j, "B"] = kitchenEmployees[i].Code;
                               xlWorkSheet.Cells[7 + j, "C"] = kitchenEmployees[i].Name;
                               xlWorkSheet.Cells[7 + j, "D"] = kitchenEmployees[i].BigDept;
                               xlWorkSheet.Cells[7 + j, "E"] = kitchenEmployees[i].Dept;
                               xlWorkSheet.Cells[7 + j, "F"] = kitchenEmployees[i].Date;
                               xlWorkSheet.Cells[7 + j, "G"] = kitchenEmployees[i].sIn;
                               j++;
                           }
                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo sheet buổi trưa ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                Thread backgroundThreadKitchenNoonExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       int j = 0;
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
                       xlWorkSheet.Name = "Chieu";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           if (kitchenEmployees[i].type == 2)
                           {

                               xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                               xlWorkSheet.Cells[7 + j, "B"] = kitchenEmployees[i].Code;
                               xlWorkSheet.Cells[7 + j, "C"] = kitchenEmployees[i].Name;
                               xlWorkSheet.Cells[7 + j, "D"] = kitchenEmployees[i].BigDept;
                               xlWorkSheet.Cells[7 + j, "E"] = kitchenEmployees[i].Dept;
                               xlWorkSheet.Cells[7 + j, "F"] = kitchenEmployees[i].Date;
                               xlWorkSheet.Cells[7 + j, "G"] = kitchenEmployees[i].sIn;
                               j++;
                           }
                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo sheet buổi chiều ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                Thread backgroundThreadKitchenDinnerExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       int j = 0;
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4);
                       xlWorkSheet.Name = "Toi";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           if (kitchenEmployees[i].type == 3)
                           {

                               xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                               xlWorkSheet.Cells[7 + j, "B"] = kitchenEmployees[i].Code;
                               xlWorkSheet.Cells[7 + j, "C"] = kitchenEmployees[i].Name;
                               xlWorkSheet.Cells[7 + j, "D"] = kitchenEmployees[i].BigDept;
                               xlWorkSheet.Cells[7 + j, "E"] = kitchenEmployees[i].Dept;
                               xlWorkSheet.Cells[7 + j, "F"] = kitchenEmployees[i].Date;
                               xlWorkSheet.Cells[7 + j, "G"] = kitchenEmployees[i].sIn;
                               j++;
                           }
                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo sheet buổi tối ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                Thread backgroundThreadKitchenNightExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       int j = 0;
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(5);
                       xlWorkSheet.Name = "Khuya";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           if (kitchenEmployees[i].type == 4)
                           {

                               xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                               xlWorkSheet.Cells[7 + j, "B"] = kitchenEmployees[i].Code;
                               xlWorkSheet.Cells[7 + j, "C"] = kitchenEmployees[i].Name;
                               xlWorkSheet.Cells[7 + j, "D"] = kitchenEmployees[i].BigDept;
                               xlWorkSheet.Cells[7 + j, "E"] = kitchenEmployees[i].Dept;
                               xlWorkSheet.Cells[7 + j, "F"] = kitchenEmployees[i].Date;
                               xlWorkSheet.Cells[7 + j, "G"] = kitchenEmployees[i].sIn;
                               j++;
                           }
                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo sheet khuya ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                Thread backgroundThreadKitchenUKExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       int j = 0;
                       xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(6);
                       xlWorkSheet.Name = "KhongXacDinh";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           if (kitchenEmployees[i].type == 0)
                           {

                               xlWorkSheet.Cells[7 + j, "A"] = (j + 1).ToString();
                               xlWorkSheet.Cells[7 + j, "B"] = kitchenEmployees[i].Code;
                               xlWorkSheet.Cells[7 + j, "C"] = kitchenEmployees[i].Name;
                               xlWorkSheet.Cells[7 + j, "D"] = kitchenEmployees[i].BigDept;
                               xlWorkSheet.Cells[7 + j, "E"] = kitchenEmployees[i].Dept;
                               xlWorkSheet.Cells[7 + j, "F"] = kitchenEmployees[i].Date;
                               xlWorkSheet.Cells[7 + j, "G"] = kitchenEmployees[i].sIn;
                               xlWorkSheet.Cells[7 + j, "H"] = kitchenEmployees[i].Error;
                               j++;
                           }
                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo sheet phụ ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                backgroundThreadKitchenExcel.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenAfternoonExcel.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenNoonExcel.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenDinnerExcel.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenNightExcel.Start();
                progressDialog.ShowDialog();
                backgroundThreadKitchenUKExcel.Start();
                progressDialog.ShowDialog();
                xlApp.DisplayAlerts = false;
                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkBook);
                reOject(xlWorkSheet);
                reOject(xlApp);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ExportKitchenWrong(List<KitchenEmployee> kitchenEmployees, string pathSave, string pathForm)
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
                ProgressDialog progressDialog = new ProgressDialog();
                Thread backgroundThreadKitchenExcel = new Thread(
                   new ThreadStart(() =>
                   {
                       xlWorkSheet.Name = "TongKetQua";//Get the name of worksheet.
                       for (int i = 0; i < kitchenEmployees.Count; i++)
                       {
                           xlWorkSheet.Cells[7 + i, "A"] = (i + 1).ToString();
                           xlWorkSheet.Cells[7 + i, "B"] = kitchenEmployees[i].Code;
                           xlWorkSheet.Cells[7 + i, "C"] = kitchenEmployees[i].Name;
                           xlWorkSheet.Cells[7 + i, "D"] = kitchenEmployees[i].BigDept;
                           xlWorkSheet.Cells[7 + i, "E"] = kitchenEmployees[i].Dept;
                           xlWorkSheet.Cells[7 + i, "F"] = kitchenEmployees[i].Date;
                           xlWorkSheet.Cells[7 + i, "G"] = kitchenEmployees[i].sIn;

                           progressDialog.UpdateProgress(100 * i / kitchenEmployees.Count, "Đang tạo file excel ... ");
                       }
                       progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                   }));
                backgroundThreadKitchenExcel.Start();
                progressDialog.ShowDialog();
                xlApp.DisplayAlerts = false;
                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkBook);
                reOject(xlWorkSheet);
                reOject(xlApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

    } 
}
