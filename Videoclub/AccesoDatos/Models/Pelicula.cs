namespace AccesoDatos.Models
{
    public class Pelicula
    {
        public int Id {get; set; }
        public string Title {get; set; } = null!;
        public string Autor {get; set; } = null!;
        public int CantDispo {get; set; }
        public int Costoxdia {get; set; }
    }
}