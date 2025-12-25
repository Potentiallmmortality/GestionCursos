// <copyright file="Persona.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entidades.Actores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Stock;

    public abstract class Persona
    {
        private DateTime fechaRegistro;
        private string nombre;
        private string dni;
        private string email;
        private string usuario;
        private string contrasena;

        public Persona(string nombre, string dni, string email, string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                throw new Exception("Datos Invalidos");
            this.nombre = nombre;
            this.dni = dni;
            this.email = email;
            this.usuario = usuario;
            this.contrasena = contraseña;
            this.fechaRegistro = DateTime.Now;
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = string.IsNullOrWhiteSpace(value) ? this.nombre : value; }
        }

        public string Dni
        {
            get { return this.dni; }
            set { this.dni = string.IsNullOrWhiteSpace(value) ? this.dni : value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = string.IsNullOrWhiteSpace(value) ? this.email : value; }
        }

        public DateTime FechaRegistro
        {
            get { return this.fechaRegistro; }
            set { this.fechaRegistro = value; }
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = string.IsNullOrWhiteSpace(value) ? this.usuario : value; }
        }

        public string Contrasena
        {
            get { return this.contrasena; }
            set { this.contrasena = string.IsNullOrWhiteSpace(value) ? this.contrasena : value; }
        }
    }
}
