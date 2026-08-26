using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace AccesoDatos.Repositories
{
    // La T significa que acepta cualquier clase existente en Models.
    public interface IGenericRepository<T> where T : class
    {
        void Agregar(T entidad);
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
    }
}