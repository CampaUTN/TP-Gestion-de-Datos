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
            //Utils.populate(this.comboBox1, roles);
        }

        private void EleccionRol_Load(object sender, EventArgs e)
        {

        }
    }
}
