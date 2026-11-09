using System.Data;
using Microsoft.Data.SqlClient;

namespace AgendaTelefonica;

// Aquí está todo lo que habla con SQL Server
public static class BaseDatos
{
    // Si tu servidor se llama distinto en SSMS, cambia "localhost\\SQLEXPRESS"
    private const string CadenaConexion =
        "Server=localhost\\SQLEXPRESS;Database=AgendaTelefonicaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    // Trae los contactos con su categoría y todos sus teléfonos
    public static DataTable ListarContactos(string filtro)
    {
        string sql = @"
            SELECT c.ContactoID,
                   c.Nombres,
                   c.Apellidos,
                   c.CorreoElectronico AS Correo,
                   c.Favorito,
                   ISNULL(cat.NombreCategoria, 'Sin categoría') AS Categoria,
                   ISNULL(STRING_AGG(t.Numero, ', '), '') AS Telefonos
            FROM Contactos c
            LEFT JOIN Categorias cat ON c.CategoriaID = cat.CategoriaID
            LEFT JOIN Telefonos t ON c.ContactoID = t.ContactoID
            WHERE c.Nombres LIKE @filtro
               OR c.Apellidos LIKE @filtro
               OR EXISTS (SELECT 1 FROM Telefonos x
                          WHERE x.ContactoID = c.ContactoID AND x.Numero LIKE @filtro)
            GROUP BY c.ContactoID, c.Nombres, c.Apellidos, c.CorreoElectronico,
                     c.Favorito, cat.NombreCategoria
            ORDER BY c.Favorito DESC, c.Nombres";

        using SqlConnection conexion = new SqlConnection(CadenaConexion);
        using SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);
        adaptador.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

        DataTable resultado = new DataTable();
        adaptador.Fill(resultado);
        return resultado;
    }

    // Trae las categorías para llenar el ComboBox
    public static DataTable ListarCategorias()
    {
        using SqlConnection conexion = new SqlConnection(CadenaConexion);
        using SqlDataAdapter adaptador = new SqlDataAdapter(
            "SELECT CategoriaID, NombreCategoria FROM Categorias ORDER BY NombreCategoria", conexion);

        DataTable resultado = new DataTable();
        adaptador.Fill(resultado);
        return resultado;
    }

    // Guarda un contacto nuevo junto con su primer teléfono
    public static void AgregarContacto(string nombres, string apellidos, string correo,
                                       bool favorito, int? categoriaId, string numero, string tipo)
    {
        string sql = @"
            INSERT INTO Contactos (Nombres, Apellidos, CorreoElectronico, Favorito, CategoriaID)
            VALUES (@nombres, @apellidos, @correo, @favorito, @categoria);

            INSERT INTO Telefonos (ContactoID, Numero, TipoTelefono)
            VALUES (SCOPE_IDENTITY(), @numero, @tipo);";

        Ejecutar(sql,
            new SqlParameter("@nombres", nombres),
            new SqlParameter("@apellidos", apellidos),
            new SqlParameter("@correo", string.IsNullOrWhiteSpace(correo) ? DBNull.Value : correo),
            new SqlParameter("@favorito", favorito),
            new SqlParameter("@categoria", categoriaId.HasValue ? categoriaId.Value : DBNull.Value),
            new SqlParameter("@numero", numero),
            new SqlParameter("@tipo", tipo));
    }

    // Agrega otro teléfono a un contacto que ya existe
    public static void AgregarTelefono(int contactoId, string numero, string tipo)
    {
        string sql = "INSERT INTO Telefonos (ContactoID, Numero, TipoTelefono) VALUES (@id, @numero, @tipo)";

        Ejecutar(sql,
            new SqlParameter("@id", contactoId),
            new SqlParameter("@numero", numero),
            new SqlParameter("@tipo", tipo));
    }

    // Borra el contacto (sus teléfonos se borran solos por el ON DELETE CASCADE)
    public static void EliminarContacto(int contactoId)
    {
        Ejecutar("DELETE FROM Contactos WHERE ContactoID = @id",
            new SqlParameter("@id", contactoId));
    }

    // Método de ayuda para los comandos que no devuelven datos
    private static void Ejecutar(string sql, params SqlParameter[] parametros)
    {
        using SqlConnection conexion = new SqlConnection(CadenaConexion);
        using SqlCommand comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddRange(parametros);
        conexion.Open();
        comando.ExecuteNonQuery();
    }
}
