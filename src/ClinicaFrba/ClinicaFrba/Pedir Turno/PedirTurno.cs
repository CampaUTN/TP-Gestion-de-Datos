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
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
        }

        private void botonListar_Click(object sender, EventArgs e)
        {
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionalesDeEspecialidad(this.textEspecialidad.Text);
        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            new SeleccionarHorario(this.userActivo, this.grillaProfesionales.CurrentCell.Value.ToString()); //Id prof + que selecciono
        
            if (grillaProfesionales.SelectedCells.Count > 0)
            {    
                int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                string profesional = grillaProfesionales.Rows[rowindex].Cells[0].Value.ToString();
                new SeleccionarHorario(this.userActivo, profesional);
            }
        }

    }
}




//private void dgvProfesionales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
//        {
//            if (dgvProfesionales.CurrentCell.ColumnIndex == 0)
//            {
//                string codigo_profesional = dgvProfesionales.CurrentCell.Value.ToString();
//                frmTurnosxProf turnosDisponibles = new frmTurnosxProf(codigo_profesional, esp, nro_afiliado);
//                turnosDisponibles.Show();
//                this.Hide();
//            }
//            else
//            {
//                MessageBox.Show("Haga click sobre el codigo del profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//        }

//        private void dgvEspecialidades_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
//        {
//            if (dgvEspecialidades.CurrentCell.ColumnIndex == 0)
//            {
//                string codigo_especialidad = dgvEspecialidades.CurrentCell.Value.ToString();
//                List<Profesional> profesionalesFiltrados = null;
//                var parametros = new Dictionary<string, object>() {
//                    { "@especialidad", codigo_especialidad}
//                };

//                esp = codigo_especialidad;

//                try
//                {
//                    profesionalesFiltrados = DBHelper.ExecuteReader("profesional_GetByFilerEspecialidad", parametros).ToProfesional2();
//                }
//                catch
//                {
//                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                btnVolver.Visible = true;
//                LoadProfesionales(profesionalesFiltrados);
//                dgvProfesionales.Visible = true;
//                labelProfesional.Visible = true;
//                this.Width = 575;
//                dgvEspecialidades.Visible = false;
//                labelEspecialidad.Visible = false;
//                button1.Visible = false;
//                label2.Visible = false;
//                textEspecialidad.Visible = false;
//                filtrarEspecialidades.Visible = false;
//            }
//            else 
//            {
//                MessageBox.Show("Haga click sobre el codigo de la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//        }
