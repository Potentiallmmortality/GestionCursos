using Entidades.Actores;
using Entidades.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

                var estudiante = new Estudiante("Ana", "87654321", "Ana@epn.edu.ec");

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
            }
            public void ComprobarToStringEstudiante()
            {
                // arrange: Crear instancia de Estudiante
                var estudiante = new Estudiante("Luis", "12345678", "Luis@epn.edu.ec");

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
                var instructor = new Instructor("Carlos", "11223344", "Carlos@epn.edu.ec");

                // act: Obtener la representación en cadena del instructor

                string resultado = TestPersona.InstructorToStringTest(instructor);
                Console.WriteLine(resultado + '\n');
            }
            [TestMethod]
            public void ComprobarCursoAInstructor()
            {
                // arrange: Crear instancia de Instructor y Curso

                var instructor = new Instructor("María", "99887766", "Maria@epn.edu.ec");
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
            }
        }
        [TestClass]
        public sealed class Debug
        {
            [TestMethod]
            public void debug()
            {
                var prueba = new Instructor("Pedro", "44556677", "");

                Assert.IsNotNull(prueba);
            }
        }

    }
}
