using System;
using System.Collections.Generic;

namespace Colecciones
{
    internal class Lector
    {
        public const int MaxPrestamosVigentes = 3;

        private string nombre;
        private string dni;
        private readonly List<Libro> prestamos;

        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.prestamos = new List<Libro>();
        }

        public string Dni => dni;

        public int CantPrestamos => prestamos.Count;

        public bool PuedeTomarPrestamo => prestamos.Count < MaxPrestamosVigentes;

        public void AgregarPrestamo(Libro libro)
        {
            prestamos.Add(libro);
        }

        public override string ToString()
        {
            return $"Lector: {nombre} (DNI: {dni}) - Prestamos vigentes: {prestamos.Count}";
        }
    }
}
