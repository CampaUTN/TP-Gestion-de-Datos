namespace ClinicaFrba.Abm_Afiliado
{
    partial class Alta
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.labelTipoDoc = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.labelNroDoc = new System.Windows.Forms.Label();
            this.textBoxNroDoc = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelSexo = new System.Windows.Forms.Label();
            this.selecFem = new System.Windows.Forms.RadioButton();
            this.selecMasc = new System.Windows.Forms.RadioButton();
            this.selecEstadoCivil = new System.Windows.Forms.ComboBox();
            this.labelEstadoCivil = new System.Windows.Forms.Label();
            this.selecPlan = new System.Windows.Forms.ComboBox();
            this.labelSelecPlan = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.labelFechaNac = new System.Windows.Forms.Label();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.comboBoxDia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(22, 26);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(106, 20);
            this.textBoxNombre.TabIndex = 0;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(19, 10);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(54, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre/s";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(164, 10);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(54, 13);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "Apellido/s";
            this.labelApellido.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(167, 26);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(106, 20);
            this.textBoxApellido.TabIndex = 2;
            this.textBoxApellido.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // labelTipoDoc
            // 
            this.labelTipoDoc.AutoSize = true;
            this.labelTipoDoc.Location = new System.Drawing.Point(19, 60);
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
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(22, 76);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(106, 21);
            this.comboBoxTipoDoc.TabIndex = 5;
            this.comboBoxTipoDoc.Text = "Seleccione tipo...";
            // 
            // labelNroDoc
            // 
            this.labelNroDoc.AutoSize = true;
            this.labelNroDoc.Location = new System.Drawing.Point(164, 61);
            this.labelNroDoc.Name = "labelNroDoc";
            this.labelNroDoc.Size = new System.Drawing.Size(102, 13);
            this.labelNroDoc.TabIndex = 7;
            this.labelNroDoc.Text = "Numero Documento";
            // 
            // textBoxNroDoc
            // 
            this.textBoxNroDoc.Location = new System.Drawing.Point(167, 77);
            this.textBoxNroDoc.Name = "textBoxNroDoc";
            this.textBoxNroDoc.Size = new System.Drawing.Size(106, 20);
            this.textBoxNroDoc.TabIndex = 6;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(19, 112);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(52, 13);
            this.labelDireccion.TabIndex = 9;
            this.labelDireccion.Text = "Dirección";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 128);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 8;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(164, 112);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(49, 13);
            this.labelTel.TabIndex = 11;
            this.labelTel.Text = "Telefono";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(106, 20);
            this.textBox2.TabIndex = 10;
            // 
            // labelSexo
            // 
            this.labelSexo.AutoSize = true;
            this.labelSexo.Location = new System.Drawing.Point(19, 162);
            this.labelSexo.Name = "labelSexo";
            this.labelSexo.Size = new System.Drawing.Size(31, 13);
            this.labelSexo.TabIndex = 13;
            this.labelSexo.Text = "Sexo";
            // 
            // selecFem
            // 
            this.selecFem.AutoSize = true;
            this.selecFem.Location = new System.Drawing.Point(22, 179);
            this.selecFem.Name = "selecFem";
            this.selecFem.Size = new System.Drawing.Size(71, 17);
            this.selecFem.TabIndex = 14;
            this.selecFem.TabStop = true;
            this.selecFem.Text = "Femenino";
            this.selecFem.UseVisualStyleBackColor = true;
            this.selecFem.CheckedChanged += new System.EventHandler(this.selecFem_CheckedChanged);
            // 
            // selecMasc
            // 
            this.selecMasc.AutoSize = true;
            this.selecMasc.Location = new System.Drawing.Point(119, 179);
            this.selecMasc.Name = "selecMasc";
            this.selecMasc.Size = new System.Drawing.Size(73, 17);
            this.selecMasc.TabIndex = 15;
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
            this.selecEstadoCivil.Location = new System.Drawing.Point(22, 284);
            this.selecEstadoCivil.Name = "selecEstadoCivil";
            this.selecEstadoCivil.Size = new System.Drawing.Size(100, 21);
            this.selecEstadoCivil.TabIndex = 17;
            // 
            // labelEstadoCivil
            // 
            this.labelEstadoCivil.AutoSize = true;
            this.labelEstadoCivil.Location = new System.Drawing.Point(19, 268);
            this.labelEstadoCivil.Name = "labelEstadoCivil";
            this.labelEstadoCivil.Size = new System.Drawing.Size(62, 13);
            this.labelEstadoCivil.TabIndex = 16;
            this.labelEstadoCivil.Text = "Estado Civil";
            // 
            // selecPlan
            // 
            this.selecPlan.FormattingEnabled = true;
            this.selecPlan.Items.AddRange(new object[] {
            "DNI"});
            this.selecPlan.Location = new System.Drawing.Point(22, 334);
            this.selecPlan.Name = "selecPlan";
            this.selecPlan.Size = new System.Drawing.Size(106, 21);
            this.selecPlan.TabIndex = 19;
            this.selecPlan.Text = "Escoga un plan...";
            // 
            // labelSelecPlan
            // 
            this.labelSelecPlan.AutoSize = true;
            this.labelSelecPlan.Location = new System.Drawing.Point(19, 318);
            this.labelSelecPlan.Name = "labelSelecPlan";
            this.labelSelecPlan.Size = new System.Drawing.Size(87, 13);
            this.labelSelecPlan.TabIndex = 18;
            this.labelSelecPlan.Text = "Seleccionar Plan";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(198, 376);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 20;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(22, 376);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 21;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comboBoxMes.Location = new System.Drawing.Point(104, 230);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(88, 21);
            this.comboBoxMes.TabIndex = 22;
            this.comboBoxMes.Text = "Mes";
            // 
            // labelFechaNac
            // 
            this.labelFechaNac.AutoSize = true;
            this.labelFechaNac.Location = new System.Drawing.Point(22, 214);
            this.labelFechaNac.Name = "labelFechaNac";
            this.labelFechaNac.Size = new System.Drawing.Size(106, 13);
            this.labelFechaNac.TabIndex = 23;
            this.labelFechaNac.Text = "Fecha de nacimiento";
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(22, 230);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(64, 21);
            this.comboBoxAnio.TabIndex = 24;
            this.comboBoxAnio.Text = "Año";
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Location = new System.Drawing.Point(202, 230);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(71, 21);
            this.comboBoxDia.TabIndex = 25;
            this.comboBoxDia.Text = "Dia";
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 417);
            this.Controls.Add(this.comboBoxDia);
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.labelFechaNac);
            this.Controls.Add(this.comboBoxMes);
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
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelNroDoc);
            this.Controls.Add(this.textBoxNroDoc);
            this.Controls.Add(this.comboBoxTipoDoc);
            this.Controls.Add(this.labelTipoDoc);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "Alta";
            this.Text = "Alta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label labelTipoDoc;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.Label labelNroDoc;
        private System.Windows.Forms.TextBox textBoxNroDoc;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelSexo;
        private System.Windows.Forms.RadioButton selecFem;
        private System.Windows.Forms.RadioButton selecMasc;
        private System.Windows.Forms.ComboBox selecEstadoCivil;
        private System.Windows.Forms.Label labelEstadoCivil;
        private System.Windows.Forms.ComboBox selecPlan;
        private System.Windows.Forms.Label labelSelecPlan;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.Label labelFechaNac;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.ComboBox comboBoxDia;
    }
}