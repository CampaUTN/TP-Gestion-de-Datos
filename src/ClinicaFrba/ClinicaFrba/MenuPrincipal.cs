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
    public partial class MenuPrincipal : Form
    {
        Dictionary<int, Func<Form>> frmsDisponibles;
        Form login_form;
        string userActivo;

        public MenuPrincipal(Form login_form, int role_code, string username)
        {
            InitializeComponent();
            this.login_form = login_form;
            this.userActivo = username;
            this.initialize_form_mapping();
            this.fill_list(role_code);
        }

        private void fill_list(int role_code)
        {
            var parametrosSP = new List<KeyValuePair<string, object>>();
            parametrosSP.Add(new KeyValuePair<string, object>("@role_id", role_code));
            var roles = new List<KeyValuePair<int, string>>();

            using (SqlConnection connection = DBConnection.getConnection())
            { 
                SqlCommand query = Utils.create_sp("CLINICA.FuncionalidadXRol", parametrosSP, connection);
                connection.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_fun"].ToString()), reader["descripcion"].ToString()));
            }
            Utils.populate(this.listBox1, roles);
            if (this.listBox1.Items.Count < 1)
            {
                this.button1.Enabled = false;
            }
        }

        private void initialize_form_mapping()
        {
            this.frmsDisponibles = new Dictionary<int, Func<Form>>();
            this.frmsDisponibles.Add(1, () => new Abm_Afiliado.Form1(this, this.username));
            this.frmsDisponibles.Add(2, () => new Abm_Especialidades_Medicas.Form1(this));
            this.frmsDisponibles.Add(3, () => new Abm_Planes.Form1(this));
            this.frmsDisponibles.Add(4, () => new Abm_Profesional.Form1(this));
            this.frmsDisponibles.Add(5, () => new Abm_Rol.Form1(this, this.username));
            this.frmsDisponibles.Add(6, () => new Cancelar_Atencion.Form1(this, this.username));
            this.frmsDisponibles.Add(7, () => new Compra_Bono.Form1(this, this.username));
            this.frmsDisponibles.Add(8, () => new Listados.Form1(this, this.username));
            this.frmsDisponibles.Add(9, () => new Pedir_Turno.Form1(this));
            this.frmsDisponibles.Add(10, () => new Registrar_Agenta_Medico.Form1(this));
            this.frmsDisponibles.Add(11, () => new Registro_Llegada.Form1(this, this.username));
            this.frmsDisponibles.Add(11, () => new Registro_Resultado.Form1(this, this.username));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.login_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_functionality_code = ((KeyValuePair<int, string>) this.listBox1.SelectedItem).Key;
            if (!this.frmsDisponibles.ContainsKey(selected_functionality_code))
                return;

            this.Hide();
            (this.frmsDisponibles[selected_functionality_code])().Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
}
