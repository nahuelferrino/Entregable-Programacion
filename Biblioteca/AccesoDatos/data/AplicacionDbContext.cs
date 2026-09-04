using Microsoft.EntityFrameworkCore;
using AccesoDatos.Models;

namespace AccesoDatos.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libros {get; set; }
        public DbSet<Categoria> Categorias{get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string rutaBaseDeDatos = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "..",
                    "AccesoDatos",
                    "biblioteca.db"
                )
            );

            optionsBuilder.UseSqlite($"Data Source={rutaBaseDeDatos}");
        }
    }
}
