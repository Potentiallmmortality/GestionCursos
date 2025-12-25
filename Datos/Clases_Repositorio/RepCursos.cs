// <copyright file="RepCursos.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.Clases_Repositorio;
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
            // implementación pendiente
        }

        void IRepGeneric<Curso>.persistirCambios()
        {
            // implementación pendiente
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
    }
}
