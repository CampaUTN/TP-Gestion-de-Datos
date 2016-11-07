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
    public partial class AbmRol : Form
    {

        public AbmRol()
        {
            InitializeComponent();
            buttonModificarRoles.Enabled = false;

        }

        private void AbmRol_Load(object sender, EventArgs e) {
            // Obtenemos los distintos usuarios del sistema y ofrecemos la opcion de autocompletar para 
            // la modificacion de roles de un ussuario
            using (SqlConnection conexion = DBConnection.getConnection()) {
                conexion.Open();
                AutoCompleteStringCollection nombresUsuarios = new AutoCompleteStringCollection();
                SqlCommand queryNombres = new SqlCommand("SELECT DISTINCT usua_username from GEDDES.Usuarios", conexion);
                SqlDataReader readerNombres = queryNombres.ExecuteReader();
                while (readerNombres.Read()) {
                    nombresUsuarios.Add(readerNombres["usua_username"].ToString());
                }
                readerNombres.Close();
                textBoxNombreUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxNombreUsuario.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxNombreUsuario.AutoCompleteCustomSource = nombresUsuarios;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            new RolAlta().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            new RolBaja().Show();
            this.Close();
        }

        private void buttonModificacion_Click(object sender, EventArgs e) {
            new RolModifSeleccion().Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonModificarRoles_Click(object sender, EventArgs e) {
            new RolUserModif(textBoxNombreUsuario.Text).Show();
            this.Close();
        }

        private void textBoxNombreUsuario_TextChanged(object sender, EventArgs e) {
            // Validamos que lo ingresado sea uno de los usuarios
            buttonModificarRoles.Enabled = textBoxNombreUsuario.AutoCompleteCustomSource.Contains(textBoxNombreUsuario.Text);
        }

    }
}
