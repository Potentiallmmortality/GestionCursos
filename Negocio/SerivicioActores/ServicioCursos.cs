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

        public ServicioCursos(IRepCursos repCursos, IRepActores<Instructor> repInstructores)
        {
            this.repCursos = repCursos;
            this.repInstructores = repInstructores;
        }

        OperationResult INegocioCursos.Agregar(string nombre, string idUnico, int cupoMaximo)
        {
            try
            {
                if (this.Existe(idUnico))
                    return OperationResult.Fail("El curso ya está registrado \n");
                if (this.repCursos.guardarCurso(new Curso(nombre, idUnico, cupoMaximo)))
                    return OperationResult.Ok("Curso agregado con exito \n");
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
    }
}
