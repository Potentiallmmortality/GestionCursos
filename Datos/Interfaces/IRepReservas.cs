using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;
using Entidades.Actores;

namespace Datos.Interfaces
{

    public interface IRepReservas<T>: IRepGeneric<Reserva>
    {
        bool guardarReserva(Reserva reserva);
        bool eliminarReserva(Reserva reserva);
        (List<Reserva>, Dictionary<string, T>) obtenerTodas();
        (List<Reserva>, Dictionary<string, T>) obtenerReservasActivas();

    }
}
