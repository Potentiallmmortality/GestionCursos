// <copyright file="ServicioDatos.cs" company="Grupo 9 Escuela Politécnica Nacional">
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
            this.repReservas.cargarDatos();
            this.repCursos.cargarDatos();
            this.repEstudiantes.cargarDatos();
            this.ReconstuirRelaciones();
        }

        private void ReconstuirRelaciones()
        {
            this.Reconstruir_Estudiante_Cursos();
            this.Reconstruir_Instructor_Cursos();
            this.Reconstruir_Reservas();
        }

        private void Reconstruir_Estudiante_Cursos()
        {
            foreach (var estudiante in this.repEstudiantes.obtenerTodos().Item1)
            {
                var idsCursos = estudiante.Datos;
                foreach (var idCurso in idsCursos)
                {
                    if (this.repCursos.obtenerTodos().Item2.TryGetValue(idCurso, out Curso? curso))
                    {
                        estudiante.agregarCurso(curso);
                        curso.agregarEstudiante(estudiante);
                    }
                }
            }
        }

        private void Reconstruir_Instructor_Cursos()
        {
            foreach (var curso in this.repCursos.obtenerTodos().Item1)
            {
                var dniInstructor = curso.Datos;
                if (!string.IsNullOrEmpty(dniInstructor) && this.repInstructores.obtenerTodos().Item2.TryGetValue(dniInstructor, out Instructor? instructor))
                {
                    curso.Instructor = instructor;
                    instructor.agregarCurso(curso);
                }
            }
        }

        private void Reconstruir_Reservas()
        {
            foreach (var reservaJson in this.repReservas.obtenerDatos())
            {
                if (this.repEstudiantes.obtenerTodos().Item2.TryGetValue(reservaJson.Dni_Estudiante!, out Estudiante? estudiante) &&
                    this.repCursos.obtenerTodos().Item2.TryGetValue(reservaJson.IdUnico_Curso!, out Curso? curso))
                {
                    Reserva reserva = new Reserva(estudiante, curso)
                    {
                        FechaCreacion = reservaJson.FechaReserva,
                        Estado = reservaJson.EstadoReserva,
                        Identifier = reservaJson.CodigoUnico,
                    };
                    this.repReservas.guardarReserva(reserva);
                }
            }
        }
    }
}
