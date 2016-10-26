using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Alta : Form, FormularioABM
    {
        string sexo;
        private AbmAfiliado formulario;
        private List<TextBox> cajasTexto;


        public Alta()
        {
            this.cajasTexto = new List<TextBox>();

            InitializeComponent();

            Utilidades.Utils.llenar(this.selecPlan, this.getPlanes());

            this.cajasTexto.Add(textBoxNombre);
            this.cajasTexto.Add(textBoxApellido);
            this.cajasTexto.Add(textBoxNroDoc);
            this.cajasTexto.Add(textBoxDireccion);
            this.cajasTexto.Add(textBoxTelefono);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
        }

        private void selecFem_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "F";
        }

        private void selecMasc_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "M";
        }


        private List<KeyValuePair<int, string>> getPlanes()
        {
            var conexion = DBConnection.getConnection();
            List<KeyValuePair<int, string>> planes = new List<KeyValuePair<int, string>>();

            SqlCommand comando = new SqlCommand("CLINICA.getPlanes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                planes.Add(new KeyValuePair<int, string>(Int32.Parse(reader["plan_id"].ToString()),
                                                                    reader["plan_nombre"].ToString()));
            }

            return planes;
        }

        private void selecPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            foreach(TextBox cajita in cajasTexto){
                cajita.Clear();
            }

            this.checkBoxHijos.CheckState = CheckState.Unchecked;
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            
        }

        private void selecEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int estado = selecEstadoCivil.SelectedIndex;
            if (estado.Equals(1) || estado.Equals(3))
            {
                this.botonAgregarFamiliar.Enabled = true;
            }
            else
            {
                this.botonAgregarFamiliar.Enabled = false;
            }

            /*
             * 0- Soltero/a
               1- Casado/a
               2- Viudo/a
               3- Concubinato
               4- Divorciado/a
             */
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Esta seguro que desea cancelar?", "Cancelar",MessageBoxButtons.YesNo);
        }

        private void checkBoxHijos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHijos.Checked)
            {
                this.botonAfiliarFamiliar.Enabled = true;
                this.textBoxCantHijos.Enabled = true;
                this.cajasTexto.Add(textBoxCantHijos);
            }
            else
            {
                this.botonAfiliarFamiliar.Enabled = false;
                this.textBoxCantHijos.Enabled = false;
                this.cajasTexto.Remove(textBoxCantHijos);
            }

        }

        private void botonAgregarFamiliar_Click(object sender, EventArgs e)
        {
            if (cajasTexto.Any(cajita => cajita.Text.Length.Equals(0)))
            {
                MessageBox.Show("Debe completar los datos del afiliado\nprincipal para poder continuar", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                //aca agrego a los conyuges
            }
        }

        private void botonAfiliarFamiliar_Click(object sender, EventArgs e)
        {
            if (cajasTexto.Any(cajita => cajita.Text.Length.Equals(0)))
            {
                MessageBox.Show("Debe completar los datos del afiliado\nprincipal para poder continuar", "Aviso", MessageBoxButtons.OK);
            }
            else
            {
                //aca agrego a los familiares a cargo
            }
        }

  
    }

}
