using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesNegocio
{
    public interface INegocioActores: INegocioGeneric
    {
        OperationResult Agregar(string nombre, string dni, string email, string usuario, string contraseña);
        OperationResult Eliminar(string dni);
        OperationResult ListarActores();
    }
}
