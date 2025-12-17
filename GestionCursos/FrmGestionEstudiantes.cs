using Datos.Clases_Repositorio;
using Entidades.Actores;       
using Negocio.InterfacesNegocio; 
using Negocio.SerivicioActores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIs
{
    public partial class FrmGestionEstudiantes : Form
    {
        // 1. Declaramos la interfaz del negocio (no la clase concreta aun)
        private INegocioActores _servicioEstudiantes;

        public FrmGestionEstudiantes()
        {
            InitializeComponent();


            _servicioEstudiantes = new ServicioEstudiantes(new RepEstudiantes("estudiantes.json"));
            _servicioEstudiantes.CargarDatos();
        }

        // BOTÓN AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos que no estén vacíos (aunque tu entidad ya lo valida, es mejor hacerlo aquí también)
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDni.Text))
                {
                    MessageBox.Show("Por favor complete Nombre y DNI.");
                    return;
                }

                // LLAMAMOS A LA CAPA DE NEGOCIO
                // Usamos los métodos que definieron: Agregar(nombre, dni, email)
                var resultado = _servicioEstudiantes.Agregar(txtNombre.Text, txtDni.Text, txtEmail.Text);

                // Verificamos el resultado (asumo que OperationResult tiene una propiedad Success o Message)
                // Voy a mostrar el mensaje que devuelve tu lógica
                MessageBox.Show(resultado.Message); // O resultado.Message si existe esa propiedad public

                // Limpiar cajas
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        // BOTÓN LISTAR
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                rtbResultados.Clear();

                // Llamamos al método ListarActores de tu interfaz
                var resultado = _servicioEstudiantes.ListarActores();

                // Tu método devuelve un OperationResult con un string gigante en el mensaje o data.
                // Asumiré que el .ToString() o una propiedad 'Data' tiene el texto.
                // Ajusta esto según qué propiedad de OperationResult tiene el string.
                rtbResultados.Text = resultado.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDni.Clear();
            txtEmail.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
