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
        private string profesional_id;
        private string especialidad_id;
        private DateTime fechaInicio, fechaFin;
        private DateTime horaInicio, horaFin;
        private int numeroDia;
        private List<Horario> horarios = new List<Horario>();
        private Logger logErrores;
        private DateTime _prevDate1, _prevDate2;
        private bool initialValue1 = false, initialValue2 = false;

        private void selectorFecha_ValueChanged(object sender, EventArgs e) {
            if (initialValue1) {
                initialValue1 = false;
                return;
            }

            DateTime dt = desde.Value;
            TimeSpan diff = dt - _prevDate1;

            if (diff.Ticks < 0)
                desde.Value = _prevDate1.AddMinutes(-30);
            else
                desde.Value = _prevDate1.AddMinutes(30);

            _prevDate1 = desde.Value;
            horaInicio = desde.Value;
        }

        private void hasta_ValueChanged(object sender, EventArgs e) {
            if (initialValue2) {
                initialValue2 = false;
                return;
            }

            DateTime dt = hasta.Value;
            TimeSpan diff = dt - _prevDate2;

            if (diff.Ticks < 0)
                hasta.Value = _prevDate2.AddMinutes(-30);
            else
                hasta.Value = _prevDate2.AddMinutes(30);

            _prevDate2 = hasta.Value; 
            fechaFin = hasta.Value;
        }


        public RegistarAgenda() {
            InitializeComponent();
            this.logErrores = new Logger();
        }

        //todo ver si pasa de mes al pasar el limite de 30/31 dias.
        public virtual void cargarHorario(){
            Horario horario;
            DateTime hora;
            double diferencia = Double.Parse(fechaInicio.DayOfWeek.ToString()) - numeroDia;
            double correccionDia = diferencia >= 0 ? diferencia : 7+diferencia; //7+differencia<7, pues diferencia <0.
            DateTime fecha = fechaInicio.AddDays(Math.Abs(Double.Parse(fechaInicio.DayOfWeek.ToString())-numeroDia));
            while(fecha<=fechaFin){
                hora = horaInicio;
                while (hora.AddMinutes(30) <= horaFin) {
                    horario = new Horario(Int32.Parse(profesional_id), Int32.Parse(especialidad_id), fecha.Add(hora.TimeOfDay));
                    horarios.Add(horario);
                    hora = hora.AddMinutes(30);
                }
                fecha = fecha.AddDays(7);
            }
            // TODO: GUARDAR LA LISTA 'HORARIOS' TODA JUNTA EN UNA QUERY. no de a un elemento xq seria lento.
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

        private void label4_Click(object sender, EventArgs e) {

        }

        private void dia_SelectedIndexChanged(object sender, EventArgs e) {
            numeroDia = Int32.Parse(dia.Text);
        }
    }
}
