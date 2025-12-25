// <copyright file="INegocioActores.cs" company=" Grupo 9: Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.InterfacesNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INegocioActores : INegocioGeneric
    {
        OperationResult Agregar(string nombre, string dni, string email, string usuario, string contraseña);

        OperationResult Eliminar(string dni);

        OperationResult ListarActores();
    }
}
