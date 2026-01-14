namespace UIs
{
    partial class FrmGestionCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionCursos));
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            txtCupo = new TextBox();
            lbl1 = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            txtDniInstructor = new TextBox();
            label1 = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            btnListar = new Button();
            btnAsignar = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            dgvCursos = new DataGridView();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(94, 28);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Location = new Point(94, 57);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtCupo
            // 
            txtCupo.BorderStyle = BorderStyle.FixedSingle;
            txtCupo.Location = new Point(94, 86);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 23);
            txtCupo.TabIndex = 2;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(23, 30);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(54, 15);
            lbl1.TabIndex = 3;
            lbl1.Text = "Nombre:";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(23, 59);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(49, 15);
            lbl2.TabIndex = 4;
            lbl2.Text = "Codigo:";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(23, 88);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(39, 15);
            lbl3.TabIndex = 5;
            lbl3.Text = "Cupo:";
            // 
            // txtDniInstructor
            // 
            txtDniInstructor.BorderStyle = BorderStyle.FixedSingle;
            txtDniInstructor.Location = new Point(96, 19);
            txtDniInstructor.Name = "txtDniInstructor";
            txtDniInstructor.Size = new Size(100, 23);
            txtDniInstructor.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 7;
            label1.Text = "Dni Instructor";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(66, 131);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(50, 69);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(501, 469);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(58, 469);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 11;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(73, 71);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(75, 23);
            btnAsignar.TabIndex = 12;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-97, -41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(983, 659);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-3, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(851, 54);
            panel1.TabIndex = 15;
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
            button2.Text = "Gestionde Cursos";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.IndianRed;
            button1.Location = new Point(783, 0);
            button1.Name = "button1";
            button1.Size = new Size(46, 45);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAsignar);
            groupBox1.Controls.Add(txtDniInstructor);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(556, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 121);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asignar instructor a Curso";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Location = new Point(304, 109);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(219, 121);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Eliminar Curso";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 34);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 10;
            label4.Text = "Codigo:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbl1);
            groupBox3.Controls.Add(txtNombre);
            groupBox3.Controls.Add(txtCodigo);
            groupBox3.Controls.Add(txtCupo);
            groupBox3.Controls.Add(lbl2);
            groupBox3.Controls.Add(lbl3);
            groupBox3.Controls.Add(btnAgregar);
            groupBox3.Location = new Point(56, 109);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(214, 187);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agregar Cursi";
            // 
            // dgvCursos
            // 
            dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(58, 326);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(717, 128);
            dgvCursos.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(582, 469);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 21;
            textBox2.Text = "Dni";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmGestionCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 560);
            Controls.Add(textBox2);
            Controls.Add(dgvCursos);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(btnListar);
            Controls.Add(btnBuscar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGestionCursos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmGestionCursos";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtCodigo;
        private TextBox txtCupo;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private TextBox txtDniInstructor;
        private Label label1;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Button btnListar;
        private Button btnAsignar;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label4;
        private GroupBox groupBox3;
        private DataGridView dgvCursos;
        private TextBox textBox2;
    }
}