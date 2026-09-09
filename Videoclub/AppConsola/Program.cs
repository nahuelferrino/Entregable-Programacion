using AccesoDatos.Models;
using AccesoDatos.Repositories;
using System.Globalization;

IGenericRepository<Socio> socioRepository = new GenericRepository<Socio>();
IGenericRepository<Pelicula> peliculaRepository = new GenericRepository<Pelicula>();
IGenericRepository<Alquiler> alquilerRepository = new GenericRepository<Alquiler>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("===============================================");
    Console.WriteLine("\tSISTEMA DE GESTIÓN DEL VIDEOCLUB");
    Console.WriteLine("===============================================");
    Console.WriteLine();
    Console.WriteLine("1. Alta Película");
    Console.WriteLine("2. Alta Socio");
    Console.WriteLine("3. Registrar Alquiler");
    Console.WriteLine("4. Reporte de alquileres por socio");
    Console.WriteLine("5. Reporte de socios con demora en la devolución");
    Console.WriteLine("6. Reporte de películas más alquiladas");
    Console.WriteLine("7. Reporte del socio que más películas alquiló");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaPelicula();
            break;

        case "2":
            AltaSocio();
            break;

        case "3":
            RegistrarAlquiler();
            break;

        case "4":
            // Acá llamás a ReporteAlquileresPorSocio();
            break;

        case "5":
            // Acá llamás a ReporteSociosConDemora();
            break;

        case "6":
            // Acá llamás a ReportePeliculasMasAlquiladas();
            break;

        case "7":
            // Acá llamás a ReporteSocioQueMasAlquilo();
            break;

        case "0":
            Console.WriteLine("¡Cerrando el sistema del videoclub!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
    }
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}
void AltaSocio()
{
    Console.WriteLine("Ingrese el DNI del usuario");
    int dni = int.Parse(Console.ReadLine());

    Console.WriteLine("Ingrese el nombre del usuario");
    string name = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del usuario");
    string lastname = Console.ReadLine();

    Console.WriteLine("Ingrese el telefono del usuario");
    int phone = int.Parse(Console.ReadLine());

    var nuevosocio = new Socio
    {
        Dni = dni,
        Name = name,
        LastName = lastname,
        Phone = phone,
    };
    socioRepository.Agregar(nuevosocio);
}
void AltaPelicula()
{
    Console.WriteLine("Ingrese el tittulo de la pelicula");
    string title = Console.ReadLine()!.Trim().ToLower();

    Console.WriteLine("Ingrese el nombre del autor");
    string autor = Console.ReadLine();

    Console.WriteLine("Ingrese la cantidad de esta pelicula en stock");
    int cantdispo = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Ingrese el costo de la pelcula por Día");
    int costoxdia = int.Parse(Console.ReadLine());

    var nuevapelicula = new Pelicula
    {
        Title = title,
        Autor = autor,
        CantDispo = cantdispo,
        Costoxdia = costoxdia,
    };
    peliculaRepository.Agregar(nuevapelicula);
}
void RegistrarAlquiler()
{
    Console.WriteLine("Ingrese el Id del socio que alquilo");
    int socioId = int.Parse(Console.ReadLine());

    Console.WriteLine("Ingrese la cantidad de peliculas que quieres alquilar");

    Console.WriteLine("Ingrese el Id de la pelicula alquilada");
    int peliculaId = int.Parse(Console.ReadLine());

    Socio socio = socioRepository.ObtenerPorId(socioId);
    if (socio == null)
    {
        Console.WriteLine("Socio no encontrado.");
        return;
    }
    Console.WriteLine($"Socio seleccionado: {socio.Name}");

    Pelicula pelicula = peliculaRepository.ObtenerPorId(peliculaId);
    if (pelicula == null)
    {
        Console.WriteLine("Pelicula no encontrada");
        return;
    }
    Console.WriteLine($"Pelicula seleccionada: {pelicula.Title}");
    
    DescuentoPelicula(peliculaId);
    CalcularDiasAlquiler();
}

void DescuentoPelicula(int peliculaId)
{
    Pelicula pelicula = peliculaRepository.ObtenerPorId(peliculaId);
    if (pelicula != null)
    {
        pelicula.CantDispo -= 1;
    }
}
void CalcularDiasAlquiler()
{
    DateTime fechadesde = DateTime.Now;

    Console.WriteLine("Cuantos dias va a durar el alquiler?");
    int DiasAlquiler = int.Parse(Console.ReadLine());
    while (DiasAlquiler <= 0)
    {
        Console.WriteLine("Cantidad de dias invalida. Ingrese una cantidad apta por favor");
    }
    DateTime FechaHasta = fechadesde.AddDays(DiasAlquiler); 
}