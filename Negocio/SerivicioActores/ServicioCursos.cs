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
    using Entidades.Report;

    public class ServicioCursos : INegocioCursos
    {
        private readonly IRepCursos repCursos;
        private readonly IRepActores<Instructor> repInstructores;
        private readonly IRepActores<Estudiante> repEstudiantes;
        private readonly IEvents _logger;

        public ServicioCursos(IRepCursos repCursos, IRepActores<Instructor> repInstructores, IRepActores<Estudiante> repEstudiantes, IEvents logger)
        {
            this.repCursos = repCursos;
            this.repInstructores = repInstructores;
            this.repEstudiantes = repEstudiantes;
            this._logger = logger;
        }

        OperationResult INegocioCursos.Agregar(string nombre, string idUnico, int cupoMaximo)
        {
            try
            {
                if (this.Existe(idUnico))
                    _logger.logEvent(Event.Error($"El curso {nombre} ya está registrado"));
                return OperationResult.Fail("El curso ya está registrado \n");

                if (this.repCursos.guardarCurso(new Curso(nombre, idUnico, cupoMaximo)))
                {
                    this.repCursos.persistirCambios(); 
                    _logger.logEvent(Event.Error($"Curso {nombre} agregado con exito"));
                    return OperationResult.Ok("Curso agregado con exito \n");
                }
                else
                    _logger.logEvent(Event.Error($"No se puedo agregar Curso {nombre}"));
                return OperationResult.Fail("No se puedo agregar Curso \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al agregar curso: {ex.Message}"));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioCursos.Eliminar(string idUnico)
        {
            try
            {
                if (!this.Existe(idUnico))
                    _logger.logEvent(Event.Error($"El curso a eliminar no se encuentra en el Sistema"));
                return OperationResult.Fail("El curso a eliminar no se encuentra en el Sistema");

                if (this.repCursos.eliminarCurso(this.repCursos.BuscarPorIdentificacion(idUnico)))

                    return OperationResult.Ok("El Curso se eliminó correctamente \n");
                else
                    _logger.logEvent(Event.Error($"El Curso no se pudo eliminar"));
                return OperationResult.Fail("El Curso no se pudo eliminar \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al eliminar curso: {ex.Message}"));
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
            _logger.logEvent(Event.Procedure("Listar Cursos", "Listado de cursos generado con éxito"));
            return OperationResult.Ok(aux);
        }

        OperationResult INegocioCursos.AsignarInstructor(string dniInstructor, string codigoCurso)
        {
            try
            {
                var instructor = this.repInstructores.BuscarPorIdentificacion(dniInstructor);
                var curso = this.repCursos.BuscarPorIdentificacion(codigoCurso);

                if (instructor.agregarCurso(curso))
                {
                    curso.Instructor = instructor;
                }
                else
                    _logger.logEvent(Event.Error($"El instructor ya está asignado a este curso"));
                return OperationResult.Fail("El instructor ya está asignado a este curso \n");

                this.repInstructores.persistirCambios();
                this.repCursos.persistirCambios();
                _logger.logEvent(Event.Procedure("Asignar Instructor", $"Instructor {instructor.Nombre} asignado al curso {curso.Nombre} con éxito"));
                return OperationResult.Ok("Curso agregado correctamente");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al asignar instructor: {ex.Message}"));
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repCursos.persistirCambios();
                _logger.logEvent(Event.Procedure("Persistir Cambios", "Cambios persistidos con éxito"));
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al persistir cambios: {ex.Message}"));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.CargarDatos()
        {
            try
            {
                this.repCursos.cargarDatos();
                _logger.logEvent(Event.Procedure("Cargar Datos", "Datos cargados con éxito"));
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al cargar datos: {ex.Message}"));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string parametro)
        {
            try
            {
                string aux = $"{this.repCursos.BuscarPorIdentificacion(parametro).ToString()} \n";
                _logger.logEvent(Event.Procedure("Buscar Curso", "Curso encontrado con éxito"));
                return OperationResult.Ok(aux);
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al buscar curso: {ex.Message}"));
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }

        private bool Existe(string idUnico)
        {
            var existente = this.repCursos.BuscarCursoExistente(idUnico);
            _logger.logEvent(Event.Procedure("Verificar Existencia", existente != null ? "Curso existente encontrado" : "Curso no existente"));
            return existente != null;
        }

        public List<Entidades.Stock.Curso> ObtenerListaReal()
        {
            var (lista, _) = this.repCursos.obtenerTodos();
            _logger.logEvent(Event.Procedure("Obtener Lista Real", "Lista de cursos obtenida con éxito"));
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
                    _logger.logEvent(Event.Procedure("Matricular Estudiante", $"Estudiante {estudiante.Nombre} matriculado en {curso.Nombre} exitosamente"));
                    return OperationResult.Ok($"Estudiante {estudiante.Nombre} matriculado en {curso.Nombre} exitosamente.");
                }
                else
                {
                    if (curso.CursoCerrado())
                        return OperationResult.Fail("No se pudo matricular: El curso está CERRADO (Cupo lleno).");
                    else
                        _logger.logEvent(Event.Error($"El estudiante ya está inscrito en este curso o hubo un error."));
                    return OperationResult.Fail("El estudiante ya está inscrito en este curso o hubo un error.");
                }
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Error($"Error al matricular estudiante: {ex.Message}"));
                return OperationResult.Fail("Error al matricular: " + ex.Message);
            }
        }

        public List<Entidades.Stock.Curso> ObtenerCursosPorEstudiante(string dniEstudiante)
        {
            var (todosLosCursos, _) = this.repCursos.obtenerTodos();
            var cursosDelEstudiante = todosLosCursos
                .Where(curso => curso.EstudiantesInscritos.Any(est => est.Dni == dniEstudiante))
                .ToList();
            _logger.logEvent(Event.Procedure("Obtener Cursos por Estudiante", $"Cursos obtenidos para el estudiante con DNI {dniEstudiante}"));
            return cursosDelEstudiante;
        }

    }
}
