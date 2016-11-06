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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegada : Form
    {
        public RegistroLlegada()
        {
            InitializeComponent();
        }

        private void botonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonListarProfesionales_Click(object sender, EventArgs e)
        {
            Parametro[] parametros = new Parametro[1];
            string consulta;
            bool esExacta;

            parametros.SetValue(new Parametro(espe_nombre, false), 0);

            consulta = Parser.armarConsulta("Profesionales",parametros);
            //prof_espe.Text = "";
            DBConnection.cargarPlanilla(planillaProfesionales, consulta); 

        }

        private void botonVerTurnos_Click(object sender, EventArgs e)
        {
            string id =Convert.ToString(planillaProfesionales.SelectedCells[0].Value);
           
            string select = "SELECT afil_id, turn_id, usua_nombre, usua_apellido, hora_inicio \n ";
            string from = "FROM CLINICA.Turnos, CLINICA.Afiliados,CLINICA.Usuarios, CLINICA.Horarios \n";

            string subselect = "SELECT turn_id FROM CLINICA.Turnos, CLINICA.Profesionales, CLINICA.Horarios WHERE turn_hora = hora_id AND prof_id = hora_profesional AND prof_id = ";
            subselect = subselect + id;

            string where = "WHERE turn_afiliado = afil_id AND afil_usuario = usua_id AND turn_hora = hora_id AND turn_activo = 1 AND turn_id IN(" + subselect + ")";

             DBConnection.cargarPlanilla(listadoTurnos,
                select + from + where);

               //"SELECT prof_id, turn_id, hora_inicio FROM CLINICA.Profesionales, CLINICA.Horarios, CLINICA.Turnos WHERE prof_id = hora_profesional AND hora_profesional = turn_hora AND turn_activo = 1 AND prof_id = " + prof_id);
      
        }

        

        private void planillaResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonVerTurnos.Enabled = true;
        }


        private void listadoTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            botonSelecAfil.Enabled = true;
        }

        private void botonSelecAfil_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(listadoTurnos.SelectedCells[0].Value);
            int turno = Convert.ToInt32(listadoTurnos.SelectedCells[1].Value);

            //MessageBox.Show("Registrando llegada");
            RegistroBono seleccionarBono = new RegistroBono(id, turno);
            seleccionarBono.Show();
        }
    }
}
