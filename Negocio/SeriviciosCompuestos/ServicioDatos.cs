// <copyright file="ServicioDatos.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SeriviciosCompuestos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.Clases_Repositorio;
    using Datos.DTOs;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;

    public class ServicioDatos
    {
        private readonly IRepReservas repReservas;
        private readonly IRepCursos repCursos;
        private readonly IRepActores<Estudiante> repEstudiantes;
        private readonly IRepActores<Instructor> repInstructores;

        public ServicioDatos(IRepReservas repReservas, IRepCursos repCursos, IRepActores<Estudiante> repEstudiantes, IRepActores<Instructor> repInstructores)
        {
            this.repReservas = repReservas;
            this.repCursos = repCursos;
            this.repEstudiantes = repEstudiantes;
            this.repInstructores = repInstructores;
        }

        public void CargarRepositorios()
        {
            // Implementacion pendiente
        }

        public void GuardarRepositorios()
        {
            // Implementación pendiente
        }

        public void ReconstuirDatos()
        {
            // Implementación
        }
    }
}
