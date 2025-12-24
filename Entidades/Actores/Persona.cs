using Entidades.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Actores
{
    public abstract class Persona
    {
        private string nombre;
        private string dni;
        private string email;
        protected DateTime fechaRegistro;

        // Atributos extra para agregar  a un sistema de login para estudintes e instructores

        private string usuario;
        private string contrasena;
        public Persona(string nombre, string dni, string email, string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(usuario) ||string.IsNullOrWhiteSpace(contraseña)) 
                throw new Exception("Datos Invalidos");
            this.nombre = nombre;
            this.dni = dni;
            this.email = email;
            this.fechaRegistro = DateTime.Now;
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = string.IsNullOrWhiteSpace(value) ? nombre : value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = string.IsNullOrWhiteSpace(value) ? dni: value; }
        }
        public string Email
        {
            get { return email; }
            set { email = string.IsNullOrWhiteSpace(value) ? email : value; }
        }
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = string.IsNullOrWhiteSpace(value) ? usuario : value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = string.IsNullOrWhiteSpace(value) ? contrasena : value; }
        }
    }
}
