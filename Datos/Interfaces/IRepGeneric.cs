// <copyright file="IRepGeneric.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Stock;

    public interface IRepGeneric<T>
        where T : class
    {
        void persistirCambios();

        void cargarDatos();

        (List<T>, Dictionary<string, T>) obtenerTodos();

        T? BuscarPorIdentificacion(string id);
    }
}
