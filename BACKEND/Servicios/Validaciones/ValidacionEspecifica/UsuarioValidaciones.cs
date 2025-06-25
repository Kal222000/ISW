using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Servicios.Validaciones;

namespace BACKEND.Servicios.Validaciones.ValidacionEspecifica
{
    public class UsuarioValidaciones : ValidacionGeneral
    {
        public UsuarioValidaciones() { }

        public override bool String(string str)
        {
            return base.String(str);
        }

        public override bool Numero(int n)
        {
            return base.Numero(n);
        }

        public override bool Fecha(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;

            int edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            if(edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarContrasena(string contrasena)
        {
            if (contrasena.Length < 8) { return false; }
            if (String(contrasena) == false) { return false; }

            bool Mayuscula = false;

            bool Numero = false;

            foreach (char c in contrasena)
            {
                if (char.IsUpper(c)) { Mayuscula = true; }

                if (char.IsDigit(c)) { Numero = true; }
            }

            return Mayuscula && Numero;
        }

        public bool Validar(NuevoUsuarioDTO usuario)
        {
            if (String(usuario.Nombre) == false) { return false; }
            if (String(usuario.ApellidoMaterno) == false) { return false; }
            if (String(usuario.ApellidoPaterno) == false) { return false; }
            return true;
        }
    }
}