using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Abm_Afiliado;
using System.Configuration;

namespace ClinicaFrba.Utilidades
{
    public static class Utils
    {
        static public void llenar(ComboBox combo, List<KeyValuePair<int,string>> items)
        {
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            items.ForEach(item => combo.Items.Add(item));

            //if (combo.Items.Count > 0)
              //  combo.SelectedItem = combo.Items[0];
        }

        static public void llenar(ListBox list, List<KeyValuePair<int,string>> items)
        {
            list.DisplayMember = "Value";
            list.ValueMember = "Key";

            items.ForEach(item => list.Items.Add(item));

            //if (list.Items.Count > 0)
              //  list.SelectedItem = list.Items[0];
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



        static public int getNumeroAfiliadoDesdeUsuario(string usuario) {
            var conexion = DBConnection.getConnection();

            long user = getIdDesdeUserName(usuario);

            SqlCommand comando = new SqlCommand("select afil_id From GEDDES.Afiliados Where afil_usuario = @user", conexion);

            comando.Parameters.AddWithValue("@user", user);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read()) {
                return Convert.ToInt32(reader[0]); //afil_plan
            }
            return -1;
        }

        static public int getNumeroProfesionalDesdeUsuario(long user) {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("select prof_id from GEDDES.Profesionales where prof_usuario = @user", conexion);

            comando.Parameters.AddWithValue("@user", user);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read()) {
                return Convert.ToInt32(reader[0]);
            }
            return -1;
        }

        static public SqlDataReader getDatosAdicionalesAfiliado(int afil)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT afil_plan, afil_estadoCivil, afil_cantidadHijos, afil_usuario FROM GEDDES.Afiliados WHERE afil_id = @id", conexion);

