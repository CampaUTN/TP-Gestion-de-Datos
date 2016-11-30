using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.AbmRol {
    public partial class RolModifSeleccion : Form {

        List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();

        public RolModifSeleccion() {
            InitializeComponent();

        }

        private void RolBaja_Load(object sender, EventArgs e) {
            cargarRolesHabilitados();
            buttonModif.Enabled = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e) {
            new AbmRol().Show();
            this.Close();
        }

        private void cargarRolesHabilitados() {
            roles.Clear();
            listRoles.Items.Clear();
            using (SqlConnection conexion = DBConnection.getConnection()) {
                SqlCommand query = new SqlCommand("SELECT role_id, role_nombre, role_habilitado FROM GEDDES.roles", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    if (Convert.ToBoolean(reader["role_habilitado"]))
                        roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()), reader["role_nombre"].ToString()));
                    else
                        roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()), reader["role_nombre"].ToString() +" (Inhabilitado)"));
                }
            }
            Utilidades.Utils.llenar(this.listRoles, roles);
        }

        private void listRoles_SelectedIndexChanged(object sender, EventArgs e) {
            if (listRoles.SelectedIndex >= 0) {
                buttonModif.Enabled = true;
            } else {
                buttonModif.Enabled = false;
            }
        }

        private void buttonModif_Click(object sender, EventArgs e) {
            KeyValuePair<int, string> item = (KeyValuePair<int, string>) listRoles.SelectedItem;
            new RolModif(item.Key).Show();
            this.Close();
        }

    }
}
