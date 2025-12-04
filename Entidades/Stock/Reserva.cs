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
        private string idUnico;
        private string codigoUnico;
        private static int contador = 1;
        private Estudiante estudiante;
        private Curso curso;
        private DateTime fechaCreacion;
        private EstadoReserva estadoReserva;

        public Reserva(Estudiante Estudiante, Curso Curso, string IdUnico)
        {
            contador++;
            this.idUnico = IdUnico;
            this.fechaCreacion = DateTime.Now;
            this.estudiante = Estudiante;
            this.curso = Curso;
            this.codigoUnico = $"Book-{DateTime.Now:yyyy}-{contador.ToString("D3")}";
            this.estadoReserva = EstadoReserva.En_Espera;
        }
        public string Identifier 
        {
            get { return this.codigoUnico; }
        }
        public string IdUnico
        {
            get { return idUnico; }
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
        public EstadoReserva Estado {
            get { return estadoReserva; } 
        }
        public bool reservaAprobada()
        {
            this.estadoReserva = EstadoReserva.Aprovada;
            return this.estadoReserva == EstadoReserva.Aprovada;
        }
    }
}
