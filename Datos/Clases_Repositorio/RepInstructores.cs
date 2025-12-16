using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Datos.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Datos.Clases_Repositorio
{
    public class RepInstructores: RepBase<Instructor>, IRepActores<Instructor>
    {
        public RepInstructores(string filename) : base(filename) { }

        protected override bool agregarAlDiccionario(Instructor entidad)
        {
            if (entidad == null) return false;
            return Diccionario.TryAdd(entidad.Dni, entidad);
        }
        protected override bool eliminarDelDiccionario(Instructor entidad)
        {
            if (entidad == null) return false;
            return Diccionario.Remove(entidad.Dni);
        }
        bool IRepActores<Instructor>.guardarPersonaje(Persona persona)
        {
            //if (persona is Instructor instructor)
            //{
            //   return agregarAlDiccionario(instructor);
            //} return false;
            if (persona is Instructor instructor && agregarAlDiccionario(instructor))
            {
                if (agregarALista(instructor)) return true;
                else
                {
                    eliminarDelDiccionario(instructor);
                    return false;
                }
            }
            return false;
        }
        bool IRepActores<Instructor>.eliminarPersonaje(Persona persona)
        {
            if (persona is Instructor instructor && eliminarDelDiccionario(instructor))
            {
                if(eliminarDeLista(instructor)) return true;
                else
                {
                    agregarAlDiccionario(instructor);
                    return false;
                }
            } return false;
        }
        (List<Instructor>, Dictionary<string, Instructor>) IRepGeneric<Instructor>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        Instructor? IRepGeneric<Instructor>.BuscarPorIdentificacion(string id)
        {
            return Diccionario.TryGetValue(id, out Instructor p) ? p : null;
        }
        Instructor? IRepGeneric<Instructor>.BuscarPorParametros(string id, string atributo1)
        {
            return Lista.FirstOrDefault(i => i.Dni == id || i.Email == atributo1);
        }
        void IRepGeneric<Instructor>.persistirCambios()
        {
            // implementación pendiente
        }
        void IRepGeneric<Instructor>.cargarDatos()
        {
            // implementación pendiente
        }

    }
}
