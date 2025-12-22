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
        private static int _contador = 0;
        private Instructor instructor;
        private string identifier;
        private List<Estudiante> estudiantesInscritos;
        private EstadoCurso estadoCurso;

        public Curso(string nombre, string idUnico, int cupoMaximo)
        {
            if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(idUnico) || cupoMaximo < 0 || cupoMaximo > 24) throw new Exception("Datos Invalidos");
            _contador++;
            this.nombre = nombre;
            this.cupoMaximo = cupoMaximo;
            this.estudiantesInscritos = new List<Estudiante>();
            this.idUnico = idUnico.ToUpper();
            this.instructor = null!;
            this.identifier = $"CLASS-{DateTime.Now:yyyyMMddHHfff}-{_contador.ToString("D3")}";
            this.estadoCurso = EstadoCurso.Abierto;
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value?? nombre; }
        }
        public string CodigoUnico
        {
            get { return idUnico; }
            set { idUnico = value?? idUnico; }
        }
        public int CupoMaximo
        {
            get { return cupoMaximo; }
            set { cupoMaximo = value < 0 || value > 24? cupoMaximo: value; }
        }
        public List<Estudiante> EstudiantesInscritos
        {
            get { return estudiantesInscritos; }
            set { estudiantesInscritos = value?? estudiantesInscritos; }
        }
        public Instructor Instructor
        {
            get { return instructor; }
            set { instructor = value ?? instructor; }
        }
        public EstadoCurso Estado
        { 
            get { return estadoCurso; }
            set { estadoCurso = value; }
        }
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value ?? identifier; }
        }
        public bool agregarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null || this.estudiantesInscritos.Count >= this.cupoMaximo || estudiantesInscritos.Contains(estudiante)) return false;
            else
            {
                this.estudiantesInscritos.Add(estudiante);
                if(estudiantesInscritos.Count == cupoMaximo)
                    this.CerrarCurso();
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
        public override string ToString()
        {
            return $"Curso: {Nombre}, Codigo Unico: {CodigoUnico}, Cupo Maximo: {CupoMaximo}, Estado: {Estado}";
        }
    }
}
