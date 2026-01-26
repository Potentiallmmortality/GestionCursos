// <copyright file="ServicioEstudiantes.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SerivicioActores
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Entidades.Report;
    using Entidades.Stock;
    using Negocio.InterfacesNegocio;

    public class ServicioEstudiantes : INegocioActores
    {
        private readonly IRepActores<Estudiante> repEstudiantes;
        private readonly IEvents _logger;

        public ServicioEstudiantes(IRepActores<Estudiante> repEstudiantes, IEvents logger)
        {
            this.repEstudiantes = repEstudiantes;
            this._logger = logger;
        }

        OperationResult INegocioActores.Agregar(string nombre, string dni, string email)
        {
            try
            {
                if (this.EstudianteExiste(dni, email))
                    return OperationResult.Fail("El estudiante ya se encuentre registrado \n");

                if (this.repEstudiantes.guardarPersonaje(new Estudiante(nombre, dni, email)))
                {
                    this.repEstudiantes.persistirCambios();
                    _logger.logEvent(Event.Procedure("Agregar Estudiante", "Estudiante agregado con éxito"));
                    return OperationResult.Ok("Estudiante agregado con éxito \n");
                }
                else
                {
                    _logger.logEvent(Event.Error("No se pudo agregar el estudiante"));
                    return OperationResult.Fail("No se pudo agregar el estudiante \n");
                }
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Agregar Estudiante", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioActores.Eliminar(string dni)
        {
            try
            {
                if (!this.EstudianteExiste(dni))
                {
                    _logger.logEvent(Event.Error("El estudiante a eliminar no se encuentra en el Sistema"));
                    return OperationResult.Fail("El estudiante a eliminar no se encuentra en el Sistema");
                }

                if (this.repEstudiantes.eliminarPersonaje(this.repEstudiantes.BuscarPorIdentificacion(dni)))
                    return OperationResult.Ok("Estudiante eliminado con éxito \n");
                else
                {
                    _logger.logEvent(Event.Error("No se pudo eliminar el estudiante"));
                    return OperationResult.Fail("No se pudo eliminar el estudiante \n");
                }

            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Eliminar Estudiante", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioActores.ListarActores()
        {
            string aux = string.Empty;

            (var lista, Dictionary<string, Estudiante> diccionario) = this.repEstudiantes.obtenerTodos();

            foreach (KeyValuePair<string, Estudiante> k in diccionario)
            {
                var estudiante = k.Value;
                aux += estudiante.ToString();
            }
            _logger.logEvent(Event.Procedure("Listar Estudiantes", "Estudiantes listados con éxito"));
            return OperationResult.Ok(aux);
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repEstudiantes.persistirCambios();
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
                this.repEstudiantes.cargarDatos();
                _logger.logEvent(Event.Procedure("Cargar Datos", "Datos Cargados correctamente"));
                return OperationResult.Ok("Datos Cargados correctamente");
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Cargar Datos", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string dni)
        {
            try
            {
                var estudiante = this.repEstudiantes.BuscarPorIdentificacion(dni);
                _logger.logEvent(Event.Procedure("Buscar Estudiante", "Estudiante encontrado con éxito"));
                return OperationResult.Ok(estudiante.ToString());
            }
            catch (Exception ex)
            {
                _logger.logEvent(Event.Critical("Buscar Estudiante", ex.Message));
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        private bool EstudianteExiste(string dni, string email = "usuarioGenercic@epn.edu.ec", string usuario = "usuarioGenerico")
        {
            var estudianteExistente = this.repEstudiantes.BuscarPersonajePorParametros(dni, email);
            _logger.logEvent(Event.Procedure("Verificar existencia de Estudiante", estudianteExistente != null ? "Estudiante existente" : "Estudiante no existente"));
            return estudianteExistente != null;
        }

        public List<Entidades.Actores.Persona> ObtenerListaReal()
        {
            var (lista, _) = this.repEstudiantes.obtenerTodos();
            _logger.logEvent(Event.Procedure("Obtener Lista Real de Estudiantes", "Lista obtenida con éxito"));
            return lista.Cast<Entidades.Actores.Persona>().ToList();
        }
    }
}
