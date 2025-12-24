using Entidades.Actores;
using Entidades.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CursosTest.EntidadesTest;

namespace CursosTest
{
    [TestClass]
    public sealed class EntidadesTest
    {
        public static class TestPersona
        {
            public static string PersonaToStringTest(Persona persona)
            {
                return $"Nombre: {persona.Nombre}, DNI: {persona.Dni}, Email: {persona.Email}";
            }
            public static string EstudianteToStringTest(Estudiante estudiante)
            {
                return TestPersona.PersonaToStringTest(estudiante) + $" Identifier: {estudiante.Identifier} \n";
            }
            public static string InstructorToStringTest(Instructor instructor)
            {
                return TestPersona.PersonaToStringTest(instructor) + $" Identifier: {instructor.Identifier} \n";
            }

        }
        [TestClass]
        public sealed class TestEstudiante
        {
            [TestMethod]
            public void ComprobarCursoAEstudiante()
            {
                // arrange: Crear instancia de Estudiante y Curso

                var estudiante = new Estudiante("Ana", "87654321", "Ana@epn.edu.ec", "usuarioRandom", "ContraseñaRandom");

                var curso = new Curso("Matemáticas", "MAT101", 4);

                // act: Agregar curso al estudiante

                bool resultado = estudiante.agregarCurso(curso);

                // assert: Verificar que el curso se haya agregado correctamente

                Assert.IsTrue(resultado);

                // verifiquemos el caso para eliminar un curso:

                bool resultadoEliminar = estudiante.eliminarCurso(curso);
                Assert.IsTrue(resultadoEliminar);

                // Verifiquemos que pasa cuando intentamos eliminar un curso que no existe en la lista

                var cursoNoExistente = new Curso("Historia", "HIS101", 3);
                bool resultadoEliminarNoExistente = estudiante.eliminarCurso(cursoNoExistente);
                Assert.IsFalse(resultadoEliminarNoExistente);

                // Comprobar si se puede agregar dos veces un mismo curso

                var cursoDuplicado = new Curso("Geografía", "GEO101", 3);
                Assert.IsTrue(estudiante.agregarCurso(cursoDuplicado));
                Assert.IsFalse(estudiante.agregarCurso(cursoDuplicado));

            }
            [TestMethod]
            public void comprobar_GetterSetter()
            {
                // Debido a que los Atributos de estudiante e instructor son compartidos, esta prueba vale por dos.

                // Assert: crear instancia de Estudiante

                var estudiante = new Estudiante("Pedro", "55667788", "pedro@epn.edu.ec", "usuarioRandom", "Contraseña");

                // Comprobar getters

                Assert.AreEqual("Pedro", estudiante.Nombre);
                Assert.AreEqual("55667788", estudiante.Dni);
                Assert.AreEqual("pedro@epn.edu.ec", estudiante.Email);

                // Comprobar al menos un setter

                // No debería cambiar porque el valor es inválido

                estudiante.Nombre = "Juan";
                Assert.AreEqual("Juan", estudiante.Nombre);

                estudiante.Nombre = "   ";
                Assert.AreEqual("Juan", estudiante.Nombre); 
                

                estudiante.Email = "";
                Assert.AreEqual("pedro@epn.edu.ec", estudiante.Email);

            }
            public void ComprobarToStringEstudiante()
            {
                // arrange: Crear instancia de Estudiante
                var estudiante = new Estudiante("Luis", "12345678", "Luis@epn.edu.ec", "usuarioRandom", "contraseña");

                // act: Obtener la representación en cadena del estudiante

                string resultado = TestPersona.EstudianteToStringTest(estudiante);

                Console.WriteLine(resultado + '\n');
            }
        }

