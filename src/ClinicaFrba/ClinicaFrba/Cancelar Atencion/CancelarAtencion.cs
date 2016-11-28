using System;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencion : Form
    {
        private long usuario;
        private int rol;
        private bool diaUnico = true;

        //constructor
        public CancelarAtencion(string usuario, int rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.usuario = Convert.ToInt64(Utilidades.Utils.getIdDesdeUserName(usuario).ToString());
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
                label8.Hide();
            }
            if(!esAfiliado()){
                grillaProfesionales.Hide();
                botonListar.Hide();
                label2.Hide();
            }
            from.Enabled = false;
            to.Enabled = false;
            desde.Enabled = true;
        }

        private bool esAfiliado(){
            return rol == 1;
        }

        private bool esAdministrativo() {
            return rol == 2;
        }

        // Boton de borrar. Se encarga de hacer validaciones y llamar a los metodos para concretar las bajas.
        private void button2_Click(object sender, EventArgs e) {
            if (selecPlan.SelectedIndex<0) {
                MessageBox.Show("Seleccione un tipo.");
                return;
            }
            if (esAfiliado()) {
                if (grillaProfesionales.SelectedRows.Count >0 ) {
                    int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                    if (grillaProfesionales.Rows[rowindex].Cells[5].Value.Equals("No")) {
                        MessageBox.Show("No se puede cancelar turnos del dia de hoy.");
                        return;
                    }else{
                        Utilidades.Utils.bajaTurnoAfiliado(usuario, Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[0].Value), selecPlan.SelectedIndex+1, textBox1.Text);
                        MessageBox.Show("Turno cancelado correctamente.");
                    }
                }else {
                    MessageBox.Show("Seleccione una fila para cancelar el turno asociado a ella.");
                }
            } else {
                long profesional = usuario;
                if(diaUnico) {
                    Utilidades.Utils.bajaDia(usuario, desde.Value.Date, selecPlan.SelectedIndex, textBox1.Text);
                    MessageBox.Show("Todos los turnos del dia dados de baja correctamente.");
                } else {
                    DateTime aux = from.Value;
                    while(from.Value.Date <= to.Value.Date){
                        Utilidades.Utils.bajaDia(profesional, from.Value.Date, selecPlan.SelectedIndex, textBox1.Text);
                        from.Value = from.Value.AddDays(1);
                    }
                    from.Value = aux;
                    MessageBox.Show("Todos los turnos del periodo dados de baja correctamente.");
                }
            }
            this.listar();
        }

        private void botonListar_Click(object sender, EventArgs e) {
            this.listar();
        }

        // actualiza la grilla
        private void listar() {
            if (esAfiliado()) {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getTurnos(usuario);
            } else {
                //this.grillaProfesionales.DataSource = Utilidades.Utils.getAgenda(usuario);
            }
        }

        private void CancelarAtencion_Load(object sender, EventArgs e) {}

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void desde_ValueChanged(object sender, EventArgs e) {}

        private void from_ValueChanged(object sender, EventArgs e) {
            desde.SuspendLayout();
        }

        private void to_ValueChanged(object sender, EventArgs e) {}

        //deshabilita lo de seleccion por periodo y habilita lo de seleccion por dia
        private void selecDia_CheckedChanged(object sender, EventArgs e) {
            from.Enabled = false;
            to.Enabled = false;

            desde.Enabled = true;
            diaUnico = true;
        }

        //habilita lo de seleccion por periodo y deshabilita lo de seleccion por dia
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

        private void label6_Click(object sender, EventArgs e) {

        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void selecPlan_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void botonSalir_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label8_Click(object sender, EventArgs e) {

        }
    }
}
