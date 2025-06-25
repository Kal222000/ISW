using System;
using System.Collections.Generic;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Repositorios;
using BACKEND.Repositorios.Interfaces;
using BACKEND.Servicios.Interfaces;
using BACKEND.Servicios.Validaciones.ValidacionEspecifica;

namespace BACKEND.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio repositorio;

        private readonly LibroValidaciones validar;

        public LibroServicio()
        {
            repositorio = new LibroRepositorio();
            validar = new LibroValidaciones();
        }

        public List<LibroDTO> DevolverLibros()
        {
            return repositorio.DevolverLibros();
        }

        public List<LibroDTO>  BuscarLibroPorTitulo(LibroBarraDTO libro)
        {
            if(validar.String(libro.Titulo) == false)
            {
                throw new Exception("No puede ser nullo o comenzar por un espacio el titulo que buscamos");
            }

            return repositorio.BuscarLibroPorTitulo(libro);
        }
    }

}