using System;

namespace Colecciones
{
    public class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;

        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }

        public string getTitulo() => titulo;
        public string Autor => autor;
        public string Editorial => editorial;

        public override string ToString()
        {
            return "Titulo: " + titulo + "  Autor: " + autor + "  Editorial: " + editorial;
        }
    }
}
