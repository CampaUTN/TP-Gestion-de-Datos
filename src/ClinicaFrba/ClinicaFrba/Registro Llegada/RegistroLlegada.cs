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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegada : Form
    {
        public RegistroLlegada()
        {
            InitializeComponent();
            clearSelections();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            clearSelections();
            this.Close();
        }

        private void botonListarProfesionales_Click(object sender, EventArgs e)
        {
            Parametro[] parametros = new Parametro[1];
            string consulta;
            bool esExacta;

            parametros.SetValue(Parametro.fromTextBox(espe_nombre, false), 0);

            consulta = Parser.armarConsulta("Profesionales",parametros);
            
            //MessageBox.Show(consulta);
            DBConnection.cargarPlanilla(planillaProfesionales, consulta);

            planillaProfesionales.ClearSelection();
            botonSelecAfil.Enabled = false;
            botonVerTurnos.Enabled = false;
            listadoTurnos.DataSource = null;
            listadoTurnos.Refresh();
        }

        //me retorna los turnos que aun no tienen asignada una consulta medica
        private void botonVerTurnos_Click(object sender, EventArgs e)
        {
            this.buscarTurnos();
            listadoTurnos.ClearSelection();
            botonSelecAfil.Enabled = false;
        }


        private void buscarTurnos()
        {
            string id = Convert.ToString(planillaProfesionales.SelectedCells[0].Value);
            string select = "SELECT afil_id iDAfiliado, turn_id Turno, usua_nombre +' '+ usua_apellido AS Afiliado, hora_inicio Hora \n ";
            string from = "FROM GEDDES.Turnos, GEDDES.Afiliados,GEDDES.Usuarios, GEDDES.Horarios join GEDDES.Especialidades ON hora_especialidad = espe_id \n";

            string subselect = "SELECT turn_id FROM GEDDES.Turnos, GEDDES.Profesionales, GEDDES.Horarios WHERE turn_hora = hora_id AND prof_id = hora_profesional AND prof_id = ";
            subselect = subselect + id;

            string where = "WHERE espe_nombre= '" + Convert.ToString(planillaProfesionales.SelectedCells[3].Value)
                            + "' AND turn_afiliado = afil_id AND afil_usuario = usua_id AND turn_hora = hora_id AND turn_activo = 1 AND hora_fecha = "+ Utils.fechaSistemaBD() 
                            + " AND turn_id NOT IN (SELECT cons_turno FROM GEDDES.Turnos, GEDDES.Consultas WHERE turn_id = cons_id) AND turn_id IN(" + subselect + ")";
            DBConnection.cargarPlanilla(listadoTurnos, select + from + where);


        }

        private void botonSelecAfil_Click(object sender, EventArgs e)
        {
            if (listadoTurnos.SelectedRows.Count == 1) {
                string id = Convert.ToString(listadoTurnos.SelectedCells[0].Value);
                int turno = Convert.ToInt32(listadoTurnos.SelectedCells[1].Value);

                //MessageBox.Show("Registrando llegada");
                RegistroBono seleccionarBono = new RegistroBono(id, turno);
                seleccionarBono.ShowDialog();
                this.buscarTurnos();
                listadoTurnos.ClearSelection();
                botonSelecAfil.Enabled = false;
            }
        }


        private void espe_nombre_Click(object sender, System.EventArgs e)
        {
            this.AcceptButton = botonListarProfesionales;
        }


        private void listadoTurnos_SelectionChanged(object sender, EventArgs e) {
            if (listadoTurnos.SelectedRows.Count != 0)
                botonSelecAfil.Enabled = true;
        }

        private void clearSelections() {
            planillaProfesionales.ClearSelection();
            listadoTurnos.ClearSelection();

        }

        private void RegistroLlegada_Load(object sender, EventArgs e) {

        }

        private void planillaProfesionales_SelectionChanged(object sender, EventArgs e) {
            botonVerTurnos.Enabled = true;
            this.AcceptButton = botonVerTurnos;
        }
    }
}
