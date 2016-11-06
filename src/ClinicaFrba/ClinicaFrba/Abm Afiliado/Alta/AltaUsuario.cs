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
        protected Abm_Afiliado.AgregadoFamiliar padre;

        public AltaUsuario(Afiliado afliadoARegistrar){
            this.afiliado = afliadoARegistrar;
            InitializeComponent();
            this.logger = new Logger();
        }

        public AltaUsuario altaFamiliarUser(Afiliado afliadoARegistrar, Abm_Afiliado.AgregadoFamiliar padre)
        {
            AltaUsuario formulario = new AltaUsuario(afliadoARegistrar);

            this.padre = padre;
            return formulario;
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

            logger.resetear();
        }


        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //afiliado.setMail(this.textBoxMail.Text);
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
                //pruebo si puedo registrar al usuario, segun si está disponible el nombre
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
            MessageBox.Show("Usted fue registrado con exito!", "Alta", MessageBoxButtons.OK);
            if (this.afiliado.puedeAfiliarAOtros()){

                this.brindarOpcionAgregar();
            }
        }


        private void brindarOpcionAgregar(){

             for (int i = 0; i <= afiliado.getHijosACargo(); i++)
                {
                    if (MessageBox.Show("Desea afiliar a un familiar?", "Alta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mostrarFormularioAgregadoFamiliares();
                    }
                    else
                    {
                        i = afiliado.getHijosACargo();
                    }
                }
            

        }


        private void mostrarFormularioAgregadoFamiliares()
        {
            Abm_Afiliado.AgregadoFamiliar otroFormulario = new AgregadoFamiliar(afiliado.getCodigoAfiliado());

            otroFormulario.inhabilitarAgregadoAfiliados();
            otroFormulario.ShowDialog();
        }


    }
}
