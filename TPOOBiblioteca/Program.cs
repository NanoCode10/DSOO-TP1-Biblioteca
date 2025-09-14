using System;

namespace Colecciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            // Libros
            Console.WriteLine("-- Carga de Libros --");
            CargarLibros(biblioteca, 5);

            // Lectores
            Console.WriteLine("\n-- Alta de Lectores --");
            Console.WriteLine(biblioteca.altaLector("Mariano Arenas", "123") ? "Lector 123 agregado." : "Lector 123 ya existía.");
            Console.WriteLine(biblioteca.altaLector("Ana Perez", "456") ? "Lector 456 agregado." : "Lector 456 ya existía.");

            // Pruebas de préstamo
            Console.WriteLine("\n-- Préstamos --");            
            Console.WriteLine("Prestamo del Libro1 a DNI 123 :" + biblioteca.prestarLibro("Libro1", "123")); // PRESTAMO EXITOSO            
            Console.WriteLine("Prestamo del Libro100 a DNI 123 :" + biblioteca.prestarLibro("Libro100", "123")); // LIBRO INEXISTENTE            
            Console.WriteLine("Prestamo del Libro2 a DNI 123 :" + biblioteca.prestarLibro("Libro2", "123")); // OK           
            Console.WriteLine("Prestamo del Libro3 a DNI 123 :" + biblioteca.prestarLibro("Libro3", "123")); // OK            
            Console.WriteLine("Prestamo del Libro4 a DNI 123 :" + biblioteca.prestarLibro("Libro4", "123")); // TOPE DE PRESTAMO ALCAZADO            
            Console.WriteLine("Prestamo del Libro5 a DNI 999 :" + biblioteca.prestarLibro("Libro5", "999")); // LECTOR INEXISTENTE
            Console.WriteLine("-- Fin de Pruebas Prestamos --");

            Console.WriteLine("\nLibros disponibles en biblioteca:");
            biblioteca.listarLibros();

            Console.WriteLine("\nLectores:");
            biblioteca.listarLectores();

            Console.WriteLine("\nFin. Presione una tecla para salir...");
            Console.ReadKey();
        }

        private static void CargarLibros(Biblioteca biblioteca, int cantidad)
        {
            bool pude;
            for (int i = 1; i <= cantidad; i++)
            {
                pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                if (pude)
                    Console.WriteLine("Libro" + i + " agregado correctamente.");
                else
                    Console.WriteLine("Libro" + i + " ya existe en la biblioteca.");
            }
        }
    }
}
