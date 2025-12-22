using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Clases_Repositorio;
using Datos.Interfaces;
using Negocio.InterfacesNegocio;

namespace Negocio.SerivicioActores
{
    public class ServicioCursos: INegocioCursos
    {
        // implementacion pendiente

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
                if (Existe(idUnico))
                    return OperationResult.Fail("El curso ya está registrado \n");

                if (repCursos.guardarCurso(new Curso(nombre, idUnico, cupoMaximo)))
                    return OperationResult.Ok("Curso agregado con exito \n");

                else return OperationResult.Fail("No se puedo agregar Curso \n");
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
                if (!Existe(idUnico))
                {
                    return OperationResult.Fail("El curso a eliminar no se encuentra en el Sistema");
                }
                if (repCursos.eliminarCurso(repCursos.BuscarPorIdentificacion(idUnico)))
                    return OperationResult.Ok("El Curso se eliminó correctamente \n");

                else return OperationResult.Fail("El Curso no se pudo eliminar \n");
            }catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioCursos.ListarCursos()
        {
            (var list, Dictionary<string, Curso> Dicc) = repCursos.obtenerTodos();
            string aux = "";
            foreach(KeyValuePair<string, Curso> pair in Dicc)
            {
                var Curso = pair.Value;
                aux += Curso.ToString();
            }
            return OperationResult.Ok(aux);
        }
        OperationResult INegocioCursos.AsignarInstructor(string dniInstructor, string codigoCurso)
        {
            // Recordatorio importante, si no se encuentra alguno de los dos se lanza una excepcion
            // please ignore the warnings
            try
            {
                var instructor = repInstructores.BuscarPorIdentificacion(dniInstructor);
                var curso = repCursos.BuscarPorIdentificacion(codigoCurso);
                
            // Cumplir con la multiplicidad de clases

                if (instructor.agregarCurso(curso))
                {
                    curso.Instructor = instructor;
                } else return OperationResult.Fail("El instructor ya está asignado a este curso \n");

                // Sincronizar ambos repositorios

                repInstructores.persistirCambios();
                repCursos.persistirCambios();

                return OperationResult.Ok("Curso agregado correctamente");

            }catch (Exception ex)
            {
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }
        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                repCursos.persistirCambios();
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
                repCursos.cargarDatos();
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch(Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioGeneric.Buscar(string parametro)
        {
            try 
            {
                string aux = $"{repCursos.BuscarPorIdentificacion(parametro).ToString()} \n";
                return OperationResult.Ok(aux);
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error: {ex.Message} \n");
            }
        }

        private bool Existe(string idUnico)
        {
            var existente = repCursos.BuscarPorParametros(idUnico);
            return existente != null;
        }
    }
}
