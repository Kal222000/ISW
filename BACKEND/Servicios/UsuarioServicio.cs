using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Repositorios;
using BACKEND.Servicios.Interfaces;
using BACKEND.Servicios.Validaciones.ValidacionEspecifica;

namespace BACKEND.Servicios
{
    public partial class UsuarioServicio : IUsuarioServicio
    {
        private readonly UsuarioRepositorio repositorio;

        private readonly UsuarioValidaciones validaciones;

        public UsuarioServicio()
        {
            repositorio = new UsuarioRepositorio();
            validaciones = new UsuarioValidaciones();
        }

        public DatosUsuarioDTO? ValidarUsuario(CredencialesDTO usuario)
        {
            return repositorio.ValidarUsuario(usuario);
        }

        public bool CreacionCliente(NuevoUsuarioDTO usuario)
        {
            if (validaciones.Validar(usuario) == false)
            {
                throw new Exception("Los espacios no pueden estar en blanco o nulos.");
            }

            if (validaciones.Numero(usuario.Carnet) == false)
            {
                throw new Exception("El carnet no puede ser negativo.");
            }

            if (validaciones.ValidarContrasena(usuario.Contrasena) == false)
            {
                throw new Exception("La contraseña debe contener al menos una mayúscula y un número.");
            }

            if (validaciones.Fecha(usuario.FechaNacimiento) == false)
            {
                throw new Exception("No puede ser menor de Edad.");
            }

            return repositorio.CreacionCliente(usuario);
        }

    }
}