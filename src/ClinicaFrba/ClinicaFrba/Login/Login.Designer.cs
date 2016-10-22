namespace ClinicaFrba
{
    partial class Login
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
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textContrasenia = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelContrasenia = new System.Windows.Forms.Label();
            this.botonIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN - Clinica FRBA";
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(138, 85);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(100, 20);
            this.textUsuario.TabIndex = 1;
            // 
            // textContrasenia
            // 
            this.textContrasenia.Location = new System.Drawing.Point(138, 124);
            this.textContrasenia.Name = "textContrasenia";
            this.textContrasenia.Size = new System.Drawing.Size(100, 20);
            this.textContrasenia.TabIndex = 2;
            this.textContrasenia.UseSystemPasswordChar = true;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(27, 85);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 3;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelContrasenia
            // 
            this.labelContrasenia.AutoSize = true;
            this.labelContrasenia.Location = new System.Drawing.Point(30, 124);
            this.labelContrasenia.Name = "labelContrasenia";
            this.labelContrasenia.Size = new System.Drawing.Size(61, 13);
            this.labelContrasenia.TabIndex = 4;
            this.labelContrasenia.Text = "Contraseña";
            // 
            // botonIngresar
            // 
            this.botonIngresar.Location = new System.Drawing.Point(152, 178);
            this.botonIngresar.Name = "botonIngresar";
            this.botonIngresar.Size = new System.Drawing.Size(75, 23);
            this.botonIngresar.TabIndex = 5;
            this.botonIngresar.Text = "Ingresar";
            this.botonIngresar.UseVisualStyleBackColor = true;
            this.botonIngresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.botonIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(369, 229);
            this.Controls.Add(this.botonIngresar);
            this.Controls.Add(this.labelContrasenia);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textContrasenia);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textContrasenia;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelContrasenia;
        private System.Windows.Forms.Button botonIngresar;
    }
}