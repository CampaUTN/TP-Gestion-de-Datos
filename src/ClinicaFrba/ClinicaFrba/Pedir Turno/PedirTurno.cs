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


namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        string userActivo;
        int rolActivo;
        int nroAfiliado = 0;
        public PedirTurno(string userActivo, int rolActivo) 
        {
            InitializeComponent();
            this.userActivo = userActivo;
            this.rolActivo = rolActivo;
            this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();
            this.grillaProfesionales.ReadOnly = true;

            if (rolActivo == 1) //Si el usuario entro en modo Afiliado se setea directamente el numero de afiliado sin posibilidad de cambiarlo
            { //Afiliado
                this.nroAfiliado = Utilidades.Utils.getNumeroAfiliadoDesdeUsuario(userActivo);
                this.textAfiliado.Text = nroAfiliado.ToString();
                this.textAfiliado.ReadOnly = true;
                this.botonSeleccionar.Enabled = true;
            }
            else if (rolActivo == 2) //Administrativo
            {
                this.textAfiliado.Text = "";
            }
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexion = DBConnection.getConnection()) //Se setea el autocompletador de afiliado
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

        private void botonListar_Click(object sender, EventArgs e)
        {
            if (this.textEspecialidad.Text != "") //Busco por filtro de especialidad
            {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionalesDeEspecialidad(this.textEspecialidad.Text);
            }
            else //Si no se escribio ningun filtro, se buscan todos los profesionales
            {
                this.grillaProfesionales.DataSource = Utilidades.Utils.getProfesionales();

            }
        }

        private void grillaProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        
       
        }

        private void botonSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.nroAfiliado != 0)
            {
                if (grillaProfesionales.SelectedCells.Count > 0) //Controlo que se haya seleccionado un valor y que tambien este seteado el afiliado
                {
                    int rowindex = grillaProfesionales.CurrentCell.RowIndex;
                    string profesional = grillaProfesionales.Rows[rowindex].Cells[0].Value.ToString(); //Esto me permite que pueda seleccionar cualquier columna de la fila y tome el valor de la fila completa
                    string especialidad = grillaProfesionales.Rows[rowindex].Cells[3].Value.ToString();
                    new SeleccionarHorario(this.nroAfiliado, profesional,especialidad).Show();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un afiliado valido o presione el boton Seleccionar Afiliado");
            }
            
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonSelecAfil_Click(object sender, EventArgs e)
        {
            if (this.textAfiliado.AutoCompleteCustomSource.Contains(this.textAfiliado.Text)) //Busco la informacion del afiliado seteado en el text
            {
                this.nroAfiliado = Int32.Parse(this.textAfiliado.Text);
                MessageBox.Show("Afiliado correcto");
            }
            else
            {
                MessageBox.Show("Ingrese un afiliado valido");
            }

        }

        private void textAfiliado_TextChanged(object sender, EventArgs e)
        {
            if (this.rolActivo == 2) //Evito que si no toma uno de la autosugerencia pueda seleccionar un porfesional ya que implica que no existe el afiliado
            {
                botonSeleccionar.Enabled = textAfiliado.AutoCompleteCustomSource.Contains(textAfiliado.Text);
            }
        }

    }
}