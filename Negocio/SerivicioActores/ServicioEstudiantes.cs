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




namespace Negocio.SerivicioActores
{
    public class ServicioEstudiantes : INegocioActores<Estudiante>
    {
        private readonly IRepActores<Estudiante> repEstudiantes;
        public ServicioEstudiantes()
        {
            this.repEstudiantes = new RepEstudiantes("");
            //.. / Datos.Archivos_Repositorio / Estudiantes / estudiantes.json
        }
        OperationResult INegocioActores<Estudiante>.Agregar(string nombre, string dni, string email)
        {
            try
            {
                Estudiante? estudianteExistente = repEstudiantes.buscarPersonaje(dni) as Estudiante;
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
                Estudiante? estudianteExistente = repEstudiantes.buscarPersonaje(dni) as Estudiante;
                if (estudianteExistente == null) throw new Exception("El estudiante no se encuentra registrado \n");
                if (repEstudiantes.eliminarPersonaje(estudianteExistente)) return OperationResult.Ok("Estudiante eliminado con éxito \n");
                else return OperationResult.Fail("No se pudo eliminar el estudiante \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
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
        OperationResult INegocioActores<Estudiante>.Buscar(string dni)
        {
            var estudiante = repEstudiantes.buscarPersonaje(dni) as Estudiante;
            if (estudiante == null) return OperationResult.Fail("Estudiante no encontrado \n");
            return OperationResult.Ok($"Nombre: {estudiante.Nombre} - DNI: {estudiante.Dni} - Email: {estudiante.Email} - ID: {estudiante.Identifier}\n");

        }
        public OperationResult ListarEstudiantes()
        {
            string aux = "";

            (var lista, Dictionary<string,Estudiante> diccionario) = repEstudiantes.obtenerTodos();
            
            foreach(KeyValuePair<string, Estudiante> k in diccionario)
            {
                var estudiante = k.Value;
                aux += $"Nombre: {estudiante.Nombre} - DNI: {estudiante.Dni} - Email: {estudiante.Email} - ID: {estudiante.Identifier}\n";
            }
            return OperationResult.Ok(aux);
        }
    }
}
