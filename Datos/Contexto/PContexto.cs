using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Datos.Contexto;

public partial class PContexto : DbContext
{
    public PContexto()
    {
    }

    public PContexto(DbContextOptions<PContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PAVILION\\SQLEXPRESS;Database=LBD;Trust Server Certificate=true;User Id=sa;Password=12345678;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__autor__3213E83F327B3A55");

            entity.ToTable("autor");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__libro__3213E83F1D04D004");

            entity.ToTable("libro");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Capitulos).HasColumnName("capitulos");
            entity.Property(e => e.Paginas).HasColumnName("paginas");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.AutorId).HasColumnName("autorId");

            // Relacion de 1 a n
            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__libro__autor__3C69FB99");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}