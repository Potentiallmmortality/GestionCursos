namespace UIs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            this.InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuarioCorrecto = "admin";
            string passCorrecto = "1234";

            if (this.txtUsuario.Text == usuarioCorrecto && this.txtPassword.Text == passCorrecto)
            {
                MessageBox.Show("Usuario correcto", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMenuPrincipal menu = new frmMenuPrincipal();
                this.Hide(); 
                menu.ShowDialog(); 
                string rutaCursos = "cursos.json";
                string rutaInstructores = "instructores.json";
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
