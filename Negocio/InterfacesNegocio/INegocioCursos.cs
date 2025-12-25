// <copyright file="INegocioCursos.cs" company=" Grupo 9: Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.InterfacesNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INegocioCursos : INegocioGeneric
    {
        OperationResult Agregar(string nombre, string idUnico, int cupoMaximo);

        OperationResult Eliminar(string idUnico);

        OperationResult ListarCursos();

        OperationResult AsignarInstructor(string dniInstructor, string codigoCurso);
    }
}
