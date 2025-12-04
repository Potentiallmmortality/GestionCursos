using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;
using Entidades.Actores;

namespace Datos.Interfaces
{

    public interface IRepReservas
    {
        void guardarReserva(Reserva reserva);
        void eliminarReserva(Reserva reserva);
        List<Reserva> obtenerTodas();
        List<Reserva> obtenerReservasActivas();
        List<Reserva> buscarPorCurso(Curso curso);
        List<Reserva> buscarPorEstudiante(Estudiante estudiante);
        Reserva buscarReserva(string idUnico);

    }
}
