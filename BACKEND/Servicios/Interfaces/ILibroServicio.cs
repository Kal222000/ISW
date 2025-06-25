using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using System.Collections.Generic; 

namespace BACKEND.Servicios.Interfaces
{
    public interface ILibroServicio
    {
        List<LibroDTO> DevolverLibros();

        List<LibroDTO> BuscarLibroPorTitulo(LibroBarraDTO libro);
    }
}