using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class RegistroResultado : Form
    {
        string select = "SELECT cons_id AS Consulta, hora_inicio AS Hora, ";
        string subselect = "(SELECT (usua_nombre + ' ' + usua_apellido) FROM GEDDES.Afiliados, GEDDES.Usuarios WHERE afil_id = turn_afiliado AND afil_usuario = usua_id) AS Afiliado ";
        string from = "FROM GEDDES.Turnos ,GEDDES.Horarios , GEDDES.Consultas ";
        string where = "WHERE cons_turno = turn_id AND turn_hora = hora_id" + " AND hora_fecha = " + Utils.fechaSistemaBD() + " AND cons_fueConcretada IS NULL AND hora_profesional = ";

        bool realizada;
        int consulta;

        public RegistroResultado(string userActivo)
        {
            InitializeComponent();

            int user = Utils.obtenerProfesionalDesdeUsername(userActivo);

            where = where + (Convert.ToString(user));
           
            this.cargarPlanilla();
            listadoConsultas.ClearSelection();
        }

        private void listadoConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxDiagnostico.ResetText();
            textBoxSintomas.ResetText();
            textBoxSintomas.Enabled = true;
            textBoxDiagnostico.Enabled = true;
            checkBoxFueConcretada.Enabled = true;
            checkBoxFueConcretada.Checked = false;

            botonAceptar.Enabled = true;

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (textBoxDiagnostico.Text.Length.Equals(0) || textBoxSintomas.Text.Length.Equals(0))
            {
                MessageBox.Show("Debe completar los resultados de la consulta", "Consulta", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Confirmar datos?", "Consulta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cargarDatos();
                    this.resetearCajitas();
                    this.cargarPlanilla();
                    listadoConsultas.ClearSelection();
                }
            }
        }

        private void textBoxDiagnostico_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void resetearCajitas()
        {
            textBoxDiagnostico.ResetText();
            textBoxSintomas.ResetText();
            textBoxSintomas.Enabled = false;
            textBoxDiagnostico.Enabled = false;
            checkBoxFueConcretada.Enabled = false;
            checkBoxFueConcretada.Checked = false;
            listadoConsultas.ClearSelection();
        }

        private void RegistroResultado_Load(object sender, EventArgs e)
        {
            listadoConsultas.ClearSelection();
        }

        private void cargarPlanilla()
        {
            DBConnection.cargarPlanilla(listadoConsultas, select + subselect + from + where);
        }

        private void cargarDatos()
        {
            if (listadoConsultas.SelectedCells.Count>0) {
                   consulta = Convert.ToInt32(listadoConsultas.SelectedCells[0].Value);
                   Utils.registrarResultadoConsulta(consulta, checkBoxFueConcretada.Checked, textBoxSintomas.Text, textBoxDiagnostico.Text);
                   MessageBox.Show("Consulta realizada");
            }else {
                    MessageBox.Show("Seleccione una fila.");
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxDiagnostico.ResetText();
            textBoxSintomas.ResetText();

            checkBoxFueConcretada.Checked = false;
        }

        private void listadoConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelSelecConsulta_Click(object sender, EventArgs e) {

        }

     }
}
