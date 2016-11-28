using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Listados
{
    public partial class Listados : Form
    {
        public Listados()
        {
            InitializeComponent();
        }

        private void Listados_Load(object sender, EventArgs e) {
            // Asignamos formato a los diferentes datetimepicker
            dateTimePickerAnio.Format = DateTimePickerFormat.Custom;
            dateTimePickerAnio.CustomFormat = "yyyy";
            dateTimePickerAnio.ShowUpDown = true;
            dateTimePickerAnio.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePickerAnio.MaxDate = dateTimePickerAnio.Value;

            dateTimePickerMesDesde.Format = DateTimePickerFormat.Custom;
            dateTimePickerMesDesde.CustomFormat = "MMMM";
            dateTimePickerMesDesde.ShowUpDown = true;

            dateTimePickerMesHasta.Format = DateTimePickerFormat.Custom;
            dateTimePickerMesHasta.CustomFormat = "MMMM";
            dateTimePickerMesHasta.ShowUpDown = true;

            
            if (dateTimePickerAnio.Value.Month<=6)
                comboBoxSemestre.SelectedIndex = 0;
            else
                comboBoxSemestre.SelectedIndex = 1;
            /* LISTADO 1*/
            comboBoxListado1Filtro.SelectedIndex = 0;

            /* LISTADO 2 */
            // Completamos el filtro del listado 2, que incluye los planes del sistema
            // Ademas incluimos la opcion "Todos" para ver totales globales
            List<KeyValuePair<int, string>> planes = Utilidades.Utils.getPlanes();
            planes.Insert(0, new KeyValuePair<int, string>(-1, "Todos"));
            Utilidades.Utils.llenar(comboBoxListado2Filtro, planes);
            comboBoxListado2Filtro.SelectedIndex=0;

            /* LISTADO 3 */
            // Completamos el filtro del listado 3, que incluye las especialidades del sistema
            // Ademas incluimos la opcion "Todas" para ver totales globales
            DataTable especialdidades = Utilidades.Utils.getEspecialidades();
            List<KeyValuePair<int, string>> listaEspecialidades = new List<KeyValuePair<int, string>>();
            foreach (DataRow especialidad in especialdidades.Rows) {
                listaEspecialidades.Add(new KeyValuePair<int, string>(Convert.ToInt32(especialidad["Especialidad"]), Convert.ToString(especialidad["espe_nombre"])));
            }
            listaEspecialidades.Insert(0, new KeyValuePair<int, string>(-1, "Todas"));
            Utilidades.Utils.llenar(comboBoxListado3Filtro, listaEspecialidades);
            comboBoxListado3Filtro.SelectedIndex = 0;

            /* LISTADO 4 */
            // Rellenamos la grilla 4
            llenarDataGridView(dataGridViewListado4, generarQueryListado4());

            /* LISTADO 5 */
            // Rellenamos la grilla 5
            llenarDataGridView(dataGridViewListado5, generarQueryListado5());

            // Los listados con combobox se rellenan en el evento SelectedIndexChanged
        }

        private void llenarListados(){
            // Para actualizar todos los listados al actualizar la fecha
            llenarDataGridView(dataGridViewListado1, generarQueryListado1());
            llenarDataGridView(dataGridViewListado2, generarQueryListado2());
            llenarDataGridView(dataGridViewListado3, generarQueryListado3());
            llenarDataGridView(dataGridViewListado4, generarQueryListado4());
            llenarDataGridView(dataGridViewListado5, generarQueryListado5());
        }

        private string generarQueryListado1() {
            // Generamos la query del listado 1, agregando los parametros de fecha y filtro especificos
            string where = "";
            if (comboBoxListado1Filtro.SelectedIndex == 0)
                where = "canc_tipo = 1 AND ";
            else if (comboBoxListado1Filtro.SelectedIndex == 1)
                where = "canc_tipo = 2 AND ";
            string queryListado = "SELECT TOP 5  COUNT(DISTINCT canc_id) AS 'Cancelaciones' , espe_nombre AS 'Especialidad'  " +
                                    "FROM GEDDES.CancelacionesTurnos " +
                                    "JOIN GEDDES.Turnos ON Turnos.turn_id = CancelacionesTurnos.canc_turno " +
                                    "JOIN GEDDES.Horarios ON Horarios.hora_id = Turnos.turn_hora " +
                                    "JOIN GEDDES.Especialidades ON espe_id = hora_especialidad " +
                                    "WHERE " + where +
                                    "hora_fecha BETWEEN '" + dateParaSql(generarFechaDesde()) + "' AND '" + dateParaSql(generarFechaHasta()) + "' " + 
                                    "GROUP BY Horarios.hora_especialidad, espe_nombre " +
                                    "ORDER BY COUNT(DISTINCT canc_id), espe_nombre DESC ";
            return queryListado;
        }

        private string generarQueryListado2() {
            // Generamos la query del listado 2, agregando los parametros de fecha y filtro especificos
            string queryListado = "SELECT TOP 5 COUNT(DISTINCT cons_id) AS 'Consultas', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario', espe_nombre AS 'Especialidad' " +
                                    "FROM GEDDES.Bonos " +
                                    "JOIN GEDDES.Consultas ON cons_id = bono_nroConsulta " +
                                    "JOIN GEDDES.Turnos ON turn_id = cons_turno " +
                                    "JOIN GEDDES.Horarios ON hora_id = turn_hora " +
                                    "JOIN GEDDES.Profesionales ON prof_id = hora_profesional " +
                                    "JOIN GEDDES.Especialidades ON espe_id = hora_especialidad " +
                                    "JOIN GEDDES.Usuarios ON usua_id = prof_usuario " +
                                    "WHERE ";
            if (comboBoxListado2Filtro.SelectedIndex !=0)
                queryListado +=     "bono_plan = " + ((KeyValuePair<int,string>) comboBoxListado2Filtro.SelectedItem).Key + " AND ";
                queryListado +=     "cons_fechaHoraConsulta BETWEEN CONVERT(date,'" + dateTimeParaSql(generarFechaDesde()) + "') AND CONVERT(date,'" + dateTimeParaSql(generarFechaHasta()) + "') " + 
                                    "GROUP BY prof_id, espe_id, espe_nombre, usua_nombre, usua_apellido " +
                                    "ORDER BY COUNT(DISTINCT cons_id) DESC";
            return queryListado;
        }

        private string generarQueryListado3(){
            // Generamos la query del listado 3, agregando los parametros de fecha y filtro especificos
            string queryListado = "SELECT TOP 5  COUNT(hora_id)*0.5 AS 'Horas', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario' " +
                                    "FROM GEDDES.Horarios " +
                                    "JOIN GEDDES.Profesionales ON prof_id = hora_profesional " +
                                    "JOIN GEDDES.Usuarios ON usua_id = prof_usuario " +
                                    "WHERE ";
            if (comboBoxListado3Filtro.SelectedIndex !=0)
                queryListado +=     "hora_especialidad = " + ((KeyValuePair<int,string>) comboBoxListado3Filtro.SelectedItem).Key + " AND ";        
                queryListado +=     "hora_fecha BETWEEN CONVERT(date,'" + dateTimeParaSql(generarFechaDesde()) + "') AND CONVERT(date,'" + dateTimeParaSql(generarFechaHasta()) + "') " + 
                                    "GROUP BY prof_id, usua_nombre, usua_apellido " +
                                    "ORDER BY COUNT(hora_id) DESC";

            return queryListado;
        }

        private string generarQueryListado4() {
            // Generamos la query del listado 4, agregando los parametros de fecha
            string queryListado = "SELECT TOP 5 SUM(comp_cantidad) AS 'Bonos comprados', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario', GEDDES.tieneFamilia(usua_id) AS 'Tiene familia' " +
                                    "FROM GEDDES.ComprasBonos " +
                                    "JOIN GEDDES.Afiliados afil ON afil_id = comp_afil " +
                                    "JOIN GEDDES.Usuarios ON usua_id = afil_usuario " +
                                    "WHERE comp_fechaCompra BETWEEN CONVERT(date,'" + dateTimeParaSql(generarFechaDesde()) + "') AND CONVERT(date,'" + dateTimeParaSql(generarFechaHasta()) + "') " + 
                                    "GROUP BY comp_afil, usua_nombre, usua_apellido, usua_id " +
                                    "ORDER BY SUM(comp_cantidad) DESC";
            return queryListado;
        }

        private string generarQueryListado5() {
            // Generamos la query del listado 5, agregando los parametros de fecha
            string queryListado = "SELECT TOP 5 COUNT(cons_id) AS 'Bonos utilizados' , espe_nombre AS 'Especialidad' " +
                                    "FROM GEDDES.Consultas " +
                                    "JOIN GEDDES.Turnos ON turn_id = cons_turno " +
                                    "JOIN GEDDES.Horarios ON hora_id = turn_hora " +
                                    "JOIN GEDDES.Especialidades ON espe_id = hora_especialidad " +
                                    "AND cons_fechaHoraConsulta BETWEEN CONVERT(date,'" + dateTimeParaSql(generarFechaDesde()) + "') AND CONVERT(date,'" + dateTimeParaSql(generarFechaHasta()) + "') " + 
                                    "GROUP BY espe_id, espe_nombre " +
                                    "ORDER BY COUNT(cons_id) DESC";
            return queryListado;
        }

        private void llenarDataGridView(DataGridView datagridview, string query) {
            using (SqlConnection conexion = DBConnection.getConnection()) {
                conexion.Open();
                SqlDataAdapter adap = new SqlDataAdapter(query, conexion);
                DataTable dataset = new DataTable();
                adap.Fill(dataset);
                datagridview.DataSource = dataset;
            }
        }

        private void comboBoxListado1Filtro_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxListado1Filtro.Items.Contains(comboBoxListado1Filtro.Text)){
                llenarDataGridView(dataGridViewListado1, generarQueryListado1());
            }
        }

        private void comboBoxListado2Filtro_SelectedIndexChanged(object sender, EventArgs e) {
            llenarDataGridView(dataGridViewListado2, generarQueryListado2());
        }

        private void comboBoxListado3Filtro_SelectedIndexChanged(object sender, EventArgs e) {
            llenarDataGridView(dataGridViewListado3, generarQueryListado3());
        }
        
        private String dateTimeParaSql(DateTime dt) {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private String dateParaSql(DateTime dt) {
            return dt.ToString("yyyy-MM-dd");
        }

        private DateTime generarFechaDesde() {
            return new DateTime(dateTimePickerAnio.Value.Year, dateTimePickerMesDesde.Value.Month, dateTimePickerMesDesde.Value.Day);
        }

        private DateTime generarFechaHasta() {
            return new DateTime(dateTimePickerAnio.Value.Year, dateTimePickerMesHasta.Value.Month, DateTime.DaysInMonth(dateTimePickerAnio.Value.Year, dateTimePickerMesHasta.Value.Month), 23, 59, 59);
        }

        private void comboBoxSemestre_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxSemestre.SelectedIndex == 0) {
                dateTimePickerMesDesde.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
                dateTimePickerMesDesde.MaxDate = new DateTime(DateTime.Now.Year, 6, 1);
                dateTimePickerMesHasta.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
                dateTimePickerMesHasta.MaxDate = new DateTime(DateTime.Now.Year, 6, 1);
            } else {
                dateTimePickerMesDesde.MaxDate = new DateTime(DateTime.Now.Year, 12, 1);
                dateTimePickerMesDesde.MinDate = new DateTime(DateTime.Now.Year, 7, 1);
                dateTimePickerMesHasta.MaxDate = new DateTime(DateTime.Now.Year, 12, 1);
                dateTimePickerMesHasta.MinDate = new DateTime(DateTime.Now.Year, 7, 1);
            }
            dateTimePickerMesDesde.Value = dateTimePickerMesDesde.MinDate;
            dateTimePickerMesHasta.Value = dateTimePickerMesHasta.MaxDate;
        }

        private void dateTimePickerMesDesde_ValueChanged(object sender, EventArgs e) {
            if (dateTimePickerMesHasta.Value < dateTimePickerMesDesde.Value && dateTimePickerMesDesde.Value > dateTimePickerMesHasta.MinDate && dateTimePickerMesDesde.Value < dateTimePickerMesHasta.MaxDate)
                dateTimePickerMesHasta.Value = dateTimePickerMesDesde.Value;
        }

        private void dateTimePickerMesHasta_ValueChanged(object sender, EventArgs e) {
            if (dateTimePickerMesHasta.Value < dateTimePickerMesDesde.Value && dateTimePickerMesHasta.Value > dateTimePickerMesDesde.MinDate && dateTimePickerMesHasta.Value < dateTimePickerMesDesde.MaxDate)
                dateTimePickerMesDesde.Value = dateTimePickerMesHasta.Value;
        }

        private void buttonVolver_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            llenarListados();
        }
    }
}
