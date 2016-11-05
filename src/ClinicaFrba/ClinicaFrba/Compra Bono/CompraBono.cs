using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {

        string userActivo;
        int rolActivo;
        int nroAfiliado;
        int plan;
        int precioPlan;

        public CompraBono(string userActivo, int rolActivo)
        {
            InitializeComponent();
            this.userActivo = userActivo;
            this.rolActivo = rolActivo;


            if (rolActivo == 1) { //Afiliado
                this.nroAfiliado = Utilidades.Utils.getNumeroAfiliadoDesdeUsuario(userActivo);
                this.textAfiliado.Text = nroAfiliado.ToString();
                this.textAfiliado.ReadOnly = true;
                this.botonSeleccionar.Visible = false;

                this.plan = Utilidades.Utils.buscarPlanDeAfiliado(this.nroAfiliado);
                this.precioPlan = Utilidades.Utils.buscarPrecioPlan(this.plan);
                this.textPlan.Text = this.plan.ToString();
                this.textPrecioBono.Text = this.precioPlan.ToString();
            }
            else if (rolActivo == 2) //Administrativo
            {
                this.textAfiliado.Text = "";
            }

            
        }

        private void labelCantidad_Click(object sender, EventArgs e)
        {

        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.textPrecioFinal.Text = (this.contadorBonos.Value * this.precioPlan).ToString();
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            this.nroAfiliado = Int32.Parse(this.textAfiliado.Text);
            this.plan = Utilidades.Utils.buscarPlanDeAfiliado(this.nroAfiliado);
            this.precioPlan = Utilidades.Utils.buscarPrecioPlan(this.plan);
            this.textPlan.Text = this.plan.ToString();
            this.textPrecioBono.Text = this.precioPlan.ToString();

            if (this.plan == -1 || this.precioPlan == -1)
            {
                MessageBox.Show("El afiliado ingresado no existe, intente nuevamente");
                this.textAfiliado.Text = "";
            }
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if(this.textAfiliado.Text!="" && this.plan!=-1){
                if (this.contadorBonos.Value > 0)
                {
                    SqlConnection conexion = DBConnection.getConnection();

                    string insert = "INSERT INTO CLINICA.ComprasBonos values (@afiliado, @cantidad, @precioFinal,@fechaCompra)";
                    SqlCommand comando = new SqlCommand(insert, conexion);
                    comando.Parameters.AddWithValue("@afiliado", this.nroAfiliado);
                    comando.Parameters.AddWithValue("@cantidad", (int)this.contadorBonos.Value);
                    comando.Parameters.AddWithValue("@precioFinal", (int)this.contadorBonos.Value * this.precioPlan);
                    comando.Parameters.AddWithValue("@fechaCompra", DateTime.Now);

                    conexion.Open();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Compra realizada con exito");
                }
                else
                {
                    MessageBox.Show("Debe ingresar la cantidad de bonos que desea comprar");
                }
            }
            else{
                MessageBox.Show("Debe ingresar un Afiliado y que sea valido");
            }
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textAfiliado_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
