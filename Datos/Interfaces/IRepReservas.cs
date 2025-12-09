using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;
using Entidades.Actores;

namespace Datos.Interfaces
{

    public interface IRepReservas<T>
    {
        bool guardarReserva(Reserva reserva);
        bool eliminarReserva(Reserva reserva);
        (List<Reserva>, Dictionary<string, T>) obtenerTodas();
        (List<Reserva>, Dictionary<string, T>) obtenerReservasActivas();
        (List<Reserva>, Dictionary<string, T>) buscarPorCurso(Curso curso);
        (List<Reserva>, Dictionary<string, T>) buscarPorEstudiante(Estudiante estudiante);
        Reserva buscarReserva(string idUnico);
        void persistirCambios();

    }
}
