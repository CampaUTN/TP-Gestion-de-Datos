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
    public partial class RolBaja : Form {

        List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();

        public RolBaja() {
            InitializeComponent();
        }

        private void RolBaja_Load(object sender, EventArgs e) {
            // Cargamos los roles habilitados del sistema
            cargarRolesHabilitados();
            buttonEliminar.Enabled = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e) {
            new AbmRol().Show();
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e) {
            KeyValuePair<int, string> item = (KeyValuePair<int, string>) listRoles.SelectedItem;
            using (SqlConnection conexion = DBConnection.getConnection()) {
                // Inhabilitamos el rol
                SqlCommand queryDehabilitarRol = new SqlCommand("UPDATE GEDDES.Roles SET role_habilitado=0 WHERE role_nombre='"+item.Value+"'", conexion);
                conexion.Open();
                try {
                    queryDehabilitarRol.ExecuteNonQuery();
                } catch { }
                // Eliminamos todas las asignaciones de usuarios a ese rol
                SqlCommand queryDesasignarRol = new SqlCommand("DELETE FROM GEDDES.RolXUsuario WHERE role_id=" + item.Key, conexion);
                try {
                    queryDesasignarRol.ExecuteNonQuery();
                } catch { }
            }
            cargarRolesHabilitados();
        }

        private void cargarRolesHabilitados() {
            roles.Clear();
            listRoles.Items.Clear();
            using (SqlConnection conexion = DBConnection.getConnection()) {
                SqlCommand query = new SqlCommand("SELECT role_id, role_nombre FROM GEDDES.roles WHERE role_habilitado=1", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()), reader["role_nombre"].ToString()));
                }
            }
            Utilidades.Utils.llenar(this.listRoles, roles);
        }

        private void listRoles_SelectedIndexChanged(object sender, EventArgs e) {
            if (listRoles.SelectedIndex >= 0) {
                buttonEliminar.Enabled = true;
            } else {
                buttonEliminar.Enabled = false;
            }
        }

    }
}
