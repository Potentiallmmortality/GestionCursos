using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;

namespace Datos.DTOs
{
    public class ReservaJson
    {
        public string CodigoUnico { get; set; }
        public string Dni_Estudiante { get; set; }
        public string IdUnico_Curso { get; set; }
        public DateTime FechaReserva { get; set; }

        public EstadoReserva EstadoReserva { get; set; }
    }
}
