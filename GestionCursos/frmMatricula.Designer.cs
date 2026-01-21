namespace UIs
{
    partial class frmMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatricula));
            groupBox1 = new GroupBox();
            cmbCursos = new ComboBox();
            cmbEstudiantes = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnMatricular = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            dgvMatriculas = new DataGridView();
            pictureBox2 = new PictureBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMatriculas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbCursos);
            groupBox1.Controls.Add(cmbEstudiantes);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnMatricular);
            groupBox1.Location = new Point(104, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 166);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Matricular Estudiante";
            // 
            // cmbCursos
            // 
            cmbCursos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCursos.FormattingEnabled = true;
            cmbCursos.Location = new Point(92, 65);
            cmbCursos.Name = "cmbCursos";
            cmbCursos.Size = new Size(183, 23);
            cmbCursos.TabIndex = 8;
            // 
            // cmbEstudiantes
            // 
            cmbEstudiantes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstudiantes.FormattingEnabled = true;
            cmbEstudiantes.Location = new Point(92, 25);
            cmbEstudiantes.Name = "cmbEstudiantes";
            cmbEstudiantes.Size = new Size(183, 23);
            cmbEstudiantes.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 28);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 3;
            label1.Text = "Estudiante";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 73);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 4;
            label2.Text = "Curso:";
            // 
            // btnMatricular
            // 
            btnMatricular.Location = new Point(107, 117);
            btnMatricular.Name = "btnMatricular";
            btnMatricular.Size = new Size(75, 23);
            btnMatricular.TabIndex = 6;
            btnMatricular.Text = "Matricular";
            btnMatricular.UseVisualStyleBackColor = true;
            btnMatricular.Click += btnMatricular_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-13, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 57);
            panel1.TabIndex = 24;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(16, 6);
            button2.Name = "button2";
            button2.Size = new Size(126, 45);
            button2.TabIndex = 6;
            button2.Text = "Matriculas";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(524, 5);
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
            pictureBox1.Location = new Point(-10, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(704, 560);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // dgvMatriculas
            // 
            dgvMatriculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriculas.Location = new Point(40, 304);
            dgvMatriculas.Name = "dgvMatriculas";
            dgvMatriculas.ReadOnly = true;
            dgvMatriculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriculas.Size = new Size(440, 150);
            dgvMatriculas.TabIndex = 26;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(511, 404);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // frmMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 493);
            Controls.Add(pictureBox2);
            Controls.Add(dgvMatriculas);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMatricula";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMatricula";
            Load += frmMatricula_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMatriculas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnMatricular;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private ComboBox cmbCursos;
        private ComboBox cmbEstudiantes;
        private DataGridView dgvMatriculas;
        private PictureBox pictureBox2;
    }
}