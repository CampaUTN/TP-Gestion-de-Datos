namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroLlegada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.espe_nombre = new System.Windows.Forms.TextBox();
            this.labelFiltroEspecialidad = new System.Windows.Forms.Label();
            this.botonListarProfesionales = new System.Windows.Forms.Button();
            this.planillaProfesionales = new System.Windows.Forms.DataGridView();
            this.botonVerTurnos = new System.Windows.Forms.Button();
            this.botonAtras = new System.Windows.Forms.Button();
            this.groupProfesionales = new System.Windows.Forms.GroupBox();
            this.listadoTurnos = new System.Windows.Forms.DataGridView();
            this.botonSelecAfil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.planillaProfesionales)).BeginInit();
            this.groupProfesionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // espe_nombre
            // 
            this.espe_nombre.Location = new System.Drawing.Point(24, 40);
            this.espe_nombre.Name = "espe_nombre";
            this.espe_nombre.Size = new System.Drawing.Size(175, 20);
            this.espe_nombre.TabIndex = 0;
            this.espe_nombre.Click += new System.EventHandler(this.espe_nombre_Click);
            // 
            // labelFiltroEspecialidad
            // 
            this.labelFiltroEspecialidad.AutoSize = true;
            this.labelFiltroEspecialidad.Location = new System.Drawing.Point(22, 26);
            this.labelFiltroEspecialidad.Name = "labelFiltroEspecialidad";
            this.labelFiltroEspecialidad.Size = new System.Drawing.Size(112, 13);
            this.labelFiltroEspecialidad.TabIndex = 1;
            this.labelFiltroEspecialidad.Text = "Filtrar por especialidad";
            // 
            // botonListarProfesionales
            // 
            this.botonListarProfesionales.Location = new System.Drawing.Point(208, 39);
            this.botonListarProfesionales.Name = "botonListarProfesionales";
            this.botonListarProfesionales.Size = new System.Drawing.Size(75, 23);
            this.botonListarProfesionales.TabIndex = 2;
            this.botonListarProfesionales.Text = "Buscar";
            this.botonListarProfesionales.UseVisualStyleBackColor = true;
            this.botonListarProfesionales.Click += new System.EventHandler(this.botonListarProfesionales_Click);
            // 
            // planillaProfesionales
            // 
            this.planillaProfesionales.AllowUserToAddRows = false;
            this.planillaProfesionales.AllowUserToDeleteRows = false;
            this.planillaProfesionales.AllowUserToResizeColumns = false;
            this.planillaProfesionales.AllowUserToResizeRows = false;
            this.planillaProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planillaProfesionales.Location = new System.Drawing.Point(9, 58);
            this.planillaProfesionales.MultiSelect = false;
            this.planillaProfesionales.Name = "planillaProfesionales";
            this.planillaProfesionales.ReadOnly = true;
            this.planillaProfesionales.RowHeadersVisible = false;
            this.planillaProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planillaProfesionales.Size = new System.Drawing.Size(455, 238);
            this.planillaProfesionales.TabIndex = 3;
            this.planillaProfesionales.SelectionChanged += new System.EventHandler(this.planillaProfesionales_SelectionChanged);
            // 
            // botonVerTurnos
            // 
            this.botonVerTurnos.Enabled = false;
            this.botonVerTurnos.Location = new System.Drawing.Point(190, 321);
            this.botonVerTurnos.Name = "botonVerTurnos";
            this.botonVerTurnos.Size = new System.Drawing.Size(113, 25);
            this.botonVerTurnos.TabIndex = 4;
            this.botonVerTurnos.Text = "Ver Turnos...";
            this.botonVerTurnos.UseVisualStyleBackColor = true;
            this.botonVerTurnos.Click += new System.EventHandler(this.botonVerTurnos_Click);
            // 
            // botonAtras
            // 
            this.botonAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonAtras.Location = new System.Drawing.Point(12, 631);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(77, 27);
            this.botonAtras.TabIndex = 5;
            this.botonAtras.Text = "<- Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.botonAtras_Click);
            // 
            // groupProfesionales
            // 
            this.groupProfesionales.Controls.Add(this.planillaProfesionales);
            this.groupProfesionales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupProfesionales.Location = new System.Drawing.Point(3, 8);
            this.groupProfesionales.Name = "groupProfesionales";
            this.groupProfesionales.Size = new System.Drawing.Size(475, 307);
            this.groupProfesionales.TabIndex = 6;
            this.groupProfesionales.TabStop = false;
            this.groupProfesionales.Text = "Seleccione un Profesional";
            // 
            // listadoTurnos
            // 
            this.listadoTurnos.AllowUserToAddRows = false;
            this.listadoTurnos.AllowUserToDeleteRows = false;
            this.listadoTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoTurnos.Location = new System.Drawing.Point(12, 352);
            this.listadoTurnos.MultiSelect = false;
            this.listadoTurnos.Name = "listadoTurnos";
            this.listadoTurnos.ReadOnly = true;
            this.listadoTurnos.RowHeadersVisible = false;
            this.listadoTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoTurnos.Size = new System.Drawing.Size(455, 273);
            this.listadoTurnos.TabIndex = 7;
            this.listadoTurnos.SelectionChanged += new System.EventHandler(this.listadoTurnos_SelectionChanged);
            // 
            // botonSelecAfil
            // 
            this.botonSelecAfil.Enabled = false;
            this.botonSelecAfil.Location = new System.Drawing.Point(337, 631);
            this.botonSelecAfil.Name = "botonSelecAfil";
            this.botonSelecAfil.Size = new System.Drawing.Size(130, 27);
            this.botonSelecAfil.TabIndex = 8;
            this.botonSelecAfil.Text = "Seleccionar Afiliado";
            this.botonSelecAfil.UseVisualStyleBackColor = true;
            this.botonSelecAfil.Click += new System.EventHandler(this.botonSelecAfil_Click);
            // 
            // RegistroLlegada
            // 
            this.AcceptButton = this.botonListarProfesionales;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonAtras;
            this.ClientSize = new System.Drawing.Size(488, 666);
            this.Controls.Add(this.botonSelecAfil);
            this.Controls.Add(this.botonVerTurnos);
            this.Controls.Add(this.listadoTurnos);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.botonListarProfesionales);
            this.Controls.Add(this.labelFiltroEspecialidad);
            this.Controls.Add(this.espe_nombre);
            this.Controls.Add(this.groupProfesionales);
            this.MaximizeBox = false;
            this.Name = "RegistroLlegada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de llegada para atención médica";
            this.Load += new System.EventHandler(this.RegistroLlegada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.planillaProfesionales)).EndInit();
            this.groupProfesionales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listadoTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.TextBox espe_nombre;
        private System.Windows.Forms.Label labelFiltroEspecialidad;
        private System.Windows.Forms.Button botonListarProfesionales;
        private System.Windows.Forms.DataGridView planillaProfesionales;
        private System.Windows.Forms.Button botonVerTurnos;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.GroupBox groupProfesionales;
        private System.Windows.Forms.DataGridView listadoTurnos;
        private System.Windows.Forms.Button botonSelecAfil;
    }
}