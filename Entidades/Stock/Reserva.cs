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
        //private string idUnico;
        private string codigoUnico;
        private static int _contador = 0;
        private Estudiante estudiante;
        private Curso curso;
        private DateTime fechaCreacion;
        private EstadoReserva estadoReserva;

        public Reserva(Estudiante Estudiante, Curso Curso/*, string IdUnico*/)
        {
            if (Estudiante == null || Curso == null) throw new Exception("Datos Invalidos para crear la reserva");
            _contador++;
            //this.idUnico = IdUnico;
            this.fechaCreacion = DateTime.Now;
            this.estudiante = Estudiante;
            this.curso = Curso;
            this.codigoUnico = $"Book-{DateTime.Now:yyyyMMddHHfff}-{_contador:D3}";
            this.estadoReserva = EstadoReserva.En_Espera;
        }
        public string Identifier 
        {
            get { return this.codigoUnico; }
        }
        //public string IdUnico
        //{
        //    get { return idUnico; }
        //}
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
        public void aprobarReserva()
        {
            this.estadoReserva = EstadoReserva.Aprovada;
        }
        public void rechazarReserva()
        {
            this.estadoReserva = EstadoReserva.Rechazada;
        }
        public bool reservaAprobada()
        {
            return this.estadoReserva == EstadoReserva.Aprovada;
        }
        public string toString()
        {
            return $"Reserva: {codigoUnico}, Estudiante: {estudiante.Nombre}, Curso: {curso.Nombre}, Fecha de Creacion: {fechaCreacion}, Estado: {estadoReserva}";
        }
    }
}
