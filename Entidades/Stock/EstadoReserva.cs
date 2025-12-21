using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Stock
{
    // Enum para los estados que podrá tener una reserva
    // Una reserva puede ser aprovada o dejada en espera
    public enum EstadoReserva
    {
        Aprovada,
        En_Espera,
        Rechazada
    }
}
