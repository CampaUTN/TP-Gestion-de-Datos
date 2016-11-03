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

namespace ClinicaFrba.AbmRol
{
    public partial class RolAlta : Form
    {
        List<KeyValuePair<int, string>> funcionalidades = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();

        bool validacionNombre;

        public RolAlta()
        {
            InitializeComponent();
            buttonCrear.Enabled = false;
            buttonAgregar.Enabled = false;
            buttonQuitar.Enabled = false;
            labelNombreValidacion.Visible = false;
            validacionNombre = false;
            buttonCrear.Enabled = false;
        }

        private void AbmRol_Load(object sender, EventArgs e) {
            using (SqlConnection conexion = DBConnection.getConnection()) {
                SqlCommand query = new SqlCommand("SELECT * FROM CLINICA.funcionalidades",conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) {
                    funcionalidades.Add(new KeyValuePair<int, string>(Int32.Parse(reader["func_id"].ToString()), reader["func_nombre"].ToString()));
                }
                query = new SqlCommand("SELECT * FROM CLINICA.roles", conexion);
                reader.Close();
                reader = query.ExecuteReader();
                while (reader.Read()) {
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["role_id"].ToString()), reader["role_nombre"].ToString()));
                }
            }
            Utilidades.Utils.llenar(this.listFuncionalidades, funcionalidades);
            Utilidades.Utils.llenar(this.listAsignadas, new List<KeyValuePair<int, string>>() );
            buttonAgregar.Enabled = true;
            if (listFuncionalidades.Items.Count > 0)
                listFuncionalidades.SelectedIndex = 0;
        }

        private void buttonAgregar_Click(object sender, EventArgs e) {
            if (listFuncionalidades.Items.Count > 0) {
                listAsignadas.Items.Add(listFuncionalidades.SelectedItem);
                int index = listFuncionalidades.SelectedIndex;
                listFuncionalidades.Items.Remove(listFuncionalidades.SelectedItem);
                if (listFuncionalidades.Items.Count > index)
                    listFuncionalidades.SelectedIndex = index;
                else
                    listFuncionalidades.SelectedIndex = index - 1;
            }

        }

        private void buttonQuitar_Click(object sender, EventArgs e) {
            if (listAsignadas.Items.Count > 0) {
                listFuncionalidades.Items.Add(listAsignadas.SelectedItem);
                int index = listAsignadas.SelectedIndex;
                listAsignadas.Items.Remove(listAsignadas.SelectedItem);
                if (listAsignadas.Items.Count > index)
                    listAsignadas.SelectedIndex = index;
                else //if (listFuncionalidades.Items.Count > 0)
                    listAsignadas.SelectedIndex = index - 1;
            }

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e) {
            labelNombreValidacion.Visible = true;
            buttonCrear.Enabled = false;
            validacionNombre = false;
            if (textBoxNombre.Text == "") {
                labelNombreValidacion.ForeColor = Color.Red;
                labelNombreValidacion.Text = "Nombre inválido";
            } else
                if (roles.Any(x => x.Value.ToUpper() == textBoxNombre.Text.ToUpper())) {
                    labelNombreValidacion.ForeColor = Color.Red;
                    labelNombreValidacion.Text = "Nombre ya existente";
                } else {
                    labelNombreValidacion.ForeColor = Color.Green;
                    labelNombreValidacion.Text = "Nombre válido";
                    validacionNombre = true;
                    buttonCrear.Enabled = true;
                }
        }

        private void buttonCancelar_Click(object sender, EventArgs e) {
            new AbmRol().Show();
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e) {
            using (SqlConnection conexion = DBConnection.getConnection()) {
                SqlCommand query = new SqlCommand("INSERT INTO CLINICA.Roles(role_nombre, role_habilitado) VALUES('" + textBoxNombre.Text + "', 1)", conexion);
                conexion.Open();
                try {
                    query.ExecuteNonQuery();

                    SqlCommand queryObtenerId = new SqlCommand("SELECT role_id FROM CLINICA.Roles WHERE role_nombre='" + textBoxNombre.Text + "'", conexion);

                    int rolId = Convert.ToInt32(queryObtenerId.ExecuteScalar());

                    foreach (KeyValuePair<int, string> funcionalidad in listAsignadas.Items) {
                        SqlCommand queryFunc = new SqlCommand("INSERT INTO CLINICA.RolXFuncionalidad(func_id, role_id) VALUES(" + funcionalidad.Key.ToString() + "," + rolId.ToString() + ")", conexion);
                        queryFunc.ExecuteNonQuery();
                    }

                    MessageBox.Show("Rol creado con éxito");
                    new AbmRol().Show();
                    this.Close();
                } catch (Exception) {
                    MessageBox.Show("Error en la creación del rol");
                    throw;
                }

            }
        }

        private void groupBoxFuncionalidades_Enter(object sender, EventArgs e) {

        }

        private void listAsignadas_SelectedIndexChanged(object sender, EventArgs e) {
            if (listAsignadas.SelectedItems.Count > 0 && listAsignadas.SelectedItems.Count > 0) {
                buttonQuitar.Enabled = true;
                listFuncionalidades.ClearSelected();
            } else
                buttonQuitar.Enabled = false;

        }

        private void listFuncionalidades_SelectedIndexChanged(object sender, EventArgs e) {
            if (listFuncionalidades.SelectedItems.Count > 0 && listFuncionalidades.SelectedItems.Count > 0) {
                buttonAgregar.Enabled = true;
                listAsignadas.ClearSelected();
            } else
                buttonAgregar.Enabled = false;
        }
    }
}
