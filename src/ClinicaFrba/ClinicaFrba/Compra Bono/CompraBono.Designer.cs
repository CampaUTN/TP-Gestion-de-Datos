namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
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
            this.label1 = new System.Windows.Forms.Label();
            this.textAfiliado = new System.Windows.Forms.TextBox();
            this.labelAfiliado = new System.Windows.Forms.Label();
            this.labelCantidad = new System.Windows.Forms.Label();
            this.contadorBonos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrecioFinal = new System.Windows.Forms.TextBox();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contadorBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compra de Bonos";
            // 
            // textAfiliado
            // 
            this.textAfiliado.Location = new System.Drawing.Point(27, 70);
            this.textAfiliado.Name = "textAfiliado";
            this.textAfiliado.Size = new System.Drawing.Size(123, 20);
            this.textAfiliado.TabIndex = 1;
            // 
            // labelAfiliado
            // 
            this.labelAfiliado.AutoSize = true;
            this.labelAfiliado.Location = new System.Drawing.Point(27, 51);
            this.labelAfiliado.Name = "labelAfiliado";
            this.labelAfiliado.Size = new System.Drawing.Size(41, 13);
            this.labelAfiliado.TabIndex = 2;
            this.labelAfiliado.Text = "Afiliado";
            // 
            // labelCantidad
            // 
            this.labelCantidad.AutoSize = true;
            this.labelCantidad.Location = new System.Drawing.Point(27, 110);
            this.labelCantidad.Name = "labelCantidad";
            this.labelCantidad.Size = new System.Drawing.Size(99, 13);
            this.labelCantidad.TabIndex = 3;
            this.labelCantidad.Text = "Cantidad a comprar";
            this.labelCantidad.Click += new System.EventHandler(this.labelCantidad_Click);
            // 
            // contadorBonos
            // 
            this.contadorBonos.Location = new System.Drawing.Point(30, 135);
            this.contadorBonos.Name = "contadorBonos";
            this.contadorBonos.Size = new System.Drawing.Size(120, 20);
            this.contadorBonos.TabIndex = 5;
            this.contadorBonos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Precio Final";
            // 
            // textPrecioFinal
            // 
            this.textPrecioFinal.Location = new System.Drawing.Point(286, 70);
            this.textPrecioFinal.Name = "textPrecioFinal";
            this.textPrecioFinal.ReadOnly = true;
            this.textPrecioFinal.Size = new System.Drawing.Size(85, 20);
            this.textPrecioFinal.TabIndex = 7;
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(398, 67);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botonConfirmar.TabIndex = 8;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(383, 150);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 9;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            // 
            // botonSeleccionar
            // 
            this.botonSeleccionar.Location = new System.Drawing.Point(167, 68);
            this.botonSeleccionar.Name = "botonSeleccionar";
            this.botonSeleccionar.Size = new System.Drawing.Size(71, 23);
            this.botonSeleccionar.TabIndex = 10;
            this.botonSeleccionar.Text = "Seleccionar";
            this.botonSeleccionar.UseVisualStyleBackColor = true;
            this.botonSeleccionar.Click += new System.EventHandler(this.botonSeleccionar_Click);
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 185);
            this.Controls.Add(this.botonSeleccionar);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.textPrecioFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contadorBonos);
            this.Controls.Add(this.labelCantidad);
            this.Controls.Add(this.labelAfiliado);
            this.Controls.Add(this.textAfiliado);
            this.Controls.Add(this.label1);
            this.Name = "CompraBono";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CompraBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contadorBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAfiliado;
        private System.Windows.Forms.Label labelAfiliado;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.NumericUpDown contadorBonos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrecioFinal;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonSeleccionar;
    }
}