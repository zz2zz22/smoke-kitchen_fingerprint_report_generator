using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSmokingData_Techlink
{
    public class SmokingReport
    {
        public string PathSmokingReport = Environment.CurrentDirectory + @"\Resources\SmokingReportForm.xlsx";

        public void ExportExcelSmokingReport(string PathSave, List<EmployeeSmoking> employeeSmoking)
        {
            ToolSupport toolSupport = new ToolSupport();
            toolSupport.ExportSmoking(employeeSmoking, PathSave, PathSmokingReport);
        }
    }
}
