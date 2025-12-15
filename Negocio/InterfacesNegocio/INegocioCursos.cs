using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesNegocio
{
    public interface INegocioCursos : INegocioGeneric
    {
        OperationResult Agregar(string nombre, string idUnico, int cupoMaximo);
        OperationResult Eliminar(string idUnico);
        OperationResult ListarCursos();
        OperationResult AsignarInstructor(string dniInstructor, string codigoCurso);
    }
}
