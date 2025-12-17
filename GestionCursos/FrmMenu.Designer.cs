namespace UIs
{
    partial class FrmMenu
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
            btnEstudiantes = new Button();
            btnCursos = new Button();
            btnInstructores = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.Location = new Point(93, 41);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Size = new Size(133, 46);
            btnEstudiantes.TabIndex = 0;
            btnEstudiantes.Text = "Gestionar Estudiantes";
            btnEstudiantes.UseVisualStyleBackColor = true;
            btnEstudiantes.Click += btnEstudiantes_Click;
            // 
            // btnCursos
            // 
            btnCursos.Location = new Point(93, 145);
            btnCursos.Name = "btnCursos";
            btnCursos.Size = new Size(133, 51);
            btnCursos.TabIndex = 1;
            btnCursos.Text = "Gestionar Cursos";
            btnCursos.UseVisualStyleBackColor = true;
            btnCursos.Click += btnCursos_Click;
            // 
            // btnInstructores
            // 
            btnInstructores.Location = new Point(93, 93);
            btnInstructores.Name = "btnInstructores";
            btnInstructores.Size = new Size(133, 46);
            btnInstructores.TabIndex = 2;
            btnInstructores.Text = "Gestionar Instructores";
            btnInstructores.UseVisualStyleBackColor = true;
            btnInstructores.Click += btnInstructores_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(245, 236);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 304);
            Controls.Add(btnSalir);
            Controls.Add(btnInstructores);
            Controls.Add(btnCursos);
            Controls.Add(btnEstudiantes);
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEstudiantes;
        private Button btnCursos;
        private Button btnInstructores;
        private Button btnSalir;
    }
}