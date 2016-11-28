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
        string consulta = "SELECT* FROM GEDDES.Bonos WHERE bono_afilUsado IS NULL AND bono_afilCompra IN ";

        string select = "SELECT afil_id ";
        string from = "FROM GEDDES.Afiliados ";
        string where = "WHERE ((afil_id - CONVERT(INT,RIGHT (STR(afil_id),2)) )/ 100 ) IN ";

        string subselect = "SELECT TOP 1 (a1.afil_id - CONVERT(INT,RIGHT (STR(a1.afil_id),2)) )/ 100 FROM GEDDES.Afiliados a1 WHERE a1.afil_id = ";

        int nroAfiliado;
        int nroTurno;

        public RegistroBono(string id, int turno)
        {
            InitializeComponent();

            this.nroTurno = turno;

            int.TryParse(id, out nroAfiliado);

            DBConnection.cargarPlanilla(listaBonos, consulta + "(" + select + from + where + "(" + subselect + id + ")" + ")" );
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void verAfil_Click(object sender, EventArgs e)
        {

            int nroBono = Convert.ToInt32(listaBonos.SelectedCells[0].Value);

            Utils.registrarConsulta(nroTurno, nroBono, nroAfiliado);
            MessageBox.Show("Llegada a la consulta efectuada");
            this.Close();
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
