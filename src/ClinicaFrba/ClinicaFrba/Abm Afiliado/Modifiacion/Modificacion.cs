using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Utilidades;

namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    class ModificacionUsuario :Alta
    {
           private List<TextBox> cajitasLlenadas;
           private string camposModificados;


        public ModificacionUsuario(Afiliado afiliado) : base()
        {
            this.camposModificados = "";
            this.cajitasLlenadas = new List<TextBox>();

            this.Text = "Modificación";
            this.afiliado = afiliado;

            this.cargarDatosAfiliado();
            this.deshabilitarCajitas();
            this.vaciar();
        }

        //deberia ser privado, pero me tira error de compilacion
        public override void realizarOperacion(){

            if (MessageBox.Show("Se modificaran los siguientes campos:\n" + this.camposModificados + "Desea continuar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.cargarUsuario();

                Utils.actualizarAfiliado(this.afiliado);

                MessageBox.Show("Modificacion Realizada con exito!");
                   this.Close();
                
            }
            else
            {
                selecPlan.ResetText();
                selecEstadoCivil.ResetText();

                selecPlan.SelectedItem = null;
                selecEstadoCivil.SelectedItem = null;

            }

            camposModificados = "";

        }

        private void cargarDatosAfiliado(){

            this.textBoxNombre.Text = afiliado.getNombre();
            this.textBoxApellido.Text = afiliado.getApellido();
            this.textBoxNroDoc.Text = Convert.ToString(afiliado.getNroDoc());
            this.comboBoxTipoDoc.Text = afiliado.getTipoDoc();
            this.selectorFecha.Value = afiliado.getFechaNac();
        }

        private void deshabilitarCajitas()
        {
            this.cajasTexto.Remove(textBoxNombre);
            this.cajasTexto.Remove(textBoxApellido);
            this.cajasTexto.Remove(textBoxNroDoc);

            this.cajasTexto.ForEach(cajita => cajita.Clear());

            this.textBoxNombre.Enabled = false;
            this.textBoxApellido.Enabled = false;
            this.textBoxNroDoc.Enabled = false;
            this.selecFem.Enabled = false;
            this.selecMasc.Enabled = false;
            this.selectorFecha.Enabled = false;
            this.comboBoxTipoDoc.Enabled = false;

            this.selecPlan.ResetText();

        }

        public override void cargarUsuario()
        {

            if (textBoxDireccion.Text.Length > 0)
            {
                afiliado.setDireccion(textBoxDireccion.Text);
            }


            if (textBoxTelefono.Text.Length > 0)
            {
                afiliado.setTelefono(Convert.ToInt32(textBoxTelefono.Text));
            }

            if (selecEstadoCivil.SelectedItem != null)
            {
                if (selecEstadoCivil.SelectedItem.ToString() != afiliado.getEstadoCivil())
                {
                     afiliado.setEstadoCivil(selecEstadoCivil.SelectedItem.ToString());
                 }
            }

            if (selecPlan.SelectedItem != null)
            {
                KeyValuePair<int, string> plan = ( KeyValuePair<int, string> ) selecPlan.SelectedItem;
                plan.Value.ToString();
                if (plan.Value.ToString() != afiliado.getPlan())
                {
                    MessageBox.Show("INDIQUE EL MOTIVO POR EL QUE DESEA CAMBIAR EL PLAN Desde " + afiliado.getPlan() + " a " + plan.Value.ToString());


                    MotivoCambioPlan formulario = new MotivoCambioPlan(afiliado.getCodigoAfiliado());
                    formulario.ShowDialog();

                    afiliado.setPlan(plan.Value.ToString());
                }
            }
        }

        private void vaciar(){
            textBoxDireccion.Clear();
            textBoxTelefono.Clear();
            textBoxCantHijos.Clear();
                        
        }

        public override bool faltaCompletarDatos(){
            bool cajasVacias = cajasTexto.FindAll(cajita => cajita.Text.Length.Equals(0)).Count().Equals(cajasTexto.Count());

            bool noSeEligioUnPlan = selecPlan.SelectedItem == null;


            if (textBoxDireccion.Text.Length > 0)
            {
                camposModificados = camposModificados + "- Direccion\n";
            }

            if (textBoxTelefono.Text.Length > 0)
            {
                camposModificados = camposModificados + "- Teléfono\n";
            }

            if (!noSeEligioUnPlan)
            {
                camposModificados = camposModificados + "- Plan\n";
            }

            bool noSeEligioEstadoCivil = selecEstadoCivil.SelectedItem == null;

            if (!noSeEligioEstadoCivil)
            {
                camposModificados = camposModificados + "- Estado Civil\n";
            }

            return noSeEligioUnPlan && noSeEligioEstadoCivil && cajasVacias;
        }

        public override void validarDatosIngresados(){
            if (!Parser.esEntero(textBoxTelefono) && textBoxTelefono.Text.Length >0 )
            {
                this.logErrores.agregarAlLog("El numero de telefono debe ser numerico");

                textBoxTelefono.Clear();
                this.cajasTexto.Remove(textBoxTelefono);
            }


            if (selecPlan.SelectedItem != null)
            {
                KeyValuePair<int, string> plan = (KeyValuePair<int, string>)selecPlan.SelectedItem;
                plan.Value.ToString();
                if (plan.Value.ToString() == afiliado.getPlan())
                {
                    logErrores.agregarAlLog("El afiliado ya dispone del plan escogido");
                    this.selecPlan.ResetText();

                    camposModificados = "";
                }

            }
        }
    }
}
