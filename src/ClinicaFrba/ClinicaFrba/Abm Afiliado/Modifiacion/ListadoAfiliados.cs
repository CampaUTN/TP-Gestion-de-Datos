using ClinicaFrba.Abm_Afiliado.Baja;
using ClinicaFrba.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public static ListadoAfiliados ListadoBaja()
        {
            ListadoAfiliados listado = new ListadoAfiliados();
            listado.botonEliminar.Visible = true;
            listado.botonEliminar.Enabled = true;
            listado.botonModificar.Enabled = false;

            return listado;
        }
        
      #region METODOS QUE SE ACTIVAN CUANDO SE ACCIONA UN BOTON O CAMBIA UN VALOR
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            usua_nombre.Clear();
            usua_apellido.Clear();
            usua_nroDoc.Clear();

            botonModificar.Enabled = false;
            botonDesactivar.Enabled = false;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            Parametro[] parametros = new Parametro[3];
            string consulta;
            bool esExacta;

            botonModificar.Enabled = false;
            botonDesactivar.Enabled = false;
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

                consulta = Parser.armarConsulta("Afiliados", parametros); 

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
            botonDesactivar.Enabled = true;
            this.AcceptButton = botonModificar;
        }



        private void planillaResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        {  
            Afiliado afil = this.completarDatosDeAfiliado() ;
            ModificacionUsuario modif = new ModificacionUsuario(afil);

            modif.Show();
        }

        private Afiliado completarDatosDeAfiliado()
        {
            string direccion;
            string tipoDoc;
            string telefono;
            string mail;
            string genero;
            int plan_id;
            string estado;
            int cantidadHijos;
            DateTime fechaNac;

            long cod_usuario = Convert.ToInt64(planillaResultados.SelectedCells[0].Value);

            string apellido = Convert.ToString(planillaResultados.SelectedCells[1].Value);
            string nombre = Convert.ToString(planillaResultados.SelectedCells[2].Value);
            string dni = Convert.ToString(planillaResultados.SelectedCells[3].Value);


            SqlDataReader reader = Utils.obtenerAfiliadoDesdeUsername(cod_usuario);

            reader.Read();
                plan_id = Convert.ToInt32(reader[2]);
                estado = Convert.ToString(reader[3]);
                cantidadHijos = Convert.ToInt32(reader[4]);
          

           reader = Utils.obtenerUsuarioDesdeUsername(cod_usuario);

           reader.Read();
                direccion = Convert.ToString(reader[0]);
                tipoDoc = Convert.ToString(reader[1]);
                telefono = Convert.ToString(reader[2]);
                //fechaNac = Convert.ToDateTime(reader[3]);
                fechaNac = DateTime.Today;

                mail = Convert.ToString(reader[4]);
                genero = Convert.ToString(reader[5]);

           string plan = Utils.getNombrePlan(plan_id);

           Afiliado afiliado = new Afiliado(nombre, apellido, fechaNac, tipoDoc, dni, direccion, telefono, genero, estado, plan);

           afiliado.setUsuaId(cod_usuario);            
            
            return afiliado;
        }


        #endregion

        private void botonDesactivar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea dar de baja logica a este afiliado?","Desactivar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Afiliado afil = this.completarDatosDeAfiliado();

                Utilidades.Utils.bajaLogicaA(afil);
                MessageBox.Show("Usuario dado de baja");
            }
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            BajaAfiliado baja;

            if (MessageBox.Show("Esta seguro que desea eliminar este afiliado?", "Desactivar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baja = new BajaAfiliado();
                Afiliado afil = this.completarDatosDeAfiliado();

                baja.eliminarAfiliado(afil);
                MessageBox.Show("Usuario eliminado");
            }
        }

       
    }
}
