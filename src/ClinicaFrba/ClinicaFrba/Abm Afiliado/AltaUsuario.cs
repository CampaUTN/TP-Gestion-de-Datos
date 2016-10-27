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
                this.agregarNuevosDatos();
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

            comando.Parameters.AddWithValue("@username", afiliado.getUsername());
            comando.Parameters.AddWithValue("@password", afiliado.getPassword());
            comando.Parameters.AddWithValue("@nombre", afiliado.getNombre());
            comando.Parameters.AddWithValue("@apellido", afiliado.getApellido());
            comando.Parameters.AddWithValue("@tipoDoc", afiliado.getTipoDoc());
            comando.Parameters.AddWithValue("@nroDoc", afiliado.getNroDoc());
            comando.Parameters.AddWithValue("@direccion", afiliado.getDireccion());
            comando.Parameters.AddWithValue("@telefono", afiliado.getTelefono());
            comando.Parameters.AddWithValue("@fechaNacimiento", afiliado.getFechaNac());
            comando.Parameters.AddWithValue("@sexo", afiliado.getSexo());
            comando.Parameters.AddWithValue("@mail", afiliado.getMail());

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }

        private void agregarNuevosDatos(){
            afiliado.setUsername(this.textBoxUsername.Text);
            afiliado.setPassword(this.textBoxPassConfirm.Text);
            afiliado.setMail(this.textBoxMail.Text);
        }

        private void registrarAfiliado(Afiliado afiliado)
        {
            int codPlan;
            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("CLINICA.ingresarAfiliado", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //TODO: Ver si lo puedo retornar desde el SP, cuando registro al usuario
            codPlan = Utilidades.Utils.getIdDesdePlan(afiliado.getPlan());

            comando.Parameters.AddWithValue("@plan", codPlan);
            comando.Parameters.AddWithValue("@estado_civil", afiliado.getEstadoCivil());


            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
        }


    }
}
