using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CursosTest.EntidadesTest;

namespace CursosTest
{
    internal class Controller
    {
        public void Execute()
        {
            // Ejecutar los tests de Estudiante
            var testEstudiante = new TestEstudiante();
            testEstudiante.ComprobarCursoAEstudiante();
            testEstudiante.ComprobarToStringEstudiante();

            // Ejecutar los tests de Instructor
            var testProfesor = new TestInstructor();
            testProfesor.ComprobarToStringInstructor();
            testProfesor.ComprobarCursoAInstructor();
        }
    }
}
