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
using Negocio.SerivicioActores;
using Negocio.InterfacesNegocio;
using Datos.Clases_Repositorio;

namespace UIs
{
    public partial class FrmGestionInstructores : Form
    {
        private INegocioActores _servicioInstructores;

        public FrmGestionInstructores()
        {
            InitializeComponent();
            // OJO: Aquí usamos RepInstructores y su archivo json
            _servicioInstructores = new ServicioInstructores(new RepInstructores("instructores.json"));
            _servicioInstructores.CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDni.Text))
                {
                    MessageBox.Show("Complete los datos.");
                    return;
                }

                var resultado = _servicioInstructores.Agregar(txtNombre.Text, txtDni.Text, txtEmail.Text);
                _servicioInstructores.PersistirCambios(); // Guardar en JSON

                // ASUMIENDO QUE YA ARREGLASTE LA PROPIEDAD .Message o .Mensaje
                MessageBox.Show(resultado.Message); // Cambia a .Message si ya lo encontraste
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                rtbResultados.Clear();
                var resultado = _servicioInstructores.ListarActores();
                rtbResultados.Text = resultado.Message; 
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Limpiar()
        {
            txtNombre.Clear(); txtDni.Clear(); txtEmail.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}