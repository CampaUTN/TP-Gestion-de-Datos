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
    public partial class RolModif : Form
    {
        List<KeyValuePair<int, string>> funcionalidades = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> asignadas = new List<KeyValuePair<int, string>>();
        List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();
        int rolId;
        string rolNombre;

        public RolModif()
        {
            InitializeComponent();
        }

        public RolModif(int rolId) {
            InitializeComponent();
            buttonGuardar.Enabled = false;
            buttonAgregar.Enabled = false;
            buttonQuitar.Enabled = false;
            labelNombreValidacion.Visible = false;
            buttonGuardar.Enabled = false;
            this.rolId = rolId;
        }

        private void RolModif_Load(object sender, EventArgs e) {
            using (SqlConnection conexion = DBConnection.getConnection()) {
                conexion.Open();


                SqlCommand queryObtenerModificable = new SqlCommand("SELECT * FROM CLINICA.roles WHERE role_id="+rolId, conexion);
                SqlDataReader readerDatos = queryObtenerModificable.ExecuteReader();
                if (readerDatos.Read()) {
                    textBoxNombre.Text = Convert.ToString(readerDatos["role_nombre"]);
                    checkBoxHabilitado.Checked = Convert.ToBoolean(readerDatos["role_habilitato"]);
                    rolNombre = textBoxNombre.Text;
                }
                readerDatos.Close();
                var parametrosSP = new List<KeyValuePair<string, object>>();
                parametrosSP.Add(new KeyValuePair<string, object>("@role_id", rolId));
                SqlCommand query = Utilidades.Utils.crearSp("CLINICA.getFuncionalidadXRol", parametrosSP, conexion);
                SqlDataReader readerAsignadas = query.ExecuteReader();
                while (readerAsignadas.Read()) {
                    asignadas.Add(new KeyValuePair<int, string>(Int32.Parse(readerAsignadas["func_id"].ToString()), readerAsignadas["func_nombre"].ToString()));
                }
                readerAsignadas.Close();

                SqlCommand queryFuncionalidades = new SqlCommand("SELECT * FROM CLINICA.funcionalidades", conexion);
                SqlDataReader readerFuncionalidades = queryFuncionalidades.ExecuteReader();
                while (readerFuncionalidades.Read()) {
                    KeyValuePair<int, string> item = new KeyValuePair<int, string>(Int32.Parse(readerFuncionalidades["func_id"].ToString()), readerFuncionalidades["func_nombre"].ToString());
                    if (!asignadas.Contains(item))
                    funcionalidades.Add(item);
                }
                readerFuncionalidades.Close();

                SqlCommand queryRoles = new SqlCommand("SELECT * FROM CLINICA.roles", conexion);
                SqlDataReader readerRoles = queryRoles.ExecuteReader();
                while (readerRoles.Read()) {
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(readerRoles["role_id"].ToString()), readerRoles["role_nombre"].ToString()));
                }
            }
            Utilidades.Utils.llenar(this.listFuncionalidades, funcionalidades);
            Utilidades.Utils.llenar(this.listAsignadas, asignadas);
            buttonAgregar.Enabled = true;
            if (listFuncionalidades.Items.Count>0)
                listFuncionalidades.SelectedIndex = 0;
            listAsignadas.SelectedIndex = -1;
        }

        private void buttonAgregar_Click(object sender, EventArgs e) {
            if (listFuncionalidades.SelectedIndex == -1)
                buttonAgregar.Enabled = false;
            else
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
            if (listAsignadas.SelectedIndex == -1)
                buttonQuitar.Enabled = false;
            else
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
            buttonGuardar.Enabled = false;
            if (textBoxNombre.Text == "") {
                labelNombreValidacion.ForeColor = Color.Red;
                labelNombreValidacion.Text = "Nombre inválido";
            } else
                if (roles.Any(x => x.Value.ToUpper() == textBoxNombre.Text.ToUpper() && textBoxNombre.Text.ToUpper() != rolNombre.ToUpper())) {
                    labelNombreValidacion.ForeColor = Color.Red;
                    labelNombreValidacion.Text = "Nombre ya existente";
                } else {
                    labelNombreValidacion.ForeColor = Color.Green;
                    labelNombreValidacion.Text = "Nombre válido";
                    buttonGuardar.Enabled = true;
                }
        }

        private void listFuncionalidades_Click(object sender, EventArgs e) {
            if (listFuncionalidades.SelectedIndex != -1)
                buttonAgregar.Enabled = true;
            buttonQuitar.Enabled = false;
            listAsignadas.ClearSelected();
        }

        private void listAsignadas_Click(object sender, EventArgs e) {
            if (listAsignadas.SelectedIndex != -1)
                buttonQuitar.Enabled = true;
            buttonAgregar.Enabled = false;
            listFuncionalidades.ClearSelected();
        }

        private void buttonCancelar_Click(object sender, EventArgs e) {
            new RolModifSeleccion().Show();
            this.Close();
        }

        private void buttonCrear_Click(object sender, EventArgs e) {
            using (SqlConnection conexion = DBConnection.getConnection()) {                
                conexion.Open();

                SqlCommand queryUpdate = new SqlCommand("UPDATE CLINICA.Roles SET role_nombre='" + textBoxNombre.Text + "', role_habilitato=" + Convert.ToInt32(checkBoxHabilitado.Checked).ToString() + " WHERE role_id=" + rolId, conexion);
                queryUpdate.ExecuteNonQuery();

                foreach (KeyValuePair<int, string> item in listAsignadas.Items) {
                    if (!asignadas.Contains(item)) {
                        // (SQL) INSERT QUERY
                        SqlCommand queryInsertFunc = new SqlCommand("INSERT INTO CLINICA.RolXFuncionalidad(func_id, role_id) VALUES(" + item.Key.ToString() + "," + rolId.ToString() + ")", conexion);
                        queryInsertFunc.ExecuteNonQuery();
                    }

                }

                foreach (KeyValuePair<int, string> item in asignadas) {
                    if (!listAsignadas.Items.Contains(item)) {
                        // (SQL) DELETE QUERY
                        SqlCommand queryDeleteFunc = new SqlCommand("DELETE FROM CLINICA.RolXFuncionalidad WHERE role_id="+rolId, conexion);
                        queryDeleteFunc.ExecuteNonQuery();
                    }
                }

                new RolModifSeleccion().Show();
                this.Close();


            }
        }

        private void groupBoxFuncionalidades_Enter(object sender, EventArgs e) {

        }
    }
}
