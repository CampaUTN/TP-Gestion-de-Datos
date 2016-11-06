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
        private int usuario;
        private int rol;
        public CancelarAtencion(string usuario, int rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.usuario = Convert.ToInt32(Utilidades.Utils.getIdDesdeUserName(usuario).ToString());
            if (esAfiliado()) {
                desde.Hide();
            }
        }

        private bool esAfiliado(){
            return rol == 1;
        }

        // Boton de borrar
        private void button2_Click(object sender, EventArgs e) {
            if (esAfiliado()) {
                
            } else {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getAgenda(usuario);
            }
            this.listar();
        }

        private void botonListar_Click(object sender, EventArgs e) {
            this.listar();
        }

        private void listar() {
            //getTurnos
            if (esAfiliado()) {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getTurnos(usuario);
            } else {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getAgenda(usuario);
            }
            // si es un medico lista la agenda ordenada
            // por fecha o da la opcion de q el usuario ingrese 2 fechas y cancelar todo lo q este entre esas fechas.
        }

        private void CancelarAtencion_Load(object sender, EventArgs e) {

        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        // cancelar un dia
        private void desde_ValueChanged(object sender, EventArgs e) {
            Utilidades.Utils.bajaDia(usuario, desde.Value.Date);
        }
    }
}
