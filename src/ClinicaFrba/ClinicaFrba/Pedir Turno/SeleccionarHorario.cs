using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class SeleccionarHorario : Form
    {
        string userActivo;
        int nroAfiliado;
        private DataGridView grillaHorarios;
        private Label label1;
        private Button botonReservar;
        private Button botonSalir;
        string profesional;

        public SeleccionarHorario(int nroAfiliado, string profesional)
        {
            InitializeComponent();
            this.nroAfiliado = nroAfiliado;
            this.profesional = profesional;

            //MessageBox.Show("Profesiona: " + profesional); Lo use para verificar el tema de que se puede seleccionar cualquier campo de la fila

            this.grillaHorarios.DataSource = Utilidades.Utils.getHorariosDelProfesional(this.profesional);
            
        }

        private void InitializeComponent()
        {
            this.grillaHorarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.botonReservar = new System.Windows.Forms.Button();
            this.botonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaHorarios
            // 
            this.grillaHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaHorarios.Location = new System.Drawing.Point(35, 68);
            this.grillaHorarios.Name = "grillaHorarios";
            this.grillaHorarios.Size = new System.Drawing.Size(487, 180);
            this.grillaHorarios.TabIndex = 0;
            this.grillaHorarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaHorarios_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccion del horario";
            // 
            // botonReservar
            // 
            this.botonReservar.Location = new System.Drawing.Point(230, 272);
            this.botonReservar.Name = "botonReservar";
            this.botonReservar.Size = new System.Drawing.Size(80, 48);
            this.botonReservar.TabIndex = 2;
            this.botonReservar.Text = "Reservar";
            this.botonReservar.UseVisualStyleBackColor = true;
            this.botonReservar.Click += new System.EventHandler(this.botonReservar_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(447, 312);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 3;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // SeleccionarHorario
            // 
            this.ClientSize = new System.Drawing.Size(557, 359);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonReservar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaHorarios);
            this.Name = "SeleccionarHorario";
            this.Load += new System.EventHandler(this.SeleccionarHorario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaHorarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SeleccionarHorario_Load(object sender, EventArgs e)
        {

        }

        private void grillaHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void botonReservar_Click(object sender, EventArgs e)
        {
            if (grillaHorarios.SelectedCells.Count > 0 && grillaHorarios.Rows.Count > 1)
            {
                int rowindex = grillaHorarios.CurrentCell.RowIndex;
                string hora = grillaHorarios.Rows[rowindex].Cells[0].Value.ToString();
                //int afiliado = Utilidades.Utils.getNumeroAfiliadoDesdeUsuario(userActivo);

                SqlConnection conexion = DBConnection.getConnection();

                string insert = "INSERT INTO GEDDES.Turnos values (@afiliado, @hora, 1)";
                SqlCommand comando = new SqlCommand(insert, conexion);
                comando.Parameters.AddWithValue("@afiliado", nroAfiliado);
                comando.Parameters.AddWithValue("@hora", Int32.Parse(hora));

                conexion.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("El turno se ha registrado correctamente");

                this.grillaHorarios.DataSource = Utilidades.Utils.getHorariosDelProfesional(this.profesional);
            }
            else
            {
                MessageBox.Show("Seleccione un horario disponible si es que lo existe");
            }
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

