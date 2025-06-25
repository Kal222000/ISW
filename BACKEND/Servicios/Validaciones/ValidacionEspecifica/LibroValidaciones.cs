using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Servicios.Validaciones;

namespace BACKEND.Servicios.Validaciones.ValidacionEspecifica
{
    public class LibroValidaciones : ValidacionGeneral
    {
        public LibroValidaciones() { }

        public override bool String(string str)
        {
            if (string.IsNullOrEmpty(str)) {  return false; }
            if (str.StartsWith(" ")) { return false; }
            return true;
        }
    }
}