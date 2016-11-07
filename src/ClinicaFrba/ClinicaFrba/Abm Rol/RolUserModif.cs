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
    public partial class RolUserModif : Form {

        List<KeyValuePair<int, string>> asignados = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();
        string username;

        public RolUserModif() {
            InitializeComponent();
        }

        public RolUserModif(string username) {
            InitializeComponent();
            this.username = username;
            labelNombreUsuario.Text = username;
        }

        private void RolUserModif_Load(object sender, EventArgs e) {
            buttonAgregar.Enabled = false;
            buttonQuitar.Enabled = false;
            // Obtenemos los roles asignados al usuario
            using (SqlConnection conexion = DBConnection.getConnection()) {
                List<KeyValuePair<int, string>> rolesAsignados = new List<KeyValuePair<int, string>>();
                SqlCommand comando = new SqlCommand("GEDDES.getRolesUsuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@user", username);
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read()) {
                    asignados.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()),reader["role_nombre"].ToString()));
                }
                Utilidades.Utils.llenar(listAsignados, asignados);
                reader.Close();
                // Obtenemos los roles disponibles en el sistema
                SqlCommand queryRoles = new SqlCommand("SELECT role_id, role_nombre FROM GEDDES.Roles WHERE role_habilitado=1", conexion);
                SqlDataReader readerRoles = queryRoles.ExecuteReader();
                while (readerRoles.Read()) {
                    KeyValuePair<int, string> item = new KeyValuePair<int, string>(Int32.Parse(readerRoles["role_id"].ToString()), readerRoles["role_nombre"].ToString());
                    // Agregamos a la lista de disponibles aquellos roles que el usuario no tenga asignado
                    if (!asignados.Contains(item))
                        roles.Add(item);
                }
                readerRoles.Close();
                Utilidades.Utils.llenar(listRoles, roles);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e) {
            // Procedemos a guardar las diferencias entre la base y lo modificado
            using (SqlConnection conexion = DBConnection.getConnection()) {
                conexion.Open();
                long userId = Utilidades.Utils.getIdDesdeUserName(username);

                try {
                    foreach (KeyValuePair<int, string> item in listAsignados.Items) {
                        if (!asignados.Contains(item)) {
                            // Insertamos los nuevos roles que posee el usuario
                            SqlCommand queryInsertFunc = new SqlCommand("INSERT INTO GEDDES.RolXUsuario(usua_id, role_id) VALUES(" + userId + "," + item.Key + ")", conexion);
                            queryInsertFunc.ExecuteNonQuery();
                        }
                    }
                    foreach (KeyValuePair<int, string> item in asignados) {
                        if (!listAsignados.Items.Contains(item)) {
                            // Eliminamos aquellos roles que ya no posee el usuario
                            SqlCommand queryDeleteFunc = new SqlCommand("DELETE FROM GEDDES.RolXUsuario WHERE usua_id=" + userId + " AND role_id=" + item.Key, conexion);
                            queryDeleteFunc.ExecuteNonQuery();
                        }
                    }
                    new AbmRol().Show();
                    this.Close();
                } catch (Exception) {
                    throw;
                }
            }
        }

        private void listAsignados_SelectedIndexChanged(object sender, EventArgs e) {
            if (listAsignados.SelectedItems.Count > 0) {
                buttonQuitar.Enabled = true;
                listRoles.ClearSelected();
            } else
                buttonQuitar.Enabled = false;
        }

        private void listRoles_SelectedIndexChanged(object sender, EventArgs e) {
            if (listRoles.SelectedItems.Count > 0 && listRoles.SelectedItems.Count > 0) {
                buttonAgregar.Enabled = true;
                listAsignados.ClearSelected();
            } else
                buttonAgregar.Enabled = false;
        }
        private void buttonAgregar_Click(object sender, EventArgs e) {
            // Transferimos uno de los roles disponibles hacia los roles asignados
            if (listRoles.Items.Count > 0) {
                listAsignados.Items.Add(listRoles.SelectedItem);
                int index = listRoles.SelectedIndex;
                listRoles.Items.Remove(listRoles.SelectedItem);
                if (listRoles.Items.Count > index)
                    listRoles.SelectedIndex = index;
                else
                    listRoles.SelectedIndex = index - 1;
            }
        }
        private void buttonQuitar_Click(object sender, EventArgs e) {
            // Transferimos uno de los roles asignados hacia los roles disponibles
            if (listAsignados.Items.Count > 0 && listAsignados.SelectedItems.Count > 0) {
                listRoles.Items.Add(listAsignados.SelectedItem);
                int index = listAsignados.SelectedIndex;
                listAsignados.Items.Remove(listAsignados.SelectedItem);
                if (listAsignados.Items.Count > index)
                    listAsignados.SelectedIndex = index;
                else
                    listAsignados.SelectedIndex = index - 1;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e) {
            new AbmRol().Show();
            this.Close();
        }
    }
}
