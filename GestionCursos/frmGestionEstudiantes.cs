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
    using Negocio;
    using Negocio.SerivicioActores;
    using Negocio.InterfacesNegocio; 
    using Datos.Clases_Repositorio; 
    using Datos.Interfaces;

    public partial class frmGestionEstudiantes : Form
    {
        private INegocioActores _servicioEstudiantes;

        public frmGestionEstudiantes()
        {
            this.InitializeComponent();
            this.ConfigurarDependencias();
        }

        private void ConfigurarDependencias()
        {
           
            string nombreArchivo = "..\\directorioPrueba\\estudiantes.json";

             IRepActores<Estudiante> repositorio = new RepEstudiantes(nombreArchivo);

            this._servicioEstudiantes = new ServicioEstudiantes(repositorio);

            var servicioGenerico = (INegocioGeneric)this._servicioEstudiantes;
            servicioGenerico.CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(this.txtDni.Text) || string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                MessageBox.Show("El nombre y el DNI son obligatorios.");
                return;
            }

            OperationResult resultado = this._servicioEstudiantes.Agregar(
                this.txtNombre.Text,
                this.txtDni.Text,
                this.txtEmail.Text);

            if (resultado.Success)
            {
                MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarCampos();

                ((INegocioGeneric)this._servicioEstudiantes).PersistirCambios();

                this.btnListar_Click(sender, e);
            }
            else
            {
                MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtDni.Text=textBox1.Text;
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
    }
}
