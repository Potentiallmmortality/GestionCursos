using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Stock;

namespace Entidades.Actores
{
    // <Sumary> Las clases de entidad: Persona, Instructor se derivan de una clase principal abstracta persona.
   

    public class Estudiante : Persona
    {
        // multiplicidad muchos a muchos

        private List<Curso> _cursoList;
        private string _identifier;
        private static int _contador= 1;
        public Estudiante(string nombre, string dni, string email)
            : base(nombre, dni, email)
        {
            _contador++;
            this._cursoList = new List<Curso>();
            this._identifier = $"EST-{DateTime.Now:yyyy}-{_contador.ToString("D3")}";
        }
        public List<Curso> Cursos
        {
            get { return _cursoList; }
        }
        public string Identifier
        {
            get { return _identifier; }
        }
        public bool agregarCurso(Curso curso)
        {
            if (curso == null || _cursoList.Contains(curso)) return false;
            else
            {
                this._cursoList.Add(curso);
                return true;
            }
        }
        public bool eliminarCurso(Curso curso)
        {
            if (curso == null) return false;
            else
            {
                return this._cursoList.Remove(curso);
            }
        }

    }
}
// private DateTime _fechaRegistro;