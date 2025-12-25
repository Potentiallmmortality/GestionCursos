// <copyright file="InstructorJson.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Datos.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class InstructorJson
    {
        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; }

        public List<string> IdsUnicosCursos { get; set; } = new ();

        public string Identifier { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }
    }
}
