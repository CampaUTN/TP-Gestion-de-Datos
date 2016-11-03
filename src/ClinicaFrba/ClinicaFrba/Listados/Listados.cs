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

namespace ClinicaFrba.Listados
{
    public partial class Listados : Form
    {
        public Listados()
        {
            InitializeComponent();
        }

        private void Listados_Load(object sender, EventArgs e) {
            dateTimePickerAnio.Format = DateTimePickerFormat.Custom;
            dateTimePickerAnio.CustomFormat = "yyyy";
            dateTimePickerAnio.ShowUpDown = true;
            dateTimePickerAnio.MaxDate = DateTime.Today;

            dateTimePickerMesDesde.Format = DateTimePickerFormat.Custom;
            dateTimePickerMesDesde.CustomFormat = "MMMM";
            dateTimePickerMesDesde.ShowUpDown = true;

            dateTimePickerMesHasta.Format = DateTimePickerFormat.Custom;
            dateTimePickerMesHasta.CustomFormat = "MMMM";
            dateTimePickerMesHasta.ShowUpDown = true;

            comboBoxSemestre.SelectedIndex = 0;

            /* LISTADO 1*/
            comboBoxListado1Filtro.SelectedIndex = 0;

            /* LISTADO 2 */
            List<KeyValuePair<int, string>> planes = Utilidades.Utils.getPlanes();
            Utilidades.Utils.llenar(comboBoxListado2Filtro, planes);
            comboBoxListado2Filtro.SelectedIndex=0;

            /* LISTADO 3 */
            DataTable especialdidades = Utilidades.Utils.getEspecialidades();
            List<KeyValuePair<int, string>> listaEspecialidades = new List<KeyValuePair<int, string>>();
            foreach (DataRow especialidad in especialdidades.Rows) {
                listaEspecialidades.Add(new KeyValuePair<int, string>(Convert.ToInt32(especialidad["Especialidad"]), Convert.ToString(especialidad["espe_nombre"])));
            }
            Utilidades.Utils.llenar(comboBoxListado3Filtro, listaEspecialidades);
            comboBoxListado3Filtro.SelectedIndex = 0;

            /* LISTADO 4 */
            llenarDataGridView(dataGridViewListado4, generarQueryListado4());

            /* LISTADO 5 */
            llenarDataGridView(dataGridViewListado5, generarQueryListado5());

            // Los listados con combobox se rellenan solos
        }

        private void llenarListados(){
            llenarDataGridView(dataGridViewListado1, generarQueryListado1());
            llenarDataGridView(dataGridViewListado2, generarQueryListado2());
            llenarDataGridView(dataGridViewListado3, generarQueryListado3());
            llenarDataGridView(dataGridViewListado4, generarQueryListado4());
            llenarDataGridView(dataGridViewListado5, generarQueryListado5());
        }

        private string generarQueryListado1() {
            string where = "";
            if (comboBoxListado1Filtro.SelectedText == "Afiliados")
                where = "WHERE canc_tipo = 0";
            else if (comboBoxListado1Filtro.SelectedText == "Profesionales")
                where = "WHERE canc_tipo = 1";
            string queryListado = "SELECT TOP 5  COUNT(DISTINCT canc_id) AS 'Cancelaciones' , espe_nombre AS 'Especialidad'  " +
                                    "FROM CLINICA.CancelacionesTurnos " +
                                    "JOIN CLINICA.Turnos ON Turnos.turn_id = CancelacionesTurnos.canc_turno " +
                                    "JOIN CLINICA.Horarios ON Horarios.hora_id = Turnos.turn_hora " +
                                    "JOIN CLINICA.Especialidades ON espe_id = hora_especialidad " +
                                    where +
                                    "GROUP BY Horarios.hora_especialidad, espe_nombre " +
                                    "ORDER BY COUNT(DISTINCT canc_id), espe_nombre DESC ";
            return queryListado;
        }

        private string generarQueryListado2() {
            string queryListado = "SELECT TOP 5 COUNT(DISTINCT cons_id) AS 'Consultas', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario', espe_nombre AS 'Especialidad' " +
                                    "FROM CLINICA.Bonos " +
                                    "JOIN CLINICA.Consultas ON cons_id = bono_nroConsulta " +
                                    "JOIN CLINICA.Turnos ON turn_id = cons_turno " +
                                    "JOIN CLINICA.Horarios ON hora_id = turn_hora " +
                                    "JOIN CLINICA.Profesionales ON prof_id = hora_profesional " +
                                    "JOIN CLINICA.Especialidades ON espe_id = hora_especialidad " +
                                    "JOIN CLINICA.Usuarios ON usua_id = prof_usuario " +
                                    "WHERE bono_plan = " + ((KeyValuePair<int,string>) comboBoxListado2Filtro.SelectedItem).Key + " " +
                                    "GROUP BY prof_id, espe_id, espe_nombre, usua_nombre, usua_apellido " +
                                    "ORDER BY COUNT(DISTINCT cons_id)";
            return queryListado;
        }

        private string generarQueryListado3() {
            string queryListado = "SELECT TOP 5  COUNT(hora_id)*0.5 AS 'Horas', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario' " +
                                    "FROM CLINICA.Horarios " +
                                    "JOIN CLINICA.Profesionales ON prof_id = hora_profesional " +
                                    "JOIN CLINICA.Usuarios ON usua_id = prof_id " +
                                    "WHERE hora_especialidad = " + ((KeyValuePair<int,string>) comboBoxListado3Filtro.SelectedItem).Key + " "+
                                    "AND hora_fecha BETWEEN '" + dateTimeParaSql(generarFechaDesde()) + "' AND '" + dateTimeParaSql(generarFechaHasta()) + "' " + 
                                    "GROUP BY prof_id, usua_nombre, usua_apellido " +
                                    "ORDER BY COUNT(hora_id)";
            return queryListado;
        }

        private string generarQueryListado4() {
            string queryListado = "SELECT TOP 5 SUM(comp_cantidad) AS 'Bonos comprados', CONCAT(usua_nombre,' ',usua_apellido) AS 'Usuario', CLINICA.tieneFamilia(usua_id) AS 'Tiene familia' " +
                                    "FROM CLINICA.ComprasBonos " +
                                    "JOIN CLINICA.Afiliados afil ON afil_id = comp_afil " +
                                    "JOIN CLINICA.Usuarios ON usua_id = afil_usuario " +
                                    "GROUP BY comp_afil, usua_nombre, usua_apellido, usua_id " +
                                    "ORDER BY SUM(comp_cantidad) DESC";
            return queryListado;
        }

        private string generarQueryListado5() {
            string queryListado = "SELECT COUNT(cons_id) AS 'Bonos utilizados' , espe_nombre AS 'Especialidad' " +
                                    "FROM CLINICA.Consultas " +
                                    "JOIN CLINICA.Turnos ON turn_id = cons_turno " +
                                    "JOIN CLINICA.Horarios ON hora_id = turn_hora " +
                                    "JOIN CLINICA.Especialidades ON espe_id = hora_especialidad " +
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
