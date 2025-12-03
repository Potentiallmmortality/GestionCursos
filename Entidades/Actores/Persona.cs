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

        public Persona(string nombre, string dni, string email)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.email = email;
            this.fechaRegistro = DateTime.Now;
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = !string.IsNullOrWhiteSpace(value) ? value : nombre; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = !string.IsNullOrWhiteSpace(value) ? value : dni; }
        }
        public string Email
        {
            get { return email; }
            set { email = !string.IsNullOrWhiteSpace(value) ? value : email; }
        }
        public DateTime FechaRegistro
        {
             get { return fechaRegistro; }
        }
    }
}
