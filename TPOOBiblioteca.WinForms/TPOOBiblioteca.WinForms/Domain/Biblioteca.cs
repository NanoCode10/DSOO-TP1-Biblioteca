using System;
using System.Collections.Generic;

namespace Colecciones
{
    public static class Mensajes
    {
        public const string PrestamoExitoso = "PRESTAMO EXITOSO";
        public const string LibroInexistente = "LIBRO INEXISTENTE";
        public const string TopePrestamoAlcazado = "TOPE DE PRESTAMO ALCAZADO"; // (sic: igual a tu consigna)
        public const string LectorInexistente = "LECTOR INEXISTENTE";
    }

    public class Biblioteca
    {
        private readonly List<Libro> libros;
        private readonly List<Lector> lectores;

        public Biblioteca()
        {
            libros = new List<Libro>();
            lectores = new List<Lector>();
        }

        public IReadOnlyList<Libro> Libros => libros.AsReadOnly();
        public IReadOnlyList<Lector> Lectores => lectores.AsReadOnly();

        // ---- PRIVADOS ----
        private Libro? buscarLibro(string titulo)
        {
            Libro? libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        private Lector? buscarLector(string dni)
        {
            Lector? encontrado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].Dni.Equals(dni))
                i++;
            if (i != lectores.Count)
                encontrado = lectores[i];
            return encontrado;
        }

        // ---- CRUD LIBROS ----
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

        // ---- LECTORES ----
        public bool altaLector(string nombre, string dni)
        {
            var lector = buscarLector(dni);
            if (lector != null) return false;

            lectores.Add(new Lector(nombre, dni));
            return true;
        }

        // ---- PRESTAMOS ----
        public string prestarLibro(string titulo, string dni)
        {
            var lector = buscarLector(dni);
            if (lector == null)
                return Mensajes.LectorInexistente;

            if (!lector.PuedeTomarPrestamo)
                return Mensajes.TopePrestamoAlcazado;

            var libro = buscarLibro(titulo);
            if (libro == null)
                return Mensajes.LibroInexistente;

            libros.Remove(libro);
            lector.AgregarPrestamo(libro);

            return Mensajes.PrestamoExitoso;
        }
    }
}
