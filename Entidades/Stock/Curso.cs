// <copyright file="Curso.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entidades.Stock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Actores;

    public class Curso
    {
        private static int _contador = 0;
        private string nombre;
        private string idUnico;
        private int cupoMaximo;
        private Instructor instructor;
        private string identifier;
        private List<Estudiante> estudiantesInscritos;
        private EstadoCurso estadoCurso;

        public Curso(string nombre, string idUnico, int cupoMaximo)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(idUnico) || cupoMaximo < 0 || cupoMaximo > 24)
                throw new Exception("Datos Invalidos");

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
            get { return this.nombre; }
            set { this.nombre = value ?? this.nombre; }
        }

        public string CodigoUnico
        {
            get { return this.idUnico; }
            set { this.idUnico = value ?? this.idUnico; }
        }

        public int CupoMaximo
        {
            get { return this.cupoMaximo; }
            set { this.cupoMaximo = value < 0 || value > 24 ? this.cupoMaximo : value; }
        }

        public List<Estudiante> EstudiantesInscritos
        {
            get { return this.estudiantesInscritos; }
            set { this.estudiantesInscritos = value ?? this.estudiantesInscritos; }
        }

        public Instructor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value ?? this.instructor; }
        }

        public EstadoCurso Estado
        {
            get { return this.estadoCurso; }
            set { this.estadoCurso = value; }
        }

        public string Identifier
        {
            get { return this.identifier; }
            set { this.identifier = value ?? this.identifier; }
        }

        public bool agregarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null || this.estudiantesInscritos.Count >= this.cupoMaximo || this.estudiantesInscritos.Contains(estudiante))
                return false;
            else
            {
                this.estudiantesInscritos.Add(estudiante);
                if (this.estudiantesInscritos.Count == this.cupoMaximo)
                    this.CerrarCurso();
                return true;
            }
        }

        public bool eliminarEstudiante(Estudiante estudiante)
        {
            if (estudiante == null)
                return false;
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
            return $"Curso: {this.Nombre}, Codigo Unico: {this.CodigoUnico}, Cupo Maximo: {this.CupoMaximo}, Estado: {this.Estado}";
        }
    }
}
