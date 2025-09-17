namespace Colecciones
{
    partial class FmBiblioteca
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpLibros;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.Button btnAgregarLibro;
        private System.Windows.Forms.Button btnEliminarLibro;

        private System.Windows.Forms.GroupBox grpLectores;
        private System.Windows.Forms.TextBox txtNombreLector;
        private System.Windows.Forms.TextBox txtDniLector;
        private System.Windows.Forms.Button btnAltaLector;

        private System.Windows.Forms.GroupBox grpPrestamos;
        private System.Windows.Forms.TextBox txtPrestamoTitulo;
        private System.Windows.Forms.TextBox txtPrestamoDni;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Label lblResultado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpLibros = new GroupBox();
            lvLibros = new ListView();
            Titulo = new ColumnHeader();
            Autor = new ColumnHeader();
            Editorial = new ColumnHeader();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtEditorial = new TextBox();
            btnAgregarLibro = new Button();
            btnEliminarLibro = new Button();
            grpLectores = new GroupBox();
            lvLectores = new ListView();
            Nombre = new ColumnHeader();
            DNI = new ColumnHeader();
            Prestamos = new ColumnHeader();
            txtNombreLector = new TextBox();
            txtDniLector = new TextBox();
            btnAltaLector = new Button();
            grpPrestamos = new GroupBox();
            lvPrestamos = new ListView();
            Titulop = new ColumnHeader();
            Autorp = new ColumnHeader();
            Editorialp = new ColumnHeader();
            txtPrestamoTitulo = new TextBox();
            txtPrestamoDni = new TextBox();
            btnPrestar = new Button();
            lblResultado = new Label();
            grpLibros.SuspendLayout();
            grpLectores.SuspendLayout();
            grpPrestamos.SuspendLayout();
            SuspendLayout();
            // 
            // grpLibros
            // 
            grpLibros.Controls.Add(lvLibros);
            grpLibros.Controls.Add(txtTitulo);
            grpLibros.Controls.Add(txtAutor);
            grpLibros.Controls.Add(txtEditorial);
            grpLibros.Controls.Add(btnAgregarLibro);
            grpLibros.Controls.Add(btnEliminarLibro);
            grpLibros.Location = new Point(12, 12);
            grpLibros.Name = "grpLibros";
            grpLibros.Size = new Size(310, 610);
            grpLibros.TabIndex = 0;
            grpLibros.TabStop = false;
            grpLibros.Text = "Libros (disponibles)";
            // 
            // lvLibros
            // 
            lvLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvLibros.Columns.AddRange(new ColumnHeader[] { Titulo, Autor, Editorial });
            lvLibros.FullRowSelect = true;
            lvLibros.GridLines = true;
            lvLibros.Location = new Point(16, 158);
            lvLibros.MultiSelect = false;
            lvLibros.Name = "lvLibros";
            lvLibros.Size = new Size(277, 424);
            lvLibros.TabIndex = 6;
            lvLibros.UseCompatibleStateImageBehavior = false;
            lvLibros.View = View.Details;
            // 
            // Titulo
            // 
            Titulo.Text = "Titulo";
            Titulo.Width = 120;
            // 
            // Autor
            // 
            Autor.Text = "Autor";
            Autor.Width = 110;
            // 
            // Editorial
            // 
            Editorial.Text = "Editorial";
            Editorial.Width = 110;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(16, 30);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Título";
            txtTitulo.Size = new Size(277, 23);
            txtTitulo.TabIndex = 0;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(16, 59);
            txtAutor.Name = "txtAutor";
            txtAutor.PlaceholderText = "Autor";
            txtAutor.Size = new Size(277, 23);
            txtAutor.TabIndex = 1;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(16, 88);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.PlaceholderText = "Editorial";
            txtEditorial.Size = new Size(277, 23);
            txtEditorial.TabIndex = 2;
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Location = new Point(16, 117);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(135, 27);
            btnAgregarLibro.TabIndex = 3;
            btnAgregarLibro.Text = "Agregar libro";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnEliminarLibro
            // 
            btnEliminarLibro.Location = new Point(158, 117);
            btnEliminarLibro.Name = "btnEliminarLibro";
            btnEliminarLibro.Size = new Size(135, 27);
            btnEliminarLibro.TabIndex = 4;
            btnEliminarLibro.Text = "Eliminar por Título";
            btnEliminarLibro.UseVisualStyleBackColor = true;
            btnEliminarLibro.Click += btnEliminarLibro_Click;
            // 
            // grpLectores
            // 
            grpLectores.Controls.Add(lvLectores);
            grpLectores.Controls.Add(txtNombreLector);
            grpLectores.Controls.Add(txtDniLector);
            grpLectores.Controls.Add(btnAltaLector);
            grpLectores.Location = new Point(338, 12);
            grpLectores.Name = "grpLectores";
            grpLectores.Size = new Size(310, 610);
            grpLectores.TabIndex = 1;
            grpLectores.TabStop = false;
            grpLectores.Text = "Lectores registrados";
            // 
            // lvLectores
            // 
            lvLectores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvLectores.Columns.AddRange(new ColumnHeader[] { Nombre, DNI, Prestamos });
            lvLectores.FullRowSelect = true;
            lvLectores.GridLines = true;
            lvLectores.Location = new Point(16, 158);
            lvLectores.MultiSelect = false;
            lvLectores.Name = "lvLectores";
            lvLectores.Size = new Size(277, 424);
            lvLectores.TabIndex = 7;
            lvLectores.UseCompatibleStateImageBehavior = false;
            lvLectores.View = View.Details;
            // 
            // Nombre
            // 
            Nombre.Text = "Nombre";
            Nombre.Width = 150;
            // 
            // DNI
            // 
            DNI.Text = "DNI";
            DNI.Width = 100;
            // 
            // Prestamos
            // 
            Prestamos.Text = "Prestamos";
            Prestamos.Width = 90;
            // 
            // txtNombreLector
            // 
            txtNombreLector.Location = new Point(16, 30);
            txtNombreLector.Name = "txtNombreLector";
            txtNombreLector.PlaceholderText = "Nombre";
            txtNombreLector.Size = new Size(277, 23);
            txtNombreLector.TabIndex = 0;
            // 
            // txtDniLector
            // 
            txtDniLector.Location = new Point(16, 59);
            txtDniLector.Name = "txtDniLector";
            txtDniLector.PlaceholderText = "DNI";
            txtDniLector.Size = new Size(277, 23);
            txtDniLector.TabIndex = 1;
            // 
            // btnAltaLector
            // 
            btnAltaLector.Location = new Point(16, 88);
            btnAltaLector.Name = "btnAltaLector";
            btnAltaLector.Size = new Size(277, 27);
            btnAltaLector.TabIndex = 2;
            btnAltaLector.Text = "Alta lector";
            btnAltaLector.UseVisualStyleBackColor = true;
            btnAltaLector.Click += btnAltaLector_Click;
            // 
            // grpPrestamos
            // 
            grpPrestamos.Controls.Add(lvPrestamos);
            grpPrestamos.Controls.Add(txtPrestamoTitulo);
            grpPrestamos.Controls.Add(txtPrestamoDni);
            grpPrestamos.Controls.Add(btnPrestar);
            grpPrestamos.Controls.Add(lblResultado);
            grpPrestamos.Location = new Point(664, 12);
            grpPrestamos.Name = "grpPrestamos";
            grpPrestamos.Size = new Size(304, 610);
            grpPrestamos.TabIndex = 2;
            grpPrestamos.TabStop = false;
            grpPrestamos.Text = "Préstamos";
            // 
            // lvPrestamos
            // 
            lvPrestamos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvPrestamos.Columns.AddRange(new ColumnHeader[] { Titulop, Autorp, Editorialp });
            lvPrestamos.FullRowSelect = true;
            lvPrestamos.GridLines = true;
            lvPrestamos.Location = new Point(9, 158);
            lvPrestamos.MultiSelect = false;
            lvPrestamos.Name = "lvPrestamos";
            lvPrestamos.Size = new Size(277, 424);
            lvPrestamos.TabIndex = 8;
            lvPrestamos.UseCompatibleStateImageBehavior = false;
            lvPrestamos.View = View.Details;
            // 
            // Titulop
            // 
            Titulop.Text = "Titulo";
            // 
            // Autorp
            // 
            Autorp.Text = "Autor";
            Autorp.Width = 120;
            // 
            // Editorialp
            // 
            Editorialp.Text = "Editorial";
            Editorialp.Width = 120;
            // 
            // txtPrestamoTitulo
            // 
            txtPrestamoTitulo.Location = new Point(16, 30);
            txtPrestamoTitulo.Name = "txtPrestamoTitulo";
            txtPrestamoTitulo.PlaceholderText = "Título a prestar";
            txtPrestamoTitulo.Size = new Size(270, 23);
            txtPrestamoTitulo.TabIndex = 0;
            // 
            // txtPrestamoDni
            // 
            txtPrestamoDni.Location = new Point(16, 59);
            txtPrestamoDni.Name = "txtPrestamoDni";
            txtPrestamoDni.PlaceholderText = "DNI del lector";
            txtPrestamoDni.Size = new Size(270, 23);
            txtPrestamoDni.TabIndex = 1;
            // 
            // btnPrestar
            // 
            btnPrestar.Location = new Point(16, 88);
            btnPrestar.Name = "btnPrestar";
            btnPrestar.Size = new Size(270, 27);
            btnPrestar.TabIndex = 2;
            btnPrestar.Text = "Prestar libro";
            btnPrestar.UseVisualStyleBackColor = true;
            btnPrestar.Click += btnPrestar_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(16, 122);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(0, 15);
            lblResultado.TabIndex = 3;
            // 
            // FmBiblioteca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 640);
            Controls.Add(grpLibros);
            Controls.Add(grpLectores);
            Controls.Add(grpPrestamos);
            Name = "FmBiblioteca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Biblioteca - Grupo 1";
            Load += FmBiblioteca_Load;
            grpLibros.ResumeLayout(false);
            grpLibros.PerformLayout();
            grpLectores.ResumeLayout(false);
            grpLectores.PerformLayout();
            grpPrestamos.ResumeLayout(false);
            grpPrestamos.PerformLayout();
            ResumeLayout(false);
        }
        private ListView lvLibros;
        private ColumnHeader Titulo;
        private ColumnHeader Autor;
        private ColumnHeader Editorial;
        private ListView lvLectores;
        private ColumnHeader Nombre;
        private ColumnHeader DNI;
        private ColumnHeader Prestamos;
        private ListView lvPrestamos;
        private ColumnHeader Titulop;
        private ColumnHeader Autorp;
        private ColumnHeader Editorialp;
    }
}
