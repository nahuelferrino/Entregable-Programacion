namespace AccesoDatos.Models
{
    public class Socio
    {
        public int Id {get; set; }
        public int Dni {get; set; }
        public string Name {get; set; } = null!;
        public string LastName {get; set; } = null!; 
        public int Phone {get; set; }
    }
}