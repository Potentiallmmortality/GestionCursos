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
            rtbResultados = new RichTextBox();
            btnListar = new Button();
            btnAgregar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCupo = new TextBox();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // rtbResultados
            // 
            rtbResultados.Location = new Point(320, 22);
            rtbResultados.Name = "rtbResultados";
            rtbResultados.Size = new Size(287, 216);
            rtbResultados.TabIndex = 17;
            rtbResultados.Text = "";
            rtbResultados.TextChanged += rtbResultados_TextChanged;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(160, 215);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 16;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 215);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 127);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 14;
            label3.Text = "Cupo Maximo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 72);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 13;
            label2.Text = "ID Unico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 25);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 12;
            label1.Text = "Nombre del Curso";
            // 
            // txtCupo
            // 
            txtCupo.Location = new Point(135, 124);
            txtCupo.Name = "txtCupo";
            txtCupo.Size = new Size(100, 23);
            txtCupo.TabIndex = 11;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(135, 69);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 9;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(492, 256);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(115, 23);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "⬅ Volver al Menú";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmGestionCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 302);
            Controls.Add(btnVolver);
            Controls.Add(rtbResultados);
            Controls.Add(btnListar);
            Controls.Add(btnAgregar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCupo);
            Controls.Add(txtCodigo);
            Controls.Add(txtNombre);
            Name = "FrmGestionCursos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmGestionCursos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbResultados;
        private Button btnListar;
        private Button btnAgregar;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCupo;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private Button btnVolver;
    }
}