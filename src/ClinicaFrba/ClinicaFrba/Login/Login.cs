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

namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){

            //Valido que el usuario haya completado las cajitas
            if (faltaCompletar()){
                MessageBox.Show("Datos incompletos! Complete los datos e intentelo de nuevo.", "Error de Login");
                this.textContrasenia.Clear();
            }
            else {
                //comienzo las validaciones de contraseña y asignacion del menu segun los roles
                conectar();
               
            }          
        }
        
        //verifico la contrasenia
        private void chequearPassWord(SqlDataReader reader, List<KeyValuePair<int, string>> rolesAsignados)
        {
            while (reader.Read())
            {
                if (!(bool)reader["login_valido"]){

                    string message;
                    if ((bool)reader["habilitado"])
                        message = "La contraseña es incorrecta. Tiene " + (3 - (Int32.Parse(reader["intentos"].ToString()))) + " intentos restantes";
                    else
                        message = "El usuario ha sido bloqueado";

                    MessageBox.Show(message, "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                }
                else{
                    rolesAsignados.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_rol"].ToString()),//TODO Mejorar nombres
                                                                         reader["nombre"].ToString()));
                }
            }
        }

        //le muestro al usuario la ventanita segun los roles
        private void dividir(List<KeyValuePair<int, string>> rolesAsignados)
        {
            if (rolesAsignados.Count > 0)
                this.Hide();
            if (rolesAsignados.Count == 1)
                (new MenuPrincipal(this, Int32.Parse(rolesAsignados[0].Key.ToString()), this.textUsuario.Text)).Show();
            if (rolesAsignados.Count > 1)
                (new EleccionRol(this, this.textUsuario.Text, rolesAsignados)).Show();
        }

        private bool faltaCompletar(){
            return this.textContrasenia.Text.Length == 0 || this.textUsuario.Text.Length == 0;

        }


        private void conectar() {

            var conexion = DBConnection.getConnection();

            SqlCommand comando = new SqlCommand("CLINICA.Login_procedure", conexion);
            
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@username", this.textUsuario.Text);
            comando.Parameters.AddWithValue("@password", this.textContrasenia.Text);

            SqlParameter retval = new SqlParameter("@cantidad", SqlDbType.Int);

            retval.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(retval);
            conexion.Open();
           
            SqlDataReader reader = comando.ExecuteReader();

            List<KeyValuePair<int, string>> rolesAsignados = new List<KeyValuePair<int, string>>();

          int cantidadIntentos = (int)comando.Parameters["@cantidad"].Value;

          switch (cantidadIntentos)
          {
              case -1:
                  MessageBox.Show("No existe el usuario '" + this.textUsuario.Text + "' en el sistema. Intente con otro nombre", "Error de Login", MessageBoxButtons.OK);
                  break;
              case 0:
                  MessageBox.Show("Ha ingresado 3 veces la contraseña incorrecta. El usuario ha sido bloqueado", "Error de Login", MessageBoxButtons.OK);
                  break;
              case 1: case 2: case 3:
                  MessageBox.Show("La contraseña es incorrecta. Intentelo de nuevo", "Error de Login", MessageBoxButtons.OK);
                  break;
              default:
                  MessageBox.Show("Bienvenido!");

                  //TODO 1- Falla cuando ingreso la contraseña correcta :(
                  //     2 - Aca debo consultar los roles y luego asignarselo
                  break;
          }
            reader.Close();
            conexion.Close();

            this.dividir(rolesAsignados);

            this.textContrasenia.Clear();
            
        }

    }
}
