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
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxNroDoc.Clear();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DBConnection.cargarPlanilla(dataGridView1, "SELECT usua_id, usua_apellido, usua_nombre, usua_nroDoc FROM CLINICA.Usuarios");
        }
    }
}
