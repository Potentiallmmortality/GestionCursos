using Datos;
using Datos.Interfaces;
using Entidades;
using Entidades.Actores;
using Entidades.Stock;
using Negocio.InterfacesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.SeriviciosCompuestos
{
    public class ServicioReservas : INegocioReservas
    {
        private readonly IRepReservas repReservas;
        private readonly IRepCursos repCursos;
        private readonly IRepActores<Estudiante> repEstudiantes;
        public ServicioReservas(IRepReservas repReservas, IRepCursos repCursos, IRepActores<Estudiante> repEstudiantes)
        {
            this.repReservas = repReservas;
            this.repCursos = repCursos;
            this.repEstudiantes = repEstudiantes;
        }
        OperationResult INegocioReservas.CrearReserva(string dniEstudiante, string idUnicoCurso)
        {
            try
            {
                var estudiante = repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                var curso = repCursos.BuscarPorIdentificacion(idUnicoCurso);

                if (Existe(estudiante,curso)) 
                    return OperationResult.Fail("La reserva ya está registrada \n");

                if(repReservas.guardarReserva(new Reserva(estudiante, curso))) 
                    return OperationResult.Ok("La reserva ha sido registrada con éxito");

                else
                    return OperationResult.Fail("No se pudo registrar la reserva \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioReservas.CancelarReserva(string identifier)
        {
            try
            {
                var reserva = repReservas.BuscarPorIdentificacion(identifier);

                if (repReservas.eliminarReserva(reserva))
                    return OperationResult.Ok("La reserva se canceló correctamente \n");

                else return OperationResult.Fail("La reserva no se pudo cancelar \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioReservas.ListarTodas()
        {
            string aux = "";
            (var list, Dictionary<string, Reserva> Dicc) = repReservas.obtenerTodos();
            foreach (KeyValuePair<string, Reserva> pair in Dicc)
            {
                aux += pair.Value.ToString() + "\n";
            }
            return OperationResult.Ok(aux);
        }
        OperationResult INegocioReservas.AprovarReserva(string identifier)
        {
            try
            {
                var reserva = repReservas.BuscarPorIdentificacion(identifier);
                
                reserva.aprobarReserva();
                reserva.Estudiante.agregarCurso(reserva.Curso);
                reserva.Curso.agregarEstudiante(reserva.Estudiante);

                // sincronizar cambios

                //repCursos.persistirCambios();
                //repEstudiantes.persistirCambios();

                return OperationResult.Ok("La reserva ha sido aprobada con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        List<Reserva> INegocioReservas.ObtenerReservasPorEstudiante(string dniEstudiante)
        {
            try
            {
                var estudiante = repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                List<Reserva> aux = new List<Reserva>();
                (List<Reserva> Lista, Dictionary<string, Reserva> dicc) = repReservas.obtenerTodos();
                foreach (Reserva reserva in Lista)
                {
                    if (reserva.Estudiante.Dni == estudiante.Dni)
                    {
                        aux.Add(reserva);
                    }
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message} \n");
            }
        }
        OperationResult INegocioGeneric.Buscar(string identifier)
        {
            try
            {
                var reserva = repReservas.BuscarPorIdentificacion(identifier);
                return OperationResult.Ok(reserva.toString());
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
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
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }
        private bool Existe(Estudiante estudiante, Curso curso)
        {
            var reservasEstudiante = repReservas.BuscarPorEstudianteYCursos(estudiante, curso);
            return reservasEstudiante != null;
        }
    }
}
