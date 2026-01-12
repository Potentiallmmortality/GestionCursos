using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Negocio.InterfacesNegocio; // Necesario para INegocioCursos

namespace UIs // Ajusta este namespace al de tu proyecto
{
    public partial class FrmGestionCursos : Form
    {
        // Variable para almacenar la referencia a la capa de negocio
        private readonly INegocioCursos _negocioCursos;

        // Constructor que recibe la dependencia (Inyección)
        public FrmGestionCursos(INegocioCursos negocioCursos)
        {
            InitializeComponent();
            _negocioCursos = negocioCursos;
        }

        // 1. BOTÓN AGREGAR CURSO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que el cupo sea un número
            if (!int.TryParse(txtCupo.Text, out int cupo))
            {
                MessageBox.Show("El cupo debe ser un número entero válido.");
                return;
            }

            // Llamamos al método Agregar de la interfaz
            var resultado = _negocioCursos.Agregar(txtNombre.Text, txtCodigo.Text, cupo);

            MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) LimpiarCamposCurso();
        }

        // 2. BOTÓN ELIMINAR CURSO
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese el Código Único del curso a eliminar.");
                return;
            }

            var resultado = _negocioCursos.Eliminar(txtCodigo.Text);
            MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) LimpiarCamposCurso();
        }

        // 3. BOTÓN BUSCAR (Usa el método genérico Buscar)
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el Código para buscar.");
                return;
            }

            var resultado = _negocioCursos.Buscar(txtCodigo.Text);
            
            // Mostramos el resultado en el cuadro de texto grande
            txtSalida.Text = resultado.Success ? resultado.Message : "No encontrado.";
            
            if (!resultado.Success) 
                MessageBox.Show(resultado.Message);
        }

        // 4. BOTÓN LISTAR TODOS
        private void btnListar_Click(object sender, EventArgs e)
        {
            var resultado = _negocioCursos.ListarCursos();
            
            txtSalida.Text = "--- LISTA DE CURSOS ---\r\n";
            txtSalida.Text += resultado.Message; // Tu servicio devuelve la lista en el string Message
        }

        // 5. BOTÓN ASIGNAR INSTRUCTOR
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            string codigoCurso = txtCodigo.Text;
            string dniInstructor = txtDniInstructor.Text;

            if (string.IsNullOrWhiteSpace(codigoCurso) || string.IsNullOrWhiteSpace(dniInstructor))
            {
                MessageBox.Show("Debe ingresar el Código del Curso y el DNI del Instructor.");
                return;
            }

            var resultado = _negocioCursos.AsignarInstructor(dniInstructor, codigoCurso);
            MostrarMensaje(resultado.Message, resultado.Success);
        }

        // --- MÉTODOS AUXILIARES ---

        private void MostrarMensaje(string mensaje, bool exito)
        {
            txtSalida.Text = mensaje;
            if (!exito)
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCamposCurso()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCupo.Clear();
            txtDniInstructor.Clear();
        }
    }
}
