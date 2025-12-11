using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Interfaces;
using System.ComponentModel.Design;

namespace Datos.Clases_Repositorio
{
    public class RepEstudiantes: RepBase<Estudiante>, IRepActores<Estudiante>
    {
        public RepEstudiantes(string filename) : base(filename) { }

        // Establezcamos el Dni como clave para buscar a un estudiante, mientras que indentifier cumplirá
        // una función de registro para logger.

        protected override bool agregarAlDiccionario(Estudiante entidad)
        {
            if(entidad == null) return false;
            return Diccionario.TryAdd(entidad.Dni, entidad);
        }
        protected override bool eliminarDelDiccionario(Estudiante entidad)
        {
            if(entidad == null) return false;
            return Diccionario.Remove(entidad.Dni);
        }
        // Pendiente modificar las reglas de guardar y eliminar para que se desarollen de manera parlela y evitar discordancias entre lista y diccionario.
        bool IRepActores<Estudiante>.guardarPersonaje(Persona persona)
        {
            //if (persona is Estudiante estudiante && agregarAlDiccionario(estudiante) && agregarALista(estudiante)) return true;
            //else return false;

            if (persona is Estudiante estudiante && agregarAlDiccionario(estudiante))
            {
                if (agregarALista(estudiante)) return true;
                else
                {
                    eliminarDelDiccionario(estudiante);
                    return false;
                } 
            }
            return false;
        }
        bool IRepActores<Estudiante>.eliminarPersonaje(Persona persona)
        {
            //if (persona is Estudiante estudiante && eliminarDelDiccionario(estudiante) && eliminarDeLista(estudiante)) return true;
            //else return false;
            if (persona is Estudiante estudiante && eliminarDelDiccionario(estudiante))
            {
                if (eliminarDeLista(estudiante)) return true;
                else
                {
                    agregarAlDiccionario(estudiante);
                    return false;
                }
            }
            return false;
        }
        Persona? IRepActores<Estudiante>.buscarPersonaje(string id)
        {
            return Diccionario.TryGetValue(id, out Estudiante p)? p: null;
        }
        (List<Estudiante>, Dictionary<string, Estudiante>) IRepActores<Estudiante>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        void IRepActores<Estudiante>.persistirCambios()
        {
            // implementacion pendiente
        }

    }
}
