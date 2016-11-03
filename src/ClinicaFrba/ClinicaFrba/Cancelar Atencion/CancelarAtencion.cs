using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencion : Form
    {
        public CancelarAtencion()
        {
            InitializeComponent();
        }

        // Boton de borrar
        private void button2_Click(object sender, EventArgs e) {
            // borrar lo seleccionado
            this.listar();
        }

        private void botonListar_Click(object sender, EventArgs e) {
            this.listar();
        }

        private void listar() {
            // todo: lista las atenciones si es un afiliado. si es un medico lista la agenda ordenada
            // por fecha o da la opcion de q el usuario ingrese 2 fechas y cancelar todo lo q este entre esas fechas.
        }
    }
}
