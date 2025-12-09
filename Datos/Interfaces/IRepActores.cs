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
    public interface IRepActores<T>
    {
        bool guardarPersonaje(Persona persona);
        bool eliminarPersonaje(Persona persona);

        // devolvemos una tupla con la lista y el diccionario
        (List<T>, Dictionary<string, T>) obtenerTodos();
        Persona? buscarPersonaje(string id);

        // Esta nueva firma permitirá crear o actualizar nuestro .json a partir de la lista auxiliar
        // una vez halla finalizado el proceso de alta, baja o modificación de actores.
        void persistirCambios();
    }
}
