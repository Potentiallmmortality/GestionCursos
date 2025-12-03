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
    public class Estudiante : Persona
    {
        // multiplicidad muchos a muchos

        // private DateTime _fechaRegistro;
        private List<Curso> _cursoList;
        private string _identifier;
        private static int _contador= 1;
        public Estudiante(string nombre, string dni, string email)
            : base(nombre, dni, email)
        {
            // this._fechaRegistro = DateTime.Now;
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
            if (curso == null) return false;
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
                this._cursoList.Remove(curso);
                return true;
            }
        }

    }
}
