using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        string userActivo;

        public PedirTurno(string userActivo)
        {
            InitializeComponent();
            this.userActivo = userActivo;
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
        }

        private void botonListar_Click(object sender, EventArgs e)
        {
            if (this.textEspecialidad.Text != "")
            {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionalesDeEspecialidad(this.textEspecialidad.Text);
            }
            else
            {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();

            }
        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        
       
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            if (grillaProfesionales.SelectedCells.Count > 0)
            {
                int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                string profesional = grillaProfesionales.Rows[rowindex].Cells[0].Value.ToString();
                new SeleccionarHorario(this.userActivo, profesional).Show();
            }

            
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}