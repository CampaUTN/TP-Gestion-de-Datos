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

        private void agregarALista(Parametro[] parametros, TextBox textbox)
        {
            int longitud = parametros.Length;
            if (textbox.Text.Length != 0)
            {
            }
        }


        private void botonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private bool camposVacios()
        {
            return Parser.estaVacio(usua_nombre) && Parser.estaVacio(usua_nroDoc) && Parser.estaVacio(usua_apellido);
        }

        private void planillaResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonModificar.Enabled = true;
        }
    }
}
