// <copyright file="ServicioReservas.cs" company="Grupo 9 Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio.SeriviciosCompuestos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using Datos;
    using Datos.Interfaces;
    using Entidades;
    using Entidades.Actores;
    using Entidades.Stock;
    using Negocio.InterfacesNegocio;

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
                var estudiante = this.repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                var curso = this.repCursos.BuscarPorIdentificacion(idUnicoCurso);

                if (this.Existe(estudiante!, curso!))
                    return OperationResult.Fail("La reserva ya está registrada \n");

                if (this.repReservas.guardarReserva(new Reserva(estudiante!, curso!)))
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
                var reserva = this.repReservas.BuscarPorIdentificacion(identifier);

                if (this.repReservas.eliminarReserva(reserva!))
                    return OperationResult.Ok("La reserva se canceló correctamente \n");
                else
                    return OperationResult.Fail("La reserva no se pudo cancelar \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioReservas.ListarTodas()
        {
            string aux = string.Empty;
            (var list, Dictionary<string, Reserva> dicc) = this.repReservas.obtenerTodos();
            foreach (KeyValuePair<string, Reserva> pair in dicc)
            {
                aux += pair.Value.ToString() + "\n";
            }

            return OperationResult.Ok(aux);
        }

        OperationResult INegocioReservas.AprovarReserva(string identifier)
        {
            try
            {
                var reserva = this.repReservas.BuscarPorIdentificacion(identifier);
                if (reserva!.Estado != EstadoReserva.En_Espera)
                    return OperationResult.Fail("La reserva no se encuentra en estado 'En Espera' \n");

                if (reserva.Curso.Estado != EstadoCurso.Abierto)
                    return OperationResult.Fail("El curso asociado a la reserva no está abierto \n");

                reserva.aprobarReserva();
                reserva.Curso.agregarEstudiante(reserva.Estudiante);
                reserva.Estudiante.agregarCurso(reserva.Curso);

                this.repCursos.persistirCambios();
                this.repEstudiantes.persistirCambios();
                this.repReservas.persistirCambios();

                return OperationResult.Ok("La reserva ha sido aprobada con éxito \n");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioReservas.ObtenerReservasPorEstudiante(string dniEstudiante)
        {
            try
            {
                var estudiante = this.repEstudiantes.BuscarPorIdentificacion(dniEstudiante);
                string aux = string.Empty;
                (List<Reserva> lista, Dictionary<string, Reserva> dicc) = this.repReservas.obtenerTodos();
                foreach (Reserva reserva in lista)
                {
                    if (reserva.Estudiante.Dni == estudiante!.Dni)
                    {
                        aux += reserva;
                    }
                }

                return OperationResult.Ok(aux);
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"Error {ex.Message} \n");
            }
        }

        OperationResult INegocioGeneric.Buscar(string identifier)
        {
            try
            {
                var reserva = this.repReservas.BuscarPorIdentificacion(identifier);
                return OperationResult.Ok(reserva!.ToString());
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

        private bool Existe(Estudiante estudiante, Curso curso)
        {
            var reservasEstudiante = this.repReservas.BuscarPorEstudianteYCursos(estudiante, curso);
            return reservasEstudiante != null;
        }
    }
}
