using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos;

public partial class Autor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;  
    public List<Libro> Libros { get; set; } = new List<Libro>();
}