using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;
using Entidades.Actores;

namespace Datos.Interfaces
{

    public interface IRepReservas: IRepGeneric<Reserva>
    {
        bool guardarReserva(Reserva reserva);
        bool eliminarReserva(Reserva reserva);
        Reserva? BuscarPorEstudianteYCursos(Estudiante estudiante, Curso curso);
    }
}
