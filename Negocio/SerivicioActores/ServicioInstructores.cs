using Datos.Clases_Repositorio;
using Datos.Interfaces;
using Entidades.Actores;
using Negocio.InterfacesNegocio;

namespace Negocio.SerivicioActores
{
    public class ServicioInstructores: INegocioActores
    {
        private readonly IRepActores<Instructor> repInstructores;
        public ServicioInstructores(IRepActores<Instructor> repInstructores)
        {
            this.repInstructores = repInstructores;
            //.. / Datos.Archivos_Repositorio / Instructores / instructores.json
        }
        OperationResult INegocioActores.Agregar(string nombre, string dni, string email)
        {
            try
            {
                if (InstructorExiste(dni, email)) 
                    return OperationResult.Fail(" El instructor ya se enuentra agregado \n");
               
                if ( repInstructores.guardarPersonaje(new Instructor(nombre, dni, email))) 
                    return OperationResult.Ok("Instructor agregado con éxito \n");

                else return OperationResult.Fail("No se pudo agregar el instructor \n");
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
                if (repInstructores.eliminarPersonaje(repInstructores.BuscarPorIdentificacion(dni)))
                    return OperationResult.Ok("Instructor eliminado con éxito \n");

                else return OperationResult.Fail("No se pudo eliminar el instructor \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores.ListarActores()
        {
            string aux = "";
            (var lista, Dictionary<string, Instructor> diccionario) = repInstructores.obtenerTodos();
            foreach (KeyValuePair<string, Instructor> k in diccionario)
            {
                var instructor = k.Value;
                aux += instructor.toString();
            }
            return OperationResult.Ok(aux);
        }
        OperationResult INegocioGeneric.PersistirCambios()
        {
            try
            {
                repInstructores.persistirCambios();
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
                repInstructores.cargarDatos();
                return OperationResult.Ok("Datos cargados con éxito \n");
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
                var instructor = repInstructores.BuscarPorIdentificacion(parametro);
                
                return OperationResult.Ok(instructor.toString());
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        private bool InstructorExiste(string dni, string email = "defaultEmail@epn.edu.ec")
        {
            var instructorExistente = repInstructores.BuscarPorParametros(dni, email);
            return instructorExistente != null;
        }
    }
 }
