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
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Negocio.InterfacesNegocio;
    using Negocio.SerivicioActores;

    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnGestionEstudiantes_Click(object sender, EventArgs e)
        {
            frmGestionEstudiantes formEst = new frmGestionEstudiantes();
            formEst.ShowDialog();
        }

        private void btnGestionCursos_Click(object sender, EventArgs e)
        {
            string rutaCursos = "cursos.json";
            string rutaInstructores = "instructores.json";
            IRepCursos repCursos = new RepCursos(rutaCursos);
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);
            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores);
            FrmGestionCursos frm = new FrmGestionCursos(servicioCursos);
            frm.ShowDialog();
        }

        private void btnGestionInstructores_Click(object sender, EventArgs e)
        {
            string rutaInstructores = "instructores.json";
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);
            INegocioActores servicioInstructores = new ServicioInstructores(repInstructores);
            FrmGestionInstructores frm = new FrmGestionInstructores(servicioInstructores);
            frm.ShowDialog();
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //aumnetar codigo si es necesario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal.ActiveForm.Close();   
        }
    }
}