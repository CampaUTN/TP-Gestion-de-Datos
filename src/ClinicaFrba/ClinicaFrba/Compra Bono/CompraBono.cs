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
using System.Configuration;



namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {

        string userActivo;
        int rolActivo;
        int nroAfiliado;
        int plan;
        int precioPlan;

        public CompraBono(string userActivo, int rolActivo)  //Al crearse la pantalla, entra por aca y segun el rol que este entrando setea diferentes valores
        {
            InitializeComponent();
            this.userActivo = userActivo;
            this.rolActivo = rolActivo;


            if (rolActivo == 1) { //Afiliado
                this.nroAfiliado = Utilidades.Utils.getNumeroAfiliadoDesdeUsuario(userActivo); //El usuario que entro es el mismo afiliado, uso su usuario para buscar su numero de afiliado
                this.textAfiliado.Text = nroAfiliado.ToString();
                this.textAfiliado.ReadOnly = true; //Hago que no lo pueda cambiar
                this.botonSeleccionar.Enabled = false;

                this.plan = Utilidades.Utils.buscarPlanDeAfiliado(this.nroAfiliado); //Busco su plan con una query sin necesidad de SP
                this.precioPlan = Utilidades.Utils.buscarPrecioPlan(this.plan); //Idem pero para el precio del plan
                this.textPlan.Text = this.plan.ToString();
                this.textPrecioBono.Text = this.precioPlan.ToString();
            }
            else if (rolActivo == 2) //Administrativo
            {
                this.textAfiliado.Text = ""; //Limpio el text para que el administrador ingrese el afiliado
            }

            
        }

        private void labelCantidad_Click(object sender, EventArgs e)
        {

        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexion = DBConnection.getConnection()) //Se setea el 'autocompletador'
            {
                conexion.Open();
                AutoCompleteStringCollection numeroAfiliado = new AutoCompleteStringCollection();
                SqlCommand queryAfiliados = new SqlCommand("SELECT DISTINCT a.afil_id from GEDDES.Afiliados a, GEDDES.Usuarios u where a.afil_usuario=u.usua_id and usua_intentos<>0", conexion);
                SqlDataReader readerNombres = queryAfiliados.ExecuteReader();
                while (readerNombres.Read())
                {
                    numeroAfiliado.Add(readerNombres["afil_id"].ToString());
                }
                readerNombres.Close();
                textAfiliado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textAfiliado.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textAfiliado.AutoCompleteCustomSource = numeroAfiliado;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.textPrecioFinal.Text = (this.contadorBonos.Value * this.precioPlan).ToString(); //Cambia la cant de bonos y cambia automaticamente el precio final
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            if(this.textAfiliado.AutoCompleteCustomSource.Contains(this.textAfiliado.Text)){ //Chequeo si el afiliado existe
                this.nroAfiliado = Int32.Parse(this.textAfiliado.Text);
                this.plan = Utilidades.Utils.buscarPlanDeAfiliado(this.nroAfiliado);
                this.precioPlan = Utilidades.Utils.buscarPrecioPlan(this.plan);
                this.textPlan.Text = this.plan.ToString();
                this.textPrecioBono.Text = this.precioPlan.ToString();
                MessageBox.Show("Afiliado correcto");
            }
            if (this.plan == -1 || this.precioPlan == -1) //Control de si no se trajo bien el plan
            {
                MessageBox.Show("El afiliado ingresado no existe, intente nuevamente");
                this.textAfiliado.Text = "";
            }
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (this.textAfiliado.Text != "" && this.plan != -1 && this.textPlan.Text != "" && this.textAfiliado.AutoCompleteCustomSource.Contains(this.textAfiliado.Text)) //Controles que si existe el afiliado y se cargaron bien los datos antes de guardar los bonos
            {
                if (this.contadorBonos.Value > 0)
                {
                    SqlConnection conexion = DBConnection.getConnection();
                    DateTime fechaSistema = DateTime.ParseExact(ConfigurationManager.AppSettings["fecha"].ToString(), "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

                    string insertComprasBonos = "INSERT INTO GEDDES.ComprasBonos values (@afiliado, @cantidad, @precioFinal,@fechaCompra)";
                    SqlCommand comandoComprasBonos = new SqlCommand(insertComprasBonos, conexion);
                    comandoComprasBonos.Parameters.AddWithValue("@afiliado", this.nroAfiliado);
                    comandoComprasBonos.Parameters.AddWithValue("@cantidad", (int)this.contadorBonos.Value);
                    comandoComprasBonos.Parameters.AddWithValue("@precioFinal", (int)this.contadorBonos.Value * this.precioPlan);
                    comandoComprasBonos.Parameters.AddWithValue("@fechaCompra", fechaSistema);

                    conexion.Open();

                    for (int i = 0; i < (int)this.contadorBonos.Value; i++) //Hago un for desde 0 hasta la cantidad de bonos seleccionados
                    {
                        string insertBonos = "INSERT INTO GEDDES.BONOS (bono_afilCompra,bono_plan) values (@afiliado,@plan)";
                        SqlCommand comandoBonos = new SqlCommand(insertBonos, conexion);
                        comandoBonos.Parameters.AddWithValue("@afiliado", this.nroAfiliado);
                        comandoBonos.Parameters.AddWithValue("@plan", this.plan);
                        comandoBonos.ExecuteNonQuery();
                    }

                    comandoComprasBonos.ExecuteNonQuery();

                    MessageBox.Show("Compra realizada con exito");
                }
                else
                {
                    MessageBox.Show("Debe ingresar la cantidad de bonos que desea comprar");
                }
            }
            else{
                MessageBox.Show("Debe ingresar un Afiliado y que sea valido. Presione el boton Seleccionar Afiliado");
            }
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textAfiliado_TextChanged(object sender, EventArgs e)
        {
            //botonConfirmar.Enabled = textAfiliado.AutoCompleteCustomSource.Contains(textAfiliado.Text);
        }

        private void textAfiliado_LostFocus(object sender, EventArgs e)
        {
            this.plan = Utilidades.Utils.buscarPlanDeAfiliado(this.nroAfiliado);
            this.precioPlan = Utilidades.Utils.buscarPrecioPlan(this.plan);
            this.textPlan.Text = this.plan.ToString();
            this.textPrecioBono.Text = this.precioPlan.ToString();
        }


}
    }
