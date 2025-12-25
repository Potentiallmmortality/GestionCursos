// <copyright file="EstadoReserva.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entidades.Stock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // Enum para los estados que podrá tener una reserva
    // Una reserva puede ser aprovada o dejada en espera
    public enum EstadoReserva
    {
        Aprovada,
        En_Espera,
    }
}
