using Datos.Modelos;
using Datos.Operaciones;
using Microsoft.AspNetCore.Mvc;

namespace EXU2.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();

        // Endpoint para consultar a todos los autores de la BD.
        [HttpGet("autores/todos")]
        public List<Autor> getTodosAutores()
        {
            var autor = autorDAO.seleccionarTodosA();
            return autor;
        } 

        // Endpoint para crear un nuevo autor.
        [HttpPost("autor/insertar")]
        public bool insertarAutor([FromBody] Autor autor)
        {
            return autorDAO.crearAutor(autor.Nombre);
        }

        // Endpoint para consultar a todas los autores de la BD.        
        [HttpGet("autoreslibros/todos")]
        public List<LibAut> getTodosAutoresConLibros()
        {
            var autor = autorDAO.seleccionarAutorConLibros();
            return autor;
        }

        // Endpoint para consultar una autor específica por ID.
        [HttpGet("autor/id")]
        public Autor getAutor(int id)
        {
            return autorDAO.seleccionarIdAutor(id);
        }

        // Endpoint para actualizar los datos de un autor.
        [HttpPut("autor/actualizar")]
        public bool actAutor([FromBody] Autor autor)
        {
            return autorDAO.actualizarAutor(autor.Id, autor.Nombre);
        }
    }
}
