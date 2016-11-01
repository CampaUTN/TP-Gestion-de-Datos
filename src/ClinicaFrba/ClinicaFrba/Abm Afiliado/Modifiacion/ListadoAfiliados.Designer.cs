namespace ClinicaFrba.Abm_Afiliado.Modifiacion
{
    partial class ListadoAfiliados
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
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNroDoc = new System.Windows.Forms.TextBox();
            this.labelSeleccionNombre = new System.Windows.Forms.Label();
            this.labelSeleccionApellido = new System.Windows.Forms.Label();
            this.labelNroDoc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(26, 47);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 0;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(153, 47);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 1;
            // 
            // textBoxNroDoc
            // 
            this.textBoxNroDoc.Location = new System.Drawing.Point(279, 47);
            this.textBoxNroDoc.Name = "textBoxNroDoc";
            this.textBoxNroDoc.Size = new System.Drawing.Size(100, 20);
            this.textBoxNroDoc.TabIndex = 2;
            // 
            // labelSeleccionNombre
            // 
            this.labelSeleccionNombre.AutoSize = true;
            this.labelSeleccionNombre.Location = new System.Drawing.Point(11, 19);
            this.labelSeleccionNombre.Name = "labelSeleccionNombre";
            this.labelSeleccionNombre.Size = new System.Drawing.Size(54, 13);
            this.labelSeleccionNombre.TabIndex = 3;
            this.labelSeleccionNombre.Text = "Nombre/s";
            // 
            // labelSeleccionApellido
            // 
            this.labelSeleccionApellido.AutoSize = true;
            this.labelSeleccionApellido.Location = new System.Drawing.Point(138, 19);
            this.labelSeleccionApellido.Name = "labelSeleccionApellido";
            this.labelSeleccionApellido.Size = new System.Drawing.Size(54, 13);
            this.labelSeleccionApellido.TabIndex = 4;
            this.labelSeleccionApellido.Text = "Apellido/s";
            // 
            // labelNroDoc
            // 
            this.labelNroDoc.AutoSize = true;
            this.labelNroDoc.Location = new System.Drawing.Point(267, 19);
            this.labelNroDoc.Name = "labelNroDoc";
            this.labelNroDoc.Size = new System.Drawing.Size(100, 13);
            this.labelNroDoc.TabIndex = 5;
            this.labelNroDoc.Text = "Numero documento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSeleccionApellido);
            this.groupBox1.Controls.Add(this.labelNroDoc);
            this.groupBox1.Controls.Add(this.labelSeleccionNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 84);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(386, 264);
            this.dataGridView1.TabIndex = 7;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(304, 102);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 8;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(26, 102);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 9;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(26, 420);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 10;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Enabled = false;
            this.botonModificar.Location = new System.Drawing.Point(296, 420);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(83, 23);
            this.botonModificar.TabIndex = 11;
            this.botonModificar.Text = "Modificar...";
            this.botonModificar.UseVisualStyleBackColor = true;
            // 
            // ListadoAfiliados
            // 
            this.AcceptButton = this.botonBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(411, 454);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxNroDoc);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ListadoAfiliados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione afiliado...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNroDoc;
        private System.Windows.Forms.Label labelSeleccionNombre;
        private System.Windows.Forms.Label labelSeleccionApellido;
        private System.Windows.Forms.Label labelNroDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonModificar;
    }
}