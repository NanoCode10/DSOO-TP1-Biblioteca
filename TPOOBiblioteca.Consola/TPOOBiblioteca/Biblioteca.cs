using System;
using System.Collections.Generic;

namespace Colecciones
{
    internal static class Mensajes
    {
       
        public const string PrestamoExitoso = "PRESTAMO EXITOSO";
        public const string LibroInexistente = "LIBRO INEXISTENTE";
        public const string TopePrestamoAlcazado = "TOPE DE PRESTAMO ALCAZADO";
        public const string LectorInexistente = "LECTOR INEXISTENTE";
    }

    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

        // ---------- PRIVADOS ----------
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

        // ---------- CRUD LIBROS ----------
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

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        // ---------- LECTORES ----------
        // Alta lector si no existe (match por DNI). True=se agregó, False=ya estaba.
        public bool altaLector(string nombre, string dni)
        {
            var lector = buscarLector(dni);
            if (lector != null) return false;

            lectores.Add(new Lector(nombre, dni));
            return true;
        }

        // Prestar libro según reglas y mensajes requeridos.
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

            // mover el libro: sale de la biblioteca, entra a los préstamos del lector
            libros.Remove(libro);
            lector.AgregarPrestamo(libro);

            return Mensajes.PrestamoExitoso;
        }

        // (Opcional) para ver estado de lectores en consola
        public void listarLectores()
        {
            foreach (var l in lectores)
                Console.WriteLine(l);
        }
    }
}
