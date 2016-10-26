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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxPassConfirm = new System.Windows.Forms.TextBox();
            this.labelPassConfirm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 31);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(118, 20);
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
            this.labelPass.Location = new System.Drawing.Point(12, 64);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(109, 13);
            this.labelPass.TabIndex = 2;
            this.labelPass.Text = "Escriba la contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(12, 81);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(118, 20);
            this.textBoxPass.TabIndex = 4;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // textBoxPassConfirm
            // 
            this.textBoxPassConfirm.Location = new System.Drawing.Point(12, 135);
            this.textBoxPassConfirm.Name = "textBoxPassConfirm";
            this.textBoxPassConfirm.Size = new System.Drawing.Size(118, 20);
            this.textBoxPassConfirm.TabIndex = 5;
            this.textBoxPassConfirm.UseSystemPasswordChar = true;
            // 
            // labelPassConfirm
            // 
            this.labelPassConfirm.AutoSize = true;
            this.labelPassConfirm.Location = new System.Drawing.Point(15, 116);
            this.labelPassConfirm.Name = "labelPassConfirm";
            this.labelPassConfirm.Size = new System.Drawing.Size(115, 13);
            this.labelPassConfirm.TabIndex = 6;
            this.labelPassConfirm.Text = "Confirme la contraseña";
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 207);
            this.Controls.Add(this.labelPassConfirm);
            this.Controls.Add(this.textBoxPassConfirm);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelNombreUsuario);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "AltaUsuario";
            this.Text = "Alta Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxPassConfirm;
        private System.Windows.Forms.Label labelPassConfirm;
    }
}