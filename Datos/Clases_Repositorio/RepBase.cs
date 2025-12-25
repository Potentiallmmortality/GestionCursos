// <copyright file="RepBase.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.IO.Pipes;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Actores;

    public abstract class RepBase<T>
    {
        private string filename;
        private List<T> lista;
        private Dictionary<string, T> diccionario;

        public RepBase(string filename)
        {
            this.filename = filename;
            this.lista = new List<T>();
            this.diccionario = new Dictionary<string, T>();
        }

        public string Filename
        {
            get { return this.filename; }
            set { this.filename = string.IsNullOrWhiteSpace(value) ? this.filename : value; }
        }

        public List<T> Lista
        {
            get { return this.lista; }
        }

        public Dictionary<string, T> Diccionario
        {
            get { return this.diccionario; }
        }

        public bool agregarALista(T entidad)
        {
            if (entidad != null && !this.lista.Contains(entidad))
            {
                this.lista.Add(entidad);
                return true;
            }
            else
                return false;
        }

        public bool eliminarDeLista(T entidad)
        {
            if (entidad != null)
            {
                return this.lista.Remove(entidad);
            }
            else
                return false;
        }

        protected abstract bool agregarAlDiccionario(T entidad);

        protected abstract bool eliminarDelDiccionario(T entidad);
    }
}
