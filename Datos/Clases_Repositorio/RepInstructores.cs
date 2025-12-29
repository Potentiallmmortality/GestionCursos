// <copyright file="RepInstructores.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Datos.DTOs;
    using Datos.Interfaces;
    using Entidades.Actores;

    public class RepInstructores : RepBase<Instructor>, IRepActores<Instructor>
    {
        public RepInstructores(string filename)
            : base(filename)
        {
        }

        bool IRepActores<Instructor>.guardarPersonaje(Persona persona)
        {
            if (persona is Instructor instructor && this.agregarAlDiccionario(instructor))
            {
                this.agregarALista(instructor);
                return true;
            }
            else
                return false;
        }

        bool IRepActores<Instructor>.eliminarPersonaje(Persona persona)
        {
            if (persona is Instructor instructor && this.eliminarDelDiccionario(instructor))
            {
                this.eliminarDeLista(instructor);
                return true;
            }
            else
                return false;
        }

        (List<Instructor>, Dictionary<string, Instructor>) IRepGeneric<Instructor>.obtenerTodos()
        {
            return (this.Lista, this.Diccionario);
        }

        Instructor? IRepGeneric<Instructor>.BuscarPorIdentificacion(string id)
        {
            return this.Diccionario.TryGetValue(id, out Instructor p) ? p : null;
        }

        Instructor? IRepActores<Instructor>.BuscarPersonajePorParametros(string dni, string email, string usuario)
        {
            return this.Lista.FirstOrDefault(i => i.Dni == dni || i.Email == email || i.Usuario == usuario);
        }

        void IRepGeneric<Instructor>.persistirCambios()
        {
            this.sincronizarDatos();

            List<InstructorJson> instructoresJson = new List<InstructorJson>();
            foreach (var instructor in this.Lista)
            {
                instructoresJson.Add(new InstructorJson
                {
                    Nombre = instructor.Nombre,
                    Dni = instructor.Dni,
                    Email = instructor.Email,
                    FechaRegistro = instructor.FechaRegistro,
                    IdsUnicosCursos = instructor.Cursos.Select(c => c.CodigoUnico).ToList(),
                    Identifier = instructor.Identifier,
                    Usuario = instructor.Usuario,
                    Contrasena = instructor.Contrasena,
                });
            }

            string jsonString = JsonSerializer.Serialize(instructoresJson, new JsonSerializerOptions { WriteIndented = true });

            string? directorio = Path.GetDirectoryName(this.Filename);

            if (directorio != null && !Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            File.WriteAllText(this.Filename, jsonString);
        }

        void IRepGeneric<Instructor>.cargarDatos()
        {
            if (!File.Exists(this.Filename))
            {
                this.Diccionario = new Dictionary<string, Instructor>();
                this.Lista = new List<Instructor>();
                return;
            }

            this.Lista.Clear();
            this.Diccionario.Clear();
            string jsonString = File.ReadAllText(this.Filename);
            List<InstructorJson>? instructoresJson = JsonSerializer.Deserialize<List<InstructorJson>>(jsonString);

            if (instructoresJson == null)
            {
                this.Lista = new List<Instructor>();
                this.Diccionario = new Dictionary<string, Instructor>();
                return;
            }

            foreach (var instructorJson in instructoresJson!)
            {
                Instructor instructor = new Instructor(
                    instructorJson.Nombre,
                    instructorJson.Dni,
                    instructorJson.Email,
                    instructorJson.Usuario,
                    instructorJson.Contrasena);
                instructor.FechaRegistro = instructorJson.FechaRegistro;
                instructor.Identifier = instructorJson.Identifier;

                this.agregarALista(instructor);
                this.agregarAlDiccionario(instructor);
            }

            this.sincronizarDatos();
        }

        protected override bool agregarAlDiccionario(Instructor entidad)
        {
            if (entidad == null)
                return false;
            return this.Diccionario.TryAdd(entidad.Dni, entidad);
        }

        protected override bool eliminarDelDiccionario(Instructor entidad)
        {
            if (entidad == null)
                return false;
            return this.Diccionario.Remove(entidad.Dni);
        }

        private void sincronizarDatos()
        {
            foreach (var instructor in this.Lista)
            {
                if (!this.Diccionario.ContainsKey(instructor.Dni))
                {
                    this.Diccionario[instructor.Dni] = instructor;
                }
            }

            var listaHashSet = new HashSet<Instructor>(this.Lista);

            foreach (var key in this.Diccionario.Keys)
            {
                var instructor = this.Diccionario[key];
                if (!listaHashSet.Contains(instructor))
                {
                    this.Lista.Add(instructor);
                    listaHashSet.Add(instructor);
                }
            }
        }
    }
}
