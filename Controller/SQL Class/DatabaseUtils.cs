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
            string datasource = "";
            string database = "";
            string username = "";
            string password = "";
            return DatabaseSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetHRDATAConnection()
        {
            string datasource = "";
            string database = "";
            string username = "";
            string password = "";
            return DatabaseSQLServerUtils.GetHRDataConnection(datasource, database, username, password);
        }
        public static SqlConnection GetAttDATAConnection()
        {
            string datasource = "";
            string database = "";
            string username = "";
            string password = "";
            return DatabaseSQLServerUtils.GetAttDBConnection(datasource, database, username, password);
        }
    }
}
