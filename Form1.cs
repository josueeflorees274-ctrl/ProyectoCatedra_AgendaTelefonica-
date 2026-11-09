using System.Data;
using Microsoft.Data.SqlClient;

namespace AgendaTelefonica;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Eventos
        Load += Form1_Load;
        btnAgregar.Click += btnAgregar_Click;
        btnTelefono.Click += btnTelefono_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnAutores.Click += btnAutores_Click;
        txtBuscar.TextChanged += txtBuscar_TextChanged;

        cmbTipo.SelectedIndex = 0;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        CargarDatos();
    }

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
        if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
            string.IsNullOrWhiteSpace(txtApellidos.Text) ||
            string.IsNullOrWhiteSpace(txtTelefono.Text))
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
            BaseDatos.AgregarContacto(
                txtNombres.Text.Trim(),
                txtApellidos.Text.Trim(),
                txtCorreo.Text.Trim(),
                chkFavorito.Checked,
                categoriaId,
                txtTelefono.Text.Trim(),
                cmbTipo.Text);

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

        if (string.IsNullOrWhiteSpace(txtTelefono.Text))
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
