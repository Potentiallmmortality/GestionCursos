using Datos.Interfaces;
using Entidades.Actores;

namespace Negocio.SerivicioActores
{
    public class ServicioInstructores: INegocioActores<Instructor>
    {
        private readonly IRepActores<Instructor> repInstructores;
        public ServicioInstructores()
        {
            this.repInstructores = null!;
            //.. / Datos.Archivos_Repositorio / Instructores / instructores.json
        }
        OperationResult INegocioActores<Instructor>.Agregar(string nombre, string dni, string email)
        {
            try
            {
                //Instructor? instructorExistente = repInstructores.buscarPersonaje(dni) as Instructor;
                //if (instructorExistente != null) throw new Exception("El instructor ya se encuentra registrado \n");
                if (repInstructores.guardarPersonaje(new Instructor(nombre, dni, email))) return OperationResult.Ok("Instructor agregado con éxito \n");
                else return OperationResult.Fail("No se pudo agregar el instructor \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores<Instructor>.Eliminar(string dni)
        {
            try
            {
                Instructor? instructorExistente = repInstructores.buscarPersonaje(dni) as Instructor;
                if (instructorExistente == null) throw new Exception("El instructor no se encuentra registrado \n");
                if (repInstructores.eliminarPersonaje(instructorExistente)) return OperationResult.Ok("Instructor eliminado con éxito \n");
                else return OperationResult.Fail("No se pudo eliminar el instructor \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores<Instructor>.PersistirCambios()
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
        OperationResult INegocioActores<Instructor>.Buscar(string parametro)
        {
            try
            {
                Instructor? instructorExistente = repInstructores.buscarPersonaje(parametro) as Instructor;
                if (instructorExistente == null) throw new Exception("El instructor no se encuentra registrado \n");
                return OperationResult.Ok("Instructor encontrado con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
    }
 }
