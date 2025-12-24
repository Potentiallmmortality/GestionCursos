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
    public class RepCursos: RepBase<Curso>, IRepCursos
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
        bool IRepCursos.guardarCurso(Curso curso)
        {

            if (agregarAlDiccionario(curso))
            {
                agregarALista(curso);
                return true;

            } return false;
        }
        bool IRepCursos.eliminarCurso(Curso curso)
        {
            if (eliminarDelDiccionario(curso))
            {
                eliminarDeLista(curso);
                return true;

            } return false;
        }
        (List<Curso>, Dictionary<string, Curso>) IRepGeneric<Curso>.obtenerTodos()
        {
            return (Lista, Diccionario);
        }
        Curso? IRepGeneric<Curso>.BuscarPorIdentificacion(string codigoUnico)
        {
            return Diccionario.TryGetValue(codigoUnico, out Curso curso) ? curso : throw new Exception("No encontramos el curso");
        }
        Curso? IRepCursos.BuscarCursoExistente(string codigoUnico)
        {
            return Lista.FirstOrDefault(c => c.CodigoUnico == codigoUnico);
        }
        void IRepGeneric<Curso>.cargarDatos()
        {
            // implementación pendiente
        }
        void IRepGeneric<Curso>.persistirCambios()
        {
            // implementación pendiente
        }
    }
}
