// <copyright file="INegocioReservas.cs" company=" Grupo 9: Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.InterfacesNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Actores;
    using Entidades.Stock;

    public interface INegocioReservas : INegocioGeneric
    {
        OperationResult CrearReserva(string dniEstudiante, string idUnicoCurso);

        OperationResult CancelarReserva(string identifier);

        OperationResult ListarTodas();

        OperationResult AprovarReserva(string identifier);

        OperationResult ObtenerReservasPorEstudiante(string dniEstudiante);
    }
}
