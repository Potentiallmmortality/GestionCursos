using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases_Repositorio;
using Entidades.Actores;
using Entidades.Stock;
using Datos.Interfaces;
using System.Globalization;
using Negocio.InterfacesNegocio;




namespace Negocio.SerivicioActores
{
    public class ServicioEstudiantes : INegocioActores
    {
        private readonly IRepActores<Estudiante> repEstudiantes;
        public ServicioEstudiantes(IRepActores<Estudiante> repEstudiantes)
        {
            this.repEstudiantes = repEstudiantes;
            //.. / Datos.Archivos_Repositorio / Estudiantes / estudiantes.json
        }
        OperationResult INegocioActores.Agregar(string nombre, string dni, string email, string usuario, string contraseña)
        {
            try
            {
                if (EstudianteExiste(dni,email,usuario)) 
                    return OperationResult.Fail("El estudiante ya se encuentre registrado \n");

                if (repEstudiantes.guardarPersonaje(new Estudiante(nombre, dni, email, usuario, contraseña))) 
                    return OperationResult.Ok("Estudiante agregado con éxito \n");
                else return OperationResult.Fail("No se pudo agregar el estudiante \n");
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
                if(!EstudianteExiste(dni))
                {
                    return OperationResult.Fail("El estudiante a eliminar no se encuentra en el Sistema");
                }

                if (repEstudiantes.eliminarPersonaje(repEstudiantes.BuscarPorIdentificacion(dni))) 
                    return OperationResult.Ok("Estudiante eliminado con éxito \n");

             
                else return OperationResult.Fail("No se pudo eliminar el estudiante \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioActores.ListarActores()
        {
            string aux = "";

            (var lista, Dictionary<string, Estudiante> diccionario) = repEstudiantes.obtenerTodos();

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
                repEstudiantes.persistirCambios();
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
                repEstudiantes.cargarDatos();
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
                var estudiante = repEstudiantes.BuscarPorIdentificacion(dni);
                return OperationResult.Ok(estudiante.ToString());
            }
            catch(Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        private bool EstudianteExiste(string dni, string email = "usuarioGenercic@epn.edu.ec", string usuario = "usuarioGenerico")
        {
            var estudianteExistente = repEstudiantes.BuscarPersonajePorParametros(dni, email, usuario);
            return estudianteExistente != null;
        }
    }
}
