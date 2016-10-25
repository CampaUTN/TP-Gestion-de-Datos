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

                MessageBox.Show("Plan: " + this.plan + " Precio: " + this.precioPlan);
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
        }


    }
}
