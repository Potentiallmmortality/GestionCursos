using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;


namespace Datos.Interfaces
{
    public interface IRepCursos: IRepGeneric<Curso> 
    {
        bool guardarCurso(Curso curso);
        bool eliminarCurso(Curso curso);
        Curso? BuscarCursoExistente(string codigoUnico);
    }
}
