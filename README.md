# Proyecto de cátedra_agenda telefónica

Proyecto de cátedra de Programación I (SP 226) en C# con Windows Forms y SQL Server Express.

## Funciones del prototipo
- Ver los contactos de la base de datos con su categoría y teléfonos
- Agregar contactos (con su primer teléfono y categoría)
- Agregar más teléfonos a un contacto
- Buscar por nombre, apellido o teléfono
- Eliminar contactos
- Formulario de autores

## Cómo ejecutarlo
1. Abrir `BaseDeDatos/AgendaTelefonicaDB.sql` en SSMS y ejecutarlo (crea la base de datos, las tablas y datos de prueba).
2. Abrir `Proyecto de cátedra_agenda telefónica.csproj` en Visual Studio y presionar F5.

La cadena de conexión está en `BaseDatos.cs` (servidor `localhost\SQLEXPRESS`, autenticación de Windows).

## Estructura
- `BaseDatos.cs`: consultas a SQL Server
- `FormPrincipal.cs`: ventana principal
- `FormAutores.cs`: autores del proyecto
- `BaseDeDatos/`: script SQL

Pendiente: editar contactos.
