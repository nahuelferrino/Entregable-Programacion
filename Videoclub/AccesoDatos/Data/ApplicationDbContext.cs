using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Alquiler> Alquileres {get; set; }
    public DbSet<Socio> Socios {get; set; }

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
                "videoclub.db"
            )
        );

        optionsBuilder.UseSqlite($"Data Source={rutaBaseDeDatos}");
    }
}
