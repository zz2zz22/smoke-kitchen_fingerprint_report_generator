using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GetSmokingData_Techlink
{
    public class DatabaseUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = "172.16.0.12";
            string database = "VUSOFT_SUPPORT";
            string username = "ERPUSER";
            string password = "12345";
            return DatabaseSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetHRDATAConnection()
        {
            string datasource = "172.16.0.9\\tx";
            string database = "txcard";
            string username = "sa";
            string password = "ppnn13";
            return DatabaseSQLServerUtils.GetHRDataConnection(datasource, database, username, password);
        }
        public static SqlConnection GetAttDATAConnection()
        {
            string datasource = "172.16.0.19";
            string database = "ZKBioAccess";
            string username = "dev";
            string password = "Techlink@123";
            return DatabaseSQLServerUtils.GetAttDBConnection(datasource, database, username, password);
        }
    }
}
