namespace ClinicaFrba.Abm_Afiliado
{
    partial class Alta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.labelTipoDoc = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.labelNroDoc = new System.Windows.Forms.Label();
            this.textBoxNroDoc = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelSexo = new System.Windows.Forms.Label();
            this.selecFem = new System.Windows.Forms.RadioButton();
            this.selecMasc = new System.Windows.Forms.RadioButton();
            this.selecEstadoCivil = new System.Windows.Forms.ComboBox();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.selecPlan = new System.Windows.Forms.ComboBox();
            this.labelSelecPlan = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.labelFechaNac = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.checkBoxHijos = new System.Windows.Forms.CheckBox();
            this.labelCantHijos = new System.Windows.Forms.Label();
            this.textBoxCantHijos = new System.Windows.Forms.TextBox();
            this.selectorFecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(14, 26);
            this.textBoxNombre.MaxLength = 255;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(117, 20);
            this.textBoxNombre.TabIndex = 0;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(11, 10);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(54, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre/s";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(150, 9);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(54, 13);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "Apellido/s";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(148, 26);
            this.textBoxApellido.MaxLength = 255;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(117, 20);
            this.textBoxApellido.TabIndex = 2;
            // 
            // labelTipoDoc
            // 
            this.labelTipoDoc.AutoSize = true;
            this.labelTipoDoc.Location = new System.Drawing.Point(11, 60);
            this.labelTipoDoc.Name = "labelTipoDoc";
            this.labelTipoDoc.Size = new System.Drawing.Size(99, 13);
            this.labelTipoDoc.TabIndex = 4;
            this.labelTipoDoc.Text = "Tipo de documento";
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "CI",
            "LC",
            "LD"});
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(14, 76);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(117, 21);
            this.comboBoxTipoDoc.TabIndex = 5;
            this.comboBoxTipoDoc.Text = "Seleccione tipo...";
            // 
            // labelNroDoc
            // 
            this.labelNroDoc.AutoSize = true;
            this.labelNroDoc.Location = new System.Drawing.Point(150, 60);
            this.labelNroDoc.Name = "labelNroDoc";
            this.labelNroDoc.Size = new System.Drawing.Size(102, 13);
            this.labelNroDoc.TabIndex = 7;
            this.labelNroDoc.Text = "Numero Documento";
            // 
            // textBoxNroDoc
            // 
            this.textBoxNroDoc.Location = new System.Drawing.Point(148, 77);
            this.textBoxNroDoc.MaxLength = 8;
            this.textBoxNroDoc.Name = "textBoxNroDoc";
            this.textBoxNroDoc.Size = new System.Drawing.Size(117, 20);
            this.textBoxNroDoc.TabIndex = 6;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(11, 112);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(52, 13);
            this.labelDireccion.TabIndex = 9;
            this.labelDireccion.Text = "Dirección";
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(14, 128);
            this.textBoxDireccion.MaxLength = 255;
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(117, 20);
            this.textBoxDireccion.TabIndex = 8;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(145, 112);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(49, 13);
            this.labelTel.TabIndex = 11;
            this.labelTel.Text = "Telefono";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(148, 128);
            this.textBoxTelefono.MaxLength = 18;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(117, 20);
            this.textBoxTelefono.TabIndex = 10;
            // 
            // labelSexo
            // 
            this.labelSexo.AutoSize = true;
            this.labelSexo.Location = new System.Drawing.Point(12, 156);
            this.labelSexo.Name = "labelSexo";
            this.labelSexo.Size = new System.Drawing.Size(31, 13);
            this.labelSexo.TabIndex = 13;
            this.labelSexo.Text = "Sexo";
            // 
            // selecFem
            // 
            this.selecFem.AutoSize = true;
            this.selecFem.Location = new System.Drawing.Point(15, 173);
            this.selecFem.Name = "selecFem";
            this.selecFem.Size = new System.Drawing.Size(71, 17);
            this.selecFem.TabIndex = 11;
            this.selecFem.TabStop = true;
            this.selecFem.Text = "Femenino";
            this.selecFem.UseVisualStyleBackColor = true;
            this.selecFem.CheckedChanged += new System.EventHandler(this.selecFem_CheckedChanged);
            // 
            // selecMasc
            // 
            this.selecMasc.AutoSize = true;
            this.selecMasc.Location = new System.Drawing.Point(112, 173);
            this.selecMasc.Name = "selecMasc";
            this.selecMasc.Size = new System.Drawing.Size(73, 17);
            this.selecMasc.TabIndex = 12;
            this.selecMasc.TabStop = true;
            this.selecMasc.Text = "Masculino";
            this.selecMasc.UseVisualStyleBackColor = true;
            this.selecMasc.CheckedChanged += new System.EventHandler(this.selecMasc_CheckedChanged);
            // 
            // selecEstadoCivil
            // 
            this.selecEstadoCivil.FormattingEnabled = true;
            this.selecEstadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divorciado/a"});
            this.selecEstadoCivil.Location = new System.Drawing.Point(20, 254);
            this.selecEstadoCivil.Name = "selecEstadoCivil";
            this.selecEstadoCivil.Size = new System.Drawing.Size(106, 21);
            this.selecEstadoCivil.TabIndex = 14;
            this.selecEstadoCivil.SelectedIndexChanged += new System.EventHandler(this.selecEstadoCivil_SelectedIndexChanged_1);
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(17, 238);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(62, 13);
            this.labelEstadoCivil.TabIndex = 16;
            this.labelEstadoCivil.Text = "Estado Civil";
            // 
            // selecPlan
            // 
            this.selecPlan.FormattingEnabled = true;
            this.selecPlan.Location = new System.Drawing.Point(135, 254);
            this.selecPlan.Name = "selecPlan";
            this.selecPlan.Size = new System.Drawing.Size(124, 21);
            this.selecPlan.TabIndex = 15;
            this.selecPlan.Text = "Escoga un plan...";
            // 
            // labelSelecPlan
            // 
            this.labelSelecPlan.AutoSize = true;
            this.labelSelecPlan.Location = new System.Drawing.Point(132, 238);
            this.labelSelecPlan.Name = "labelSelecPlan";
            this.labelSelecPlan.Size = new System.Drawing.Size(87, 13);
            this.labelSelecPlan.TabIndex = 18;
            this.labelSelecPlan.Text = "Seleccionar Plan";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(186, 339);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 19;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(98, 339);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 21;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // labelFechaNac
            // 
            this.labelFechaNac.AutoSize = true;
            this.labelFechaNac.Location = new System.Drawing.Point(15, 204);
            this.labelFechaNac.Name = "labelFechaNac";
            this.labelFechaNac.Size = new System.Drawing.Size(106, 13);
            this.labelFechaNac.TabIndex = 23;
            this.labelFechaNac.Text = "Fecha de nacimiento";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(10, 339);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 20;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // checkBoxHijos
            // 
            this.checkBoxHijos.AutoSize = true;
            this.checkBoxHijos.Location = new System.Drawing.Point(20, 297);
            this.checkBoxHijos.Name = "checkBoxHijos";
            this.checkBoxHijos.Size = new System.Drawing.Size(117, 17);
            this.checkBoxHijos.TabIndex = 16;
            this.checkBoxHijos.Text = "Familiares a cargo?";
            this.checkBoxHijos.UseVisualStyleBackColor = true;
            this.checkBoxHijos.CheckedChanged += new System.EventHandler(this.checkBoxHijos_CheckedChanged);
            // 
            // labelCantHijos
            // 
            this.labelCantHijos.AutoSize = true;
            this.labelCantHijos.Location = new System.Drawing.Point(143, 298);
            this.labelCantHijos.Name = "labelCantHijos";
            this.labelCantHijos.Size = new System.Drawing.Size(49, 13);
            this.labelCantHijos.TabIndex = 29;
            this.labelCantHijos.Text = "Cantidad";
            // 
            // textBoxCantHijos
            // 
            this.textBoxCantHijos.Enabled = false;
            this.textBoxCantHijos.Location = new System.Drawing.Point(202, 295);
            this.textBoxCantHijos.MaxLength = 2;
            this.textBoxCantHijos.Name = "textBoxCantHijos";
            this.textBoxCantHijos.Size = new System.Drawing.Size(38, 20);
            this.textBoxCantHijos.TabIndex = 17;
            // 
            // selectorFecha
            // 
            this.selectorFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.selectorFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectorFecha.Checked = false;
            this.selectorFecha.CustomFormat = "";
            this.selectorFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.selectorFecha.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.selectorFecha.Location = new System.Drawing.Point(135, 202);
            this.selectorFecha.Margin = new System.Windows.Forms.Padding(5);
            this.selectorFecha.MaxDate = new System.DateTime(2016, 11, 2, 0, 0, 0, 0);
            this.selectorFecha.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.selectorFecha.Name = "selectorFecha";
            this.selectorFecha.RightToLeftLayout = true;
            this.selectorFecha.Size = new System.Drawing.Size(130, 20);
            this.selectorFecha.TabIndex = 13;
            this.selectorFecha.Value = new System.DateTime(2016, 10, 26, 0, 0, 0, 0);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(276, 378);
            this.Controls.Add(this.selectorFecha);
            this.Controls.Add(this.textBoxCantHijos);
            this.Controls.Add(this.labelCantHijos);
            this.Controls.Add(this.checkBoxHijos);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelFechaNac);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.selecPlan);
            this.Controls.Add(this.labelSelecPlan);
            this.Controls.Add(this.selecEstadoCivil);
            this.Controls.Add(this.labelEstadoCivil);
            this.Controls.Add(this.selecMasc);
            this.Controls.Add(this.selecFem);
            this.Controls.Add(this.labelSexo);
            this.Controls.Add(this.labelTel);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.labelNroDoc);
            this.Controls.Add(this.textBoxNroDoc);
            this.Controls.Add(this.comboBoxTipoDoc);
            this.Controls.Add(this.labelTipoDoc);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.textBoxNombre);
            this.MaximizeBox = false;
            this.Name = "Alta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta";
            this.Load += new System.EventHandler(this.Alta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox textBoxNombre;
        protected System.Windows.Forms.Label labelNombre;
        protected System.Windows.Forms.Label labelApellido;
        protected System.Windows.Forms.TextBox textBoxApellido;
        protected System.Windows.Forms.Label labelTipoDoc;
        protected System.Windows.Forms.ComboBox comboBoxTipoDoc;
        protected System.Windows.Forms.Label labelNroDoc;
        protected System.Windows.Forms.TextBox textBoxNroDoc;
        protected System.Windows.Forms.Label labelDireccion;
        protected System.Windows.Forms.TextBox textBoxDireccion;
        protected System.Windows.Forms.Label labelTel;
        protected System.Windows.Forms.TextBox textBoxTelefono;
        protected System.Windows.Forms.Label labelSexo;
        protected System.Windows.Forms.RadioButton selecFem;
        protected System.Windows.Forms.RadioButton selecMasc;
        protected System.Windows.Forms.ComboBox selecEstadoCivil;
        protected System.Windows.Forms.Label labelEstadoCivil;
        protected System.Windows.Forms.ComboBox selecPlan;
        protected System.Windows.Forms.Label labelSelecPlan;
        protected System.Windows.Forms.Button AceptarButton;
        protected System.Windows.Forms.Button botonLimpiar;
        protected System.Windows.Forms.Label labelFechaNac;
        protected System.Windows.Forms.Button botonCancelar;
        protected System.Windows.Forms.CheckBox checkBoxHijos;
        protected System.Windows.Forms.Label labelCantHijos;
        protected System.Windows.Forms.TextBox textBoxCantHijos;
        protected System.Windows.Forms.DateTimePicker selectorFecha;
    }
}