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
using ClinicaFrba.Utilidades;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Alta : Form, FormularioABM
    {
        protected bool esDeAfiliadoPrincipal;
        protected string sexo;
        protected List<TextBox> cajasTexto;
        protected Afiliado afiliado;
        protected Logger logErrores;

        public Alta(){
            this.cajasTexto = new List<TextBox>();

            InitializeComponent();

            Utils.llenar(this.selecPlan,Utils.getPlanes());
            cargarCajitas();

            this.logErrores = new Logger();
        }

        
        #region METODOS QUE SE ACTIVAN CUANDO SE ACCIONA UN BOTON O CAMBIA UN VALOR
        //metodo que se activa cuando hago click en aceptar
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            //chequeo que todos los campos se hayan completado
            if (!faltaCompletarDatos()){
                //chequeo que los datos sean correctos
                this.validarDatosIngresados();
                if (!this.logErrores.huboErrores())
                {
                    //metodo que sobreescribe Modificacion
                    realizarOperacion();
                }
                else{
                    MessageBox.Show("Error en el ingreso de datos:\n" + this.logErrores.mostrarLog() + "\nCompruebe que haya ingresado los datos en forma correcta y vuelva a intentarlo.", "Error", MessageBoxButtons.OK);
                   
                }
                this.logErrores.resetear();
            }
            else {
                MessageBox.Show("Debe completar los datos del afiliado para continuar", "Aviso", MessageBoxButtons.OK);
      
            }
        }
        
        //me baso en un string para la seleccion del genero
        private void selecFem_CheckedChanged(object sender, EventArgs e){
            sexo = "F";
        }

        private void selecMasc_CheckedChanged(object sender, EventArgs e){
            sexo = "M";
        }

        //limpio los datos que el usuario completo
        private void botonLimpiar_Click(object sender, EventArgs e){
            this.limpiarCajitas();
        }

        private void limpiarCajitas(){
            foreach (TextBox cajita in cajasTexto){
                cajita.Clear();
            }
            this.checkBoxHijos.CheckState = CheckState.Unchecked;
        }


        private void selecEstadoCivil_SelectedIndexChanged(object sender, EventArgs e){
            int estado = selecEstadoCivil.SelectedIndex;
            if (estado.Equals(1) || estado.Equals(3)){
                //this.botonAgregarFamiliar.Enabled = true;
            }
            else{
                //this.botonAgregarFamiliar.Enabled = false;
            }

            /*Me fijo si el valor seleccionado es 1 o 3
             * 0- Soltero/a  1- Casado/a
               2- Viudo/a    3- Concubinato
               4- Divorciado/a
             */
        }
        
        private void botonCancelar_Click(object sender, EventArgs e){
            if (MessageBox.Show("¿Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes){
                this.Close();
            }
        }

        private void checkBoxHijos_CheckedChanged(object sender, EventArgs e){
            if (checkBoxHijos.Checked){
                //this.botonAfiliarFamiliar.Enabled = true;
                this.textBoxCantHijos.Enabled = true;
                this.cajasTexto.Add(textBoxCantHijos);
            }
            else {
                //this.botonAfiliarFamiliar.Enabled = false;
                this.textBoxCantHijos.Enabled = false;
                this.cajasTexto.Remove(textBoxCantHijos);
            }
        }

        private void botonAgregarFamiliar_Click(object sender, EventArgs e){
            if (faltaCompletarDatos()){
                MessageBox.Show("Debe completar los datos del afiliado\nprincipal para poder continuar", "Aviso", MessageBoxButtons.OK);
            }
            else{
                //aca agrego a los conyuges
            }
        }

        private void botonAfiliarFamiliar_Click(object sender, EventArgs e){
            if (faltaCompletarDatos()){
                MessageBox.Show("Debe completar los datos del afiliado\nprincipal para poder continuar", "Aviso", MessageBoxButtons.OK);
            }
            else{
                //aca agrego a los familiares a cargo
            }
        }

        #endregion

        #region METODOS AUXILIARES
        
        //deberia ser privado, pero me tira error de compilacion
        public virtual void  realizarOperacion()
        {
            //abro el formulario de usuario
            this.cargarUsuario();
            new AltaUsuario(this.afiliado).Show();
            this.limpiarCajitas();
        }

        protected void cargarCajitas() {
            this.cajasTexto.Add(textBoxNombre);
            this.cajasTexto.Add(textBoxApellido);
            this.cajasTexto.Add(textBoxNroDoc);
            this.cajasTexto.Add(textBoxDireccion);
            this.cajasTexto.Add(textBoxTelefono);
        }


        //agrego los datos en el objeto usuario
        public virtual void cargarUsuario(){
            afiliado = new Afiliado(this.textBoxNombre.Text,
                                    this.textBoxApellido.Text,
                                    this.selectorFecha.Value.Date,
                                    this.comboBoxTipoDoc.SelectedItem.ToString(),
                                    this.textBoxNroDoc.Text,
                                    this.textBoxDireccion.Text,
                                    this.textBoxTelefono.Text,
                                    this.sexo,
                                    this.selecEstadoCivil.SelectedItem.ToString(),
                                    this.selecPlan.Text);

            setearCantidadHijos();
            MessageBox.Show("Registrese como usuario antes de continuar");

        }
        
    #endregion

        #region VALIDACION DE LOS DATOS

        private bool faltaCompletarDatos() {
            return cajasTexto.Any(cajita => cajita.Text.Length.Equals(0));
        }

        private void validarDatosIngresados() {

            if (!Parser.esEntero(textBoxTelefono)){
                this.logErrores.agregarAlLog("El numero de telefono debe ser numerico");
                textBoxTelefono.Clear();
            }

            if (!Parser.esEntero(textBoxNroDoc)){
                this.logErrores.agregarAlLog("El numero de documento debe ser numerico");
                textBoxNroDoc.Clear();
            }

            if (textBoxCantHijos.Enabled && !Parser.esEntero(textBoxCantHijos)){
                this.logErrores.agregarAlLog("La cantidad de familiares a cargo debe ser un numero entero");
                textBoxCantHijos.Clear(); 
            }

            if (Parser.tieneNumeros(textBoxNombre)){
                this.logErrores.agregarAlLog("El nombre de afiliado no debe contener numeros enteros");
                textBoxNombre.Clear();
            }

            if (Parser.tieneNumeros(textBoxApellido)){
                this.logErrores.agregarAlLog("El apellido del afiliado no debe contener numeros enteros");   
                textBoxApellido.Clear();
            }
        }

       private void setearCantidadHijos(){
            if (checkBoxHijos.Checked){
                this.afiliado.setHijosACargo(int.Parse(textBoxCantHijos.Text));
            }
        }
        
        public void inhabilitarAgregadoAfiliados(){
            this.checkBoxHijos.Enabled = false;

            //his.afiliado.setAfiliadoRaiz(false);
        }

    }

    #endregion

}