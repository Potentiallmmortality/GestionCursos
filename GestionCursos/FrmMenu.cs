using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIs
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            FrmGestionEstudiantes form = new FrmGestionEstudiantes();
            form.ShowDialog();
        }

        private void btnInstructores_Click(object sender, EventArgs e)
        {
            FrmGestionInstructores form = new FrmGestionInstructores();
            form.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            FrmGestionCursos form = new FrmGestionCursos();
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
