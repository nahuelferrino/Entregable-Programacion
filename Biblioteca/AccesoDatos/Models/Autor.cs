namespace AccesoDatos.Models
{
    public class Autor
    {
        public int Id {get; set; }
        public string Name {get; set; } = null!;
        public List<Libro> libros {get; set; } = new(); 
    }
}