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

namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    public partial class ListadoAfiliados : Form, FormularioABM
    {
        public ListadoAfiliados()
        {
            InitializeComponent();
           // conexion = new Connection();
        }
        
      #region METODOS QUE SE ACTIVAN CUANDO SE ACCIONA UN BOTON O CAMBIA UN VALOR
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            usua_nombre.Clear();
            usua_apellido.Clear();
            usua_nroDoc.Clear();

            botonModificar.Enabled = false;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            Parametro[] parametros = new Parametro[3];
            string consulta;
            bool esExacta;

            botonModificar.Enabled = false;
            if (camposVacios())
            {
                consulta = "SELECT usua_id, usua_apellido, usua_nombre, usua_nroDoc FROM CLINICA.Usuarios";
            }
            else
            {
                esExacta = checkBoxNombre.Checked;

                parametros.SetValue(new Parametro(usua_nombre, esExacta), 0);

                esExacta = checkBoxApellido.Checked;

                parametros.SetValue(new Parametro(usua_apellido, esExacta), 1);

                esExacta = checkBoxDoc.Checked;

                parametros.SetValue(new Parametro(usua_nroDoc, esExacta), 2);

                consulta = Parser.armarConsulta("Usuarios", parametros); 

            }

            DBConnection.cargarPlanilla(planillaResultados, consulta);  
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void planillaResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonModificar.Enabled = true;
        }


        private void botonModificar_Click(object sender, EventArgs e)
        {
            this.cargarAlAfiliado();
        }

        #endregion


        #region METODOS AUXILIARES
        private void agregarALista(Parametro[] parametros, TextBox textbox)
        {
            int longitud = parametros.Length;
            if (textbox.Text.Length != 0)
            {
            }
        }

        private bool camposVacios()
        {
            return Parser.estaVacio(usua_nombre) && Parser.estaVacio(usua_nroDoc) && Parser.estaVacio(usua_apellido);
        }

        private void cargarAlAfiliado()
        {            string nombre = Convert.ToString(planillaResultados.SelectedCells[2].Value);
            string apellido = Convert.ToString(planillaResultados.SelectedCells[1].Value);
            string dni = Convert.ToString(planillaResultados.SelectedCells[3].Value);
           
            Afiliado afil = new Afiliado(nombre, apellido,
             DateTime.Parse("27/11/1995 00:00:00"), "DNI", dni, "Strangford 1857", "46220932", "M", "Soltero/a", "asdas");
            ModificacionUsuario modif = new ModificacionUsuario(afil);


            modif.Show();
        }


        #endregion

       
    }
}