        [TestClass]
        public sealed class TestInstructor
        {
            public void ComprobarToStringInstructor()
            {
                // arrange: Crear instancia de Instructor
                var instructor = new Instructor("Carlos", "11223344", "Carlos@epn.edu.ec", "usuarioRandom", "contraseña");

                // act: Obtener la representación en cadena del instructor

                string resultado = TestPersona.InstructorToStringTest(instructor);
                Console.WriteLine(resultado + '\n');
            }
            [TestMethod]
            public void ComprobarCursoAInstructor()
            {
                // arrange: Crear instancia de Instructor y Curso

                var instructor = new Instructor("María", "99887766", "Maria@epn.edu.ec", "usuarioRandom", "contraseña");
                var curso = new Curso("Física", "FIS101", 4);

                // act: Agregar curso al instructor

                bool resultado = instructor.agregarCurso(curso);
                //assert: Verificar que el curso se haya agregado correctamente

                Assert.IsTrue(resultado);

                // verifiquemos el caso para eliminar un curso:

                bool resultadoEliminar = instructor.eliminarCurso(curso);
                Assert.IsTrue(resultadoEliminar);

                // Verifiquemos que pasa cuando intentamos eliminar un curso que no existe en la lista

                var cursoNoExistente = new Curso("Química", "QUI101", 3);
                bool resultadoEliminarNoExistente = instructor.eliminarCurso(cursoNoExistente);
                Assert.IsFalse(resultadoEliminarNoExistente);

                // Comprobar si se puede agregar dos veces un mismo curso

                var cursoDuplicado = new Curso("Biología", "BIO101", 3);
                Assert.IsTrue(instructor.agregarCurso(cursoDuplicado));
                Assert.IsFalse(instructor.agregarCurso(cursoDuplicado));
            }
            [TestMethod]
            public void comprobar_GetterSetter()
            {
                // Debido a que los Atributos de estudiante e instructor son compartidos, esta prueba vale por dos.
                // Assert: crear instancia de Instructor
                var instructor = new Instructor("Laura", "66778899", "Laura@epn.edu.ec", "usuarioRandom", "contraseña");

                // Comprobar getters

                Assert.AreEqual("Laura", instructor.Nombre);
                Assert.AreEqual("66778899", instructor.Dni);
                Assert.AreEqual("Laura@epn.edu.ec", instructor.Email);

                // comprobar al menos un  setter

                instructor.Nombre = "   ";
                Assert.AreEqual("Laura", instructor.Nombre);
            }

            [TestClass]
            public sealed class TestCurso
            {

                [TestMethod]
                public void ComprobarCursoA()
                {
                    // Act: Crear instancias de Curso y Estudiantes

                    var curso = new Curso("Biología", "BIO101", 4);
                    Estudiante? estudiante = new Estudiante("Sofía", "8856345", "SOFIA.belen@epn.edu.ec", "usuarioRandom", "contraseña");
                    Estudiante? estudiante_2 = new Estudiante("Miguel", "77441122", "email@generico", "usuarioRandom", "contraseña");

                    // Comprobar que el estudiante se haya agregado correctamente

                    Assert.IsTrue(curso.agregarEstudiante(estudiante));

                    // Comprobar que se pueda eliminar estudiante agregado

                    Assert.IsTrue(curso.eliminarEstudiante(estudiante));

                    // Comprobar que no se pueda eliminar un estudiante que no está en la lista

                    Assert.IsFalse(curso.eliminarEstudiante(estudiante_2));

                    // comprobar si se puede agregar dos veces un mismo estudiante

                    Assert.IsTrue(curso.agregarEstudiante(estudiante_2));
                    Assert.IsFalse(curso.agregarEstudiante(estudiante_2));
                }
                [TestMethod]
                public void comprobar_GetterSetter()
                {
                    // Arrange: Crear instancia de Curso
                    var curso = new Curso("Historia", "HIS101", 5);
                    
                    // Comprobar getters
                    Assert.AreEqual("Historia", curso.Nombre);
                    Assert.AreEqual("his101", curso.CodigoUnico);
                    Assert.AreEqual(5, curso.CupoMaximo);

                    // Comprobar al menos un setter

                    var instructor = new Instructor("Andrés", "33445566", "andresi@epn.edu.ec", "usuarioRandom", "contraseña");

                    curso.Instructor = instructor;

                    Assert.AreEqual(instructor, curso.Instructor);

#pragma warning disable CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.
                    curso.Instructor = null;
#pragma warning restore CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.

                    Assert.AreEqual(instructor, curso.Instructor);


                    // comprobemos si podemos abrir y cerrar el curso


                    curso.CerrarCurso();

                    Assert.IsTrue(curso.CursoCerrado());
                }
            }
            [TestClass]
            public sealed class TestReserva
            {

            }
            [TestClass]

            // Tautologías de calibración
            public sealed class Debug
            {
                [TestMethod]
                public void debug()
                {
                    var prueba = new Instructor("Pedro", "44556677", "eamailGenerico@epn.edu.ec", "usuarioRandom", "contraseña");
                    var prueba_2 = new Estudiante("Juan", "1886655", "maiGenerico2@epn.edu.ec", "usuarioRandom", "contraseña");
                    var prueba_3 = new Curso("Curso de Prueba", "C101", 3);

                    Assert.IsNotNull(prueba);
                    Assert.IsNotNull(prueba_2);
                    Assert.IsNotNull(prueba_3);
                }
            }
    }   }

}
