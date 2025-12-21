using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;

namespace Negocio.InterfacesNegocio
{
    public interface INegocioReservas:INegocioGeneric
    {
        OperationResult CrearReserva(string dniEstudiante, string idUnicoCurso);
        OperationResult CancelarReserva(string Identifier);
        OperationResult ListarTodas(); 
        OperationResult AprovarReserva(string Identifier);
        List<Reserva> ObtenerReservasPorEstudiante(Estudiante estudiante);
    }
}
