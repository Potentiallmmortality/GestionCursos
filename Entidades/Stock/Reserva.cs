using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;

namespace Entidades.Stock
{
    public class Reserva
    {
        private string identifier;
        private static int contador = 1;
        private Estudiante estudiante;
        private Curso curso;
        private DateTime fechaCreacion;

        public Reserva(Estudiante Estudiante, Curso Curso)
        {
            contador++;
            this.fechaCreacion = DateTime.Now;
            this.estudiante = Estudiante;
            this.curso = Curso;
            this.identifier = $"Book-{DateTime.Now:yyyy}-{contador.ToString("D3")}";
        }
        public string Identifier 
        {
            get { return this.identifier; }
        }
        public Curso Curso 
        { 
            get { return this.curso; }
        }
        public Estudiante Estudiante {
            get { return this.estudiante; }
        }
        public DateTime FechaCreacion
        {
            get { return this.fechaCreacion; } 
        }
    }
}
