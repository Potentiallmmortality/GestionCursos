namespace Entidades.Report
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Nivel
    {
        // Toda acción o procedimiento que no afecta la seguridad, integridad o disponibilidad de los sistemas o datos.
        Procedure,

        // Evento que cuyo status no ha sido exitoso
        Critical,

        // Se ha lanzado una éxcepción que ha sido controlada
        Error,
    }
}
