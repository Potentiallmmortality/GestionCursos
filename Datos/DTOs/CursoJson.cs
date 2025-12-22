using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;

namespace Datos.DTOs
{
    public class CursoJson
    {
        public string Nombre { get; set; }
        public string CodigoUnico { get; set; }
        public int CupoMaximo { get; set; }
        public string Dni_Instructor { get; set; }
        public List<string> Dni_Estudiantes { get; set; }
        public EstadoCurso Estado { get; set; }
        public string Identifier { get; set; }

    }
}
