using Datos.Contexto;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Operaciones
{
    public class AutorDAO
    {
        // Creamos un objeto de contexto de BD
        public PContexto contexto = new PContexto();

        // Método para seleccionar todos los autores
        public List<Autor> seleccionarTodosA()
        {
            var autores = contexto.Autores.ToList<Autor>();
            return autores;
        }

        // Método para seleccionar un autor en especifico por id
        public Autor seleccionarIdAutor(int id)
        {
            var autor = contexto.Autores.Where(a => a.Id == id).FirstOrDefault();
            return autor;
        }

        // Método para crear un autor: Creará un nuevo autor en la BD
        public bool crearAutor(string nombre)
        {
            try
            {
                Autor autor = new Autor();
                autor.Nombre = nombre;

                contexto.Autores.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para obtener todos los autores: Deberá devolver un listado de todos los autores con los libros que tengan.
        public List<LibAut> seleccionarAutorConLibros()
        {
            var query = from author in contexto.Autores
                        join book in contexto.Libros on author.Id equals book.AutorId
                        select new LibAut
                        {
                            NombreAutor = author.Nombre,
                            TituloLibro = book.Titulo,                            
                        };

            return query.ToList();
        }

        // Método para actuaizar los datos de un autor a la BD
        public bool actualizarAutor(int id, string nombre)
        {
            try
            {                
                var autor = seleccionarIdAutor(id);
                if (autor == null)
                {
                    return false;
                }
                else
                {
                    autor.Id = id;
                    autor.Nombre = nombre;

                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}