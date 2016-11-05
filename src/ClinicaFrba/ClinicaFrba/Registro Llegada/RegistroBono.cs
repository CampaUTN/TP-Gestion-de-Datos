using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroBono : Form
    {
        string consulta = "SELECT* FROM CLINICA.Bonos WHERE bono_afilUsado IS NULL AND bono_afilCompra =";

        public RegistroBono(string id)
        {
            InitializeComponent();

            consulta = consulta + id;
            DBConnection.cargarPlanilla(listaBonos,
                  "SELECT* FROM CLINICA.Bonos WHERE bono_afilUsado IS NULL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void verAfil_Click(object sender, EventArgs e)
        {
               }
    }
}
