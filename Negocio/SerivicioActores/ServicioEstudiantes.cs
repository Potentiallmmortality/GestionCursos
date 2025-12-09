using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases_Repositorio;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Interfaces;




namespace Negocio.SerivicioActores
{
    public class ServicioEstudiantes : INegocioActores<Estudiante>
    {
        private readonly IRepActores<Estudiante> repEstudiantes;
        public ServicioEstudiantes()
        {
            this.repEstudiantes = new RepEstudiantes("");
        }
        OperationResult INegocioActores<Estudiante>.Agregar(string nombre, string dni, string email)
        {
            try
            {
                var estudianteExistente = repEstudiantes.buscarPersonaje(dni);
                if (estudianteExistente != null) throw new Exception("El estudiante ya se encuentra registrado \n");

                if (repEstudiantes.guardarPersonaje(new Estudiante(nombre, dni, email))) return OperationResult.Ok("Estudiante agregado con éxito \n");
                else return OperationResult.Fail("No se pudo agregar el estudiante \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores<Estudiante>.Eliminar(string dni)
        {
            try
            {
                var estudianteExistente = repEstudiantes.buscarPersonaje(dni);
                if (estudianteExistente == null) throw new Exception("El estudiante no se encuentra registrado \n");
                if (repEstudiantes.eliminarPersonaje(estudianteExistente)) return OperationResult.Ok("Estudiante eliminado con éxito \n");
                else return OperationResult.Fail("No se pudo eliminar el estudiante \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores<Estudiante>.Modificar(string parametro)
        {
            throw new NotImplementedException();
        }
        OperationResult INegocioActores<Estudiante>.PersistirCambios()
        {
            try
            {
                repEstudiantes.persistirCambios();
                return OperationResult.Ok("Cambios persistidos con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        Estudiante INegocioActores<Estudiante>.Buscar(string parametro)
        {
            throw new NotImplementedException();
        }
        public void ListarEstudiantes()
        {

        }
    }
}
