// <copyright file="Estudiante.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entidades.Actores
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Stock;

    public class Estudiante : Persona
    {
        private static int _contador = 0;
        private List<Curso> _cursoList;
        private string _identifier;

        public Estudiante(string nombre, string dni, string email, string usuario, string contraseña)
            : base(nombre, dni, email, usuario, contraseña)
        {
            _contador++;
            this._cursoList = new List<Curso>();
            this._identifier = $"EST-{DateTime.Now:yyyyMMddHHfff}-{_contador.ToString("D3")}";
        }

        public List<Curso> Cursos
        {
            get { return this._cursoList; }
            set { this._cursoList = value; }
        }

        public string Identifier
        {
            get { return this._identifier; }
            set { this._identifier = string.IsNullOrWhiteSpace(value) ? this._identifier : value; }
        }

        public bool agregarCurso(Curso curso)
        {
            if (curso == null || this._cursoList.Contains(curso))
                return false;
            else
            {
                this._cursoList.Add(curso);
                return true;
            }
        }

        public bool eliminarCurso(Curso curso)
        {
            if (curso == null)
                return false;
            else
                return this._cursoList.Remove(curso);
        }

        public override string ToString()
        {
            return $"Estudiante: {this.Nombre}, Dni: {this.Dni}, Email: {this.Email}, Fecha de Registro: {this.FechaRegistro}, Identifier: {this.Identifier}";
        }
    }
}