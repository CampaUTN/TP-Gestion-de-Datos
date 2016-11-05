using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class RegistarAgenda : Form
    {
        protected string profesional_id;
        protected string especialidad_id;
        protected DateTime fechaInicio, fechaFin;
        protected DateTime horaInicio, horaFin;
        protected Horario horario;

        protected Logger logErrores;

        public RegistarAgenda() {
            InitializeComponent();
            this.logErrores = new Logger();
        }

        public virtual void cargarHorario(){
            horario = new Horario(Int32.Parse(profesional_id), Int32.Parse(especialidad_id), fechaHora);
        }

        private bool horarioValido() {
            if(fechaHora.DayOfWeek.Equals(0)){ //domingo
                 String hora = fechaHora.ToString("HH:mm");
                 if (fechaHora.DayOfWeek.Equals(6)) { //sabado
                     return String.Compare(hora,"10:00") >= 0 && String.Compare(hora,"15:00") <= 0; 
                }else{ // lunes a viernes
                     return String.Compare(hora,"´07:00") >= 0 && String.Compare(hora,"20:00") <= 0; 
                }
            }
            return false;
        }

        private void RegistarAgenda_Load(object sender, EventArgs e) {

        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (grillaProfesionales.SelectedCells.Count == 1) {
                int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                profesional_id = grillaProfesionales.Rows[rowindex].Cells[0].Value.ToString();
                especialidad_id = grillaProfesionales.Rows[rowindex].Cells[3].Value.ToString();
            }else{
                MessageBox.Show("Seleccione solo un profesional a la vez.", "Error", MessageBoxButtons.OK);
            }
        }


        private void botonListar_Click(object sender, EventArgs e) {
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
        }


        //agregar horario
        private void button2_Click(object sender, EventArgs e) {
            if (horarioValido()) {
                try{
                cargarHorario();
                }
                catch (SqlException e){
                    if(e.Errors[0].Number == -10) {
                        //todo: no se deberia hacer if savepoint!=null, savepoint.rollback?
                        MessageBox.Show("No se permite agregar estos horarios: El profesional ya atiende en alguno de los horarios indicados, o se superaria el limite de 48 horas semanales de agregar estos horarios.", "Error", MessageBoxButtons.OK);
                    }
                }
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
            horaInicio = inicio.Value;
        }

        private void fin_ValueChanged(object sender, EventArgs e) {
            horaFin = fin.Value;
        }


        //desde
        private void selectorFecha_ValueChanged(object sender, EventArgs e) {
            fechaInicio = desde.Value;
        }

        private void hasta_ValueChanged(object sender, EventArgs e) {
            fechaFin = hasta.Value;
        }

        private void label4_Click(object sender, EventArgs e) {

        }
    }
}
