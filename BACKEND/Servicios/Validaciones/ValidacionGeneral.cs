using System;
using System.Text.RegularExpressions;

namespace BACKEND.Servicios.Validaciones
{
    public class ValidacionGeneral
    {
        public virtual bool String(string str)
        {
            if (string.IsNullOrEmpty(str)) { return false; }
            if (str.Contains(" ")) { return false; }
            return true;
        }

        public virtual bool Numero(int n)
        {
            if (n <= 0) { return false; }
            return true;
        }

        public virtual bool Fecha(DateTime fecha)
        {
            return false;
        }

        public virtual bool FechaComleta(DateTime fecha)
        {
            return false;
        }
    }
}