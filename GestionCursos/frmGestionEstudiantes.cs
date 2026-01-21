namespace UIs
{
    using Datos.Clases_Repositorio; 
    using Datos.Interfaces;
    using Entidades.Actores;
    using Negocio;
    using Negocio.InterfacesNegocio; 
    using Negocio.SerivicioActores;
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

    public partial class frmGestionEstudiantes : Form
    {
        private INegocioActores _servicioEstudiantes;

        public frmGestionEstudiantes(INegocioActores servicioEstudiantes)
        {
            this.InitializeComponent();
            this._servicioEstudiantes = servicioEstudiantes;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                if (!Validaciones.EsDniValido(txtDni.Text))
                {
                    MessageBox.Show("El DNI debe contener solo números.");
                    return;
                }

                if (!Validaciones.EsNombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo debe contener letras.");
                    return;
                }

                if (!Validaciones.EsEmailValido(txtEmail.Text))
                {
                    MessageBox.Show("El formato del correo no es válido.");
                    return;
                }

                var resultado = _servicioEstudiantes.Agregar(txtNombre.Text, txtDni.Text, txtEmail.Text);

                MostrarMensaje(resultado.Message, resultado.Success);

                if (resultado.Success)
                {
                    LimpiarCampos();
                    CargarGrilla(); // Si tienes el método de refresco
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtDni.Text = textBox1.Text;
            if (string.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Escribe el DNI del estudiante a eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Seguro que deseas eliminar este estudiante?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                OperationResult resultado = this._servicioEstudiantes.Eliminar(this.txtDni.Text);

                if (resultado.Success)
                {
                    MessageBox.Show(resultado.Message);
                    this.LimpiarCampos();
                    ((INegocioGeneric)this._servicioEstudiantes).PersistirCambios();
                    this.btnListar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = _servicioEstudiantes.ObtenerListaReal();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var lista = _servicioEstudiantes.ObtenerListaReal();
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = lista;
            this.CargarGrilla();
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtDni.Clear();
            this.txtEmail.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGestionEstudiantes.ActiveForm.Close();
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            //this.txtSalida.Text = mensaje;
            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmGestionEstudiantes.ActiveForm.Close();   
        }
    }
}
