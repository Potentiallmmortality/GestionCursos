// <copyright file="IRepActores.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Actores;

    public interface IRepActores<T> : IRepGeneric<T>
        where T : Persona
    {
        bool guardarPersonaje(Persona persona);

        bool eliminarPersonaje(Persona persona);

        T? BuscarPersonajePorParametros(string dni, string email, string usuario);
    }
}
