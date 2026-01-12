namespace UIs
{
    using Datos.Interfaces;
    using Entidades.Actores;
    using Negocio.InterfacesNegocio;
    using Negocio.SerivicioActores;
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
            // 1. Rutas de archivos
            string rutaCursos = "cursos.json";
            string rutaInstructores = "instructores.json";

            // 2. Instanciamos los repositorios
            // Fíjate aquí: Para RepCursos y RepInstructores NO usamos < >
            IRepCursos repCursos = new RepCursos(rutaCursos);

            // CORRECCIÓN AQUÍ: Quitamos <Instructor> después del new RepInstructores
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);

            // 3. Instanciamos el Servicio (aquí sí recibe las interfaces)
            INegocioCursos servicioCursos = new ServicioCursos(repCursos, repInstructores);

            // 4. Abrimos el formulario
            FrmGestionCursos frm = new FrmGestionCursos(servicioCursos);
            frm.ShowDialog();
        }

        private void btnGestionInstructores_Click(object sender, EventArgs e)
        {
            string rutaInstructores = "instructores.json";
            // 1. Repositorio
            IRepActores<Instructor> repInstructores = new RepInstructores(rutaInstructores);

            // 2. Servicio
            // Si tu clase se llama ServicioInstructores y hereda de INegocioActores:
            INegocioActores servicioInstructores = new ServicioInstructores(repInstructores);

            // 3. Formulario (Ya no pide <Instructor>)
            FrmGestionInstructores frm = new FrmGestionInstructores(servicioInstructores);
            frm.ShowDialog();
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Opcional: Confirmar salida si es necesario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}