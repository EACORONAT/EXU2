﻿// <auto-generated />
using Datos.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(PContexto))]
    [Migration("20231112204654_LBD")]
    partial class LBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Datos.Modelos.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PK__autor__3213E83F327B3A55");

                    b.ToTable("autor", (string)null);
                });

            modelBuilder.Entity("Datos.Modelos.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int")
                        .HasColumnName("autorId");

                    b.Property<int>("Capitulos")
                        .HasColumnType("int")
                        .HasColumnName("capitulos");

                    b.Property<int>("Paginas")
                        .HasColumnType("int")
                        .HasColumnName("paginas");

                    b.Property<int>("Precio")
                        .HasColumnType("int")
                        .HasColumnName("precio");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("titulo");

                    b.HasKey("Id")
                        .HasName("PK__libro__3213E83F1D04D004");

                    b.HasIndex("AutorId");

                    b.ToTable("libro", (string)null);
                });

            modelBuilder.Entity("Datos.Modelos.Libro", b =>
                {
                    b.HasOne("Datos.Modelos.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__libro__autor__3C69FB99");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Datos.Modelos.Autor", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}