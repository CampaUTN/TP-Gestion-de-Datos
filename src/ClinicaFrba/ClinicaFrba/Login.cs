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
            var conexion = DBConnection.getInstance().getConnection();

            SqlCommand comando = new SqlCommand("CLINICA.spLogin", conexion);
            /* Tiene que ser un SP creado en el script que verifique del lado del motor la cantidad de intentos */
            comando.CommandType = CommandType.StoredProcedure;
            /* Aca van los parametros del SP, lo comento porque no se bien que mas va a necesitar
             * comando.Parameters.Add(new SqlParameter("@usuario",this.textUsuario.Text));
             * comando.Parameters.Add(new SqlParameter("@contrasenia",this.textContrasenia.Text));
             */
            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();
            // List key value?
            if (!reader.HasRows){
                MessageBox.Show("No existe el usuario '" + this.textUsuario + "' en el sistema", "Error de Login", MessageBoxButtons.OK);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
