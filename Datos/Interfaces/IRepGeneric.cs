using Entidades.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IRepGeneric<T> where T : class
    {
        void persistirCambios();
        void cargarDatos();
        (List<T>, Dictionary<string, T>) obtenerTodos();
        // Tanto actores como productos se construyen a partir de 3 parametros de tipo string
        // uno de ellos es un identificador principal y los otros dos son atributos adicionales
        T? BuscarPorIdentificacion(string id);

        // Este método tiene la intención de buscar repetidos (búsqueda por disyunción), en muchos objetos hay parametros a los
        // que si se les permite ser repetidos, por lo que se ha tenido en cuenta solo id y un parametro adicional.
        T? BuscarPorParametros(string id, string atributo1 = "cadena por defecto");
    }
}
