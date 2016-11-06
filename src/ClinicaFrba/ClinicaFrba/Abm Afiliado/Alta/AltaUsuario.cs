using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Afiliado;
using System.Data.SqlClient;
using ClinicaFrba.Utilidades;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaUsuario : Form
    {
        private Afiliado afiliado;
        protected Logger logger;

        public AltaUsuario(Afiliado afliadoARegistrar){
            this.afiliado = afliadoARegistrar;
            InitializeComponent();
            this.logger = new Logger();
        }

        #region METODOS QUE SE ACTIVAN CUANDO SE ACCIONA UN BOTON O CAMBIA UN VALOR
        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            //verifico que el usuario haya completado los datos
            if (!faltaCompletarDatos())
            {
                this.verificarDatos();

                //verifico que los datos se hayan ingresado de forma correcta
                if (!logger.huboErrores())
                {
                    this.agregarNuevosDatos();
                    MessageBox.Show("Registrando en la base de datos...");

                    //pruebo si puedo agregar al usuario o no.
                    this.realizarOP();           
                }
                else
                {
                    MessageBox.Show("Error en el ingreso de datos:\n" + this.logger.mostrarLog() + "\nCompruebe que haya ingresado los datos en forma correcta y vuelva a intentarlo.", "Error", MessageBoxButtons.OK);
             
                }
            }
            else
            {
                MessageBox.Show("Debe completar los datos del afiliado para continuar", "Aviso", MessageBoxButtons.OK);          
            }
        }


        #endregion

        #region VALIDACIONES
        private bool chequearPass() {
            return this.textBoxPass.Text == this.textBoxPassConfirm.Text;
        }

        private void agregarNuevosDatos()
        {
            afiliado.setUsername(this.textBoxUsername.Text);
            afiliado.setPassword(this.textBoxPassConfirm.Text);
            afiliado.setMail(this.textBoxMail.Text);
        }



        public void verificarDatos(){


            if (!chequearPass()){
                logger.agregarAlLog("Las contraseñas no coinciden");
            }

            if (!verificarDisponibilidadDelNombre()) {
                logger.agregarAlLog("El nombre de usuario no esta disponible");
                
            }
        }

        public bool faltaCompletarDatos() {
            return Parser.estaVacio(textBoxUsername) || Parser.estaVacio(textBoxPass) || Parser.estaVacio(textBoxPassConfirm);        
        }

        public bool verificarDisponibilidadDelNombre() {
            return true;
        }
#endregion

        public void realizarOP(){

            try{
                Utils.registarUsuario(this.afiliado);
                if (afiliado.esAfiliadoRaiz()){
                    Utils.registrarAfiliado(this.afiliado);
                    afiliado.setCodigo(Utils.obtenerNumeroAfiliadoRecienRegistrado());

                    validarSiPuedeAfiliar();
                }
                else{
                    Utils.registrarFamiliarAfiliado(this.afiliado);
                }
                
                this.Close();
     
            }catch (SqlException e){
                MessageBox.Show(e.Message);
            }
        }

        
        public void validarSiPuedeAfiliar(){
            //Segun los datos, debo darle la opcion de agregar un afiliado mas
            if (this.afiliado.puedeAfiliarAOtros()){
                this.brindarOpcionAgregar();
            }
            else{
                MessageBox.Show("Usted fue registrado con exito!", "Alta", MessageBoxButtons.OK);
            }
        }


        private void brindarOpcionAgregar(){

            if (MessageBox.Show("Usted fue registrado con exito! Desea agregar un nuevo afiliado?", "Alta", MessageBoxButtons.YesNo)
                == DialogResult.Yes) {
                Abm_Afiliado.AgregadoFamiliar otroFormulario = new AgregadoFamiliar(afiliado.getCodigoAfiliado());

                otroFormulario.inhabilitarAgregadoAfiliados();
                otroFormulario.Show();

            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
