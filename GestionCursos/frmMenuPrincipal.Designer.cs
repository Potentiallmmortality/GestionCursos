namespace UIs
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            btnGestionEstudiantes = new Button();
            btnGestionInstructores = new Button();
            btnGestionCursos = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnMatricular = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGestionEstudiantes
            // 
            btnGestionEstudiantes.Image = (Image)resources.GetObject("btnGestionEstudiantes.Image");
            btnGestionEstudiantes.Location = new Point(45, 90);
            btnGestionEstudiantes.Name = "btnGestionEstudiantes";
            btnGestionEstudiantes.Size = new Size(276, 101);
            btnGestionEstudiantes.TabIndex = 0;
            btnGestionEstudiantes.Text = "\r\n";
            btnGestionEstudiantes.UseVisualStyleBackColor = true;
            btnGestionEstudiantes.Click += btnGestionEstudiantes_Click;
            // 
            // btnGestionInstructores
            // 
            btnGestionInstructores.Image = (Image)resources.GetObject("btnGestionInstructores.Image");
            btnGestionInstructores.Location = new Point(383, 90);
            btnGestionInstructores.Name = "btnGestionInstructores";
            btnGestionInstructores.Size = new Size(276, 98);
            btnGestionInstructores.TabIndex = 1;
            btnGestionInstructores.UseVisualStyleBackColor = true;
            btnGestionInstructores.Click += btnGestionInstructores_Click;
            // 
            // btnGestionCursos
            // 
            btnGestionCursos.Image = (Image)resources.GetObject("btnGestionCursos.Image");
            btnGestionCursos.Location = new Point(45, 233);
            btnGestionCursos.Name = "btnGestionCursos";
            btnGestionCursos.Size = new Size(276, 99);
            btnGestionCursos.TabIndex = 2;
            btnGestionCursos.UseVisualStyleBackColor = true;
            btnGestionCursos.Click += btnGestionCursos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(726, 54);
            panel1.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 6);
            button2.Name = "button2";
            button2.Size = new Size(183, 45);
            button2.TabIndex = 6;
            button2.Text = "Gestion de Cursos";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(661, 3);
            button1.Name = "button1";
            button1.Size = new Size(46, 45);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-73, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(831, 421);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // btnMatricular
            // 
            btnMatricular.Image = (Image)resources.GetObject("btnMatricular.Image");
            btnMatricular.Location = new Point(383, 234);
            btnMatricular.Name = "btnMatricular";
            btnMatricular.Size = new Size(276, 98);
            btnMatricular.TabIndex = 14;
            btnMatricular.UseVisualStyleBackColor = true;
            btnMatricular.Click += btnMatricular_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 372);
            Controls.Add(btnMatricular);
            Controls.Add(panel1);
            Controls.Add(btnGestionCursos);
            Controls.Add(btnGestionInstructores);
            Controls.Add(btnGestionEstudiantes);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMenuPrincipal";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGestionEstudiantes;
        private Button btnGestionInstructores;
        private Button btnGestionCursos;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private Button btnMatricular;
    }
}