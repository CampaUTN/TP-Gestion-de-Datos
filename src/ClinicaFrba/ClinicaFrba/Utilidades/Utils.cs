using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Utilidades
{
    public static class Utils
    {
        static public void llenar(ComboBox combo, List<KeyValuePair<int,string>> items)
        {
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            items.ForEach(item => combo.Items.Add(item));

            if (combo.Items.Count > 0)
                combo.SelectedItem = combo.Items[0];
        }

        static public void llenar(ListBox list, List<KeyValuePair<int,string>> items)
        {
            list.DisplayMember = "Value";
            list.ValueMember = "Key";

            items.ForEach(item => list.Items.Add(item));

            if (list.Items.Count > 0)
                list.SelectedItem = list.Items[0];
        }

        static public SqlCommand crearSp(string nombreSp, List<KeyValuePair<string, object>> parametros, SqlConnection conexion)
        { //Con parametros
            SqlCommand query = new SqlCommand(nombreSp, conexion);
            query.CommandType = CommandType.StoredProcedure;
            parametros.ForEach(pair => query.Parameters.Add(new SqlParameter(pair.Key, pair.Value)));
            return query;
        }

        static public SqlCommand crearSp(string nombreSp, SqlConnection conexion) 
        { //Sin parametros explicitos
            SqlCommand query = new SqlCommand(nombreSp, conexion);
            query.CommandType = CommandType.StoredProcedure;
            return query;
        }



        static public int getNumeroAfiliadoDesdeUsuario(string usuario)
        {
            var conexion = DBConnection.getConnection();

            int userId;
            Int32.TryParse(usuario, out userId);

            SqlCommand comando = new SqlCommand("select afil_id From CLINICA.Afiliados Where afil_usuario = @user", conexion);

            comando.Parameters.AddWithValue("@user", userId);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                return Convert.ToInt32(reader[0]); //afil_plan
            }
            return -1;
        }


        static public int buscarPlanDeAfiliado(int afiliado)
        {
            var conexion = DBConnection.getConnection();

            //int afilId;
            //Int32.TryParse(afiliado, out afilId);

            SqlCommand comando = new SqlCommand("select afil_plan From CLINICA.Afiliados Where afil_id = @afiliado", conexion);

            comando.Parameters.AddWithValue("@afiliado", afiliado);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                return Convert.ToInt32(reader[0]); //afil_plan
            }
            return -1;
        }

        static public int buscarPrecioPlan(int plan)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("select plan_precioBono From CLINICA.Planes Where plan_id = @plan", conexion);
            comando.Parameters.AddWithValue("@plan", plan);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                return Convert.ToInt32(reader[0]);//plan_precioBono
            }
            return -1;
        }

    }
}
