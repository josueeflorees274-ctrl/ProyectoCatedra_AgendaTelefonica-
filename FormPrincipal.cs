using Microsoft.Data.SqlClient;

namespace AgendaTelefonica;

public class FormPrincipal : Form
{
    private TextBox txtNombres = new TextBox();
    private TextBox txtApellidos = new TextBox();
    private TextBox txtCorreo = new TextBox();
    private TextBox txtTelefono = new TextBox();
    private TextBox txtBuscar = new TextBox();
    private ComboBox cmbCategoria = new ComboBox();
    private ComboBox cmbTipo = new ComboBox();
    private CheckBox chkFavorito = new CheckBox();
    private DataGridView tabla = new DataGridView();
    private Button btnAgregar = new Button();
    private Button btnTelefono = new Button();
    private Button btnEliminar = new Button();
    private Button btnAutores = new Button();

    public FormPrincipal()
    {
        Text = "Proyecto de cátedra - Agenda Telefónica";
        ClientSize = new Size(700, 520);
        StartPosition = FormStartPosition.CenterScreen;

        // Campos para escribir los datos
        AgregarCampo("Nombres:", 20, 20, txtNombres);
        AgregarCampo("Apellidos:", 20, 55, txtApellidos);
        AgregarCampo("Correo:", 20, 90, txtCorreo);
        AgregarCampo("Categoría:", 20, 125, cmbCategoria);
        AgregarCampo("Teléfono:", 360, 20, txtTelefono);
        AgregarCampo("Tipo:", 360, 55, cmbTipo);
        AgregarCampo("Buscar:", 20, 215, txtBuscar);

        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipo.Items.AddRange(new object[] { "Móvil", "Casa", "Trabajo" });
        cmbTipo.SelectedIndex = 0;

        chkFavorito.Text = "Favorito";
        chkFavorito.Location = new Point(450, 90);
        chkFavorito.AutoSize = true;
        Controls.Add(chkFavorito);

        // Botones
        ConfigurarBoton(btnAgregar, "Agregar contacto", 20, 165, 150);
        ConfigurarBoton(btnTelefono, "Agregar teléfono al seleccionado", 180, 165, 210);
        ConfigurarBoton(btnEliminar, "Eliminar contacto", 400, 165, 150);
        ConfigurarBoton(btnAutores, "Autores", 560, 165, 120);

        btnAgregar.Click += btnAgregar_Click;
        btnTelefono.Click += btnTelefono_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnAutores.Click += btnAutores_Click;
        txtBuscar.TextChanged += txtBuscar_TextChanged;

        // Tabla
        tabla.Location = new Point(20, 250);
        tabla.Size = new Size(660, 250);
        tabla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabla.ReadOnly = true;
        tabla.AllowUserToAddRows = false;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        Controls.Add(tabla);

        CargarDatos();
    }

    // Crea una etiqueta y deja el control a su derecha
    private void AgregarCampo(string texto, int x, int y, Control control)
    {
        Label etiqueta = new Label();
        etiqueta.Text = texto;
        etiqueta.Location = new Point(x, y + 3);
        etiqueta.AutoSize = true;

        control.Location = new Point(x + 90, y);
        control.Width = 190;

        Controls.Add(etiqueta);
        Controls.Add(control);
    }

    private void ConfigurarBoton(Button boton, string texto, int x, int y, int ancho)
    {
        boton.Text = texto;
        boton.Location = new Point(x, y);
        boton.Size = new Size(ancho, 30);
        Controls.Add(boton);
    }

    // Llena el ComboBox de categorías y la tabla con los datos de la base
    private void CargarDatos()
    {
        try
        {
            cmbCategoria.DataSource = BaseDatos.ListarCategorias();
            cmbCategoria.DisplayMember = "NombreCategoria";
            cmbCategoria.ValueMember = "CategoriaID";

            CargarTabla();
        }
        catch (SqlException ex)
        {
            MostrarError(ex);
        }
    }

    private void CargarTabla()
    {
        tabla.DataSource = BaseDatos.ListarContactos(txtBuscar.Text.Trim());

        // El ID se usa por dentro, pero no hace falta mostrarlo
        if (tabla.Columns["ContactoID"] != null)
        {
            tabla.Columns["ContactoID"]!.Visible = false;
        }
    }

    private void MostrarError(SqlException ex)
    {
        MessageBox.Show("No se pudo conectar con la base de datos AgendaTelefonicaDB.\n\n" + ex.Message,
            "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // Devuelve el ID del contacto que está seleccionado en la tabla (o null si no hay)
    private int? ContactoSeleccionado()
    {
        if (tabla.CurrentRow == null)
        {
            return null;
        }
        return Convert.ToInt32(tabla.CurrentRow.Cells["ContactoID"].Value);
    }

    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        if (txtNombres.Text.Trim() == "" || txtApellidos.Text.Trim() == "" || txtTelefono.Text.Trim() == "")
        {
            MessageBox.Show("Escribe al menos nombres, apellidos y teléfono.");
            return;
        }

        int? categoriaId = null;
        if (cmbCategoria.SelectedValue is int id)
        {
            categoriaId = id;
        }

        try
        {
            BaseDatos.AgregarContacto(txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
                txtCorreo.Text.Trim(), chkFavorito.Checked, categoriaId,
                txtTelefono.Text.Trim(), cmbTipo.Text);

            txtNombres.Clear();
            txtApellidos.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            chkFavorito.Checked = false;
            CargarTabla();
        }
        catch (SqlException ex)
        {
            MostrarError(ex);
        }
    }

    private void btnTelefono_Click(object? sender, EventArgs e)
    {
        int? contactoId = ContactoSeleccionado();
        if (contactoId == null)
        {
            MessageBox.Show("Selecciona un contacto de la tabla.");
            return;
        }
        if (txtTelefono.Text.Trim() == "")
        {
            MessageBox.Show("Escribe el número de teléfono.");
            return;
        }

        try
        {
            BaseDatos.AgregarTelefono(contactoId.Value, txtTelefono.Text.Trim(), cmbTipo.Text);
            txtTelefono.Clear();
            CargarTabla();
        }
        catch (SqlException ex)
        {
            MostrarError(ex);
        }
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        int? contactoId = ContactoSeleccionado();
        if (contactoId == null)
        {
            MessageBox.Show("Selecciona un contacto de la tabla.");
            return;
        }

        DialogResult respuesta = MessageBox.Show("¿Seguro que quieres eliminar este contacto?",
            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        try
        {
            BaseDatos.EliminarContacto(contactoId.Value);
            CargarTabla();
        }
        catch (SqlException ex)
        {
            MostrarError(ex);
        }
    }

    private void txtBuscar_TextChanged(object? sender, EventArgs e)
    {
        try
        {
            CargarTabla();
        }
        catch (SqlException ex)
        {
            MostrarError(ex);
        }
    }

    private void btnAutores_Click(object? sender, EventArgs e)
    {
        FormAutores formulario = new FormAutores();
        formulario.ShowDialog();
    }
}
