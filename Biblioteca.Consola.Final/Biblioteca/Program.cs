using System;

namespace Colecciones
{
    // Punto de entrada con menú de consola.
    internal class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();
            seed(biblioteca); // sólo altas; sin préstamos

            while (true)
            {
                Console.Clear();
                setBaseColors(); // blanco 
                header();
                menu();
                Console.Write("Opción: ");
                var opcion = (Console.ReadLine() ?? "").Trim();

                if (opcion == "0") return;

                if (opcion == "1") { altaLector(biblioteca); pause(); }
                else if (opcion == "2") { eliminarLector(biblioteca); pause(); }
                else if (opcion == "3") { listarLectores(biblioteca); pause(); }
                else if (opcion == "4") { agregarLibro(biblioteca); pause(); }
                else if (opcion == "5") { eliminarLibro(biblioteca); pause(); }
                else if (opcion == "6") { listarLibros(biblioteca); pause(); }
                else if (opcion == "7") { prestar(biblioteca); pause(); }
                else if (opcion == "8") { verLibrosDeUnLector(biblioteca); pause(); }
                else { writeError("Opción inválida."); pause(); }
            }
        }

        // ----- UI base -----

        private static void setBaseColors()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Encabezado 
        private static void header()
        {
            line();
            writeTitle("BIBLIOTECA — MODO CONSOLA");
            line();
            Console.WriteLine();
        }

        // Menú principal
        private static void menu()
        {
            Console.WriteLine("1) Agregar lector");
            Console.WriteLine("2) Eliminar lector");
            Console.WriteLine("3) Listar lectores");
            Console.WriteLine();
            Console.WriteLine("4) Agregar libro");
            Console.WriteLine("5) Eliminar libro");
            Console.WriteLine("6) Listar libros");
            Console.WriteLine();
            Console.WriteLine("7) Prestar libro a lector");
            Console.WriteLine("8) Ver libros de un lector");
            Console.WriteLine();
            Console.WriteLine("0) Salir");
            Console.WriteLine();
            line();
        }

        // Seed mínimo
        private static void seed(Biblioteca b)
        {
            b.agregarLibro("Libro1", "Autor1", "Editorial1");
            b.agregarLibro("Libro2", "Autor2", "Editorial2");
            b.agregarLibro("Libro3", "Autor3", "Editorial3");
            b.agregarLibro("Libro4", "Autor4", "Editorial4");
            b.altaLector("Ana Pérez", "1");
            b.altaLector("Juan López", "2");
        }

        // ----- Acciones -----

        // Alta de lector.       
        private static void altaLector(Biblioteca b)
        {
            section("Alta de lector");
            var nombre = prompt("Nombre");
            var dni = prompt("DNI");
            bool ok = b.altaLector(nombre, dni);
            if (ok) writeOk("Lector agregado.");
            else writeError("El lector ya existe.");
        }

        // Eliminación de lector por DNI.       
        private static void eliminarLector(Biblioteca b)
        {
            section("Eliminar lector");
            var dni = prompt("DNI");
            bool ok = b.eliminarLector(dni);
            if (ok) writeOk("Lector eliminado.");
            else writeError("No existe ese lector o tiene préstamos.");
        }

        // Listado de lectores.       
        private static void listarLectores(Biblioteca b)
        {
            section("Lectores");
            b.listarLectores();
        }

        // Alta de libro.       
        private static void agregarLibro(Biblioteca b)
        {
            section("Agregar libro");
            var titulo = prompt("Título");
            var autor = prompt("Autor");
            var editorial = prompt("Editorial");
            bool ok = b.agregarLibro(titulo, autor, editorial);
            if (ok) writeOk("Libro agregado.");
            else writeError("El libro ya existe.");
        }

        // Eliminación de libro por título.   
        private static void eliminarLibro(Biblioteca b)
        {
            section("Eliminar libro");
            var titulo = prompt("Título");
            bool ok = b.eliminarLibro(titulo);
            if (ok) writeOk("Libro eliminado.");
            else writeError("No existe ese libro.");
        }

        // Listado de libros.
        private static void listarLibros(Biblioteca b)
        {
            section("Libros");
            b.listarLibros();
        }

        // Préstamo de libro a lector.  
        private static void prestar(Biblioteca b)
        {
            section("Préstamo");
            var titulo = prompt("Título del libro");
            var dni = prompt("DNI del lector");
            _ = b.prestarLibro(titulo, dni);
        }

        // Ver libros de un lector específico. 
        private static void verLibrosDeUnLector(Biblioteca b)
        {
            section("Libros de un lector");
            var dni = prompt("DNI del lector");
            b.verLibrosDeLector(dni);
        }


        // ----- Helpers de UI -----
        // Utilidades: separadores, colores, prompts y pausas.

        // Imprime una línea separadora
        private static void line()
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White; // separador visible
            Console.WriteLine(new string('─', 58));
            Console.ForegroundColor = prev;
        }

        // Imprime el título principal        
        private static void writeTitle(string text)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White; // color base
        }

        // Encabezado de sección        
        private static void section(string title)
        {
            Console.WriteLine();
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"— {title} —");
            Console.ForegroundColor = prev;
            line();
        }

        // Mensaje de éxito
        // usar para confirmar operaciones OK.
        private static void writeOk(string msg)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Mensaje de error/aviso       
        private static void writeError(string msg)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Prompt simple que muestra una etiqueta, lee la línea y devuelve string.      
        private static string prompt(string label)
        {
            Console.Write($"{label}: ");
            return Console.ReadLine() ?? string.Empty;
        }

        // Pausa       
        private static void pause()
        {
            Console.WriteLine();
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Presioná una tecla para volver al menú...");
            Console.ForegroundColor = prev;
            Console.ReadKey(true);
        }
    }
}