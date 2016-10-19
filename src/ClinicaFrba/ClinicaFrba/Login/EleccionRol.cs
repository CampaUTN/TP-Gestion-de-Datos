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
        Form frmLogin;
        string userActivo;

        public EleccionRol(Form frmLogin, string userActivo, List<KeyValuePair<int, string>> rolesAsignados)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            this.userActivo = userActivo;
            //Utils.populate(this.comboRolesPosibles, rolesAsignados);
           
        }

        private void EleccionRol_Load(object sender, EventArgs e)
        {

        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            int rolSeleccionado = ((KeyValuePair<int, string>)this.comboRolesPosibles.SelectedItem).Key;
            new MenuPrincipal(this.frmLogin, rolSeleccionado, this.userActivo).Show();
            this.Close();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }
    }
}
