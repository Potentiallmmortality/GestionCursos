using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.SerivicioActores;
using Negocio.InterfacesNegocio;
using Datos.Clases_Repositorio;
using Entidades.Stock; // Para Curso

namespace UIs
{
    public partial class FrmGestionCursos : Form
    {
        private INegocioCursos _servicioCursos;

        public FrmGestionCursos()
        {
            InitializeComponent();

            // ATENCIÓN AQUÍ: Tu ServicioCursos pide 2 cosas: RepCursos y RepInstructores
            var repCursos = new RepCursos("cursos.json");
            var repInstructores = new RepInstructores("instructores.json");

            _servicioCursos = new ServicioCursos(repCursos, repInstructores);
            _servicioCursos.CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Faltan datos del curso.");
                    return;
                }

                // Convertir el cupo a número
                int cupo = 0;
                if (!int.TryParse(txtCupo.Text, out cupo))
                {
                    MessageBox.Show("El cupo debe ser un número.");
                    return;
                }

                // Llamar al servicio
                var resultado = _servicioCursos.Agregar(txtNombre.Text, txtCodigo.Text, cupo);
                _servicioCursos.PersistirCambios();

                MessageBox.Show(resultado.Message);

                txtNombre.Clear(); txtCodigo.Clear(); txtCupo.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            rtbResultados.Clear();
            var resultado = _servicioCursos.ListarCursos();
            rtbResultados.Text = resultado.Message;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbResultados_TextChanged(object sender, EventArgs e)
        {

        }
    }
}