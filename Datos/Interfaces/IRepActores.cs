using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;

namespace Datos.Interfaces
{
    public interface IRepActores
    {
        void guardarPersonaje(Persona persona);
        void eliminarPersonaje(Persona persona);
        List<Persona> obtenerTodos();
        Persona buscarPersona(string id);
    }
}
