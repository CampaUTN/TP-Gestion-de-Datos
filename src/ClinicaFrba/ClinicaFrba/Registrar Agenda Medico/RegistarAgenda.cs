using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class RegistarAgenda : Form
    {
        private DateTime horaInicio, horaFin;
        private int numeroDia;
        private Logger logErrores;



        private void selectorFecha_ValueChanged(object sender, EventArgs e) {
        }

        private void hasta_ValueChanged(object sender, EventArgs e) {
        }


        public RegistarAgenda() {
            InitializeComponent();
            this.logErrores = new Logger();
            horaInicio = inicio.Value;
            horaFin = fin.Value;
        }

        //todo ver si pasa de mes al pasar el limite de 30/31 dias.
        public virtual void cargarHorario(){
            int rowindex = grillaProfesionales.CurrentCell.RowIndex;
            List<Horario> horarios = new List<Horario>();
            Horario horario;
            DateTime hora;
            double diferencia = (int)desde.Value.DayOfWeek - numeroDia;
            double correccionDia = diferencia >= 0 ? diferencia : 7+diferencia; //7+differencia<7, pues diferencia <0.
            DateTime fecha = desde.Value.AddDays(Math.Abs((int)desde.Value.DayOfWeek-numeroDia));
           // MessageBox.Show(desde.Value.ToString()+"         "+fecha.ToString()+"      "+hasta.Value.ToString());
            while (fecha <= hasta.Value) {
                hora = horaInicio;
                while (hora.AddMinutes(30) <= horaFin) {
                    horario = new Horario(Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[0].ToString()), Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[3].Value.ToString()), fecha.Add(hora.TimeOfDay));
                    horarios.Add(horario);
                    hora = hora.AddMinutes(30);
                }
                fecha = fecha.AddDays(7);
            }

            SqlConnection conexion = DBConnection.getConnection();

            string insertHorarios = "INSERT INTO CLINICA.Horarios values (@profesional, @especialidad, @fecha, @inicio)";
            SqlCommand comandoInsertarHorarios = new SqlCommand(insertHorarios, conexion);
            comandoInsertarHorarios.CommandType = CommandType.Text;
            comandoInsertarHorarios.Connection = conexion;
            comandoInsertarHorarios.Parameters.AddWithValue("@profesional", DbType.Int32);
            comandoInsertarHorarios.Parameters.AddWithValue("@especialidad", DbType.Int32);
            comandoInsertarHorarios.Parameters.AddWithValue("@fecha", DbType.Date);
            comandoInsertarHorarios.Parameters.AddWithValue("@inicio", DbType.Time);

            conexion.Open();

            foreach (Horario h in horarios) {
                comandoInsertarHorarios.Parameters[0].Value = h.profesional_id;
                comandoInsertarHorarios.Parameters[1].Value = h.especialidad_id;
                comandoInsertarHorarios.Parameters[2].Value = h.fechaHora.Date;
                comandoInsertarHorarios.Parameters[3].Value = h.fechaHora.TimeOfDay;
                comandoInsertarHorarios.ExecuteNonQuery();
            }

            //conexion.Close();

            MessageBox.Show("Carga realizada con exito.");
        }

        private bool horarioValido(DateTime fechaHora) {
            String hora = fechaHora.ToString("HH:mm");
            if (fechaHora.DayOfWeek.Equals(6)) { //sabado
                return String.Compare(hora,"10:00") >= 0 && String.Compare(hora,"15:00") <= 0; 
            }else{ // lunes a viernes
                return String.Compare(hora,"´07:00") >= 0 && String.Compare(hora,"20:00") <= 0; 
            }
        }

        private void RegistarAgenda_Load(object sender, EventArgs e) {

        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (grillaProfesionales.SelectedCells.Count > 0) {
                int rowindex = grillaProfesionales.CurrentCell.RowIndex;
            }else{
                MessageBox.Show("Seleccione un profesional.", "Error", MessageBoxButtons.OK);
            }
        }


        private void botonListar_Click(object sender, EventArgs e) {
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
        }


        //agregar horario
        private void button2_Click(object sender, EventArgs e) {
            if (grillaProfesionales.SelectedCells.Count == 0) {
                MessageBox.Show("Seleccione un profesional y especialidad en la grilla.", "Error", MessageBoxButtons.OK);
                return;
            }
            int rowindex = grillaProfesionales.CurrentCell.RowIndex;
            if (horarioValido(horaInicio) && horarioValido(horaFin)) {
                try{
                cargarHorario();
                }
                catch (SqlException ex){
                    if(ex.Errors[0].Number == -10) {
                        //todo: no se deberia hacer if savepoint!=null, savepoint.rollback?
                        MessageBox.Show("No se permite agregar estos horarios: El profesional ya atiende en alguno de los horarios indicados, o se superaria el limite de 48 horas semanales de agregar estos horarios.", "Error", MessageBoxButtons.OK);
                    }
                }
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
            } else {
                MessageBox.Show("La fecha debe estar comprendida entre 7:00 y 20:00 para horarios de lunes a viernes, y entre 10:00 y 15:00 para los sabados.", "Error", MessageBoxButtons.OK);
            }
        }


        private void label2_Click(object sender, EventArgs e) {

        }

        // ir atras.
        private void botonAtras_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void inicio_ValueChanged(object sender, EventArgs e) {
            if (this.inicio.Value.Minute % 30 != 0) {

                if (this.inicio.Value.Minute % 30 == 1)
                    this.inicio.Value = this.inicio.Value.AddMinutes(29);

                if (this.inicio.Value.Minute % 30 == 29)
                    this.inicio.Value = this.inicio.Value.AddMinutes(-29);
            }
            horaInicio = inicio.Value;
        }

        private void fin_ValueChanged(object sender, EventArgs e) {
            if (this.fin.Value.Minute % 30 != 0){

                 if (this.fin.Value.Minute % 30 == 1)
                      this.fin.Value = this.fin.Value.AddMinutes(29);

                 if (this.fin.Value.Minute % 30 == 29)
                     this.fin.Value = this.fin.Value.AddMinutes(-29);
            }
            horaFin = fin.Value;
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void dia_SelectedIndexChanged(object sender, EventArgs e) {
            numeroDia = dia.SelectedIndex+1;
        }
    }
}
