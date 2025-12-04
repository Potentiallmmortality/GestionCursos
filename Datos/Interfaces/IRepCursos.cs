using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;

namespace Datos.Interfaces
{
    public interface IRepCursos
    {
        void guardarCurso(Curso curso);
        void eliminarCurso(Curso curso);
        List<Curso> obtenerTodos();
        Curso BuscarPorCodigo(string codigoUnico);
    }
}
