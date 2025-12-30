// <copyright file="ReservaJson.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Stock;

    public class ReservaJson
    {
        public string CodigoUnico { get; set; }

        public string? Dni_Estudiante { get; set; }

        public string? IdUnico_Curso { get; set; }

        public DateTime FechaReserva { get; set; }

        public EstadoReserva EstadoReserva { get; set; }
    }
}
