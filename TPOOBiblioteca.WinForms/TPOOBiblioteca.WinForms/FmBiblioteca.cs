using System;
using System.Linq;
using System.Windows.Forms;
using TPOOBiblioteca.WinForms;

namespace Colecciones
{
    public partial class FmBiblioteca : Form
    {
        private readonly Biblioteca _biblioteca = new Biblioteca();

        public FmBiblioteca()
        {
            InitializeComponent();
        }

        private void FmBiblioteca_Load(object? sender, EventArgs e)
        {
            // Datos de prueba (podés quitarlo)
            _biblioteca.agregarLibro("Libro1", "Autor1", "Editorial1");
            _biblioteca.agregarLibro("Libro2", "Autor2", "Editorial2");
            _biblioteca.agregarLibro("Libro3", "Autor3", "Editorial3");

            _biblioteca.altaLector("Mariano Arenas", "123");
            _biblioteca.altaLector("Ana Perez", "456");

            RefrescarLibros();
            RefrescarLectores();
            RefrescarPrestamos(null);
        }

        // Devuelve el lector actualmente seleccionado en el ListView
        private Lector? ObtenerLectorSeleccionado()
        {
            return lvLectores.SelectedItems.Count > 0
                ? lvLectores.SelectedItems[0].Tag as Lector
                : null;
        }

        // Selecciona en el ListView el lector cuyo DNI coincida
        private void SeleccionarLectorPorDni(string dni)
        {
            foreach (ListViewItem it in lvLectores.Items)
            {
                if (it.SubItems[1].Text == dni) // col 1 = DNI
                {
                    it.Selected = true;
                    it.Focused = true;
                    it.EnsureVisible();
                    break;
                }
            }
        }

        private void RefrescarLibros()
        {
            lvLibros.BeginUpdate();
            lvLibros.Items.Clear();

            foreach (var libro in _biblioteca.Libros)
            {
                var it = new ListViewItem(libro.getTitulo());
                it.SubItems.Add(libro.Autor);
                it.SubItems.Add(libro.Editorial);
                it.Tag = libro; // opcional
                lvLibros.Items.Add(it);
            }

            lvLibros.EndUpdate();
        }
        private void RefrescarLectores()
        {
            lvLectores.BeginUpdate();
            lvLectores.Items.Clear();

            foreach (var l in _biblioteca.Lectores)
            {
                var it = new ListViewItem(l.Nombre);
                it.SubItems.Add(l.Dni);
                it.SubItems.Add(l.CantPrestamos.ToString());
                it.Tag = l; // <- MUY IMPORTANTE
                lvLectores.Items.Add(it);
            }

            lvLectores.EndUpdate();

            lvLectores.SelectedItems.Clear();
            txtPrestamoDni.Clear();
            RefrescarPrestamos(null);
        }


        private void RefrescarPrestamos(Lector? lector)
        {
            lvPrestamos.BeginUpdate();
            lvPrestamos.Items.Clear();

            if (lector != null)
            {
                foreach (var p in lector.Prestamos)
                {
                    var it = new ListViewItem(p.getTitulo());
                    it.SubItems.Add(p.Autor);
                    it.SubItems.Add(p.Editorial);
                    lvPrestamos.Items.Add(it);
                }
            }

            lvPrestamos.EndUpdate();
        }


        // ------- Eventos de botones -------

        private void btnAgregarLibro_Click(object? sender, EventArgs e)
        {
            var titulo = txtTitulo.Text.Trim();
            var autor = txtAutor.Text.Trim();
            var editorial = txtEditorial.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(editorial))
            {
                MessageBox.Show("Completá Título, Autor y Editorial.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ok = _biblioteca.agregarLibro(titulo, autor, editorial);
            if (!ok)
                MessageBox.Show("Ya existe un libro con ese título.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarLibros();
            txtTitulo.Clear(); txtAutor.Clear(); txtEditorial.Clear();
            txtTitulo.Focus();
        }

        private void btnEliminarLibro_Click(object? sender, EventArgs e)
        {
            var titulo = txtTitulo.Text.Trim();
            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("Indicá el Título a eliminar (campo Título).", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ok = _biblioteca.eliminarLibro(titulo);
            if (!ok)
                MessageBox.Show("No se encontró el libro.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarLibros();
        }

        private void btnAltaLector_Click(object? sender, EventArgs e)
        {
            var nombre = txtNombreLector.Text.Trim();
            var dni = txtDniLector.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Completá Nombre y DNI.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ok = _biblioteca.altaLector(nombre, dni);
            if (!ok)
                MessageBox.Show("El lector ya existe (DNI duplicado).", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarLectores();
            txtNombreLector.Clear(); txtDniLector.Clear();
            txtNombreLector.Focus();
        }

        private void btnPrestar_Click(object? sender, EventArgs e)
        {
            var titulo = txtPrestamoTitulo.Text.Trim();
            var dni = txtPrestamoDni.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Completá Título y DNI del lector.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = _biblioteca.prestarLibro(titulo, dni);
            lblResultado.Text = resultado;

            // el libro puede haber salido de disponibles
            RefrescarLibros();

            // actualizar contadores en la lista de lectores
            RefrescarLectores();

            // seleccionar al lector del DNI y mostrar sus préstamos
            SeleccionarLectorPorDni(dni);
            var lectorSel = ObtenerLectorSeleccionado();
            RefrescarPrestamos(lectorSel);

            // limpiar campos
            txtPrestamoTitulo.Clear();
            if (lectorSel is null) txtPrestamoDni.Clear();
        }



        private void lvLectores_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var lectorSel = ObtenerLectorSeleccionado();
            RefrescarPrestamos(lectorSel);
            txtPrestamoDni.Text = lectorSel?.Dni ?? string.Empty;
        }
    }
}
