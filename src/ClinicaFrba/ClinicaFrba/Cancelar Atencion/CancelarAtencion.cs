using System;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencion : Form
    {
        private int usuario;
        private int rol;
        private bool diaUnico = true;

        public CancelarAtencion(string usuario, int rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.usuario = Convert.ToInt32(Utilidades.Utils.getIdDesdeUserName(usuario).ToString());
            if (esAfiliado()) {
                desde.Hide();
                from.Hide();
                to.Hide();
                selecDia.Hide();
                selecPeriodo.Hide();
                label1.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
            }
            from.Enabled = false;
            to.Enabled = false;
            desde.Enabled = true;
        }

        private bool esAfiliado(){
            return rol == 1;
        }

        // Boton de borrar
        private void button2_Click(object sender, EventArgs e) {
            if (esAfiliado()) {
                if (grillaProfesionales.SelectedRows.Count >0 ) {
                    int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                    Utilidades.Utils.bajaTurnoAfiliado(usuario, Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[0].Value));
                    MessageBox.Show("Turno cancelado correctamente.");
                }else {
                    MessageBox.Show("Seleccione un turno a cancelar.");
                }
            } else {
                if(diaUnico) {
                    Utilidades.Utils.bajaDia(usuario, desde.Value.Date);
                    MessageBox.Show("Dia dado de baja correctamente.");
                } else {
                    while(from.Value.Date <= to.Value.Date){
                        Utilidades.Utils.bajaDia(usuario, from.Value.Date);
                        from.Value = from.Value.AddDays(1);
                    }
                    MessageBox.Show("Periodo dado de baja correctamente.");
                }
            }
            this.listar();
        }

        private void botonListar_Click(object sender, EventArgs e) {
            this.listar();
        }

        private void listar() {
            if (esAfiliado()) {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getTurnos(usuario);
            } else {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getAgenda(usuario);
            }
        }

        private void CancelarAtencion_Load(object sender, EventArgs e) {}

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void desde_ValueChanged(object sender, EventArgs e) {}

        private void from_ValueChanged(object sender, EventArgs e) {
            desde.SuspendLayout();
        }

        private void to_ValueChanged(object sender, EventArgs e) {}

        private void selecDia_CheckedChanged(object sender, EventArgs e) {
            from.Enabled = false;
            to.Enabled = false;

            desde.Enabled = true;
            diaUnico = true;
        }

        private void selecPeriodo_CheckedChanged(object sender, EventArgs e) {
            desde.Enabled = false; ;

            from.Enabled = true; ;
            to.Enabled = true; ;
            diaUnico = false;
        }

        private void label1_Click(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e) {}

        private void label4_Click(object sender, EventArgs e) {}

        private void label5_Click(object sender, EventArgs e) {}

        private void botonAtras_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
