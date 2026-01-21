namespace Datos.Clases_Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Datos.Interfaces;
    using Entidades.Report;

    public class EventLogger : IEvents
    {
        private string filePath;
        private List<Event> events;

        public EventLogger(string filePath)
        {
            this.filePath = filePath;
            this.events = new List<Event>();
        }

        void IEvents.logEvent(Event evento)
        {
            this.events.Add(evento);

            this.SaveEventsToFile();
        }

        void IEvents.LoadEventsFromFile()
        {
            if (File.Exists(this.filePath))
            {
                string json = File.ReadAllText(this.filePath);
                var options = new JsonSerializerOptions();
                options.Converters.Add(new JsonStringEnumConverter());
                this.events = JsonSerializer.Deserialize<List<Event>>(json, options) ?? new List<Event>();
            }
            else
                this.events = new List<Event>();
        }

        private void SaveEventsToFile()
        {
            string? directory = Path.GetDirectoryName(this.filePath);

            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            options.Converters.Add(new JsonStringEnumConverter());

            string json = JsonSerializer.Serialize(this.events, options);
            File.WriteAllText(this.filePath, json);
        }
    }
}



