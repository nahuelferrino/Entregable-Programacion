using AccesoDatos.Data;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AplicationDbContext _context;

        public GenericRepository()
        {
            _context = new AplicationDbContext();
        }
// 1. LECTURA (SELECT *) Con propiedad relacionada
        public List<T> ObtenerTodos(string propiedadRelacionada)
        {
            return _context.Set<T>().Include(propiedadRelacionada).AsNoTracking().ToList();
        }
// 2. ALTA (INSERT), es decir, se agrega un registro en la tabla de la base de datos.
        public void Agregar(T entidad)
        {
            _context.Set<T>().Add(entidad);
            _context.SaveChanges();
        }
// 5. BÚSQUEDA POR ID
        public T ObtenerPorId(int id)
        {
            // Busca directamente en el conjunto de datos del tipo T correspondientes
            return _context.Set<T>().Find(id);
        }

         public void Modificar(T entidad)
        {
            _context.Set<T>().Update(entidad);
            _context.SaveChanges();
        }
// 3. BAJA (DELETE) - Busca por ID y elimina.
        public void Eliminar(object id)
        {
            var entidad = _context.Set<T>().Find(id);
            if (entidad != null)
            {
                _context.Set<T>().Remove(entidad);
                _context.SaveChanges();
            }
        }
        // 1. LECTURA (SELECT *) Con propiedad relacionada
        public List<T> ObtenerTodos()
        {
            return _context.Set<T>()            
                .AsNoTracking()
                .ToList();
        }
    }
}