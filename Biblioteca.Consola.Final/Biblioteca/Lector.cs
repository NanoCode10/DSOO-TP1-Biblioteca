using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Colecciones
{
    // Representa un lector con DNI, nombre y sus libros prestados.
    internal class Lector
    {
        private string nombre;
        private string dni;
        private List<Libro> librosPrestados;

        // Crea un lector con listas vacías.
        // params: nombre del lector, dni del lector
        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.librosPrestados = new List<Libro>();
        }

        // return: DNI del lector
        public string getDni()
        {
            return dni;
        }

        // return: nombre del lector
        public string getNombre()
        {
            return nombre;
        }

        // return: lista de libros prestados (lista interna actual)
        public List<Libro> getLibrosPrestados()
        {
            return librosPrestados;
        }

        // Devuelve detalles cantidad y títulos de libros prestados.
        public override string ToString()
        {
            string detallesLibros = string.Join(", ", librosPrestados.Select(libro => libro.getTitulo()));
            return $"Nombre: {nombre}, DNI: {dni}, Libros Cantidad: {librosPrestados.Count}, Libros en su haber detalle: {detallesLibros}";
        }

        // Agrega un libro a la lista de prestados del lector si no tiene uno con el mismo título.
        // param: libro -> libro a agregar
        // return: true si se agregó; false si ya tenía un libro con ese título
        public bool agregarLibroPrestado(Libro libro)
        {
            bool yaTieneTitulo = librosPrestados.Any(l =>
                l.getTitulo().Equals(libro.getTitulo(), StringComparison.OrdinalIgnoreCase));

            if (!yaTieneTitulo)
            {
                librosPrestados.Add(libro);
                Console.WriteLine("Libro prestado correctamente al lector.");
                return true;
            }
            else
            {
                Console.WriteLine("El libro ya está prestado a este lector.");
                return false;
            }
        }
    }
}
