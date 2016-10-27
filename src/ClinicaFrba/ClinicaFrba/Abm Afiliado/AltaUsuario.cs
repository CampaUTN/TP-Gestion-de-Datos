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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaUsuario : Form
    {
        private Afiliado afiliado = new Afiliado();

        public AltaUsuario(Afiliado afliadoARegistrar)
        {
            this.afiliado = afliadoARegistrar;
            InitializeComponent();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            if (chequearPass())
            {
                MessageBox.Show("Mostrando usuario");
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifique que ingreso la contraseña correcta e intentelo de nuevo");
            }
        }

        private bool chequearPass() {
            return this.textBoxPass.Text == this.textBoxPassConfirm.Text;
        }

    }





}
