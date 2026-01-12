using Datos.Clases_Repositorio; // Aquí suelen estar las clases concretas
using Datos.Interfaces;
using UIs;         // Por si acaso necesites las interfaces

namespace GestionCursos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}