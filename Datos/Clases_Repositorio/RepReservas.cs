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
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;

    public class RepReservas : RepBase<Reserva>, IRepReservas
    {
        // Solo se manejará Identifier como clave para las reservas.
        public RepReservas(string filename)
            : base(filename)
        {
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
           // implementacion pendiente
        }

        void IRepGeneric<Reserva>.cargarDatos()
        {
           // implementacion pendiente
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
    }
}
