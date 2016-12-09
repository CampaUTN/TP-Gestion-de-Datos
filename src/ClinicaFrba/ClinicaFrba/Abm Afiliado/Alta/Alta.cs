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
    public partial class Alta : Form
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
            this.selectorFecha.MaxDate = System.DateTime.ParseExact(Utils.fechaSistema(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
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
                    //metodo que sobreescribe Modificacion. Acá se realiza la operación principal
                    realizarOperacion();
                }
                else{
                    MessageBox.Show("Error en el ingreso de datos:\n" + this.logErrores.mostrarLog() + "\nCompruebe que haya ingresado los datos en forma correcta y vuelva a intentarlo.", "Error", MessageBoxButtons.OK);
                }
            }
            else {

                MessageBox.Show("Debe completar los datos del afiliado para continuar", "Aviso", MessageBoxButtons.OK);
      
            }
            this.logErrores.resetear();
        }
                
        //me baso en un string para la seleccion del genero
        private void selecFem_CheckedChanged(object sender, EventArgs e){
            sexo = "F";
        }

        private void selecMasc_CheckedChanged(object sender, EventArgs e){
            sexo = "M";
        }

        //limpio los datos que el usuario completo
        public virtual void botonLimpiar_Click(object sender, EventArgs e){
            this.limpiarCajitas();
            selecPlan.ResetText();
            selecEstadoCivil.ResetText();

            selecPlan.SelectedItem = null;
            selecEstadoCivil.SelectedItem = null;
        }

        private void botonCancelar_Click(object sender, EventArgs e){
            if (MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes){
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


        protected void limpiarCajitas(){
            foreach (TextBox cajita in cajasTexto){ cajita.Clear();  }

            this.selecPlan.ResetText();
            this.selecEstadoCivil.ResetText();
            this.checkBoxHijos.CheckState = CheckState.Unchecked;
        }

        #endregion

        #region METODOS AUXILIARES
        
        //deberia ser privado, pero me tira error de compilacion
        public virtual void  realizarOperacion()
        {
            //abro el formulario de usuario
            this.cargarUsuario();
            (new AltaUsuario(this.afiliado)).ShowDialog();
            this.limpiarCajitas();

            if (MessageBox.Show("Agregar otro afiliado?", "Alta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.limpiarCajitas();
            }
            else
            {
                this.Close();
            }


        }

        protected void cargarCajitas() {
            this.cajasTexto.Add(textBoxNombre);
            this.cajasTexto.Add(textBoxApellido);
            this.cajasTexto.Add(textBoxNroDoc);
            this.cajasTexto.Add(textBoxDireccion);
            this.cajasTexto.Add(textBoxTelefono);

            this.selecPlan.ResetText();
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
            MessageBox.Show("Regístrese como usuario antes de continuar");

        }
        
    #endregion

        #region VALIDACION DE LOS DATOS

        public virtual bool faltaCompletarDatos() {

            bool seEligioUnPlan = selecPlan.SelectedItem != null;
            bool seEligioEstadoCivil = selecEstadoCivil.SelectedItem != null;
            bool cajasVacias = cajasTexto.Any(cajita => cajita.Text.Length.Equals(0));

            return !seEligioUnPlan || !seEligioEstadoCivil || cajasVacias;
        }

        //valido el formato de los datos ingresados
        public virtual void validarDatosIngresados() {

            if (!Parser.esEntero(textBoxNroDoc))
            {
                this.logErrores.agregarAlLog("El número de documento debe ser numérico");
                textBoxNroDoc.Clear();
            }
            else if (Utils.dniOcupado(textBoxNroDoc.Text))
            {
                this.logErrores.agregarAlLog("El número de DNI ya se encuentra registrado en el sistema");

                textBoxNroDoc.Clear();
            }

            if (textBoxCantHijos.Enabled && !Parser.esEntero(textBoxCantHijos)){
                this.logErrores.agregarAlLog("La cantidad de familiares a cargo debe ser un número entero");
                textBoxCantHijos.Clear(); 
            }

            if (Parser.tieneNumeros(textBoxNombre)){
                this.logErrores.agregarAlLog("El nombre de afiliado no debe contener números enteros");
                textBoxNombre.Clear();
            }

            if (Parser.tieneNumeros(textBoxApellido)){
                this.logErrores.agregarAlLog("El apellido del afiliado no debe contener números enteros");   
                textBoxApellido.Clear();
            }

            if (!Parser.esEntero(textBoxTelefono))
            {
                this.logErrores.agregarAlLog("El nùmero de telefono debe ser númerico");

                textBoxTelefono.Clear();
            }       
        }
                
       private void setearCantidadHijos(){
            if (checkBoxHijos.Checked){
                this.afiliado.setHijosACargo(int.Parse(textBoxCantHijos.Text));
            }
        }
        
        public void inhabilitarAgregadoAfiliados(){
            this.checkBoxHijos.Enabled = false;

        }

        private void selecEstadoCivil_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Alta_Load(object sender, EventArgs e) {
            comboBoxTipoDoc.SelectedIndex = 0;
        }

    }
    #endregion
}