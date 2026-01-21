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
            if (string.IsNullOrWhiteSpace(email)) 
                return false;

            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }

        public static bool EsSoloNumeros(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) 
                return false;
            string patron = @"^\d+$";
            return Regex.IsMatch(texto, patron);
        }

        public static bool EsSoloLetras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) 
                return false;

            string patron = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(texto, patron);
        }

        // Regex para CÓDIGO DE CURSO (Ejemplo: C-123 o CUR-099)
        public static bool EsCodigoCursoValido(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) 
                return false;
            string patron = @"^[a-zA-Z0-9-]{3,}$";
            return Regex.IsMatch(codigo, patron);
        }

        public static bool EsAlfanumerico(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) 
                return false;
            string patron = @"^[a-zA-Z0-9\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(texto, patron);
        }
    }
}
