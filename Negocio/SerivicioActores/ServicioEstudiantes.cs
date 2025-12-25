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
    using Entidades.Stock;
    using Negocio.InterfacesNegocio;

    public class ServicioEstudiantes : INegocioActores
    {
        private readonly IRepActores<Estudiante> repEstudiantes;

        public ServicioEstudiantes(IRepActores<Estudiante> repEstudiantes)
        {
            this.repEstudiantes = repEstudiantes;

            // .. / Datos.Archivos_Repositorio / Estudiantes / estudiantes.json
        }

        OperationResult INegocioActores.Agregar(string nombre, string dni, string email, string usuario, string contraseña)
        {
            try
            {
                if (this.EstudianteExiste(dni, email, usuario))
                    return OperationResult.Fail("El estudiante ya se encuentre registrado \n");

                if (this.repEstudiantes.guardarPersonaje(new Estudiante(nombre, dni, email, usuario, contraseña)))
                    return OperationResult.Ok("Estudiante agregado con éxito \n");
                else
                    return OperationResult.Fail("No se pudo agregar el estudiante \n");
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
                if (!this.EstudianteExiste(dni))
                    return OperationResult.Fail("El estudiante a eliminar no se encuentra en el Sistema");

                if (this.repEstudiantes.eliminarPersonaje(this.repEstudiantes.BuscarPorIdentificacion(dni)))
                    return OperationResult.Ok("Estudiante eliminado con éxito \n");
                else
                    return OperationResult.Fail("No se pudo eliminar el estudiante \n");
            }
            catch (Exception ex)
            {
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

            return OperationResult.Ok(aux);
        }

        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                this.repEstudiantes.persistirCambios();
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
                this.repEstudiantes.cargarDatos();
                return OperationResult.Ok("Datos Cargados correctamente");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string dni)
        {
            try
            {
                var estudiante = this.repEstudiantes.BuscarPorIdentificacion(dni);
                return OperationResult.Ok(estudiante.ToString());
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        private bool EstudianteExiste(string dni, string email = "usuarioGenercic@epn.edu.ec", string usuario = "usuarioGenerico")
        {
            var estudianteExistente = this.repEstudiantes.BuscarPersonajePorParametros(dni, email, usuario);
            return estudianteExistente != null;
        }
    }
}
