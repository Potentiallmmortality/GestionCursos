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
    using System.Threading.Tasks;
    using System.Transactions;
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
            // implementacion pendiente
        }

        void IRepGeneric<Estudiante>.cargarDatos()
        {
            // implementacion pendiente
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
    }
}
