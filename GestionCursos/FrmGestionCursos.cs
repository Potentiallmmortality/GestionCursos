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
    using Negocio.InterfacesNegocio;

    public partial class FrmGestionCursos : Form
    {
        private readonly INegocioCursos _negocioCursos;

        public FrmGestionCursos(INegocioCursos negocioCursos)
        {
            this.InitializeComponent();
            this._negocioCursos = negocioCursos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtCupo.Text, out int cupo))
            {
                MessageBox.Show("El cupo debe ser un número entero válido.");
                return;
            }

            var resultado = this._negocioCursos.Agregar(this.txtNombre.Text, this.txtCodigo.Text, cupo);

            this.MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) this.LimpiarCamposCurso();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = textBox1.Text;
            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese el Código Único del curso a eliminar.");
                return;
            }

            var resultado = this._negocioCursos.Eliminar(this.txtCodigo.Text);
            this.MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) this.LimpiarCamposCurso();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = textBox2.Text;
            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el Código para buscar.");
                return;
            }

            var resultado = this._negocioCursos.Buscar(this.txtCodigo.Text);
            MessageBox.Show(resultado.Success ? "Curso encontrado." : "Curso no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (!resultado.Success)
                MessageBox.Show(resultado.Message);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvCursos.DataSource = null;
            dgvCursos.DataSource = _negocioCursos.ObtenerListaReal();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            string codigoCurso = this.txtCodigo.Text;
            string dniInstructor = this.txtDniInstructor.Text;

            if (string.IsNullOrWhiteSpace(codigoCurso) || string.IsNullOrWhiteSpace(dniInstructor))
            {
                MessageBox.Show("Debe ingresar el Código del Curso y el DNI del Instructor.");
                return;
            }

            var resultado = this._negocioCursos.AsignarInstructor(dniInstructor, codigoCurso);
            this.MostrarMensaje(resultado.Message, resultado.Success);
        }

        // --- MÉTODOS AUXILIARES ---

        private void MostrarMensaje(string mensaje, bool exito)
        {
            MessageBox.Show(mensaje);
            if (!exito)
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCamposCurso()
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtCupo.Clear();
            this.txtDniInstructor.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           FrmGestionCursos.ActiveForm.Close();
        }
    }
}
