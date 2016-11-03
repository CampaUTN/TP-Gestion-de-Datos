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


        public ModificacionUsuario(Afiliado afiliado) : base()
        {

            this.cajitasLlenadas = new List<TextBox>();

            this.Text = "Modificación";
            this.afiliado = afiliado;
            cargarDatosAfiliado();
            deshabilitarCajitas();
            vaciar();
        }

        //deberia ser privado, pero me tira error de compilacion
        public override void realizarOperacion(){
                        
            MessageBox.Show("Modificando datos!");
            this.cargarUsuario();

            Utils.actualizarAfiliado(this.afiliado);
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

            if (selecEstadoCivil.SelectedItem.ToString().Length > 0)
            {
                MessageBox.Show("se eligio: " + selecEstadoCivil.SelectedItem.ToString());
                afiliado.setEstadoCivil(selecEstadoCivil.SelectedItem.ToString());
            }

        }

        private void vaciar()
        {
            textBoxTelefono.Clear();
            textBoxCantHijos.Clear();

        }

        public override bool faltaCompletarDatos()
        {
            return cajasTexto.FindAll(cajita => cajita.Text.Length.Equals(0)).Count().Equals(cajasTexto.Count());
        }

        public override void validarDatosIngresados() 
        {
            if (!Parser.esEntero(textBoxTelefono) && textBoxTelefono.Text.Length >0 )
            {
                this.logErrores.agregarAlLog("El numero de telefono debe ser numerico");

                textBoxTelefono.Clear();
                this.cajasTexto.Remove(textBoxTelefono);
            }
        }
    }
}
