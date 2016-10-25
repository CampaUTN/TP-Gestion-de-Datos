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
    public partial class Alta : Form, FormularioABM
    {
        string sexo;

        public Alta()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            //verificar que se hayan completado los datos
        }

        private void selecFem_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "F";
        }

        private void selecMasc_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "M";
        }
    }

}
