using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    public partial class Modificacion : Alta
    {
        public Modificacion(Afiliado afiliado)
        {
            InitializeComponent();

            this.Text = "Modificacion";

            this.textBoxNombre.Text = afiliado.getNombre();
            this.textBoxApellido.Text = afiliado.getApellido();
            this.textBoxNroDoc.Text = Convert.ToString(afiliado.getNroDoc());
            this.comboBoxTipoDoc.Text = afiliado.getTipoDoc();

            this.textBoxNombre.Enabled = false;
            this.textBoxApellido.Enabled = false;
            this.textBoxNroDoc.Enabled = false;
            this.selecFem.Enabled = false;
            this.selecMasc.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.comboBoxTipoDoc.Enabled = false;
        }

        //deberia ser privado, pero me tira error de compilacion
        public override void realizarOperacion()
        {
            MessageBox.Show("Modificando datos!");
            
        }
    }
}
