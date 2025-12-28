using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos.Clases_Repositorio;
using Datos.Interfaces;
using Entidades.Actores;

namespace CursosTest
{
    [TestClass]
    public sealed class RepEstudiantesTest
    {
        private void Test_ManejoArchivos_repositorio_PersistirCambios()
        {
            try
            {
                IRepActores<Estudiante> RepEstudiantes = new RepEstudiantes("..\\CursosTest\\DirectorioTest\\EstudiantesTest.json");

                RepEstudiantes.guardarPersonaje(new Estudiante("Juan Perez", "1234567890", "Juan.Perez@epn.ecu.ec", "juanito", "pasword"));

                RepEstudiantes.guardarPersonaje(new Estudiante("Maria Gomez", "0987654321", "maria.gomez@epn.edu.ec", "marie", "currie"));

                RepEstudiantes.guardarPersonaje(new Estudiante("Sebastian Arevalo", "1755323215", "sebastian.arevalo@epn.edu.ec", "sebitas3", "saludos"));

                RepEstudiantes.persistirCambios();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + '\n');
            }
        }
        private IRepActores<Estudiante>? Test_ManejoArchivos_repositorio_CargarCambios()
        {
            try
            {
                IRepActores<Estudiante> RepEstudiantes = new RepEstudiantes("..\\CursosTest\\DirectorioTest\\EstudiantesTest.json");

                RepEstudiantes.cargarDatos();

                return RepEstudiantes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + '\n');
                return null;
            }
        }

        [TestMethod]
        public void Test_ManejoArchivos()
        {
            this.Test_ManejoArchivos_repositorio_PersistirCambios();
            
            IRepActores<Estudiante>? rep = this.Test_ManejoArchivos_repositorio_CargarCambios();

            Assert.IsNotNull(rep);

            Assert.IsNotNull(rep.obtenerTodos());

            Assert.IsTrue(File.Exists("..\\CursosTest\\DirectorioTest\\EstudiantesTest.json"));

            Assert.AreEqual(3, rep.obtenerTodos().Item1.Count());
        }
    }
}
