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
using Negocio;                 
using Negocio.SerivicioActores; 
using Negocio.InterfacesNegocio; // Para INegocioActores
using Datos.Clases_Repositorio; // NECESARIO: Para RepEstudiantes
using Datos.Interfaces;        // NECESARIO: Para IRepActores

namespace UIs
{
    public partial class frmGestionEstudiantes : Form
    {
        // Declaramos la interfaz, no la clase concreta, para poder usar los métodos
        private INegocioActores _servicioEstudiantes;

        public frmGestionEstudiantes()
        {
            InitializeComponent();
            ConfigurarDependencias();
        }

        private void ConfigurarDependencias()
        {
            // CORRECCIÓN: Definimos la ruta o nombre del archivo JSON
            string nombreArchivo = "..\\directorioPrueba\\estudiantes.json";

            // 1. Instanciamos el Repositorio pasando el argumento 'filename' que faltaba
            // Esto soluciona el error: "No se ha dado ningún argumento..."
            IRepActores<Estudiante> repositorio = new RepEstudiantes(nombreArchivo);

            // 2. Instanciamos el Servicio inyectando el repositorio
            _servicioEstudiantes = new ServicioEstudiantes(repositorio);

            // 3. Cargar datos existentes
            var servicioGenerico = (INegocioGeneric)_servicioEstudiantes;
            servicioGenerico.CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de UI
            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre y el DNI son obligatorios.");
                return;
            }

            // Llamamos al método Agregar de la interfaz INegocioActores
            OperationResult resultado = _servicioEstudiantes.Agregar(
                txtNombre.Text,
                txtDni.Text,
                txtEmail.Text
            );

            if (resultado.Success)
            {
                MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();

                // Guardar cambios en el archivo (Persistencia)
                ((INegocioGeneric)_servicioEstudiantes).PersistirCambios();

                // Actualizar la lista visualmente
                btnListar_Click(sender, e);
            }
            else
            {
                MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Escribe el DNI del estudiante a eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Seguro que deseas eliminar este estudiante?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                OperationResult resultado = _servicioEstudiantes.Eliminar(txtDni.Text);

                if (resultado.Success)
                {
                    MessageBox.Show(resultado.Message);
                    LimpiarCampos();
                    ((INegocioGeneric)_servicioEstudiantes).PersistirCambios();
                    btnListar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            // Como tu amigo devuelve un STRING en lugar de una LISTA, 
            // no podemos usar DataGridView fácilmente. Usamos el RichTextBox.
            OperationResult resultado = _servicioEstudiantes.ListarActores();

            if (resultado.Success)
            {
                rtbListado.Text = resultado.Message;
            }
            else
            {
                MessageBox.Show("Error al listar: " + resultado.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDni.Clear();
            txtEmail.Clear();
        }
    }
}
