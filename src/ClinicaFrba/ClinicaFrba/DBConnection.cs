using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba
{
    public class DBConnection
    {
        private DBConnection instance = null;

        private string server = ConfigurationManager.AppSettings["server"].ToString();
        private string user = ConfigurationManager.AppSettings["user"].ToString();
        private string password = ConfigurationManager.AppSettings["password"].ToString();

        private DBConnection() { }

        public DBConnection getInstance(){
            if (instance == null) {
                instance = new DBConnection();
            }

            return instance;
        }

        public SqlConnection getConnection(){
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASEGD2C2016;UID=" + user + ";PASSWORD=" + password + ";";
            return connection;
        }

    }
}
