namespace Negocio.SeriviciosCompuestos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class Validaciones
    {
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        public static bool EsDniValido(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;

            // ^ = inicio
            // \d = dígito
            // {10} = exactamente 10 veces
            // $ = fin
            string patron = @"^\d{10}$";
            return Regex.IsMatch(dni, patron);
        }

        public static bool EsSoloNumeros(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string patron = @"^\d+$";
            return Regex.IsMatch(texto, patron);
        }

        public static bool EsNombreValido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string patron = @"^[A-ZÁÉÍÓÚÑ][a-zA-ZáéíóúÁÉÍÓÚñÑ\s]*$";

            return Regex.IsMatch(texto, patron);
        }

        public static bool EsCodigoCursoValido(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;

            // Ejemplo válido: MAT-101, FISICA, C1
            string patron = @"^[a-zA-Z0-9-]{3,}$";
            return Regex.IsMatch(codigo, patron);
        }

        public static bool EsAlfanumerico(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            string patron = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$";
            return Regex.IsMatch(texto, patron);
        }
    }
}