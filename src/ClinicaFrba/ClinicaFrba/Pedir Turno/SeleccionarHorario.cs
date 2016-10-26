using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class SeleccionarHorario : Form
    {
        string userActivo;
        string profesional;

        public SeleccionarHorario(string userActivo, string profesional)
        {
            InitializeComponent();
            this.userActivo = userActivo;
            this.profesional = profesional;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SeleccionarHorario
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "SeleccionarHorario";
            this.Load += new System.EventHandler(this.SeleccionarHorario_Load);
            this.ResumeLayout(false);

        }

        private void SeleccionarHorario_Load(object sender, EventArgs e)
        {

        }
    }
}
