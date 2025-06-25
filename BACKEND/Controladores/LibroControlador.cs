using System;
using Microsoft.AspNetCore.Mvc;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Servicios;
using BACKEND.Servicios.Interfaces;

namespace BACKEND.Controladores
{
    [ApiController]
    [Route("api/libro")]
    public class LibroControlador : ControllerBase
    {
        private readonly ILibroServicio servicio;

        public LibroControlador()
        {
            servicio = new LibroServicio();
        }

        [HttpGet("DevolverLibros")]
        public IActionResult DevolverLibros()
        {
            var resultado = servicio.DevolverLibros();

            return Ok(resultado);
        }

        [HttpPost("BuscarLibroPorTitulo")]
        public IActionResult BuscarLibroPorTitulo([FromBody] LibroBarraDTO libro)
        {
            try
            {
                var respuesta = servicio.BuscarLibroPorTitulo(libro);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}