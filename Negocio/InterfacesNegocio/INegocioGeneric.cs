using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesNegocio
{
    public interface INegocioGeneric
    {
        OperationResult PersistirCambios();
        OperationResult CargarDatos();
        OperationResult Buscar(string parametro);
    }
}
