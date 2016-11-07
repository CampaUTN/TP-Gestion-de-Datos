namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.grillaProfesionales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botonListar = new System.Windows.Forms.Button();
            this.textEspecialidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.botonSeleccionar = new System.Windows.Forms.Button();
            this.botonSalir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textAfiliado = new System.Windows.Forms.TextBox();
            this.botonSelecAfil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaProfesionales
            // 
            this.grillaProfesionales.AllowUserToAddRows = false;
            this.grillaProfesionales.AllowUserToDeleteRows = false;
            this.grillaProfesionales.AllowUserToResizeColumns = false;
            this.grillaProfesionales.AllowUserToResizeRows = false;
            this.grillaProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaProfesionales.Location = new System.Drawing.Point(48, 149);
            this.grillaProfesionales.Name = "grillaProfesionales";
            this.grillaProfesionales.ShowEditingIcon = false;
            this.grillaProfesionales.Size = new System.Drawing.Size(538, 188);
            this.grillaProfesionales.TabIndex = 0;
            this.grillaProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaProfesionales_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.45F);
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedido de Turnos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(45, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtro nombre especialidad";
            // 
            // botonListar
            // 
            this.botonListar.Location = new System.Drawing.Point(243, 76);
            this.botonListar.Name = "botonListar";
            this.botonListar.Size = new System.Drawing.Size(88, 47);
            this.botonListar.TabIndex = 3;
            this.botonListar.Text = "Listar Profesionales";
            this.botonListar.UseVisualStyleBackColor = true;
            this.botonListar.Click += new System.EventHandler(this.botonListar_Click);
            // 
            // textEspecialidad
            // 
            this.textEspecialidad.Location = new System.Drawing.Point(47, 103);
            this.textEspecialidad.Name = "textEspecialidad";
            this.textEspecialidad.Size = new System.Drawing.Size(172, 20);
            this.textEspecialidad.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(508, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione un profesional de la grilla para reservar turno. Puede filtrar los pro" +
    "fesionales por su especialidad";
            // 
            // botonSeleccionar
            // 
            this.botonSeleccionar.Location = new System.Drawing.Point(274, 361);
            this.botonSeleccionar.Name = "botonSeleccionar";
            this.botonSeleccionar.Size = new System.Drawing.Size(88, 38);
            this.botonSeleccionar.TabIndex = 6;
            this.botonSeleccionar.Text = "Seleccionar";
            this.botonSeleccionar.UseVisualStyleBackColor = true;
            this.botonSeleccionar.Click += new System.EventHandler(this.botonSeleccionar_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(568, 401);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(75, 23);
            this.botonSalir.TabIndex = 7;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(398, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Afiliado";
            // 
            // textAfiliado
            // 
            this.textAfiliado.Location = new System.Drawing.Point(401, 103);
            this.textAfiliado.Name = "textAfiliado";
            this.textAfiliado.Size = new System.Drawing.Size(152, 20);
            this.textAfiliado.TabIndex = 9;
            this.textAfiliado.TextChanged += new System.EventHandler(this.textAfiliado_TextChanged);
            // 
            // botonSelecAfil
            // 
            this.botonSelecAfil.Location = new System.Drawing.Point(568, 88);
            this.botonSelecAfil.Name = "botonSelecAfil";
            this.botonSelecAfil.Size = new System.Drawing.Size(75, 35);
            this.botonSelecAfil.TabIndex = 10;
            this.botonSelecAfil.Text = "Seleccionar Afiliado";
            this.botonSelecAfil.UseVisualStyleBackColor = true;
            this.botonSelecAfil.Click += new System.EventHandler(this.botonSelecAfil_Click);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.botonSelecAfil);
            this.Controls.Add(this.textAfiliado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.botonSeleccionar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEspecialidad);
            this.Controls.Add(this.botonListar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaProfesionales);
            this.Name = "PedirTurno";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaProfesionales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonListar;
        private System.Windows.Forms.TextBox textEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonSeleccionar;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAfiliado;
        private System.Windows.Forms.Button botonSelecAfil;
    }
}