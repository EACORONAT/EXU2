using Datos.Modelos;
using Datos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace EXU2.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibroDAO libroDAO = new LibroDAO();

        // Endpoint para consultar a todos los libros de la BD.
        [HttpGet("libros/todos")]
        public List<Libro> getTodosLibros()
        {
            var libro = libroDAO.seleccionarTodosL();
            return libro;
        }
        
        // Endpoint para crear un nuevo libro.
        [HttpPost("libro/insertar")]
        public bool insertarLibro([FromBody] Libro libro)
        {
            return libroDAO.crearLibro(libro);
        }

        // Endpoint para consultar a todas los libros de la BD.        
        [HttpGet("LibrosConAutores/todos")]
        public List<LibAut> getTodosLibrosConAutores()
        {
            var libro = libroDAO.seleccionarLibrosConAutor();
            return libro;
        }
        
        // Endpoint para consultar una autor específica por ID.      
        [HttpGet("libro/id")]
        public Libro getLibro(int id)
        {
            return libroDAO.seleccionarLibroId(id);
        }
        
        // Endpoint para actualizar los datos de un libro.   
        [HttpPut("libro/actualizar")]
        public bool actLibro([FromBody] Libro libro)
        {
            return libroDAO.actualizarLibro(libro.Id, libro.Titulo, libro.Capitulos, libro.Paginas, libro.Precio, libro.AutorId);
        }

        // Endpoint para buscar un libro por titulo
        [HttpGet("tituloBusqueda")]
        public IActionResult BuscarLibrosPorTitulo(string tituloBusqueda)
        {
            try
            {
                var libros = libroDAO.buscarLibrosPorTitulo(tituloBusqueda);
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar libros por título");
            }
        }
    }
}