using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos.Clases_Repositorio;
using Datos.Interfaces;
using Entidades.Actores;
using Entidades.Stock;

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
                throw new Exception(ex.ToString());
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
                throw new Exception(ex.ToString());
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

            Assert.AreEqual(3, rep.obtenerTodos().Item2.Count());
        }
    }
    [TestClass]
    public sealed class RepInstructoresTest
    {

        private void Test_ManejoArchivos_repositorio_PersistirCambios()
        {
            try
            {
                IRepActores<Instructor> RepInstructores = new RepInstructores("..\\CursosTest\\DirectorioTest\\InstructoresTest.json");

                RepInstructores.guardarPersonaje(new Instructor("Carlos Mena", "1122334455", "carlos.mena@epn.edu.ec", "cmenaa", "clave123"));

                RepInstructores.guardarPersonaje(new Instructor("Ana Torres", "5566778899", "ana.torres@epn.edu.ec", "anaisd", "user123"));

                RepInstructores.persistirCambios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [TestMethod]
        public void Test_ManejoArchivos()
        {
            try
            {
                this.Test_ManejoArchivos_repositorio_PersistirCambios();

                IRepActores<Instructor> RepInstructores = new RepInstructores("..\\CursosTest\\DirectorioTest\\InstructoresTest.json");

                RepInstructores.cargarDatos();

                Assert.IsNotNull(RepInstructores.obtenerTodos());

                Assert.IsTrue(File.Exists("..\\CursosTest\\DirectorioTest\\InstructoresTest.json"));

                Assert.AreEqual(2, RepInstructores.obtenerTodos().Item1.Count());

                Assert.AreEqual(2, RepInstructores.obtenerTodos().Item2.Count());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }

    [TestClass]
    public sealed class RepCursosTest
    {
        private void Test_ManejoArchivos_repositorio_PersistirCambios()
        {
            try
            {
                IRepCursos RepCursos = new RepCursos("..\\CursosTest\\DirectorioTest\\CursosTest.json");

                RepCursos.guardarCurso(new Curso("Matematicas", "MATH101", 20));

                RepCursos.guardarCurso(new Curso("Fisica", "PHYS101", 15));

                var curso = new Curso("Quimica", "CHEM101", 20);
                curso.Instructor = new Instructor("Laura Martinez", "2233445566", "laura.martinez@epn.edu.ec", "alurita", "123456");
                RepCursos.guardarCurso(curso);

                RepCursos.persistirCambios();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        [TestMethod]
        public void Test_ManejoArchivos()
        {
            try
            {
                this.Test_ManejoArchivos_repositorio_PersistirCambios();

                IRepGeneric<Entidades.Stock.Curso> RepCursos = new RepCursos("..\\CursosTest\\DirectorioTest\\CursosTest.json");

                RepCursos.cargarDatos();

                Assert.IsNotNull(RepCursos.obtenerTodos());

                Assert.IsTrue(File.Exists("..\\CursosTest\\DirectorioTest\\CursosTest.json"));

                Assert.AreEqual(3, RepCursos.obtenerTodos().Item1.Count());

                Assert.AreEqual(3, RepCursos.obtenerTodos().Item2.Count());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }

}
