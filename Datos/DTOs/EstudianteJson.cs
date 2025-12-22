using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    internal class EstudianteJson
    {
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<string> IdsUnicos_Cursos { get; set; } = new();
        public string Identifier { get; set; }
    
        // Nota del desarrollador, la parte de manejo de archivos .json es mas jodida de lo
        // que pensé que sería.


        // El objetivo será representar cada instancia de clase en su respectivo modelado 
        // Json , el problema es poder guardar y volver a reconstruir las relaciones de multiplicidad

        // Solo podemos guardar una lista de claves (IDs) que representen al otro objeto, asi que cuando
        // el archivo se lea de nuevo habrá que reconstruir 
    }
}
