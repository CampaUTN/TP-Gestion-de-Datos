using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace ClinicaFrba
{
    public static class DBConnection
    {
        private static string server = ConfigurationManager.AppSettings["server"].ToString();
        private static string user = ConfigurationManager.AppSettings["user"].ToString();
        private static string password = ConfigurationManager.AppSettings["password"].ToString();

        public static SqlConnection getConnection(){
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012; DATABASE = GD2C2016;UID=" + user + ";PASSWORD=" + password + ";";
            return connection;
        }

        public static void cargarPlanilla(DataGridView dataGridView, string consulta) {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection connection = DBConnection.getConnection();
            connection.Open();

            try
            {

                dataAdapter = new SqlDataAdapter(consulta, connection);
                dataTable = new DataTable();

                dataGridView.DataSource = dataTable;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo realizar la consulta: \n" + e.Message);

            }
        }


    }
}
