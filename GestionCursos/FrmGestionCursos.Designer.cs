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
            txtSalida = new TextBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(161, 95);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Location = new Point(161, 124);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtCupo
            // 
            txtCupo.BorderStyle = BorderStyle.FixedSingle;
            txtCupo.Location = new Point(161, 153);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 23);
            txtCupo.TabIndex = 2;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(90, 97);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(54, 15);
            lbl1.TabIndex = 3;
            lbl1.Text = "Nombre:";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(90, 126);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(49, 15);
            lbl2.TabIndex = 4;
            lbl2.Text = "Codigo:";
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(90, 155);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(39, 15);
            lbl3.TabIndex = 5;
            lbl3.Text = "Cupo:";
            // 
            // txtDniInstructor
            // 
            txtDniInstructor.BorderStyle = BorderStyle.FixedSingle;
            txtDniInstructor.Location = new Point(417, 95);
            txtDniInstructor.Name = "txtDniInstructor";
            txtDniInstructor.Size = new Size(100, 23);
            txtDniInstructor.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 101);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 7;
            label1.Text = "Dni Instructor";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(126, 224);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(126, 257);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(224, 224);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(224, 257);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 11;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(394, 147);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(75, 23);
            btnAsignar.TabIndex = 12;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // txtSalida
            // 
            txtSalida.Location = new Point(332, 224);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(185, 107);
            txtSalida.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-97, -41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(760, 496);
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
            panel1.Size = new Size(639, 54);
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
            button1.Location = new Point(571, 0);
            button1.Name = "button1";
            button1.Size = new Size(46, 45);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmGestionCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 409);
            Controls.Add(panel1);
            Controls.Add(txtSalida);
            Controls.Add(btnAsignar);
            Controls.Add(btnListar);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtDniInstructor);
            Controls.Add(lbl3);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Controls.Add(txtCupo);
            Controls.Add(txtCodigo);
            Controls.Add(txtNombre);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGestionCursos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmGestionCursos";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
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
        private TextBox txtSalida;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button2;
        private Button button1;
    }
}