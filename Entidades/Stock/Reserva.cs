// <copyright file="Reserva.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Entidades.Stock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Actores;

    public class Reserva
    {
        private static int _contador = 0;
        private string codigoUnico;
        private Estudiante estudiante;
        private Curso curso;
        private DateTime fechaCreacion;
        private EstadoReserva estadoReserva;

        public Reserva(Estudiante estudiante, Curso curso)
        {
            if (estudiante == null || curso == null)
                throw new Exception("Datos Invalidos para crear la reserva");

            _contador++;
            this.fechaCreacion = DateTime.Now;
            this.estudiante = estudiante;
            this.curso = curso;
            this.codigoUnico = $"Book-{DateTime.Now:yyyyMMddHHfff}-{_contador:D3}";
            this.estadoReserva = EstadoReserva.En_Espera;
        }

        public string Identifier
        {
            get { return this.codigoUnico; }
            set { this.codigoUnico = value ?? this.codigoUnico; }
        }

        public Curso Curso
        {
            get { return this.curso; }
            set { this.curso = value ?? this.curso; }
        }

        public Estudiante Estudiante
        {
            get { return this.estudiante; }
            set { this.estudiante = value ?? this.estudiante; }
        }

        public DateTime FechaCreacion
        {
            get { return this.fechaCreacion; }
            set { this.fechaCreacion = value; }
        }

        public EstadoReserva Estado
        {
            get { return this.estadoReserva; }
            set { this.estadoReserva = value; }
        }

        public void aprobarReserva()
        {
            this.estadoReserva = EstadoReserva.Aprovada;
        }

        public bool reservaAprobada()
        {
            return this.estadoReserva == EstadoReserva.Aprovada;
        }

        public override string ToString()
        {
            return $"Reserva: {this.codigoUnico}, Estudiante: {this.estudiante.Nombre}, Curso: {this.curso.Nombre}, Fecha de Creacion: {this.fechaCreacion}, Estado: {this.estadoReserva}";
        }
    }
}
