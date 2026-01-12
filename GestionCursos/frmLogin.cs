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
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Credenciales "de fábrica" (Hardcoded)
            string usuarioCorrecto = "admin";
            string passCorrecto = "1234";

            if (txtUsuario.Text == usuarioCorrecto && txtPassword.Text == passCorrecto)
            {
                // Pantalla emergente
                MessageBox.Show("Usuario correcto", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el menú principal
                frmMenuPrincipal menu = new frmMenuPrincipal();
                this.Hide(); // Ocultamos el login
                menu.ShowDialog(); // Mostramos el menú
                string rutaCursos = "cursos.json";
                string rutaInstructores = "instructores.json";

                // Al cerrar el menú, cerramos la aplicación completa para que no quede en memoria
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
