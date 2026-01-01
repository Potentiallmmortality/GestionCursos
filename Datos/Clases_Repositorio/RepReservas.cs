// <copyright file="RepReservas.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.DTOs;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;

    public class RepReservas : RepBase<Reserva>, IRepReservas
    {
        private List<ReservaJson> listaJson;

        public RepReservas(string filename)
            : base(filename)
        {
            this.listaJson = new List<ReservaJson>();
        }

        List<ReservaJson> IRepReservas.obtenerDatos()
        {
            return this.listaJson;
        }

        bool IRepReservas.guardarReserva(Reserva reserva)
        {
            if (this.agregarAlDiccionario(reserva))
            {
               this.agregarALista(reserva);
               return true;
            }
            else
                return false;
        }

        bool IRepReservas.eliminarReserva(Reserva reserva)
        {
            if (this.eliminarDelDiccionario(reserva))
            {
                this.eliminarDeLista(reserva);
                return true;
            }
            else
                return false;
        }

        (List<Reserva>, Dictionary<string, Reserva>) IRepGeneric<Reserva>.obtenerTodos()
        {
            return (this.Lista, this.Diccionario);
        }

        Reserva? IRepReservas.BuscarPorEstudianteYCursos(Estudiante estudiante, Curso curso)
        {
            return this.Lista.FirstOrDefault(r => r.Estudiante.Dni == estudiante.Dni && r.Curso.CodigoUnico == curso.CodigoUnico);
        }

        Reserva? IRepGeneric<Reserva>.BuscarPorIdentificacion(string id)
        {
            return this.Diccionario.TryGetValue(id, out Reserva b) ? b : throw new Exception("Reserva No encontrada");
        }

        void IRepGeneric<Reserva>.persistirCambios()
        {
            this.sincronizarDatos();
            List<ReservaJson> reservaJsons = new List<ReservaJson>();

            foreach (var reserva in this.Lista)
            {
                ReservaJson reservaJson = new ReservaJson
                {
                    CodigoUnico = reserva.Identifier,
                    Dni_Estudiante = reserva.Estudiante?.Dni,
                    IdUnico_Curso = reserva.Curso?.CodigoUnico,
                    FechaReserva = reserva.FechaCreacion,
                    EstadoReserva = reserva.Estado,
                };
                reservaJsons.Add(reservaJson);
            }

            string jsonString = System.Text.Json.JsonSerializer.Serialize(reservaJsons, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            string? directory = Path.GetDirectoryName(this.Filename);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(this.Filename, jsonString);
        }

        // Debdido a que las reservas dependen de  las referencias estudiantes y cursos, necesito reconstruir esas referencias despues de cargar los datos
        // Es mejor hacerlo fuera de este metodo, en una capa superior donde tenga acceso a los repositorios de estudiantes y cursos
        void IRepGeneric<Reserva>.cargarDatos()
        {
            if (!File.Exists(this.Filename))
           {
                this.Lista = new List<Reserva>();
                this.Diccionario = new Dictionary<string, Reserva>();
                return;
           }

            string jsonString = File.ReadAllText(this.Filename);
            List<ReservaJson>? reservaJsons = System.Text.Json.JsonSerializer.Deserialize<List<ReservaJson>>(jsonString);

            if (reservaJsons == null)
                return;

            this.listaJson = reservaJsons;
        }

        protected override bool agregarAlDiccionario(Reserva entidad)
        {
            if (entidad == null)
                return false;

            return this.Diccionario.TryAdd(entidad.Identifier, entidad);
        }

        protected override bool eliminarDelDiccionario(Reserva entidad)
        {
            if (entidad == null)
                return false;

            return this.Diccionario.Remove(entidad.Identifier);
        }

        private void sincronizarDatos()
        {
            foreach (var reserva in this.Lista)
            {
                if (!this.Diccionario.ContainsKey(reserva.Identifier))
                    this.Diccionario[reserva.Identifier] = reserva;
            }

            HashSet<Reserva> listaHashSet = new HashSet<Reserva>(this.Lista);

            foreach (var keyPair in this.Diccionario)
            {
                var reserva = keyPair.Value;
                if (!listaHashSet.Contains(reserva))
                {
                    this.Lista.Add(reserva);
                    listaHashSet.Add(reserva);
                }
            }
        }
    }
}
