namespace AccesoDatos.Models
{
    public class Alquiler
    {
        public int Id {get; set; }
        public int SocioId {get; set; }
        public Socio Socio {get; set; } = null!;
        public int PeliculaId {get;set; }
        public Pelicula Pelicula {get; set; } = null!;
        public DateTime Fechadesde {get; set; }
        public DateTime FechaHasta {get; set; }
    }
}