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
    public class RepEstudiantes: RepBase<Estudiante>, IRepActores
    {
        private Dictionary<string, Estudiante> diccionarioEstudiantes;

        public RepEstudiantes(string filename) : base(filename)
        {
            diccionarioEstudiantes = new Dictionary<string, Estudiante>();
        }
        // Establezcamos el Dni como clave para buscar a un estudiante, mientras que indentifier cumplirá
        // una función de registro para logger.
        private bool agregarEstudianteAlDiccionario(Estudiante estudiante)
        {
            if (estudiante != null)
            {
                diccionarioEstudiantes.TryAdd(estudiante.Dni, estudiante);
                return true;
            }
            return false;
        }
        private bool eliminarEstudianteDelDiccionario(Estudiante estudiante)
        {
           if (estudiante != null)
            {
                return diccionarioEstudiantes.Remove(estudiante.Dni);
            }
            else return false;
        }
        public Dictionary<string, Estudiante> DiccionarioEstudiantes
        {
            get { return diccionarioEstudiantes; }
        }
        void IRepActores.guardarPersonaje(Persona persona)
        {
            //if (persona is Estudiante estudiante)
            //{
            //    agregarEstudianteAlDiccionario(estudiante);
            //}
        }
        void IRepActores.eliminarPersonaje(Persona persona)
        {
            //if (persona is Estudiante estudiante)
            //{
            //    eliminarEstudianteDelDiccionario(estudiante);
            //}
        }
        Persona IRepActores.buscarPersonaje(string id)
        {
           throw new NotImplementedException();
        }
        List<Persona> IRepActores.obtenerTodos()
        {
            throw new NotImplementedException();
        }

    }
}
