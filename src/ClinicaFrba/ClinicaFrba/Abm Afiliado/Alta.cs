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

        public Alta()
        {
            InitializeComponent();

            Utilidades.Utils.llenar(this.selecPlan, this.getPlanes());
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
            //verificar que se hayan completado los datos
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

    }

}
