using System;
using System.Collections.Generic;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Repositorios.Interfaces;
using BACKEND.Datos.Mongo;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using BACKEND.Modelos;


namespace BACKEND.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        public List<LibroDTO> DevolverLibros()
        {
            var LibroColleccion = MongoConexion.ObtenerLibros();

            var Libros = LibroColleccion.Find(Libro => !Libro.eliminado).ToList();

            List<LibroDTO> lista = Libros.Select(Libro => new LibroDTO
            {
                Id = Libro._id,
                Titulo = Libro.titulo,
                Autor = Libro.autor
            }).ToList();

            return lista;
        }

        public List<LibroDTO> BuscarLibroPorTitulo(LibroBarraDTO libro)
        {
            var LibroColleccion = MongoConexion.ObtenerLibros();

            var filtro = Builders<Libro>.Filter.And(
                Builders<Libro>.Filter.Regex(l => l.titulo, new BsonRegularExpression(libro.Titulo, "i")),
                Builders<Libro>.Filter.Eq(l => l.eliminado, false));

            var busqueda = LibroColleccion.Find(filtro).ToList();

            List<LibroDTO> lista = busqueda.Select(Libro => new LibroDTO
            {
                Id = Libro._id,
                Titulo = Libro.titulo,
                Autor = Libro.autor
            }).ToList();

            return lista;
        }
    }
}