            comando.Parameters.AddWithValue("@id", afil);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }


        static public int buscarPlanDeAfiliado(int afiliado)
        {
            var conexion = DBConnection.getConnection();

            //int afilId;
            //Int32.TryParse(afiliado, out afilId);

            SqlCommand comando = new SqlCommand("select afil_plan From GEDDES.Afiliados Where afil_id = @afiliado", conexion);

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

            SqlCommand comando = new SqlCommand("select plan_precioBono From GEDDES.Planes Where plan_id = @plan", conexion);
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
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_nombre as Especialidad from GEDDES.Profesionales p, GEDDES.Usuarios u, GEDDES.EspecialidadXProfesional espe, GEDDES.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id", conexion);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }


        static public DataTable getProfesionales2()
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_id as Especialidad, e.espe_nombre as Detalle from GEDDES.Profesionales p, GEDDES.Usuarios u, GEDDES.EspecialidadXProfesional espe, GEDDES.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id", conexion);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getProfesionales3(string usuario) {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_id as Especialidad, e.espe_nombre as Detalle from GEDDES.Profesionales p, GEDDES.Usuarios u, GEDDES.EspecialidadXProfesional espe, GEDDES.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id and u.usua_username = @usuario", conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@usuario", usuario);

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getProfesionalesPosta(String usuario) {
            var conexion = DBConnection.getConnection();
            SqlCommand comando;
            if(usuario!=""){
                comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre from GEDDES.Profesionales p, GEDDES.Usuarios u WHERE p.prof_usuario=u.usua_id and u.usua_username = @usuario", conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
            } else {
                comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre from GEDDES.Profesionales p, GEDDES.Usuarios u WHERE p.prof_usuario=u.usua_id ", conexion);
            }
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getEspecialidades()
{
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select e.espe_id as Especialidad, e.espe_nombre from GEDDES.Especialidades e", conexion);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getProfesionalesDeEspecialidad(string filtroEspe) 
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select p.prof_id as Profesional, u.usua_apellido as Apellido, u.usua_nombre as Nombre, e.espe_nombre as Especialidad from GEDDES.Profesionales p, GEDDES.Usuarios u, GEDDES.EspecialidadXProfesional espe, GEDDES.Especialidades e WHERE p.prof_usuario=u.usua_id AND espe.prof_id = p.prof_id AND espe.espe_id = e.espe_id AND e.espe_nombre like @filtroEspe", conexion); // en vez de LIKE, =
            //comando.Parameters.AddWithValue("@filtroEspe", filtroEspe);
            comando.Parameters.AddWithValue("@filtroEspe", "%" + filtroEspe + "%");
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public DataTable getHorariosDelProfesional(string profesional)
        {
            String textoFecha = ConfigurationManager.AppSettings["fecha"].ToString();
            DateTime fecha = DateTime.ParseExact(textoFecha.Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).Date;
            TimeSpan hora = DateTime.ParseExact(textoFecha.Substring("yyyy-MM-dd".Length + 1, "HH:mm:ss,fff".Length), "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;

            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("select hora_id as IdHorario, hora_fecha Dia, hora_inicio Hora from GEDDES.Horarios where hora_activo=1 AND (CAST(hora_fecha AS DATE)>CAST(@fechaActual AS DATE) or (CAST(hora_fecha AS DATE)=CAST(@fechaActual AS DATE) and hora_inicio>@horaActual))  and hora_profesional = @profesional and (hora_id NOT IN (select turn_hora from GEDDES.Turnos) or 1<>(select TOP 1 turn_activo from GEDDES.Turnos where turn_hora=hora_id order by turn_activo DESC)) order by hora_fecha, hora_inicio ASC", conexion);
            comando.Parameters.AddWithValue("@profesional", Int32.Parse(profesional));
            comando.Parameters.AddWithValue("@fechaActual", fecha);
            comando.Parameters.AddWithValue("@horaActual", hora);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public int getIdDesdePlan(string plan)
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SELECT plan_id from GEDDES.Planes WHERE plan_nombre = @plan", conexion);
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


        static public long getIdDesdeUserName(string username)
        {
            var conexion = DBConnection.getConnection();
            SqlCommand comando = new SqlCommand("SELECT usua_id FROM GEDDES.Usuarios WHERE usua_username = @username", conexion);
            comando.Parameters.AddWithValue("@username", username);
            comando.CommandType = CommandType.Text;

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToInt64(reader[0]);
            }
            return -1;
        }



        //INGRESO VALORES A LA BD

        static public void registarUsuario(Afiliado afiliado){

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.ingresarUsuario", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@username", afiliado.getUsername());
            comando.Parameters.AddWithValue("@password", afiliado.getPassword());
            comando.Parameters.AddWithValue("@nombre", afiliado.getNombre());
            comando.Parameters.AddWithValue("@apellido", afiliado.getApellido());
            comando.Parameters.AddWithValue("@tipoDoc", afiliado.getTipoDoc());
            comando.Parameters.AddWithValue("@nroDoc", afiliado.getNroDoc());
            comando.Parameters.AddWithValue("@direccion", afiliado.getDireccion());
            comando.Parameters.AddWithValue("@telefono", afiliado.getTelefono());
            comando.Parameters.AddWithValue("@fechaNacimiento", afiliado.getFechaNac());
            comando.Parameters.AddWithValue("@sexo", afiliado.getSexo());

            if (afiliado.getMail() != null)
            {
                comando.Parameters.AddWithValue("@mail", afiliado.getMail());
            }
            else
            {
                comando.Parameters.AddWithValue("@mail", DBNull.Value);
            }


            conexion.Open();
            comando.ExecuteReader();
         
        }

        static public void registrarAfiliado(Afiliado afiliado)
        {
            int codPlan = Utilidades.Utils.getIdDesdePlan(afiliado.getPlan());

            long usuaId = Utilidades.Utils.getIdDesdeUserName(afiliado.getUsername());

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.ingresarAfiliado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //TODO: Ver si lo puedo retornar desde el SP, cuando registro al usuario
            comando.Parameters.AddWithValue("@usuario", usuaId);
            comando.Parameters.AddWithValue("@plan", codPlan);
            comando.Parameters.AddWithValue("@estado", afiliado.getEstadoCivil());
            comando.Parameters.AddWithValue("@hijos", afiliado.getHijosACargo());

            conexion.Open();
            comando.ExecuteReader();
        }


        static public void registrarFamiliarAfiliado(Afiliado afiliado)
        {
            int codPlan = Utilidades.Utils.getIdDesdePlan(afiliado.getPlan());
            long usuaId = Utilidades.Utils.getIdDesdeUserName(afiliado.getUsername());

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.agregarFamiliar", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@afiliado_raiz", afiliado.getCodigoAfiliado());
            comando.Parameters.AddWithValue("@usuario", usuaId);
            comando.Parameters.AddWithValue("@plan", codPlan);
            comando.Parameters.AddWithValue("@estado", afiliado.getEstadoCivil());
            comando.Parameters.AddWithValue("@hijos", afiliado.getHijosACargo());

            conexion.Open();
            comando.ExecuteReader();
        }

        static public void actualizarAfiliado(Afiliado afiliado)
        {

            int codPlan = Utilidades.Utils.getIdDesdePlan(afiliado.getPlan());
            //long usuaId = Utilidades.Utils.getIdDesdeUserName(afiliado.getUsername());

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.modificarAfiliado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            MessageBox.Show(afiliado.getPlan());
            comando.Parameters.AddWithValue("@username", afiliado.getUsuaId());
            comando.Parameters.AddWithValue("@direccion", afiliado.getDireccion());
            comando.Parameters.AddWithValue("@telefono", afiliado.getTelefono());
            comando.Parameters.AddWithValue("@plan", codPlan);
            comando.Parameters.AddWithValue("@estado", afiliado.getEstadoCivil());
            comando.Parameters.AddWithValue("@hijos", afiliado.getHijosACargo());

            conexion.Open();
            comando.ExecuteReader();
        }

        static public int obtenerNumeroAfiliadoRecienRegistrado()
        {
            int afil_id = 0;
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT MAX(afil_id) FROM GEDDES.Afiliados ", conexion);
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                afil_id = Convert.ToInt32(reader[0]);
            }

            return afil_id;
        }

        static public List<KeyValuePair<int, string>> getPlanes()
        {
            var conexion = DBConnection.getConnection();
            List<KeyValuePair<int, string>> planes = new List<KeyValuePair<int, string>>();

            SqlCommand comando = new SqlCommand("GEDDES.getPlanes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                planes.Add(new KeyValuePair<int, string>(Int32.Parse(reader["plan_id"].ToString()),
                                                                    reader["plan_nombre"].ToString()));
            }

            return planes;
        }

        static public List<KeyValuePair<int, string>> getRoles(string usuario) {
            var conexion = DBConnection.getConnection();

            List<KeyValuePair<int, string>> rolesAsignados = new List<KeyValuePair<int, string>>();
            SqlCommand comando = new SqlCommand("GEDDES.getRolesUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@user", usuario);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read()) {
                rolesAsignados.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()),
                                                                    reader["role_nombre"].ToString()));
            }

            return rolesAsignados;
        }


        static public SqlDataReader obtenerAfiliadoDesdeUsername(long cod_usuario)
        {

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT * From GEDDES.Afiliados WHERE afil_usuario = @user", conexion);
            comando.Parameters.AddWithValue("@user", cod_usuario);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }


        static public int obtenerProfesionalDesdeUsername(string username)
        {
            int prof = 0;
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT * From GEDDES.Profesionales, GEDDES.Usuarios WHERE prof_usuario = usua_id AND usua_username = @user", conexion);
            comando.Parameters.AddWithValue("@user", username);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                prof = Convert.ToInt32(reader[0]);
            }

            return prof;
        }


        static public SqlDataReader obtenerUsuarioDesdeUsername(long cod_usuario)
        {

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("select usua_direccion,usua_tipoDoc, usua_telefono, usua_fechaNacimiento, usua_mail, usua_sexo from GEDDES.Usuarios WHERE usua_id = @user", conexion);
            comando.Parameters.AddWithValue("@user", cod_usuario);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }


        static public string getNombrePlan(int plan)
        {
            string nombre = "";
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT plan_nombre FROM GEDDES.Planes WHERE plan_id = @id", conexion);
            comando.Parameters.AddWithValue("@id", plan);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                nombre = Convert.ToString(reader[0]);
            }

            return nombre;
        }

        static public void bajaLogicaA(Afiliado afiliado)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.darDeBaja", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@user", afiliado.getUsuaId());

            conexion.Open();
            try
            {
                SqlDataReader reader = comando.ExecuteReader();

                MessageBox.Show("Usuario dado de baja");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }


        static public void bajaDia(int profesional, DateTime fecha, int tipo, string motivo) {
            var conexion = DBConnection.getConnection();
            conexion.Open();
            //seteo fecha
            String textoFechaAux = ConfigurationManager.AppSettings["fecha"].ToString();
            DateTime auxFecha = DateTime.ParseExact(textoFechaAux.Substring(0, "yyyy-MM-dd HH:mm:ss,fff".Length), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

            SqlCommand comandoAux = new SqlCommand("declare @ctx varbinary(128); select @ctx = CONVERT(varbinary(128), @fecha); SET CONTEXT_INFO @ctx;", conexion);
            comandoAux.Parameters.AddWithValue("@fecha", auxFecha);
            comandoAux.ExecuteNonQuery();
            //fin seteo
            SqlCommand comando = new SqlCommand("GEDDES.cancelar_dia_agenda", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@profesional", profesional);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@motivo", motivo);

            comando.ExecuteReader();
        }

        static public void bajaTurnoAfiliado(long usuario, int turno_id, int tipo, string motivo) {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.cancelar_turno_afiliado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@turno", turno_id);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@motivo", motivo);

            conexion.Open();

            comando.ExecuteReader();
        }


        static public void registrarConsulta(int turno, int bono, int afiliado) {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.registrarConsulta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@turno", turno);
            comando.Parameters.AddWithValue("@bono", bono);
            comando.Parameters.AddWithValue("@afil", afiliado);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }


        static public DataTable getTurnos(long usuario) {
            var conexion = DBConnection.getConnection();


            String textoFecha = ConfigurationManager.AppSettings["fecha"].ToString();
            DateTime fecha = DateTime.ParseExact(textoFecha.Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).Date;
            TimeSpan hora = DateTime.ParseExact(textoFecha.Substring("yyyy-MM-dd".Length + 1, "HH:mm:ss,fff".Length), "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;

            SqlCommand comando = new SqlCommand("select turn_id numero, hora_fecha fecha, hora_inicio hora, hora_profesional profesional, hora_especialidad especialidad, CASE WHEN (CAST(hora_fecha AS DATE)=CAST(@fechaActual AS DATE) and hora_inicio <= @horaActual) THEN 'No (hora anterior o igual a la actual)' WHEN (CAST(hora_fecha AS DATE)=CAST(@fechaActual AS DATE)) THEN 'No' ELSE 'Si' END 'Se puede cancelar' from GEDDES.Turnos join GEDDES.Horarios on (turn_hora = hora_id) where turn_activo = 1 and turn_afiliado = (select afil_id from GEDDES.Afiliados where afil_usuario = @usuario) and  (CAST(hora_fecha AS DATE)>CAST(@fechaActual AS DATE) or (CAST(hora_fecha AS DATE)=CAST(@fechaActual AS DATE) and hora_inicio>=@horaActual)) ", conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@fechaActual", fecha);
            comando.Parameters.AddWithValue("@horaActual", hora);
            comando.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            sqlDataAdap.Fill(tabla);

            return tabla;
        }

        static public void registrarResultadoConsulta(int consulta, bool realizada, string sintomas, string diagnostico)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.registrarResultadoConsulta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@consulta", consulta);

            comando.Parameters.AddWithValue("@concretada", realizada);

            comando.Parameters.AddWithValue("@sintomas", sintomas);
            comando.Parameters.AddWithValue("@diagnostico", diagnostico);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }


        static public void registrarMotivoModificacion(int afiliado, string motivo)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.registrarMotivo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@afil", afiliado);
            comando.Parameters.AddWithValue("@motivo", motivo);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }


        static public void darDeBajaAfiliado(long idUsuario)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("GEDDES.eliminarAfiliado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@user", idUsuario);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }

        static public bool dniOcupado(string dni)
        {
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("SELECT * FROM GEDDES.Usuarios WHERE usua_nroDoc = @dni OR usua_id = @dni", conexion);
            comando.Parameters.AddWithValue("@dni", Convert.ToInt32(dni));

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();

            return reader.Read();

        }


        public static string fechaSistema()
        {
            string textoFecha = ConfigurationManager.AppSettings["fecha"].ToString();

            return textoFecha.Substring(0, "yyyy-MM-dd".Length);
        }
    }
}
