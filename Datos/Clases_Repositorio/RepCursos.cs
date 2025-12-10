using Entidades.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases_Repositorio;
using Entidades.Actores;
using Datos.Interfaces;
using System.Security.AccessControl;


namespace Datos.Clases_Repositorio
{
    public class RepCursos: RepBase<Curso>, IRepCursos<Curso>
    {
        public RepCursos(string filename) : base(filename) { }
        protected override bool agregarAlDiccionario(Curso entidad)
        {
            if (entidad == null) return false;
            return Diccionario.TryAdd(entidad.CodigoUnico, entidad);
        }
        protected override bool eliminarDelDiccionario(Curso entidad)
        {
            if (entidad == null) return false;
            return Diccionario.Remove(entidad.CodigoUnico);
        }
        bool IRepCursos<Curso>.guardarCurso(Curso curso)
        {
            //if (agregarAlDiccionario(curso) && agregarALista(curso)) return true;
            //else return false;

            if (agregarAlDiccionario(curso))
            {
                if (agregarALista(curso)) return true;
                else
                {
                    eliminarDelDiccionario(curso);
                    return false;
                }
            } return false;
        }
        bool IRepCursos<Curso>.eliminarCurso(Curso curso)
        {
            if (eliminarDelDiccionario(curso) && eliminarDeLista(curso)) return true;
            else return false;
        }
        (List<Curso>, Dictionary<string, Curso>) IRepCursos<Curso>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        Curso IRepCursos<Curso>.BuscarPorCodigo(string codigoUnico)
        {
            return Diccionario.TryGetValue(codigoUnico, out Curso curso) ? curso : throw new Exception("No encontramos el curso");
        }
        void IRepCursos<Curso>.persistirCambios()
        {
            // implementación pendiente
        }

    }
}
