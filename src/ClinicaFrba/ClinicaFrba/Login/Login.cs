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

        private void button1_Click(object sender, EventArgs e)
        {
            if (faltaCompletar()){
                MessageBox.Show("Datos incompletos! Complete los datos e intentelo de nuevo.");
            }
            else {

                var conexion = DBConnection.getConnection();

                SqlCommand comando = new SqlCommand("spLogin", conexion);
                
                /* Tiene que ser un SP creado en el script que verifique del lado del motor la cantidad de intentos */
                comando.CommandType = CommandType.StoredProcedure;
                /* Aca van los parametros del SP, lo comento porque no se bien que mas va a necesitar
                 * comando.Parameters.Add(new SqlParameter("@usuario",this.textUsuario.Text));
                 * comando.Parameters.Add(new SqlParameter("@contrasenia",this.textContrasenia.Text));
                 */


                /* CON ESTO SE PUEDE VERIFICAR SI EL USUARIO ESTA O NO. FUNCA LA VERIFICACION, PERO NO EL RESTO
                 *SqlCommand comando = new SqlCommand("SELECT usua_username FROM CLINICA.Usuarios WHERE usua_username = @usuario", conexion);
                 *comando.Parameters.Add(new SqlParameter("@usuario", this.textUsuario.Text));
                 * 
                 */

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                List<KeyValuePair<int, string>> rolesAsignados = new List<KeyValuePair<int, string>>();

                if (!reader.HasRows){

                    MessageBox.Show("No existe el usuario '" + this.textUsuario.Text + "' en el sistema", "Error de Login", MessageBoxButtons.OK);
                }
                else{

                    chequearPassWord(reader, rolesAsignados);
                }
                
                reader.Close();
                conexion.Close();

                this.dividir(rolesAsignados);

                this.textContrasenia.Clear();
            }          
        }
        
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


        private void dividir(List<KeyValuePair<int, string>> rolesAsignados)
        {
            if (rolesAsignados.Count > 0)
                this.Hide();
            if (rolesAsignados.Count == 1)
                (new MenuPrincipal(this, Int32.Parse(rolesAsignados[0].Key.ToString()), this.textUsuario.Text)).Show();
            if (rolesAsignados.Count > 1)
                (new EleccionRol(this, this.textUsuario.Text, rolesAsignados)).Show();
        }

        private bool faltaCompletar()
        {
            return this.textContrasenia.Text.Length == 0 || this.textUsuario.Text.Length == 0;

        }

    }
}
