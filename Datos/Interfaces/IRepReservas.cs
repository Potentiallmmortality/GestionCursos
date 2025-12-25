// <copyright file="IRepReservas.cs" company="Grupo 9 Escuela Politécnica Nacional">
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

    public interface IRepReservas : IRepGeneric<Reserva>
    {
        bool guardarReserva(Reserva reserva);

        bool eliminarReserva(Reserva reserva);

        Reserva? BuscarPorEstudianteYCursos(Estudiante estudiante, Curso curso);
    }
}
