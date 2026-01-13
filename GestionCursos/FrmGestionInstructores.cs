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
    using Entidades.Actores;        
    using Negocio.InterfacesNegocio; 

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
                string nombre = this.txtNombre.Text;
                string dni = this.txtDni.Text;
                string email = this.txtEmail.Text;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni))
                {
                    MessageBox.Show("El Nombre y el DNI son obligatorios.");
                    return;
                }

                var resultado = this._negocioInstructores.Agregar(nombre, dni, email);

                this.MostrarMensaje(resultado.Message, resultado.Success);
                if (resultado.Success) 
                    this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para eliminar.");
                return;
            }

            var resultado = this._negocioInstructores.Eliminar(this.txtDni.Text);
            this.MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) this.LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para buscar.");
                return;
            }

            var resultado = this._negocioInstructores.Buscar(this.txtDni.Text);
            this.txtSalida.Text = resultado.Success ? resultado.Message : "Instructor no encontrado.";
        }
        
        private void btnListar_Click(object sender, EventArgs e)
        {
            var resultado = this._negocioInstructores.ListarActores();
            this.txtSalida.Text = "--- LISTA DE INSTRUCTORES ---\r\n";
            this.txtSalida.Text += resultado.Message;
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            this.txtSalida.Text = mensaje;
            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtDni.Clear();
            this.txtEmail.Clear();
        }

        private void FrmGestionInstructores_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestionInstructores.ActiveForm.Close();
        }
    }
}