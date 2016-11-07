using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class EleccionRol : Form
    {
        string userActivo;

        public EleccionRol(string userActivo, List<KeyValuePair<int, string>> rolesAsignados)
        {
            InitializeComponent();

            this.userActivo = userActivo;
            Utilidades.Utils.llenar(this.comboRolesPosibles, rolesAsignados);
        }

        private void EleccionRol_Load(object sender, EventArgs e) {
            if (comboRolesPosibles.Items.Count > 0)
                comboRolesPosibles.SelectedIndex = 0;
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            bool esValido = false;
            foreach (KeyValuePair<int, string> item in comboRolesPosibles.Items){
                if (item.Value == comboRolesPosibles.Text) {
                    esValido = true;
                    break;
                }
            }

            if (esValido) {
                int rolSeleccionado = ((KeyValuePair<int, string>)this.comboRolesPosibles.SelectedItem).Key;
                new MenuPrincipal(rolSeleccionado, this.userActivo).Show();
                this.Close();
            } else
                MessageBox.Show("El rol seleccionado no es válido");
            
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            Program.loginForm.Show();
            this.Close();

        }
    }
}
