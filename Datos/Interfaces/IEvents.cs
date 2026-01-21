namespace Datos.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Entidades.Report;

    public interface IEvents
    {
        void logEvent(Event evento);

        void LoadEventsFromFile();
    }
}
