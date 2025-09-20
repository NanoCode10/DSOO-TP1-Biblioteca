using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    // Biblioteca en memoria: maneja listas de libros y lectores y permite prestar libros (máximo 3 por lector).
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        // Crea la biblioteca con listas vacías.
        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

        // Busca un libro por título exacto.
        // param: titulo -> título a buscar
        // return: libro encontrado o null
        private Libro? buscarLibro(string titulo)
        {
            Libro? libroBuscado = null;
            int i = 0;
            while (i < this.libros.Count && !libros[i].getTitulo().Equals(titulo))
            {
                i++;
            }

            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        // Busca un lector por DNI exacto.
        // param: dni -> DNI a buscar
        // return: lector encontrado o null
        private Lector? buscarLector(string dni)
        {
            Lector? lectorBuscado = null;
            int i = 0;
            while (i < this.lectores.Count && !lectores[i].getDni().Equals(dni))
            {
                i++;
            }

            if (i != lectores.Count)
                lectorBuscado = lectores[i];
            return lectorBuscado;
        }

        // Agrega un libro si no existe otro con el mismo título.
        // params: titulo, autor, editorial
        // return: true si se agregó; false si ya existía
        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro? libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        // Da de alta un lector si no existe otro con el mismo DNI.
        // params: nombre, dni
        // return: true si se agregó; false si ya existía
        public bool altaLector(string nombre, string dni)
        {
            bool resultado = false;
            Lector? lector = buscarLector(dni);
            if (lector == null)
            {
                lector = new Lector(nombre, dni);
                lectores.Add(lector);
                resultado = true;
            }
            return resultado;
        }

        // Lista por consola todos los libros.
        public void listarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                return;
            }
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        // Lista por consola todos los lectores.
        public void listarLectores()
        {
            foreach (var lector in lectores)
                Console.WriteLine(lector);
        }

        // Elimina un libro por título si existe.
        // param: titulo -> título a eliminar
        // return: true si se eliminó; false si no existía
        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro? libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        // Elimina un lector por DNI si existe.
        // param: dni -> DNI a eliminar
        // return: true si se eliminó; false si no existía
        public bool eliminarLector(string dni)
        {
            bool resultado = false;
            Lector? lector = buscarLector(dni);
            if (lector != null)
            {
                lectores.Remove(lector);
                resultado = true;
            }
            return resultado;
        }

        // Registra el préstamo de un libro a un lector (máximo 3 préstamos por lector).
        // params: titulo (del libro), dni (del lector)
        // return: true si el préstamo fue exitoso; false si falló
        public bool prestarLibro(string titulo, string dni)
        {
            bool resultado = false;
            Libro? libro = buscarLibro(titulo);
            Lector? lector = buscarLector(dni);

            if (lector == null || libro == null)
            {
                if (lector == null && libro != null)
                {
                    Console.WriteLine("LECTOR INEXISTENTE");
                }
                else if (lector != null && libro == null)
                {
                    Console.WriteLine("LIBRO INEXISTENTE");
                }
                else
                {
                    Console.WriteLine("LECTOR Y LIBRO INEXISTENTES");
                }
            }
            else
            {
                if (lector.getLibrosPrestados().Count >= 3)
                {
                    Console.WriteLine("TOPE DE PRESTAMO ALCANZADO");
                    return false;
                }
                else
                {
                    lector.agregarLibroPrestado(libro);
                    eliminarLibro(titulo); // se quita de la biblioteca al estar prestado
                    Console.WriteLine("PRESTAMO EXITOSO" + "\nLibro: " + libro + "\nLector: " + lector);
                    resultado = true;
                }
            }
            return resultado;
        }

        // Muestra los datos del lector y el detalle de sus libros (usa ToString del lector).
        // param: dni -> DNI del lector a consultar
        public void verLibrosDeLector(string dni)
        {
            Lector? lector = buscarLector(dni);
            if (lector == null)
            {
                Console.WriteLine("LECTOR INEXISTENTE");
                return;
            }
            Console.WriteLine(lector.ToString());
        }
    }
}

