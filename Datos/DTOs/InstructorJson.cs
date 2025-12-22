using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    internal class InstructorJson
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<string> IdsUnicosCursos { get; set; }
        public string Identifier { get; set; }
    }
}
