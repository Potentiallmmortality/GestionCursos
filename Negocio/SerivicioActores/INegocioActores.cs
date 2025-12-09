using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SerivicioActores
{
    public interface INegocioActores<T>
    {
        OperationResult Agregar(string nombre, string dni, string email);
        OperationResult Eliminar(string dni);

        // Calquiera de los tres atributos modificables es un string
        OperationResult Modificar(string parametro);
        OperationResult PersistirCambios();
        T Buscar(string parametro);
    }
}
