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

        public AltaUsuario(Afiliado afliadoARegistrar)
        {
            this.afiliado = afliadoARegistrar;
            InitializeComponent();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (chequearPass())
            {
                this.agregarNuevosDatos();
                MessageBox.Show("Registrando en la base de datos...");
                Utils.registarUsuario(this.afiliado);

                Utils.registrarAfiliado(this.afiliado);
                
                //Segun los datos, debo darle la opcion de agregar un afiliado mas
                if (this.afiliado.puedeAfiliarAOtros())
                {
                    brindarOpcionAgregar();
                }
                else {
                    MessageBox.Show("Usted fue registrado con exito!", "Alta", MessageBoxButtons.OK);                    
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifique que ingreso la contraseña correcta e intentelo de nuevo");
            }
        }

        private bool chequearPass() {
            return this.textBoxPass.Text == this.textBoxPassConfirm.Text;
        }

        private void agregarNuevosDatos()
        {
            afiliado.setUsername(this.textBoxUsername.Text);
            afiliado.setPassword(this.textBoxPassConfirm.Text);
            afiliado.setMail(this.textBoxMail.Text);
        }

        private void brindarOpcionAgregar() {

            if (MessageBox.Show("Usted fue registrado con exito! Desea agregar un nuevo afiliado", "Alta", MessageBoxButtons.YesNo) 
                == DialogResult.Yes) 
            {
                Abm_Afiliado.Alta otroFormulario = new Alta();

                otroFormulario.inhabilitarAgregadoAfiliados();
                otroFormulario.Show();

            } 
        }

    }
}
