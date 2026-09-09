using AccesoDatos.Data;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository()
    {
        _context = new ApplicationDbContext();
    }

    public void Agregar(T entidad)
    {
        _context.Set<T>().Add(entidad);
        _context.SaveChanges();
    }

    public List<T> ObtenerTodos()
    {
        return _context.Set<T>()
            .AsNoTracking()
            .ToList();
    }

    public List<T> ObtenerTodos(string propiedadRelacionada)
    {
        return _context.Set<T>()
            .Include(propiedadRelacionada)
            .AsNoTracking()
            .ToList();
    }
//Se puede borrar este
    public List<T> ObtenerTodos(string primeraPropiedad, string segundaPropiedad)
    {
        return _context.Set<T>()
            .Include(primeraPropiedad)
            .Include(segundaPropiedad)
            .AsNoTracking()
            .ToList();
    }

    public T? ObtenerPorId(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Modificar(T entidad)
    {
        _context.Set<T>().Update(entidad);
        _context.SaveChanges();
    }

    public void Eliminar(object id)
    {
        T? entidad = _context.Set<T>().Find(id);

        if (entidad != null)
        {
            _context.Set<T>().Remove(entidad);
            _context.SaveChanges();
        }
    }
}
