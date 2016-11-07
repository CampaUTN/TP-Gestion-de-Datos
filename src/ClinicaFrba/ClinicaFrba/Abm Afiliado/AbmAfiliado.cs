using ClinicaFrba.Abm_Afiliado.Modifiacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AbmAfiliado : Form
    {

        public AbmAfiliado()
        {
            InitializeComponent();
        }

        private void botonSeguir_Click(object sender, EventArgs e)
        {

            if (selecBaja.Checked){
               ListadoAfiliados.ListadoBaja().Show();
            }
            else if (selecModif.Checked){
                (new ListadoAfiliados()).Show();
                
            }
            else if (seleccionAlta.Checked){
                (new Alta()).Show();
            }

        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seleccionAlta_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void selecBaja_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void selecModif_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
