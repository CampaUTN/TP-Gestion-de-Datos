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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.MaxDate = DateTime.Today;

            /* LISTADO 1*/
                
            //llenarDataGridView(dataGridViewListado1, generarQueryListado1());
            comboBoxListado1Filtro.SelectedIndex = 0;

            /* LISTADO 2 */
            List<KeyValuePair<int, string>> planes = Utilidades.Utils.getPlanes();
            Utilidades.Utils.llenar(comboBoxListado2Filtro, planes);
            comboBoxListado2Filtro.SelectedIndex=0;
            //llenarDataGridView(dataGridViewListado2, generarQueryListado2());

            /* LISTADO 3 */
            DataTable especialdidades = Utilidades.Utils.getEspecialidades();
            List<KeyValuePair<int, string>> listaEspecialidades = new List<KeyValuePair<int, string>>();
            foreach (DataRow especialidad in especialdidades.Rows) {
                listaEspecialidades.Add(new KeyValuePair<int, string>(Convert.ToInt32(especialidad["Especialidad"]), Convert.ToString(especialidad["espe_nombre"])));
            }
            Utilidades.Utils.llenar(comboBoxListado3Filtro, listaEspecialidades);
            comboBoxListado3Filtro.SelectedIndex = 0;
            //llenarDataGridView(dataGridViewListado3, generarQueryListado3());
            

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
            string queryListado = "SELECT TOP 5 COUNT(DISTINCT cons_id) AS 'Consultas', usua_nombre AS 'Nombre', usua_apellido AS 'Apellido', espe_nombre AS 'Especialidad' " +
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
            string queryListado = "SELECT TOP 5  COUNT(hora_id)*0.5 AS 'Horas', usua_nombre AS 'Nombre', usua_apellido AS 'Apellido' " +
                                    "FROM CLINICA.Horarios " +
                                    "JOIN CLINICA.Profesionales ON prof_id = hora_profesional " +
                                    "JOIN CLINICA.Usuarios ON usua_id = prof_id " +
                                    "WHERE hora_especialidad = " + ((KeyValuePair<int,string>) comboBoxListado3Filtro.SelectedItem).Key + " "+
                                    "GROUP BY prof_id, usua_nombre, usua_apellido " +
                                    "ORDER BY COUNT(hora_id)";
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
                MessageBox.Show("ACTUALIZANDO DATAGRIDVIEW");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }


    }
}
