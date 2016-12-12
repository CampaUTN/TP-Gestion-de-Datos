using System;
using System.Configuration;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencion : Form
    {
        private long usuarioId;
        private int rol;
        private bool diaUnico = true;
        private String username;

        //constructor
        public CancelarAtencion(string usuario, int rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = usuario;
            this.usuarioId = Convert.ToInt64(Utilidades.Utils.getIdDesdeUserName(usuario).ToString());
            selecPlan.Hide();
            label7.Hide();
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
                button1.Hide();
            }
            if(!esAfiliado()){
                botonListar.Hide();
                label2.Hide();
                botonListar.Hide();
            }
            from.Enabled = false;
            to.Enabled = false;
            desde.Enabled = true;

            this.desde.MinDate = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            this.desde.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
           
            this.from.MinDate = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            this.from.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            
            this.to.MinDate = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);
            this.to.Value = System.DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).AddDays(1);

            textBox1.Text = "";
            this.label9.Text = "Observacion: No se pueden cancelar turnos del dia actual (" + ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length) + ")";
            this.listar();
        }

        private bool esAfiliado(){
            return rol == 1;
        }

        private bool esAdministrativo() {
            return rol == 2;
        }

        private bool esProfesional() {
            return rol == 3;
        }

        // Boton de borrar. Se encarga de hacer validaciones y llamar a los metodos para concretar las bajas.
        private void button2_Click(object sender, EventArgs e) {
            if (textBox1.Text=="") {
                MessageBox.Show("Complete el motivo.");
                return;
            }
            if (esAfiliado()) {
                if (grillaProfesionales.SelectedRows.Count >0 ) {
                    int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                    if (!grillaProfesionales.Rows[rowindex].Cells[5].Value.Equals("Si")) {
                        MessageBox.Show("No se puede cancelar turnos del dia de hoy.");
                        return;
                    }else{
                        Utilidades.Utils.bajaTurnoAfiliado(usuarioId, Convert.ToInt32(grillaProfesionales.Rows[rowindex].Cells[0].Value), 1, textBox1.Text);
                        MessageBox.Show("Turno cancelado correctamente.");
                    }
                }else {
                    MessageBox.Show("Seleccione una fila para cancelar el turno asociado a ella.");
                }
            } else {
                int profesional;
                if (!esProfesional()) {
                    int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                    if (grillaProfesionales.SelectedRows.Count <= 0) {
                        MessageBox.Show("Seleccione un profesional.");
                        return;
                    } else {
                        int rowindex2 = grillaProfesionales.CurrentCell.RowIndex;
                        profesional = Convert.ToInt32(grillaProfesionales.Rows[rowindex2].Cells[0].Value);
                    }
                } else { // es profesional
                    profesional = Utilidades.Utils.getNumeroProfesionalDesdeUsuario(usuarioId);
                }
                if(diaUnico) {
                    Utilidades.Utils.bajaDia(profesional, desde.Value.Date, 2, textBox1.Text);
                    MessageBox.Show("Todos los turnos del dia dados de baja correctamente.");
                } else {
                    DateTime aux = from.Value;
                    while(from.Value.Date <= to.Value.Date){
                        Utilidades.Utils.bajaDia(profesional, from.Value.Date, 2, textBox1.Text);
                        from.Value = from.Value.AddDays(1);
                    }
                    from.Value = aux;
                    MessageBox.Show("Todos los turnos del periodo dados de baja correctamente.");
                }
            }
            this.listar();
        }

        private void botonListar_Click(object sender, EventArgs e) {    
            this.label9.Text = "Observacion: No se pueden cancelar turnos del dia actual (" + ConfigurationManager.AppSettings["fecha"].ToString().Substring(0, "yyyy-MM-dd".Length) + ")";
            this.listar();
        }

        // actualiza la grilla
        private void listar() {
            if (esAfiliado()) {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getTurnos(usuarioId);
            } else {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionalesPosta(!esProfesional() ? "" : username);
                if (grillaProfesionales.Rows.Count > 0) {
                    grillaProfesionales.MultiSelect = false; //esto hace que no quede nada seleccionado.
                    grillaProfesionales.MultiSelect = true;
                    grillaProfesionales.Rows[0].Selected = true;
                }
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

        private void button1_Click(object sender, EventArgs e) {
            this.listar();
        }

        private void label10_Click(object sender, EventArgs e) {
        }
    }
}
