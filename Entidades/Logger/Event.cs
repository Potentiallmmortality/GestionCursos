namespace Entidades.Report
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Event(Nivel tipo, string accion, string mensaje)
    {
        public Nivel Tipo { get; protected set; } = tipo;

        public DateTime Fecha { get; protected set; } = DateTime.Now;

        public string Accion { get; protected set; } = accion;

        public string Mensaje { get; protected set; } = mensaje;

        public static Event Procedure(string accion, string mensaje)
        {
            return new Event(Nivel.Procedure, accion, mensaje);
        }

        public static Event Critical(string accion, string mensaje)
        {
            return new Event(Nivel.Critical, accion, mensaje);
        }

        public static Event Error(string mensaje)
        {
            return new Event(Nivel.Error, "Excepción controlada", mensaje);
        }

        public override string ToString()
        {
            return $"[{this.Fecha.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}] [{this.Tipo}] {this.Accion} - {this.Mensaje}\n";
        }
    }
}
