using AccesoDatos.Models;
using AccesoDatos.Repositories;

IGenericRepository<Autor> autorRepository = new GenericRepository<Autor>();
IGenericRepository<Libro> libroRepository = new GenericRepository<Libro>();



bool continuar = true;

while (continuar)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("\tGestión de Usuarios");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Alta Autor");
    Console.WriteLine("2. Alta Libro");
    Console.WriteLine("3. Ver Libros");
    Console.WriteLine("4. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaAutor();
            break;

        case "2":
            AltaLibro();
            break;

        case "3":
            VerLibros();
            break;
        case "4":
            Console.WriteLine("¡Cerrando el sistema de usuarios!");
            continuar = false;;
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void AltaLibro()
{
    Console.Write("Ingrese el Titulo del Libro: ");
    string titulo = Console.ReadLine();

    Console.Write("Ingrese el año de publicacion del libro: ");
    int aniodepublicacion = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el ID del autor: ");
    int autorId = int.Parse(Console.ReadLine());

    Autor? autor = autorRepository.ObtenerPorId(autorId);

    if (autor == null)
    {
        Console.WriteLine("Autor no encontrado.");
        return;
    }

    Console.WriteLine($"Autor seleccionado: {autor.Name}");
    var nuevoLibro = new Libro
    {
        Titulo = titulo,
        AnioDePublicacion = aniodepublicacion,
        AutorId = autorId            
    };
    libroRepository.Agregar(nuevoLibro);
    Console.WriteLine("El libro a sido agregado exitosamente");
    PresioneParaContinuar();
}

void AltaAutor()
{
    Console.Write("Ingrese el Nombre del Autor: ");
    string name = Console.ReadLine();

    var nuevoAutor = new Autor
    {
        Name = name,
    };

    autorRepository.Agregar(nuevoAutor);
    Console.WriteLine("El Autor a sido agregado exitosamente");
    PresioneParaContinuar();
}

void VerLibros()
{
    MostrarListaLibros(libroRepository);
    PresioneParaContinuar();
}

void MostrarListaLibros(IGenericRepository<Libro> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var libros = repository.ObtenerTodos();

    if (!libros.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var l in libros)
        {
            Autor? autor = autorRepository.ObtenerPorId(l.AutorId);
            Console.WriteLine($"ID: {l.Id} | Título: {l.Titulo} | Año: {l.AnioDePublicacion} | Autor: {autor?.Name}");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}