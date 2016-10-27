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

            comando.Parameters.AddWithValue("@afiliado", afiliado); //OJO, TIENEN QUE LLAMARSE IGUAL

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

        static public DataTable getProfesionales() //Hecho para pedir turno, se puede tomar la forma y cambiar!
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_nombre as Especialidad from CLINICA.Profesionales p, CLINICA.Usuarios u, CLINICA.EspecialidadXProfesional espe, CLINICA.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id", conexion);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getProfesionalesDeEspecialidad(string filtroEspe) 
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_nombre as Especialidad from CLINICA.Profesionales p, CLINICA.Usuarios u, CLINICA.EspecialidadXProfesional espe, CLINICA.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id AND e.espe_nombre=@filtroEspe", conexion);
            comando.Parameters.AddWithValue("@filtroEspe", filtroEspe);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getHorariosDelProfesional(string profesional)
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select hora_id as IdHorario, hora_fecha Dia, hora_inicio Hora from CLINICA.Horarios where hora_profesional = @profesional", conexion);
            comando.Parameters.AddWithValue("@profesional", Int32.Parse(profesional));
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public int getIdDesdePlan(string plan)
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SELECT plan_id from CLINICA.Planes WHERE plan_nombre = @plan", conexion);
            comando.Parameters.AddWithValue("@plan", plan);
            comando.CommandType = CommandType.Text;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToInt32(reader[0]);
            }
            return -1;
        }
    }
}
