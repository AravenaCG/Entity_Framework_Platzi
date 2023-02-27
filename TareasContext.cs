using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework_Platzi.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Platzi
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("f32d1ab564a44df08e828326fcd8bdcd"), Nombre = "Actividades pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("28a8f77b-ca15-4f4f-900e-2de94d3c2260"), Nombre = "Actividades personales", Peso = 50 });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);
                categoria.HasData(categoriasInit);

            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("0559da4f-e287-4412-bb0e-1ef3648a8b1f"), CategoriaId = Guid.Parse("f32d1ab564a44df08e828326fcd8bdcd"), PrioridadTarea = Prioridad.Media, Titulo = "Pagar Telecentro", FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("8cea31e3-1bba-46e7-9195-b595479625fd"), CategoriaId = Guid.Parse("28a8f77b-ca15-4f4f-900e-2de94d3c2260"), PrioridadTarea = Prioridad.Baja, Titulo = "Digitar tango", FechaCreacion = DateTime.Now });

            modelBuilder.Entity<Tarea>(tarea =>
            {

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.HasData(tareasInit);
            });
        }



    }
}