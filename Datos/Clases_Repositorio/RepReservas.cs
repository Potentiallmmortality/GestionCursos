using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Interfaces;

namespace Datos.Clases_Repositorio
{
    public class RepReservas: RepBase<Reserva>,IRepReservas
    {
        // Solo se manejará Identifier como clave para las reservas.
        public RepReservas(string filename) : base(filename) { }
        protected override bool agregarAlDiccionario(Reserva entidad)
        {
            if (entidad == null) 
                return false;

            return Diccionario.TryAdd(entidad.Identifier, entidad);
        }
        protected override bool eliminarDelDiccionario(Reserva entidad)
        {
            if (entidad == null) 
                return false;

            return Diccionario.Remove(entidad.Identifier);
        }
        bool IRepReservas.guardarReserva(Reserva reserva)
        {
            if( agregarAlDiccionario(reserva))
            {
                if (agregarALista(reserva))
                    return true;
                else
                {
                    eliminarDelDiccionario(reserva);
                    return false;
                }
            }
            else return false;
        }
        bool IRepReservas.eliminarReserva(Reserva reserva)
        {
            if (eliminarDelDiccionario(reserva))
            {
                if (eliminarDeLista(reserva)) return true;
                else
                {
                    agregarAlDiccionario(reserva);
                    return false;
                }
            }
            else return false;
        }
        (List<Reserva>, Dictionary<string, Reserva>) IRepGeneric<Reserva>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        Reserva? IRepGeneric<Reserva>.BuscarPorParametros(string id, string atributo1 = "cadena por defecto")
        {
            // Esta implementación no es soportada para Reservas.
            //return Lista.FirstOrDefault(b => b.Identifier == id);
            throw new NotSupportedException();
        }
        Reserva? IRepReservas.BuscarPorEstudianteYCursos(Estudiante estudiante, Curso curso)
        {
            return Lista.FirstOrDefault(r => r.Estudiante.Dni == estudiante.Dni && r.Curso.CodigoUnico == curso.CodigoUnico);
        }
        Reserva? IRepGeneric<Reserva>.BuscarPorIdentificacion(string id)
        {
            return Diccionario.TryGetValue(id, out Reserva b) ? b : throw new Exception("Reserva No encontrada");
        }
        void IRepGeneric<Reserva>.persistirCambios()
        { 
           // implementacion pendiente 
        }

        void IRepGeneric<Reserva>.cargarDatos()
        { 
           // implementacion pendiente 
        }
    }
}
