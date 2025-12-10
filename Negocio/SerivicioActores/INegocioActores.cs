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

        // Pendiente implementar una merjor lógica para modificar actores

        //OperationResult Modificar(string parametro);
        OperationResult PersistirCambios();
        OperationResult Buscar(string parametro);
    }
}
