namespace UIs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Negocio.InterfacesNegocio;
    using Negocio.SerivicioActores;
    using Negocio.SeriviciosCompuestos;

    public partial class frmMenuPrincipal : Form
    {
        private IRepActores<Estudiante> repEstudiantes;
        private IRepActores<Instructor> repInstructores;
        private IRepCursos repCursos;
        private IRepReservas repReservas;

        private IEvents eventLogger;


        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.repEstudiantes = new RepEstudiantes("..\\directorioPrueba\\estudiantes.json");
            this.repInstructores = new RepInstructores("..\\directorioPrueba\\instructores.json");
            this.repCursos = new RepCursos("..\\directorioPrueba\\cursos.json");
            this.eventLogger = new EventLogger("..\\directorioPrueba\\logs.txt");
            this.RecuperarRelaciones();
        }

        private void RecuperarRelaciones()
        {
            ServicioDatos servicioDatos = new ServicioDatos(this.repReservas, this.repCursos, this.repEstudiantes, this.repInstructores);
            servicioDatos.CargarRepositorios();
        }

        private void btnGestionEstudiantes_Click(object sender, EventArgs e)
        {
            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
            frmGestionEstudiantes frm = new frmGestionEstudiantes(servicioEstudiantes);
            frm.ShowDialog();
        }

        private void btnGestionCursos_Click(object sender, EventArgs e)
        {
            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores, repEstudiantes);
            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
            FrmGestionCursos frm = new FrmGestionCursos(servicioCursos);
            frm.ShowDialog();
        }

        private void btnGestionInstructores_Click(object sender, EventArgs e)
        {
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
            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores, repEstudiantes);

            INegocioActores servicioEstudiantes = new ServicioEstudiantes(repEstudiantes);
        
            frmMatricula frm = new frmMatricula(servicioCursos, servicioEstudiantes, this.repEstudiantes, this.repCursos);
            frm.ShowDialog();

        }
    }
}