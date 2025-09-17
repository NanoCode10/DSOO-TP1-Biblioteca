using System;
using System.Windows.Forms;
using Colecciones; // para ver FmBiblioteca

namespace TPOOBiblioteca.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // ahora sí existe
            Application.Run(new FmBiblioteca());
        }
    }
}
