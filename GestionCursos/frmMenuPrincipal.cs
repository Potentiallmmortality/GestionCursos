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
            string rutaEstudiantes = "..\\directorioPrueba\\estudiantes.json";
            IRepActores<Estudiante> repEstudiantes = new RepEstudiantes(rutaEstudiantes);
            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
            frmGestionEstudiantes frm = new frmGestionEstudiantes(servicioEstudiantes);
            frm.ShowDialog();
        }

        private void btnGestionCursos_Click(object sender, EventArgs e)
        {
            string rutaCursos = "..\\directorioPrueba\\cursos.json";
            string rutaInstructores = "..\\directorioPrueba\\instructores.json";
            string rutaEstudiantes = "..\\directorioPrueba\\estudiantes.json";
            IRepCursos repCursos = new RepCursos(rutaCursos);
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);
            IRepActores<Estudiante> repEstudiantes = new RepEstudiantes(rutaEstudiantes);
            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores, repEstudiantes);
            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
            FrmGestionCursos frm = new FrmGestionCursos(servicioCursos);
            frm.ShowDialog();
        }

        private void btnGestionInstructores_Click(object sender, EventArgs e)
        {
            string rutaInstructores = "..\\directorioPrueba\\instructores.json";
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

        private void btnMatricular_Click(object sender, EventArgs e)
        {

            string rutaCursos = "..\\directorioPrueba\\cursos.json";
            string rutaInstructores = "..\\directorioPrueba\\instructores.json";
            string rutaEstudiantes = "..\\directorioPrueba\\estudiantes.json"; 

            IRepCursos repCursos = new RepCursos(rutaCursos);
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);
            IRepActores<Estudiante> repEstudiantes = new RepEstudiantes(rutaEstudiantes);

            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores, repEstudiantes);

            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
        
            frmMatricula frm = new frmMatricula(servicioCursos, servicioEstudiantes);
            frm.ShowDialog();

        }
    }
}