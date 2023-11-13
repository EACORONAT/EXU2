using Datos.Contexto;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Operaciones
{
    public class LibroDAO
    {
        // Creamos un objeto de contexto de BD
        public PContexto contexto = new PContexto();

        // Método para seleccionar a todos los libros
        public List<Libro> seleccionarTodosL()
        {
            var profesor = contexto.Libros.ToList<Libro>();
            return profesor;
        }

        // Método para seleccionar un libro en especifico por id
        public Libro seleccionarLibroId(int id)
        {
            var libro = contexto.Libros.Where(p => p.Id == id).FirstOrDefault();
            return libro;
        }

        // Método para crear nuevo Libro: Creará un nuevo libro en la BD
        public bool crearLibro(Libro nuevoLibro)
        {
            try
            {
                // Verifica si el autor ya existe en la base de datos
                Autor autorExistente = contexto.Autores.FirstOrDefault(a => a.Nombre == nuevoLibro.Autor.Nombre);

                if (autorExistente == null)
                {
                    // Si el autor no existe, agrega el nuevo autor a la base de datos
                    contexto.Autores.Add(nuevoLibro.Autor);
                    contexto.SaveChanges();
                }
                else
                {
                    // Si el autor ya existe, asigna el autor existente al nuevo libro
                    nuevoLibro.AutorId = autorExistente.Id;
                }
                // Agrega el nuevo libro a la base de datos
                contexto.Libros.Add(nuevoLibro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para obtener todos los libros: Deberá devolver un listado de libros con sus autores.
        public List<LibAut> seleccionarLibrosConAutor()
        {
            var query = from book in contexto.Libros
                        join author in contexto.Autores on book.AutorId
                        equals author.Id
                        select new LibAut
                        {
                            TituloLibro = book.Titulo,
                            NombreAutor = author.Nombre, 
                            CapitulosLibro = book.Capitulos,
                            PaginasLibro = book.Paginas,
                            PrecioLibro = book.Precio
                        };

            return query.ToList();
        }        
         
        // Método para actualizar los datos de un libro en la BD
        public bool actualizarLibro(int id, string titulo, int capitulos, int paginas, int precio, int autorId)
        {
            try
            {              
                var libro = seleccionarLibroId(id);
                if (libro == null)
                {
                    return false;
                }
                else
                {
                    libro.Id = id;
                    libro.Titulo = titulo;
                    libro.Capitulos = capitulos;
                    libro.Paginas = paginas;
                    libro.Precio = precio;
                    libro.AutorId = autorId;

                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para buscar libros por título
        public List<LibAut> buscarLibrosPorTitulo(string titulo)
        {
            var query = from book in contexto.Libros
                        join author in contexto.Autores on book.AutorId equals author.Id
                        where book.Titulo.Contains(titulo)
                        select new LibAut
                        {
                            TituloLibro = book.Titulo,
                            NombreAutor = author.Nombre,
                            CapitulosLibro = book.Capitulos,
                            PaginasLibro = book.Paginas,
                            PrecioLibro = book.Precio
                        };

            return query.ToList();
        }

    }
}