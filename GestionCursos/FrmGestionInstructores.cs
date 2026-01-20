namespace UIs
{
    using Entidades.Actores;
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

    public partial class FrmGestionInstructores : Form
    {
        private readonly INegocioActores _negocioInstructores;

        public FrmGestionInstructores(INegocioActores negocioInstructores)
        {
            this.InitializeComponent();
            this._negocioInstructores = negocioInstructores;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string email = txtEmail.Text;

                if (!Validaciones.EsSoloNumeros(dni))
                {
                    MessageBox.Show("El DNI debe contener exactamente 10 numeros", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Validaciones.EsEmailValido(email))
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Validaciones.EsSoloLetras(nombre))
                {
                    MessageBox.Show("El nombre no debe contener números ni símbolos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var resultado = _negocioInstructores.Agregar(nombre, dni, email);
                MostrarMensaje(resultado.Message, resultado.Success);

                if (resultado.Success)
                {
                    LimpiarCampos();
                    CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtDni.Text = textBox1.Text;
            if (string.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para eliminar.");
                return;
            }

            var resultado = this._negocioInstructores.Eliminar(this.txtDni.Text);
            this.MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) this.LimpiarCampos();
            this.CargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtDni.Text = textBox2.Text;
            if (string.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para buscar.");
                return;
            }

            var resultado = this._negocioInstructores.Buscar(this.txtDni.Text);
            MessageBox.Show(resultado.Message, resultado.Success ? "Instructor Encontrado" : "No Encontrado", MessageBoxButtons.OK, resultado.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            this.CargarGrilla();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvInstructores.DataSource = null;
            dgvInstructores.DataSource = _negocioInstructores.ObtenerListaReal();
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            //this.txtSalida.Text = mensaje;
            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtDni.Clear();
            this.txtEmail.Clear();
        }

        private void CargarGrilla()
        {
            this.dgvInstructores.DataSource = null;
            this.dgvInstructores.DataSource = _negocioInstructores.ObtenerListaReal();
        }

        private void FrmGestionInstructores_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestionInstructores.ActiveForm.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmGestionInstructores.ActiveForm.Close();  
        }
    }
}