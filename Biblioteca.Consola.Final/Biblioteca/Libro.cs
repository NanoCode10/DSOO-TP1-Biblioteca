using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    // Representa un libro con título, autor y editorial.
    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;

        // Crea un libro.
        // params: titulo del libro, autor del libro, editorial del libro
        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }

        // return: título del libro
        public string getTitulo()
        {
            return titulo;
        }

        // return: autor del libro
        public string getAutor()
        {
            return autor;
        }

        // return: editorial del libro
        public string getEditorial()
        {
            return editorial;
        }

        // Devuelve para mostrar en consola.
        public override string ToString()
        {
            return $"Título: {titulo}, Autor: {autor}, Editorial: {editorial}";
        }
    }
}
