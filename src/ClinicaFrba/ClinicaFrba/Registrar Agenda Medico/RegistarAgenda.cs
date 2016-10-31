using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public partial class RegistarAgenda : Form
    {
        protected int profesional_id;
        protected int especialidad_id;
        protected DateTime fechaHora;
        protected Horario horario;

        protected Logger logErrores;

        public RegistarAgenda() {
            InitializeComponent();
            this.logErrores = new Logger();
        }

        private void selectorFecha_ValueChanged(object sender, EventArgs e) {}

        private void botonCancelar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.Close();
            }
        }


        private void AceptarButton_Click(object sender, EventArgs e) {
                if(diaValido()){
                    cargarHorario();
                }else{
                    MessageBox.Show("La fecha debe estar comprendida entre 7:00 y 20:00 para horarios de lunes a viernes, y entre 10:00 y 15:00 para los sabados.", "Error", MessageBoxButtons.OK);
                }
        }


        public virtual void cargarHorario(){
            horario = new Horario(profesional_id, especialidad_id, fechaHora);
        }

        private bool diaValido() {
            return fechaHora.DayOfWeek != 0;
        }
    }
}
