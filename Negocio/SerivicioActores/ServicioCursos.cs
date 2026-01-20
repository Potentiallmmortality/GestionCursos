// <copyright file="ServicioCursos.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SerivicioActores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Stock;
    using Negocio.InterfacesNegocio;

    public class ServicioCursos : INegocioCursos
    {
        private readonly IRepCursos repCursos;
        private readonly IRepActores<Instructor> repInstructores;

        private readonly IRepActores<Estudiante> repEstudiantes;

        public ServicioCursos(IRepCursos repCursos, IRepActores<Instructor> repInstructores, IRepActores<Estudiante> repEstudiantes)
        {
            this.repCursos = repCursos;
            this.repInstructores = repInstructores;
            this.repEstudiantes = repEstudiantes;

        }

        OperationResult INegocioCursos.Agregar(string nombre, string idUnico, int cupoMaximo)
        {
            try
            {
                if (this.Existe(idUnico))
                    return OperationResult.Fail("El curso ya está registrado \n");

                // 1. Guardamos en memoria (RAM)
                if (this.repCursos.guardarCurso(new Curso(nombre, idUnico, cupoMaximo)))
                {
                    // 2. ¡IMPORTANTE! Guardamos en el archivo físico (JSON)
                    this.repCursos.persistirCambios(); // <--- AGREGA ESTA LÍNEA

                    return OperationResult.Ok("Curso agregado con exito \n");
                }
                else
                    return OperationResult.Fail("No se puedo agregar Curso \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioCursos.Eliminar(string idUnico)
        {
            try
            {
                if (!this.Existe(idUnico))
                    return OperationResult.Fail("El curso a eliminar no se encuentra en el Sistema");

                if (this.repCursos.eliminarCurso(this.repCursos.BuscarPorIdentificacion(idUnico)))
                    return OperationResult.Ok("El Curso se eliminó correctamente \n");
                else
                    return OperationResult.Fail("El Curso no se pudo eliminar \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioCursos.ListarCursos()
        {
            (var list, Dictionary<string, Curso> dicc) = this.repCursos.obtenerTodos();
            string aux = string.Empty;

            foreach (KeyValuePair<string, Curso> pair in dicc)
            {
                var curso = pair.Value;
                aux += curso.ToString();
            }

            return OperationResult.Ok(aux);
        }

        OperationResult INegocioCursos.AsignarInstructor(string dniInstructor, string codigoCurso)
        {
            // Recordatorio importante, si no se encuentra alguno de los dos se lanza una excepcion
            // please ignore the warnings
            try
            {
                var instructor = this.repInstructores.BuscarPorIdentificacion(dniInstructor);
                var curso = this.repCursos.BuscarPorIdentificacion(codigoCurso);

                if (instructor.agregarCurso(curso))
                {
                    curso.Instructor = instructor;
                }
                else
                    return OperationResult.Fail("El instructor ya está asignado a este curso \n");

                this.repInstructores.persistirCambios();
                this.repCursos.persistirCambios();

                return OperationResult.Ok("Curso agregado correctamente");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repCursos.persistirCambios();
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.CargarDatos()
        {
            try
            {
                this.repCursos.cargarDatos();
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string parametro)
        {
            try
            {
                string aux = $"{this.repCursos.BuscarPorIdentificacion(parametro).ToString()} \n";
                return OperationResult.Ok(aux);
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }

        private bool Existe(string idUnico)
        {
            var existente = this.repCursos.BuscarCursoExistente(idUnico);
            return existente != null;
        }

        public List<Entidades.Stock.Curso> ObtenerListaReal()
        {
            var (lista, _) = this.repCursos.obtenerTodos();
            return lista;
        }

        public OperationResult MatricularEstudiante(string dniEstudiante, string codigoCurso)
        {
            try
            {
                var estudiante = this.repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                var curso = this.repCursos.BuscarPorIdentificacion(codigoCurso);

                if (estudiante == null) return OperationResult.Fail("Estudiante no encontrado.");
                if (curso == null) return OperationResult.Fail("Curso no encontrado.");

                if (curso.agregarEstudiante(estudiante))
                {
                    this.repCursos.persistirCambios();

                    return OperationResult.Ok($"Estudiante {estudiante.Nombre} matriculado en {curso.Nombre} exitosamente.");
                }
                else
                {
                    if (curso.CursoCerrado())
                        return OperationResult.Fail("No se pudo matricular: El curso está CERRADO (Cupo lleno).");
                    else
                        return OperationResult.Fail("El estudiante ya está inscrito en este curso o hubo un error.");
                }
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Error al matricular: " + ex.Message);
            }
        }

        public List<Entidades.Stock.Curso> ObtenerCursosPorEstudiante(string dniEstudiante)
        {
            var (todosLosCursos, _) = this.repCursos.obtenerTodos();
            var cursosDelEstudiante = todosLosCursos
                .Where(curso => curso.EstudiantesInscritos.Any(est => est.Dni == dniEstudiante))
                .ToList();

            return cursosDelEstudiante;
        }

    }
}
