namespace ClinicaFrba.AbmRol {
    partial class RolBaja {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listRoles = new System.Windows.Forms.ListBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listRoles
            // 
            this.listRoles.FormattingEnabled = true;
            this.listRoles.Location = new System.Drawing.Point(12, 35);
            this.listRoles.Name = "listRoles";
            this.listRoles.Size = new System.Drawing.Size(156, 186);
            this.listRoles.TabIndex = 0;
            this.listRoles.SelectedIndexChanged += new System.EventHandler(this.listRoles_SelectedIndexChanged);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(93, 227);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 1;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(12, 227);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 2;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccionar rol a eliminar:";
            // 
            // RolBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.listRoles);
            this.Name = "RolBaja";
            this.Text = "Baja de Rol";
            this.Load += new System.EventHandler(this.RolBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listRoles;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
    }
}