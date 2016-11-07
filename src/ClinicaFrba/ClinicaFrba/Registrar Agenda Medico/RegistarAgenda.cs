using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class RegistarAgenda : Form
    {
        private DateTime horaInicio, horaFin;
        private int numeroDia = 99;
        private Logger logErrores;
        private string usuario;
        private int rol;
        
        private bool esProfesional(){
            return rol == 3;
        }

        private void selectorFecha_ValueChanged(object sender, EventArgs e) {
            if (hasta.Value.Date < desde.Value.Date) {
                MessageBox.Show("La fecha final debe ser posterior a la inicial.");
            }   
        }

        private void hasta_ValueChanged(object sender, EventArgs e) {
            if(hasta.Value.Date<desde.Value.Date){
                MessageBox.Show("La fecha final debe ser posterior a la inicial.");
            }                
        }


        public RegistarAgenda(string usuario, int rol) {
            InitializeComponent();
            this.logErrores = new Logger();
            horaInicio = inicio.Value;
            horaFin = fin.Value;
            this.usuario = usuario;
            this.rol = rol;
        }

        //todo ver si pasa de mes al pasar el limite de 30/31 dias.
        public virtual void cargarHorario(SqlConnection conexion) {
            int rowindex = grillaProfesionales.CurrentCell.RowIndex;
            List<Horario> horarios = new List<Horario>();
            Horario horario;
            DateTime hora;
            double diferencia = (int)desde.Value.DayOfWeek - numeroDia;
            DateTime fecha = desde.Value.AddDays(Math.Abs((int)desde.Value.DayOfWeek-numeroDia));
           // MessageBox.Show(desde.Value.ToString()+"         "+fecha.ToString()+"      "+hasta.Value.ToString());
            while (fecha <= hasta.Value) {
                hora = horaInicio;
                while (hora.AddMinutes(30) <= horaFin) {
                    horario = new Horario(Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[0].Value), Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[3].Value), fecha.Add(hora.TimeOfDay));
                    horarios.Add(horario);
                    hora = hora.AddMinutes(30);
                }
                fecha = fecha.AddDays(7);
            }


            foreach (Horario h in horarios) {
                string insertHorarios = "INSERT INTO GEDDES.Horarios values (@profesional, @especialidad, @fecha, @inicio)";
                SqlCommand comandoInsertarHorarios = new SqlCommand(insertHorarios, conexion);
                comandoInsertarHorarios.Parameters.AddWithValue("@profesional", h.profesional_id);
                comandoInsertarHorarios.Parameters.AddWithValue("@especialidad", h.especialidad_id);
                comandoInsertarHorarios.Parameters.AddWithValue("@fecha", h.fechaHora.Date);
                comandoInsertarHorarios.Parameters.AddWithValue("@inicio", h.fechaHora.TimeOfDay);
                comandoInsertarHorarios.ExecuteNonQuery();
            }
            MessageBox.Show("Carga realizada con exito.");
        }

        private bool horarioValido(DateTime fechaHora) {
            String hora = fechaHora.ToString("HH:mm");
            if (numeroDia == 99) {
                return false;
            }
            if (numeroDia == 6) { //sabado
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
            if (esProfesional()){
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales3(usuario);
            } else {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales2();
            }
        }


        //agregar horario
        private void button2_Click(object sender, EventArgs e) {
            if (grillaProfesionales.SelectedCells.Count == 0) {
                MessageBox.Show("Seleccione un profesional y especialidad en la grilla.", "Error", MessageBoxButtons.OK);
                return;
            }
            if (horaInicio.TimeOfDay>=horaFin.TimeOfDay) {
                MessageBox.Show("La hora de inicio no puede ser mayor o igual a la hora de finalizacion.", "Error", MessageBoxButtons.OK);
                return;
            }
            int rowindex = grillaProfesionales.CurrentCell.RowIndex;
            if (horarioValido(horaInicio) && horarioValido(horaFin)) {
                try{
                    SqlConnection conexion = DBConnection.getConnection();
                    conexion.Open();
                    cargarHorario(conexion);
                }
                catch (SqlException ex){
                       MessageBox.Show("No se permite agregar estos horarios: se superaria el limite de 48 horas semanales de agregarlos. Se han insertado todos los horarios posibles hasta alcanzar dicho limite.", "Error", MessageBoxButtons.OK);
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
