// <copyright file="IRepCursos.cs" company="Grupo 9 Escuela Politécnica Nacional">
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
    using Entidades.Stock;

    public interface IRepCursos : IRepGeneric<Curso>
    {
        bool guardarCurso(Curso curso);

        bool eliminarCurso(Curso curso);

        Curso? BuscarCursoExistente(string codigoUnico);
    }
}
