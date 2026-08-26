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
// 1. LECTURA (SELECT *)
        public List<T> ObtenerTodos()
        {
            return _context.Set<T>().AsNoTracking().ToList();
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
    }
}