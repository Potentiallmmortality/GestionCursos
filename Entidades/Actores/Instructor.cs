using Entidades.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Actores
{

    // Se decidió agregar la lista de de alumnos en cada subtipo de persona, envés de la clase base Persona
    // ya que no todos los tipos de personas van a tener una lista de cursos asociados; evitamos agregar un atributo inecesario
    // a costa de repetir algo de código.

    // Otros atributos individualizados en cada subtipo son: contador e identificador único (cada subtipo tiene una manera diferente de identificarse y numerarse).
    // Identificador único: se genera en base al año de registro y un contador estático que se incrementa con cada nueva instancia.
    // esto asegura que cada instancia tenga un identificador único y rastreable.

    public class Instructor: Persona
    {
        // multiplicidad muchos a muchos

        private List<Curso> _cursoList;
        private static int _contador = 0;
        private string _identifier;

        public Instructor(string nombre, string dni, string email)
            :base(nombre, dni, email)
        {
            _contador++;
            this._cursoList = new List<Curso>();
            this._identifier = $"PROF-{DateTime.Now:yyyyMMddHHfff}-{_contador.ToString("D3")}";
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
        public string toString()
        {
            return $"Instructor: {Nombre}, Dni: {Dni}, Email: {Email}, Fecha de Registro: {FechaRegistro}, Identifier: {Identifier}";
        }
    }
}
