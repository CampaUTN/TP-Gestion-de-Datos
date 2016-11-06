using ClinicaFrba.Utilidades;
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

        int nroAfiliado;
        int nroTurno;

        public RegistroBono(string id, int turno)
        {
            InitializeComponent();

            this.nroTurno = turno;

            int.TryParse(id, out nroAfiliado);

            consulta = consulta + id;
            DBConnection.cargarPlanilla(listaBonos,
                  "SELECT* FROM CLINICA.Bonos WHERE bono_afilUsado IS NULL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void verAfil_Click(object sender, EventArgs e)
        {

            int nroBono = Convert.ToInt32(listaBonos.SelectedCells[0].Value);

            Utils.registrarConsulta(nroTurno, nroBono, nroAfiliado);
            MessageBox.Show("Llegada a la consulta efectuada");


        }

        private void listaBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonSelecBono.Enabled = true;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
