namespace AccesoDatos.Repositories;

public interface IGenericRepository<T> where T : class
{
    void Agregar(T entidad);
    List<T> ObtenerTodos();
    List<T> ObtenerTodos(string propiedadRelacionada);
    //Se puede borrar ese
    List<T> ObtenerTodos(string primeraPropiedad, string segundaPropiedad);
    T? ObtenerPorId(int id);
    void Modificar(T entidad);
    void Eliminar(object id);
}
