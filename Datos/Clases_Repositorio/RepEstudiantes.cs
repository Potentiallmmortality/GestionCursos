using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Interfaces;
using System.ComponentModel.Design;
using System.Transactions;

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
        bool IRepActores<Estudiante>.guardarPersonaje(Persona persona)
        {

            if (persona is Estudiante estudiante && agregarAlDiccionario(estudiante))
            {
                agregarALista(estudiante);             
                return true;
            }
            return false;
        }
        bool IRepActores<Estudiante>.eliminarPersonaje(Persona persona)
        {
            if (persona is Estudiante estudiante && eliminarDelDiccionario(estudiante))
            {
                eliminarDeLista(estudiante);
                return true;
            }
            return false;
        }
        (List<Estudiante>, Dictionary<string, Estudiante>) IRepGeneric<Estudiante>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        Estudiante? IRepGeneric<Estudiante>.BuscarPorIdentificacion(string id)
        {
            return Diccionario.TryGetValue(id, out Estudiante p)? p: throw new Exception("No encontramos al Estudiante");
        }
        Estudiante? IRepActores<Estudiante>.BuscarPersonajePorParametros(string dni, string email, string usuario)
        {
            return Lista.FirstOrDefault(e => e.Dni == dni || e.Email == email || e.Usuario == usuario);
        }
        void IRepGeneric<Estudiante>.persistirCambios()
        {
            // implementacion pendiente
        }
        void IRepGeneric<Estudiante>.cargarDatos()
        {
            // implementacion pendiente
        }
    }
}
