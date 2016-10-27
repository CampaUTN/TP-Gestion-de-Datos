namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaUsuario
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelNombreUsuario = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxPassConfirm = new System.Windows.Forms.TextBox();
            this.labelPassConfirm = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 31);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(130, 20);
            this.textBoxUsername.TabIndex = 0;
            // 
            // labelNombreUsuario
            // 
            this.labelNombreUsuario.AutoSize = true;
            this.labelNombreUsuario.Location = new System.Drawing.Point(12, 12);
            this.labelNombreUsuario.Name = "labelNombreUsuario";
            this.labelNombreUsuario.Size = new System.Drawing.Size(96, 13);
            this.labelNombreUsuario.TabIndex = 1;
            this.labelNombreUsuario.Text = "Nombre de usuario";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(12, 103);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(109, 13);
            this.labelPass.TabIndex = 2;
            this.labelPass.Text = "Escriba la contraseña";
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(131, 211);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botonConfirmar.TabIndex = 4;
            this.botonConfirmar.Text = "Confirmar";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(12, 119);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(152, 20);
            this.textBoxPass.TabIndex = 2;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // textBoxPassConfirm
            // 
            this.textBoxPassConfirm.Location = new System.Drawing.Point(12, 174);
            this.textBoxPassConfirm.Name = "textBoxPassConfirm";
            this.textBoxPassConfirm.Size = new System.Drawing.Size(152, 20);
            this.textBoxPassConfirm.TabIndex = 3;
            this.textBoxPassConfirm.UseSystemPasswordChar = true;
            // 
            // labelPassConfirm
            // 
            this.labelPassConfirm.AutoSize = true;
            this.labelPassConfirm.Location = new System.Drawing.Point(15, 155);
            this.labelPassConfirm.Name = "labelPassConfirm";
            this.labelPassConfirm.Size = new System.Drawing.Size(115, 13);
            this.labelPassConfirm.TabIndex = 6;
            this.labelPassConfirm.Text = "Confirme la contraseña";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(15, 74);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(127, 20);
            this.textBoxMail.TabIndex = 1;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(13, 58);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(109, 13);
            this.labelMail.TabIndex = 8;
            this.labelMail.Text = "Igrese mail (opcional):";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(12, 211);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 9;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 249);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.labelPassConfirm);
            this.Controls.Add(this.textBoxPassConfirm);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelNombreUsuario);
            this.Controls.Add(this.textBoxUsername);
            this.MaximizeBox = false;
            this.Name = "AltaUsuario";
            this.Text = "Alta Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxPassConfirm;
        private System.Windows.Forms.Label labelPassConfirm;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Button botonCancelar;
    }
}