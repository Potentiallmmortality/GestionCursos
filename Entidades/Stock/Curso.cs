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
        private string idUnico;
        // Identificador de cada asigntura, en este caso se lo conceptualiza como un atributo pensado para su búsqueda
        private int cupoMaximo;
        private static int contador = 1;
        private Instructor instructor;
        private List<Estudiante> estudiantesInscritos;
        private EstadoCurso estadoCurso;

        public Curso(string nombre, string idUnico, int cupoMaximo)
        {
            if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(idUnico) || cupoMaximo < 0) throw new Exception("Datos Invalidos");
            contador++;
            this.nombre = nombre;
            this.cupoMaximo = cupoMaximo;
            this.estudiantesInscritos = new List<Estudiante>();
            this.idUnico = idUnico.ToLower();
            this.instructor = null!;
            this.estadoCurso = EstadoCurso.Abierto;
        }
        public string Nombre
        {
            get { return nombre; }
        }
        public string CodigoUnico
        {
            get { return idUnico; }
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
            set { instructor = instructor != null ? instructor : value; }
        }
        public EstadoCurso Estado { get { return estadoCurso; } }
        public bool agregarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null || this.estudiantesInscritos.Count >= this.cupoMaximo || estudiantesInscritos.Contains(estudiante)) return false;
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
                return this.estudiantesInscritos.Remove(estudiante);
            }
        }
        public void CerrarCurso()
        {
            this.estadoCurso = EstadoCurso.Cerrado;
        }
        public void AbrirCurso()
        {
            this.estadoCurso = EstadoCurso.Abierto;
        }
        public bool CursoCerrado()
        {
            return this.estadoCurso == EstadoCurso.Cerrado;
        }

    }
}
