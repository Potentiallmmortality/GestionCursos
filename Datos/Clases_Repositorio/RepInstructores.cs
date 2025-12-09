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
            return Diccionario.TryAdd(entidad.Identifier, entidad);
        }
        protected override bool eliminarDelDiccionario(Instructor entidad)
        {
            if (entidad == null) return false;
            return Diccionario.Remove(entidad.Identifier);
        }
        bool IRepActores<Instructor>.guardarPersonaje(Persona persona)
        {
            if (persona is Instructor instructor)
            {
               return agregarAlDiccionario(instructor);
            } return false;
        }
        bool IRepActores<Instructor>.eliminarPersonaje(Persona persona)
        {
            if (persona is Instructor instructor)
            {
                return eliminarDelDiccionario(instructor);
            } return false;
        }
        Persona IRepActores<Instructor>.buscarPersonaje(string id)
        {
           throw new NotImplementedException();
        }
        (List<Instructor>, Dictionary<string, Instructor>) IRepActores<Instructor>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        public void persistirCambios()
        {
            // implementación pendiente
        }

    }
}
