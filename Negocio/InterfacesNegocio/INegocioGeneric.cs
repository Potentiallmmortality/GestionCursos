// <copyright file="INegocioGeneric.cs" company=" Grupo 9: Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.InterfacesNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INegocioGeneric
    {
        OperationResult PersistirCambios();

        OperationResult CargarDatos();

        OperationResult Buscar(string parametro);
    }
}
