using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;

namespace Entidades.Stock
{
    public class Curso
    {
        private string nombre;
        private string codigoUnico; // Identificador especial para cada asignatura
        private int cupoMaximo;
        private static int contador = 1;
        private Instructor instructor;
        private List<Estudiante> estudiantesInscritos;
        private EstadoCurso estadoCurso;

        public Curso(string nombre, string codigoUnico, int cupoMaximo)
        {
            contador++;
            this.nombre = nombre;
            this.cupoMaximo = cupoMaximo;
            this.estudiantesInscritos = new List<Estudiante>();
            this.codigoUnico = codigoUnico.ToLower();
            this.instructor = null!;
            this.estadoCurso = EstadoCurso.Abierto;
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public string CodigoUnico
        {
            get { return codigoUnico; }
        }
        public int CupoMaximo
        {
            get { return cupoMaximo; }
        }
        public List<Estudiante> EstudiantesInscritos
        {
            get { return estudiantesInscritos; }
        }
        public Instructor Instructor
        {
            get { return instructor; }
            set { instructor = instructor != null? instructor:value; }
        }
        public bool agregarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null) return false;
            if (this.estudiantesInscritos.Count >= this.cupoMaximo) return false;
            else
            {
                this.estudiantesInscritos.Add(estudiante);
                return true;
            }
        }
        public bool eliminarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null) return false;
            else
            {
                this.estudiantesInscritos.Remove(estudiante);
                return true;
            }
        }
        public bool CursoCerrado()
        {
            this.estadoCurso = EstadoCurso.Cerrado;
            return this.estadoCurso == EstadoCurso.Cerrado;
        }

    }
}
