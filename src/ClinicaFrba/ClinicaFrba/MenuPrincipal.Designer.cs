﻿namespace ClinicaFrba
{
    partial class MenuPrincipal
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
            this.listFuncionalidades = new System.Windows.Forms.ListBox();
            this.botonSeleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listFuncionalidades
            // 
            this.listFuncionalidades.FormattingEnabled = true;
            this.listFuncionalidades.Location = new System.Drawing.Point(51, 66);
            this.listFuncionalidades.Name = "listFuncionalidades";
            this.listFuncionalidades.Size = new System.Drawing.Size(405, 108);
            this.listFuncionalidades.TabIndex = 0;
            // 
            // botonSeleccionar
            // 
            this.botonSeleccionar.Location = new System.Drawing.Point(368, 209);
            this.botonSeleccionar.Name = "botonSeleccionar";
            this.botonSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.botonSeleccionar.TabIndex = 1;
            this.botonSeleccionar.Text = "Seleccionar";
            this.botonSeleccionar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elija una funcionalidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonSeleccionar);
            this.Controls.Add(this.listFuncionalidades);
            this.Name = "MenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFuncionalidades;
        private System.Windows.Forms.Button botonSeleccionar;
        private System.Windows.Forms.Label label1;
    }
}