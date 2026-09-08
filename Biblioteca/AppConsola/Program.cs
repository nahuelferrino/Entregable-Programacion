using AccesoDatos.Models;
using AccesoDatos.Repositories;

IGenericRepository<Autor> autorRepository = new GenericRepository<Autor>();
IGenericRepository<Libro> libroRepository = new GenericRepository<Libro>();
IGenericRepository<Categoria> categoriaRepository = new GenericRepository<Categoria>();



bool continuar = true;

while (continuar)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("\tGestión de Usuarios");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Alta Autor");
    Console.WriteLine("2. Alta Categoria");
    Console.WriteLine("3. Alta Libro");
    Console.WriteLine("4. Ver Autores");
    Console.WriteLine("5. Ver Categorias");
    Console.WriteLine("6. Ver Libros");
    Console.WriteLine("7. Modificar Libro");
    Console.WriteLine("8. Modificar Autores");
    Console.WriteLine("9. Baja Libro");
    Console.WriteLine("0. Salir");
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
            AltaCategoria();
            break;

        case "3":
            AltaLibro();
            break;
        
        case "4":
            VerAutores();
            break;

        case "5":
            VerCategorias();
            break;

        case "6":
            VerLibros();
            break;
        case "7":
            ModificarLibro();
            break;
        case "8":
            ModificarAutores();
            break;
        case "9":
            BajaLibro();
            break;
        case "0":
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

    Console.Write("Ingrese el ID de la categoria: ");
    int categoriaId = int.Parse(Console.ReadLine());

    Categoria categoria = categoriaRepository.ObtenerPorId(categoriaId);
    if (categoria == null)
    {
        Console.WriteLine("Categoria no encontrada");
        return;
    }

    Autor autor = autorRepository.ObtenerPorId(autorId);

    if (autor == null)
    {
        Console.WriteLine("Autor no encontrado.");
        return;
    }


    Console.WriteLine($"Autor seleccionado: {autor.Name}");
    bool activo = true;
    var nuevoLibro = new Libro
    {
        Titulo = titulo,
        AnioDePublicacion = aniodepublicacion,
        AutorId = autorId,
        Activo = activo,
        CategoriaId = categoriaId
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
    var libros = repository.ObtenerTodos("Autor");

    if (!libros.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var l in libros)
        {
            if(l.Activo == true)
            {
                Console.WriteLine($"ID: {l.Id} | Título: {l.Titulo} | Año: {l.AnioDePublicacion} | Autor: {l.Autor.Name}");
            }
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

void ModificarAutores()
{
    Console.Write("Ingrese el ID del usuario a modificar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var AutorACambiar = autorRepository.ObtenerPorId(id);

        if (AutorACambiar != null)
        {
            Console.Write($"Ingrese el nuevo nombre para '{AutorACambiar.Name}': ");
            AutorACambiar.Name = Console.ReadLine();
            autorRepository.Modificar(AutorACambiar);
            Console.WriteLine("Autor modificado correctamente.");
            PresioneParaContinuar();
        }
        else
        {
            Console.WriteLine("No se encontró ningún usuario con ese ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    PresioneParaContinuar();
}
void ModificarLibro()
{
    MostrarListaLibros(libroRepository);
    Console.Write("Ingrese el ID del Libro a modificar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var LibroACambiar = libroRepository.ObtenerPorId(id);

        if (LibroACambiar != null)
        {
            Console.Write($"Ingrese el nuevo nombre para '{LibroACambiar.Titulo}': ");
            LibroACambiar.Titulo = Console.ReadLine();
            libroRepository.Modificar(LibroACambiar);
            Console.WriteLine("Libro modificado correctamente.");
            PresioneParaContinuar();
        }
        else
        {
            Console.WriteLine("No se encontro ningun libro con ese id");
        }
    }
    else
    {
        Console.WriteLine("ID inválido");
    }
}
void BajaLibro()
{
    MostrarListaLibros(libroRepository);
    Console.Write("Ingrese el ID del libro a eliminar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var libro = libroRepository.ObtenerPorId(id);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
        }
        else if (libro.Activo != true)
        {
            Console.WriteLine("El libro ya está dado de baja.");
        }
        else
        {
            libro.Activo = false;
            libroRepository.Modificar(libro);
            Console.WriteLine("Proceso de eliminación finalizado.");        
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    PresioneParaContinuar();
}
void AltaCategoria()
{
    Console.WriteLine("Ingrese el nombre de la categoria: ");
    string nombre = Console.ReadLine();
    var nuevaCategoria = new Categoria
    {
      Nombre = nombre 
    };
    categoriaRepository.Agregar(nuevaCategoria);
    Console.WriteLine("La categoria a sido agregado exitosamente");
    PresioneParaContinuar();
}
void VerCategorias()
{
    {
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var categorias = categoriaRepository.ObtenerTodos();

    if (!categorias.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var c in categorias)
        {          
                Console.WriteLine($"ID: {c.Id} | Nombre: {c.Nombre}");
        }            
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
    }
    PresioneParaContinuar();
}
void VerAutores()
{
    {
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var autores = autorRepository.ObtenerTodos();

    if (!autores.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var a in autores)
        {          
                Console.WriteLine($"ID: {a.Id} | Nombre: {a.Name}");
        }            
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
    }
    PresioneParaContinuar();
}



