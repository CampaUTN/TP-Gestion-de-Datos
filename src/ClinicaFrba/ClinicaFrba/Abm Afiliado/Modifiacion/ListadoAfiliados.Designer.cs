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
            this.usua_nombre = new System.Windows.Forms.TextBox();
            this.usua_apellido = new System.Windows.Forms.TextBox();
            this.usua_nroDoc = new System.Windows.Forms.TextBox();
            this.labelSeleccionNombre = new System.Windows.Forms.Label();
            this.labelSeleccionApellido = new System.Windows.Forms.Label();
            this.labelNroDoc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDoc = new System.Windows.Forms.CheckBox();
            this.checkBoxApellido = new System.Windows.Forms.CheckBox();
            this.checkBoxNombre = new System.Windows.Forms.CheckBox();
            this.planillaResultados = new System.Windows.Forms.DataGridView();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonDesactivar = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.usua_intentos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planillaResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // usua_nombre
            // 
            this.usua_nombre.Location = new System.Drawing.Point(11, 33);
            this.usua_nombre.Name = "usua_nombre";
            this.usua_nombre.Size = new System.Drawing.Size(125, 20);
            this.usua_nombre.TabIndex = 0;
            // 
            // usua_apellido
            // 
            this.usua_apellido.Location = new System.Drawing.Point(157, 33);
            this.usua_apellido.Name = "usua_apellido";
            this.usua_apellido.Size = new System.Drawing.Size(140, 20);
            this.usua_apellido.TabIndex = 1;
            // 
            // usua_nroDoc
            // 
            this.usua_nroDoc.Location = new System.Drawing.Point(309, 33);
            this.usua_nroDoc.Name = "usua_nroDoc";
            this.usua_nroDoc.Size = new System.Drawing.Size(132, 20);
            this.usua_nroDoc.TabIndex = 2;
            // 
            // labelSeleccionNombre
            // 
            this.labelSeleccionNombre.AutoSize = true;
            this.labelSeleccionNombre.Location = new System.Drawing.Point(9, 19);
            this.labelSeleccionNombre.Name = "labelSeleccionNombre";
            this.labelSeleccionNombre.Size = new System.Drawing.Size(54, 13);
            this.labelSeleccionNombre.TabIndex = 3;
            this.labelSeleccionNombre.Text = "Nombre/s";
            // 
            // labelSeleccionApellido
            // 
            this.labelSeleccionApellido.AutoSize = true;
            this.labelSeleccionApellido.Location = new System.Drawing.Point(157, 20);
            this.labelSeleccionApellido.Name = "labelSeleccionApellido";
            this.labelSeleccionApellido.Size = new System.Drawing.Size(54, 13);
            this.labelSeleccionApellido.TabIndex = 4;
            this.labelSeleccionApellido.Text = "Apellido/s";
            // 
            // labelNroDoc
            // 
            this.labelNroDoc.AutoSize = true;
            this.labelNroDoc.Location = new System.Drawing.Point(308, 19);
            this.labelNroDoc.Name = "labelNroDoc";
            this.labelNroDoc.Size = new System.Drawing.Size(100, 13);
            this.labelNroDoc.TabIndex = 5;
            this.labelNroDoc.Text = "Numero documento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxDoc);
            this.groupBox1.Controls.Add(this.checkBoxApellido);
            this.groupBox1.Controls.Add(this.checkBoxNombre);
            this.groupBox1.Controls.Add(this.labelSeleccionApellido);
            this.groupBox1.Controls.Add(this.labelNroDoc);
            this.groupBox1.Controls.Add(this.labelSeleccionNombre);
            this.groupBox1.Controls.Add(this.usua_nroDoc);
            this.groupBox1.Controls.Add(this.usua_nombre);
            this.groupBox1.Controls.Add(this.usua_apellido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 84);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // checkBoxDoc
            // 
            this.checkBoxDoc.AutoSize = true;
            this.checkBoxDoc.Location = new System.Drawing.Point(317, 56);
            this.checkBoxDoc.Name = "checkBoxDoc";
            this.checkBoxDoc.Size = new System.Drawing.Size(109, 17);
            this.checkBoxDoc.TabIndex = 8;
            this.checkBoxDoc.Text = "Busqueda exacta";
            this.checkBoxDoc.UseVisualStyleBackColor = true;
            // 
            // checkBoxApellido
            // 
            this.checkBoxApellido.AutoSize = true;
            this.checkBoxApellido.Location = new System.Drawing.Point(169, 55);
            this.checkBoxApellido.Name = "checkBoxApellido";
            this.checkBoxApellido.Size = new System.Drawing.Size(109, 17);
            this.checkBoxApellido.TabIndex = 7;
            this.checkBoxApellido.Text = "Busqueda exacta";
            this.checkBoxApellido.UseVisualStyleBackColor = true;
            // 
            // checkBoxNombre
            // 
            this.checkBoxNombre.AutoSize = true;
            this.checkBoxNombre.Location = new System.Drawing.Point(18, 54);
            this.checkBoxNombre.Name = "checkBoxNombre";
            this.checkBoxNombre.Size = new System.Drawing.Size(109, 17);
            this.checkBoxNombre.TabIndex = 6;
            this.checkBoxNombre.Text = "Busqueda exacta";
            this.checkBoxNombre.UseVisualStyleBackColor = true;
            // 
            // planillaResultados
            // 
            this.planillaResultados.AllowUserToAddRows = false;
            this.planillaResultados.AllowUserToDeleteRows = false;
            this.planillaResultados.AllowUserToResizeColumns = false;
            this.planillaResultados.AllowUserToResizeRows = false;
            this.planillaResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planillaResultados.EnableHeadersVisualStyles = false;
            this.planillaResultados.Location = new System.Drawing.Point(12, 142);
            this.planillaResultados.MultiSelect = false;
            this.planillaResultados.Name = "planillaResultados";
            this.planillaResultados.ReadOnly = true;
            this.planillaResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planillaResultados.Size = new System.Drawing.Size(460, 264);
            this.planillaResultados.TabIndex = 7;
            this.planillaResultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.planillaResultados_CellClick);
            this.planillaResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.planillaResultados_CellContentClick);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(388, 102);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 8;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(290, 102);
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
            this.botonCancelar.Text = "<- Atrás";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Enabled = false;
            this.botonModificar.Location = new System.Drawing.Point(380, 419);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(83, 23);
            this.botonModificar.TabIndex = 11;
            this.botonModificar.Text = "Modificar...";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonDesactivar
            // 
            this.botonDesactivar.Enabled = false;
            this.botonDesactivar.Location = new System.Drawing.Point(290, 419);
            this.botonDesactivar.Name = "botonDesactivar";
            this.botonDesactivar.Size = new System.Drawing.Size(75, 23);
            this.botonDesactivar.TabIndex = 12;
            this.botonDesactivar.Text = "Desactivar";
            this.botonDesactivar.UseVisualStyleBackColor = true;
            this.botonDesactivar.Click += new System.EventHandler(this.botonDesactivar_Click);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(198, 419);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(75, 23);
            this.botonEliminar.TabIndex = 13;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Visible = false;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // usua_intentos
            // 
            this.usua_intentos.AutoSize = true;
            this.usua_intentos.Location = new System.Drawing.Point(30, 102);
            this.usua_intentos.Name = "usua_intentos";
            this.usua_intentos.Size = new System.Drawing.Size(126, 17);
            this.usua_intentos.TabIndex = 14;
            this.usua_intentos.Text = "Ocultar desactivados";
            this.usua_intentos.UseVisualStyleBackColor = true;
            // 
            // ListadoAfiliados
            // 
            this.AcceptButton = this.botonBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(484, 454);
            this.Controls.Add(this.usua_intentos);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.botonDesactivar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.planillaResultados);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ListadoAfiliados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione afiliado...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planillaResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usua_nombre;
        private System.Windows.Forms.TextBox usua_apellido;
        private System.Windows.Forms.TextBox usua_nroDoc;
        private System.Windows.Forms.Label labelSeleccionNombre;
        private System.Windows.Forms.Label labelSeleccionApellido;
        private System.Windows.Forms.Label labelNroDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView planillaResultados;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.CheckBox checkBoxNombre;
        private System.Windows.Forms.CheckBox checkBoxDoc;
        private System.Windows.Forms.CheckBox checkBoxApellido;
        private System.Windows.Forms.Button botonDesactivar;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.CheckBox usua_intentos;
    }
}