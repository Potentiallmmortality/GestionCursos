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
    using System.Threading.Tasks;
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
            // implementación pendiente
        }

        void IRepGeneric<Instructor>.cargarDatos()
        {
            // implementación pendiente
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
    }
}
