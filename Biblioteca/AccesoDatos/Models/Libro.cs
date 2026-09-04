namespace AccesoDatos.Models
{
    public class Libro
    {
        public int Id {get; set; }
        public string Titulo {get; set; } = null!;
        public int AnioDePublicacion {get; set; }
        public Autor Autor {get; set; } = null!;
        public int AutorId {get; set; }
        public bool? Activo {get; set; }
        public int CategoriaId {get; set; }
        public Categoria Categoria {get; set; } = null!;
    }
}