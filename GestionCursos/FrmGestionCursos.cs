namespace UIs
{
    using Negocio.InterfacesNegocio;
    using Negocio.SeriviciosCompuestos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtCupo.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                if (!Validaciones.EsSoloNumeros(txtCupo.Text))
                {
                    MessageBox.Show("El cupo debe ser un número entero.");
                    return;
                }

                if (!Validaciones.EsCodigoCursoValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre del curso no debe contener símbolos extraños.");
                    return;
                }

                int cupo = int.Parse(txtCupo.Text);

                if (cupo < 0 || cupo > 24)
                {
                    MessageBox.Show("El cupo debe estar entre 0 y 24.");
                    return;
                }

                var resultado = _negocioCursos.Agregar(txtNombre.Text, txtCodigo.Text, cupo);

                if (resultado.Success)
                {
                    MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposCurso();
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void CargarGrilla()
        {
            this.dgvCursos.DataSource = null;
            this.dgvCursos.DataSource = _negocioCursos.ObtenerListaReal();
        }

        private void FrmGestionCursos_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmGestionCursos.ActiveForm.Close();    
        }
    }

}
