using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos;
public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Capitulos { get; set; }
    public int Paginas { get; set; }
    public int Precio { get; set; }
    public int AutorId { get; set; }
    public virtual Autor Autor { get; set; } = null!;
}