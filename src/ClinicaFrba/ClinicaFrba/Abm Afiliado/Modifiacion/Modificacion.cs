using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Afiliado;

namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    class ModificacionUsuario :Alta
    {
        public ModificacionUsuario(Afiliado afiliado) : base()
        {
            this.Text = "Modificación";
            this.afiliado = afiliado;
            cargarDatosAfiliado();
            deshabilitarCajitas();
            vaciar();
        }

        //deberia ser privado, pero me tira error de compilacion
        public override void realizarOperacion(){
                        
            MessageBox.Show("Modificando datos!");
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

        }

        private void vaciar()
        {
            textBoxTelefono.Clear();
            textBoxCantHijos.Clear();

        }


    }
}
