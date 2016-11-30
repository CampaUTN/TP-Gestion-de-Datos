namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroBono
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
            this.listaBonos = new System.Windows.Forms.DataGridView();
            this.botonSelecBono = new System.Windows.Forms.Button();
            this.labelSelecBono = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // listaBonos
            // 
            this.listaBonos.AllowUserToAddRows = false;
            this.listaBonos.AllowUserToDeleteRows = false;
            this.listaBonos.AllowUserToResizeColumns = false;
            this.listaBonos.AllowUserToResizeRows = false;
            this.listaBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaBonos.Location = new System.Drawing.Point(23, 25);
            this.listaBonos.Name = "listaBonos";
            this.listaBonos.ReadOnly = true;
            this.listaBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaBonos.Size = new System.Drawing.Size(492, 226);
            this.listaBonos.TabIndex = 0;
            this.listaBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaBonos_CellClick);
            // 
            // botonSelecBono
            // 
            this.botonSelecBono.Enabled = false;
            this.botonSelecBono.Location = new System.Drawing.Point(401, 257);
            this.botonSelecBono.Name = "botonSelecBono";
            this.botonSelecBono.Size = new System.Drawing.Size(116, 23);
            this.botonSelecBono.TabIndex = 1;
            this.botonSelecBono.Text = "Seleccionar Bono";
            this.botonSelecBono.UseVisualStyleBackColor = true;
            this.botonSelecBono.Click += new System.EventHandler(this.verAfil_Click);
            // 
            // labelSelecBono
            // 
            this.labelSelecBono.AutoSize = true;
            this.labelSelecBono.Location = new System.Drawing.Point(23, 9);
            this.labelSelecBono.Name = "labelSelecBono";
            this.labelSelecBono.Size = new System.Drawing.Size(102, 13);
            this.labelSelecBono.TabIndex = 2;
            this.labelSelecBono.Text = "Seleccione un bono";
            // 
            // botonCancelar
            // 
            this.botonCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(23, 257);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "<- Atrás";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // RegistroBono
            // 
            this.AcceptButton = this.botonSelecBono;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(533, 284);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelSelecBono);
            this.Controls.Add(this.botonSelecBono);
            this.Controls.Add(this.listaBonos);
            this.MaximizeBox = false;
            this.Name = "RegistroBono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Bono";
            this.Load += new System.EventHandler(this.RegistroBono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaBonos;
        private System.Windows.Forms.Button botonSelecBono;
        private System.Windows.Forms.Label labelSelecBono;
        private System.Windows.Forms.Button botonCancelar;
    }
}