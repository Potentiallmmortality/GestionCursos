// <copyright file="ServicioInstructores.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SerivicioActores
{
    using Datos.Clases_Repositorio;
    using Datos.Interfaces;
    using Entidades.Actores;
    using Negocio.InterfacesNegocio;

    public class ServicioInstructores : INegocioActores
    {
        private readonly IRepActores<Instructor> repInstructores;

        public ServicioInstructores(IRepActores<Instructor> repInstructores)
        {
            this.repInstructores = repInstructores;

            // .. / Datos.Archivos_Repositorio / Instructores / instructores.json
        }

        OperationResult INegocioActores.Agregar(string nombre, string dni, string email, string usuario, string contraseña)
        {
            try
            {
                if (this.InstructorExiste(dni, email, usuario))
                    return OperationResult.Fail(" El instructor ya se enuentra agregado \n");

                if (this.repInstructores.guardarPersonaje(new Instructor(nombre, dni, email, usuario, contraseña)))
                    return OperationResult.Ok("Instructor agregado con éxito \n");
                else
                    return OperationResult.Fail("No se pudo agregar el instructor \n");
            }
            catch (Exception ex)
            {
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

            return OperationResult.Ok(aux);
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repInstructores.persistirCambios();
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
                this.repInstructores.persistirCambios();
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
                var instructor = this.repInstructores.BuscarPorIdentificacion(parametro);
                return OperationResult.Ok(instructor.ToString());
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        private bool InstructorExiste(string dni, string email = "defaultEmail@epn.edu.ec", string usuario = "usuarioGenerico")
        {
            var instructorExistente = this.repInstructores.BuscarPersonajePorParametros(dni, email, usuario);
            return instructorExistente != null;
        }
    }
 }
