using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.InterfacesNegocio; // Para INegocioActores
using Entidades.Actores;         // Para Instructor

namespace UIs
{
    public partial class FrmGestionInstructores : Form
    {
        // Usamos la interfaz genérica o específica según tengas configurado
        private readonly INegocioActores _negocioInstructores;

        public FrmGestionInstructores(INegocioActores negocioInstructores)
        {
            InitializeComponent();
            _negocioInstructores = negocioInstructores;
        }

        // 1. AGREGAR INSTRUCTOR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Solo pedimos los 3 datos que dejaste
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string email = txtEmail.Text;

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni))
                {
                    MessageBox.Show("El Nombre y el DNI son obligatorios.");
                    return;
                }

                // Asegúrate de que tu método Agregar en el servicio acepte solo estos 3
                var resultado = _negocioInstructores.Agregar(nombre, dni, email);

                MostrarMensaje(resultado.Message, resultado.Success);
                if (resultado.Success) LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 2. ELIMINAR INSTRUCTOR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para eliminar.");
                return;
            }

            var resultado = _negocioInstructores.Eliminar(txtDni.Text);
            MostrarMensaje(resultado.Message, resultado.Success);
            if (resultado.Success) LimpiarCampos();
        }

        // 3. BUSCAR INSTRUCTOR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese el DNI para buscar.");
                return;
            }

            var resultado = _negocioInstructores.Buscar(txtDni.Text);
            txtSalida.Text = resultado.Success ? resultado.Message : "Instructor no encontrado.";
        }

        // 4. LISTAR TODOS
        private void btnListar_Click(object sender, EventArgs e)
        {
            var resultado = _negocioInstructores.ListarActores();
            txtSalida.Text = "--- LISTA DE INSTRUCTORES ---\r\n";
            txtSalida.Text += resultado.Message;
        }

        // MÉTODOS AUXILIARES
        private void MostrarMensaje(string mensaje, bool exito)
        {
            txtSalida.Text = mensaje;
            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDni.Clear();
            txtEmail.Clear();
        }
    }
}