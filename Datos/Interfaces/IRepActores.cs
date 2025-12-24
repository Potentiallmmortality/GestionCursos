using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;

// Cada clase tendrá asignada una lista auxiliar para modelar la persistencia en archivos .json
// mientras que el diccionario servirá para búsquedas rápidas en memoria.

// las firmas para guardar o eliminar actuarán en la memoria de ejeción (RAM) de la aplicación.


namespace Datos.Interfaces
{
    public interface IRepActores<T>: IRepGeneric<T> where T : Persona
    {
        bool guardarPersonaje(Persona persona);
        bool eliminarPersonaje(Persona persona);
        T? BuscarPersonajePorParametros(string dni, string email, string usuario);
    }
}
