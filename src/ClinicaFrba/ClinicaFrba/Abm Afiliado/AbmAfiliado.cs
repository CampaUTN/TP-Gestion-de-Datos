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
    public partial class AbmAfiliado : Form, FormularioABM
    {
        FormularioABM formulario;

        public AbmAfiliado()
        {
            InitializeComponent();
        }

        private void botonSeguir_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.formulario.Show();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seleccionAlta_CheckedChanged(object sender, EventArgs e)
        {
            formulario = new Alta();
        }

        private void selecBaja_CheckedChanged(object sender, EventArgs e)
        {
            //formulario = new Baja();
        }

        private void selecModif_CheckedChanged(object sender, EventArgs e)
        {
            //Lo uso para probar mientras
            formulario = new ListadoAfiliados();
         //   formulario = new ModificacionUsuario(new Afiliado(
           //    "Emiliano", "Tolaba", DateTime.Parse("27/11/1995 00:00:00"), "DNI", "39372207", "Strangford 1857","46220932", "M", "Soltero/a","asdas"));
        }
    }
}
