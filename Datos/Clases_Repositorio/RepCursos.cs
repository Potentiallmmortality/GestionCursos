// <copyright file="RepCursos.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.Clases_Repositorio;
    using Datos.DTOs;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;

    public class RepCursos : RepBase<Curso>, IRepCursos
    {
        public RepCursos(string filename)
            : base(filename)
        {
        }

        bool IRepCursos.guardarCurso(Curso curso)
        {
            if (this.agregarAlDiccionario(curso))
            {
                this.agregarALista(curso);
                return true;
            }
            else
                return false;
        }

        bool IRepCursos.eliminarCurso(Curso curso)
        {
            if (this.eliminarDelDiccionario(curso))
            {
                this.eliminarDeLista(curso);
                return true;
            }
            else
                return false;
        }

        (List<Curso>, Dictionary<string, Curso>) IRepGeneric<Curso>.obtenerTodos()
        {
            return (this.Lista, this.Diccionario);
        }

        Curso? IRepGeneric<Curso>.BuscarPorIdentificacion(string codigoUnico)
        {
            return this.Diccionario.TryGetValue(codigoUnico, out Curso curso) ? curso : throw new Exception("No encontramos el curso");
        }

        Curso? IRepCursos.BuscarCursoExistente(string codigoUnico)
        {
            return this.Lista.FirstOrDefault(c => c.CodigoUnico == codigoUnico);
        }

        void IRepGeneric<Curso>.cargarDatos()
        {
           if (!File.Exists(this.Filename))
           {
                this.Lista = new List<Curso>();
                this.Diccionario = new Dictionary<string, Curso>();
                return;
           }

           this.Lista.Clear();
           this.Diccionario.Clear();

           string jsonString = File.ReadAllText(this.Filename);
           List<CursoJson>? cursosJson = System.Text.Json.JsonSerializer.Deserialize<List<CursoJson>>(jsonString);

           if (cursosJson == null)
           {
                this.Lista = new List<Curso>();
                this.Diccionario = new Dictionary<string, Curso>();
                return;
           }

           foreach (var cursoJson in cursosJson)
           {
                Curso curso = new Curso(
                    cursoJson.Nombre,
                    cursoJson.CodigoUnico,
                    cursoJson.CupoMaximo);
                curso.Estado = cursoJson.Estado;
                curso.Identifier = cursoJson.Identifier;

                this.agregarALista(curso);

                this.agregarAlDiccionario(curso);
            }

           this.sincronizarDatos();
        }

        void IRepGeneric<Curso>.persistirCambios()
        {
           this.sincronizarDatos();

           List<CursoJson> cursosJson = new List<CursoJson>();

           foreach (var curso in this.Lista)
           {
                CursoJson cursoJson = new CursoJson
                {
                    Nombre = curso.Nombre,
                    CodigoUnico = curso.CodigoUnico,
                    CupoMaximo = curso.CupoMaximo,
                    Dni_Instructor = curso.Instructor?.Dni,
                    Dni_Estudiantes = curso.EstudiantesInscritos.Select(e => e.Dni).ToList(),
                    Estado = curso.Estado,
                    Identifier = curso.Identifier,
                };
                cursosJson.Add(cursoJson);
           }

           string jsonString = System.Text.Json.JsonSerializer.Serialize(cursosJson, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

           string? directorio = Path.GetDirectoryName(this.Filename);

           if (!Directory.Exists(directorio) && directorio != null)
                    Directory.CreateDirectory(directorio);

           File.WriteAllText(this.Filename, jsonString);
        }

        protected override bool agregarAlDiccionario(Curso entidad)
        {
            if (entidad == null)
                return false;

            return this.Diccionario.TryAdd(entidad.CodigoUnico, entidad);
        }

        protected override bool eliminarDelDiccionario(Curso entidad)
        {
            if (entidad == null)
                return false;

            return this.Diccionario.Remove(entidad.CodigoUnico);
        }

        private void sincronizarDatos()
        {
            foreach (var curso in this.Lista)
            {
                if (!this.Diccionario.ContainsKey(curso.CodigoUnico))
                {
                    this.Diccionario[curso.CodigoUnico] = curso;
                }
            }

            var listaHashSet = new HashSet<Curso>(this.Lista);

            foreach (var key in this.Diccionario.Keys)
            {
                var curso = this.Diccionario[key];
                if (!listaHashSet.Contains(curso))
                {
                    this.Lista.Add(curso);
                    listaHashSet.Add(curso);
                }
            }
        }
    }
}
