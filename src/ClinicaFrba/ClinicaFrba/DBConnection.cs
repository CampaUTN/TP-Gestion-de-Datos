using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba
{
    public static class DBConnection
    {
        private static string server = ConfigurationManager.AppSettings["server"].ToString();
        private static string user = ConfigurationManager.AppSettings["user"].ToString();
        private static string password = ConfigurationManager.AppSettings["password"].ToString();

        public static SqlConnection getConnection(){
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASEGD2C2016;UID=" + user + ";PASSWORD=" + password + ";";
            return connection;
        }

    }
}
