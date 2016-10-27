using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Afiliado;
using System.Data.SqlClient;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaUsuario : Form
    {
        private Afiliado afiliado = new Afiliado();

        public AltaUsuario(Afiliado afliadoARegistrar)
        {
            this.afiliado = afliadoARegistrar;
            InitializeComponent();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (chequearPass())
            {
                MessageBox.Show("Registrando usuario");
                registarUsuario(this.afiliado);

                MessageBox.Show("Usuario registrado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifique que ingreso la contraseña correcta e intentelo de nuevo");
            }
        }

        private bool chequearPass() {
            return this.textBoxPass.Text == this.textBoxPassConfirm.Text;
        }

        private void registarUsuario(Afiliado afiliado){

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("CLINICA.ingresarUsuario", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@username", this.textBoxUsername.Text);
            comando.Parameters.AddWithValue("@password", this.textBoxPassConfirm.Text);
            comando.Parameters.AddWithValue("@nombre", afiliado.getNombre());
            comando.Parameters.AddWithValue("@apellido", afiliado.getApellido());
            comando.Parameters.AddWithValue("@tipoDoc", afiliado.getTipoDoc());
            comando.Parameters.AddWithValue("@nroDoc", afiliado.getNroDoc());
            comando.Parameters.AddWithValue("@direccion", afiliado.getDireccion());
            comando.Parameters.AddWithValue("@telefono", afiliado.getTelefono());
            comando.Parameters.AddWithValue("@fechaNacimiento", afiliado.getFechaNac());
            comando.Parameters.AddWithValue("@sexo", afiliado.getSexo());
            comando.Parameters.AddWithValue("@mail", this.textBoxMail.Text);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }

    }
}
