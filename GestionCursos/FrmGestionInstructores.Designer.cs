namespace UIs
{
    partial class FrmGestionInstructores
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
            txtEmail = new TextBox();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // rtbResultados
            // 
            rtbResultados.Location = new Point(332, 29);
            rtbResultados.Name = "rtbResultados";
            rtbResultados.Size = new Size(293, 216);
            rtbResultados.TabIndex = 17;
            rtbResultados.Text = "";
            // 
            // btnListar
            // 
            btnListar.Location = new Point(172, 222);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 16;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(32, 222);
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
            label3.Location = new Point(32, 134);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 14;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 79);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 13;
            label2.Text = "DNI";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 32);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(147, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(147, 76);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(147, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 9;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(510, 263);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(115, 23);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "⬅ Volver al Menú";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmGestionInstructores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 309);
            Controls.Add(btnVolver);
            Controls.Add(rtbResultados);
            Controls.Add(btnListar);
            Controls.Add(btnAgregar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtDni);
            Controls.Add(txtNombre);
            Name = "FrmGestionInstructores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmGestionInstructores";
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
        private TextBox txtEmail;
        private TextBox txtDni;
        private TextBox txtNombre;
        private Button btnVolver;
    }
}