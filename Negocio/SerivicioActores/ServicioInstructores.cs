// <copyright file="ServicioInstructores.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SerivicioActores
{
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Report;
    using Negocio.InterfacesNegocio;

    public class ServicioInstructores : INegocioActores
    {
        private readonly IRepActores<Instructor> repInstructores;
        private readonly IEvents _logger;

        public ServicioInstructores(IRepActores<Instructor> repInstructores, IEvents logger)
        {
            this.repInstructores = repInstructores;
            this._logger = logger;
        }

        OperationResult INegocioActores.Agregar(string nombre, string dni, string email)
        {
            try
            {
                if (this.InstructorExiste(dni, email))
                {
                    _logger.logEvent(Event.Error("El instructor ya se encuentra registrado"));
                    return OperationResult.Fail(" El instructor ya se enuentra agregado \n");
                }

                if (this.repInstructores.guardarPersonaje(new Instructor(nombre, dni, email)))
                {
                    _logger.logEvent(Event.Procedure("Agregar Instructor", $"Instructor {nombre} agregado con éxito"));
                    this.repInstructores.persistirCambios();
                    _logger.logEvent(Event.Procedure("Persistir Cambios", "Cambios persistidos con éxito"));
                    return OperationResult.Ok("Instructor agregado con éxito \n");
                }
                else
                {
                    _logger.logEvent(Event.Error("No se pudo agregar el instructor"));
                    return OperationResult.Fail("No se pudo agregar el instructor \n");
                }
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Agregar Instructor", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioActores.Eliminar(string dni)
        {
            try
            {
                if (!this.InstructorExiste(dni))
                    return OperationResult.Fail(" El instructor no se encuentra registrado \n");

                if (this.repInstructores.eliminarPersonaje(this.repInstructores.BuscarPorIdentificacion(dni)))
                    return OperationResult.Ok("Instructor eliminado con éxito \n");
                else
                    return OperationResult.Fail("No se pudo eliminar el instructor \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Eliminar Instructor", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioActores.ListarActores()
        {
            string aux = string.Empty;
            (var lista, Dictionary<string, Instructor> diccionario) = this.repInstructores.obtenerTodos();
            foreach (KeyValuePair<string, Instructor> k in diccionario)
            {
                var instructor = k.Value;
                aux += instructor.ToString();
            }
            _logger.logEvent(Event.Procedure("Listar Instructores", "Instructores listados con éxito"));
            return OperationResult.Ok(aux);
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repInstructores.persistirCambios();
                _logger.logEvent(Event.Procedure("Persistir Cambios", "Cambios persistidos con éxito"));
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Persistir Cambios", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.CargarDatos()
        {
            try
            {
                this.repInstructores.persistirCambios();
                _logger.logEvent(Event.Procedure("Cargar Datos", "Datos cargados con éxito"));
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Cargar Datos", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string parametro)
        {
            try
            {
                var instructor = this.repInstructores.BuscarPorIdentificacion(parametro);
                _logger.logEvent(Event.Procedure("Buscar Instructor", "Instructor encontrado con éxito"));
                return OperationResult.Ok(instructor.ToString());
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Buscar Instructor", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        private bool InstructorExiste(string dni, string email = "defaultEmail@epn.edu.ec", string usuario = "usuarioGenerico")
        {
            var instructorExistente = this.repInstructores.BuscarPersonajePorParametros(dni, email);
            _logger.logEvent(Event.Procedure("Verificar Existencia Instructor", instructorExistente != null ? "Instructor existente encontrado" : "Instructor no existente"));
            return instructorExistente != null;
        }

        public List<Entidades.Actores.Persona> ObtenerListaReal()
        {
            // Obtenemos la lista de instructores del repositorio
            var (lista, _) = this.repInstructores.obtenerTodos();
            _logger.logEvent(Event.Procedure("Obtener Lista Real de Instructores", "Lista obtenida con éxito"));
            return lista.Cast<Entidades.Actores.Persona>().ToList();
        }
    }
 }
