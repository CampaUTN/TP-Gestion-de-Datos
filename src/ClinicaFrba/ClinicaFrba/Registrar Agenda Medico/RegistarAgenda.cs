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
            //chequeo que todos los campos se hayan completado
            if (!faltaCompletarDatos()) {
                //chequeo que los datos sean correctos
                this.validarDatosIngresados();
                if (!this.logErrores.huboErrores()) {
                    //metodo que sobreescribe Modificacion
                    cargarHorario();
                } else {
                    MessageBox.Show("Error en el ingreso de datos:\n" + this.logErrores.mostrarLog() + "\nCompruebe que haya ingresado los datos en forma correcta y vuelva a intentarlo.", "Error", MessageBoxButtons.OK);
                }
                this.logErrores.resetear();
            } else {
                MessageBox.Show("Debe completar todos los datos del horario para continuar", "Aviso", MessageBoxButtons.OK);

            }
        }


        public virtual void cargarHorario(){
            horario = new Horario(profesional_id, especialidad_id, fechaHora);
        }

        private bool faltaCompletarDatos() {
            return cajasTexto.Any(cajita => cajita.Text.Length.Equals(0));
        }

        private void validarDatosIngresados() {
            // TODO
        }
    }
}
