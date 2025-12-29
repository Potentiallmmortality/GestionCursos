// <copyright file="RepEstudiantes.cs" company="Grupo 9 Escuela Politéncia Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Transactions;
    using Datos.DTOs;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;

    public class RepEstudiantes : RepBase<Estudiante>, IRepActores<Estudiante>
    {
        public RepEstudiantes(string filename)
            : base(filename)
        {
        }

        // Establezcamos el Dni como clave para buscar a un estudiante, mientras que indentifier cumplirá
        // una función de registro para logger.
        bool IRepActores<Estudiante>.guardarPersonaje(Persona persona)
        {
            if (persona is Estudiante estudiante && this.agregarAlDiccionario(estudiante))
            {
                this.agregarALista(estudiante);
                return true;
            }
            else
                return false;
        }

        bool IRepActores<Estudiante>.eliminarPersonaje(Persona persona)
        {
            if (persona is Estudiante estudiante && this.eliminarDelDiccionario(estudiante))
            {
                this.eliminarDeLista(estudiante);
                return true;
            }
            else
                return false;
        }

        (List<Estudiante>, Dictionary<string, Estudiante>) IRepGeneric<Estudiante>.obtenerTodos()
        {
            return (this.Lista, this.Diccionario);
        }

        Estudiante? IRepGeneric<Estudiante>.BuscarPorIdentificacion(string id)
        {
            return this.Diccionario.TryGetValue(id, out Estudiante p) ? p : throw new Exception("No encontramos al Estudiante");
        }

        Estudiante? IRepActores<Estudiante>.BuscarPersonajePorParametros(string dni, string email, string usuario)
        {
            return this.Lista.FirstOrDefault(e => e.Dni == dni || e.Email == email || e.Usuario == usuario);
        }

        void IRepGeneric<Estudiante>.persistirCambios()
        {
            this.sincronizarDatos();

            List<EstudianteJson> estudiantesJson = new List<EstudianteJson>();
            foreach (var estudiante in this.Lista)
            {
                // Console.WriteLine($"Persistiendo datos del estudiante: {estudiante} \n");   // Debug
                EstudianteJson estudianteJson = new EstudianteJson
                {
                    Nombre = estudiante.Nombre,
                    Dni = estudiante.Dni,
                    Email = estudiante.Email,
                    FechaRegistro = estudiante.FechaRegistro,
                    IdsUnicos_Cursos = estudiante.Cursos.Select(c => c.CodigoUnico).ToList(),
                    Identifier = estudiante.Identifier,
                    Usuario = estudiante.Usuario,
                    Contrasena = estudiante.Contrasena,
                };

                estudiantesJson.Add(estudianteJson);
            }

            string jsonString = JsonSerializer.Serialize(estudiantesJson, new JsonSerializerOptions { WriteIndented = true });

            string? directorio = Path.GetDirectoryName(this.Filename);

            if (!Directory.Exists(directorio) && directorio != null)
                Directory.CreateDirectory(directorio);

            File.WriteAllText(this.Filename, jsonString);
        }

        void IRepGeneric<Estudiante>.cargarDatos()
        {
            if (!File.Exists(this.Filename))
            {
                this.Diccionario = new Dictionary<string, Estudiante>();
                this.Lista = new List<Estudiante>();
                return;
            }

            this.Lista.Clear();
            this.Diccionario.Clear();

            string jsonString = File.ReadAllText(this.Filename);
            List<EstudianteJson>? estudiantesJson = JsonSerializer.Deserialize<List<EstudianteJson>>(jsonString);

            if (estudiantesJson == null)
            {
                this.Diccionario = new Dictionary<string, Estudiante>();
                this.Lista = new List<Estudiante>();
                return;
            }

            foreach (var estudianteJson in estudiantesJson!)
            {
                Estudiante estudiante = new Estudiante(
                    estudianteJson.Nombre,
                    estudianteJson.Dni,
                    estudianteJson.Email,
                    estudianteJson.Usuario,
                    estudianteJson.Contrasena);

                estudiante.FechaRegistro = estudianteJson.FechaRegistro;
                estudiante.Identifier = estudianteJson.Identifier;

                this.agregarAlDiccionario(estudiante);
                this.agregarALista(estudiante);
            }

            this.sincronizarDatos();
        }

        protected override bool agregarAlDiccionario(Estudiante entidad)
        {
            if (entidad == null)
                return false;
            return this.Diccionario.TryAdd(entidad.Dni, entidad);
        }

        protected override bool eliminarDelDiccionario(Estudiante entidad)
        {
            if (entidad == null)
                return false;
            return this.Diccionario.Remove(entidad.Dni);
        }

        private void sincronizarDatos()
        {
            foreach (var estudiante in this.Lista)
            {
                if (!this.Diccionario.ContainsKey(estudiante.Dni))
                {
                    this.Diccionario[estudiante.Dni] = estudiante;
                }
            }

            var listaHashSet = new HashSet<Estudiante>(this.Lista);

            foreach (var key in this.Diccionario.Keys)
            {
                var estudiante = this.Diccionario[key];
                if (!listaHashSet.Contains(estudiante))
                {
                    this.Lista.Add(estudiante);
                    listaHashSet.Add(estudiante);
                }
            }
        }
    }
}
