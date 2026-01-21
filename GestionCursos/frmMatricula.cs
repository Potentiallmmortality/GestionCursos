using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio.InterfacesNegocio;
using Entidades.Stock;
using Entidades.Actores;
using System.Linq;
using Datos.Interfaces;
using Negocio.SerivicioActores;//importanteeeeee

namespace UIs 
{
    public partial class frmMatricula : Form
    {
        private readonly INegocioCursos _negocioCursos;
        private readonly INegocioActores _negocioEstudiantes;
        private readonly IRepActores<Estudiante> _repEstudiantes;
        private readonly IRepCursos _repCursos;

        public frmMatricula()
        {
            InitializeComponent();
        }

        public frmMatricula(INegocioCursos negocioCursos, INegocioActores negocioEstudiantes, IRepActores<Estudiante> repEstudiantes, IRepCursos repCursos)
        {
            InitializeComponent();
            this._negocioCursos = negocioCursos;
            this._negocioEstudiantes = negocioEstudiantes;
            this._repEstudiantes = repEstudiantes;
            this._repCursos = repCursos;
        }

        private void btnMatricular_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEstudiantes.SelectedValue == null || cmbCursos.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un Estudiante y un Curso.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string dniEstudiante = cmbEstudiantes.SelectedValue.ToString();
                string codigoCurso = cmbCursos.SelectedValue.ToString();
                var resultado = _negocioCursos.MatricularEstudiante(dniEstudiante, codigoCurso);
                var estudiante = _repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                var curso = _repCursos.BuscarPorIdentificacion(codigoCurso);

                if (resultado.Success)
                {
                    estudiante.agregarCurso(curso);
                    MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show(resultado.Message, "Error al Matricular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void CargarCombos()
        {
            try
            {
                var listaEstudiantes = _negocioEstudiantes.ObtenerListaReal();

                cmbEstudiantes.DataSource = null;
                cmbEstudiantes.DataSource = listaEstudiantes;
                cmbEstudiantes.DisplayMember = "Nombre";
                cmbEstudiantes.ValueMember = "Dni";

                var listaCursos = _negocioCursos.ObtenerListaReal();

                cmbCursos.DataSource = null;
                cmbCursos.DataSource = listaCursos;
                cmbCursos.DisplayMember = "Nombre";
                cmbCursos.ValueMember = "CodigoUnico";

                cmbEstudiantes.SelectedIndex = -1;
                cmbCursos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cmbEstudiantes.SelectedIndex = -1;
            cmbCursos.SelectedIndex = -1;
        }

        private void frmMatricula_Load_1(object sender, EventArgs e)
        {
            if (_negocioCursos != null && _negocioEstudiantes != null)
            {
                CargarCombos();
                ActualizarGrilla();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMatricula.ActiveForm.Close();
        }

        private void ActualizarGrilla()
        {
            try
            {
                var listaCursos = _negocioCursos.ObtenerListaReal();

                var listaVisual = listaCursos.Select(curso => new
                {
                    Materia = curso.Nombre,
                    Codigo = curso.CodigoUnico,
                    Cupo = $"{curso.EstudiantesInscritos.Count} / {curso.CupoMaximo}",
                    Alumnos_Inscritos = string.Join(", ", curso.EstudiantesInscritos.Select(e => e.Nombre))
                }).ToList();

                dgvMatriculas.DataSource = null;
                dgvMatriculas.DataSource = listaVisual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMatricula.ActiveForm.Close();    
        }
    }
}