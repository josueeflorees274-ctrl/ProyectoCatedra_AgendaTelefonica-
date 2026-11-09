-----Crear la base de datos
CREATE DATABASE AgendaTelefonicaDB;
GO

USE AgendaTelefonicaDB;
GO

------ Tabla de Categorías
CREATE TABLE Categorias (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria VARCHAR(50) NOT NULL
);
GO

------- Tabla de Contactos
CREATE TABLE Contactos (
    ContactoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(60) NOT NULL,
    Apellidos VARCHAR(60) NOT NULL,
    CorreoElectronico VARCHAR(100),
    Favorito BIT DEFAULT 0, -- 1 si es favorito, 0 si no
    CategoriaID INT,
    CONSTRAINT FK_Contacto_Categoria FOREIGN KEY (CategoriaID) 
        REFERENCES Categorias(CategoriaID)
        ON DELETE SET NULL
);
GO

------- Tabla de Teléfonos (Permite múltiples números por contacto)
CREATE TABLE Telefonos (
    TelefonoID INT IDENTITY(1,1) PRIMARY KEY,
    ContactoID INT NOT NULL,
    Numero VARCHAR(20) NOT NULL,
    TipoTelefono VARCHAR(20) NOT NULL, -- Ejemplo: Móvil, Casa, Trabajo
    CONSTRAINT FK_Telefono_Contacto FOREIGN KEY (ContactoID) 
        REFERENCES Contactos(ContactoID)
        ON DELETE CASCADE
);
GO
-- Insertar Categorías de prueba
INSERT INTO Categorias (NombreCategoria) VALUES ('Familia'), ('Trabajo'), ('Amigos'), ('Universidad');

-- Insertar Contactos de prueba
INSERT INTO Contactos (Nombres, Apellidos, CorreoElectronico, Favorito, CategoriaID) 
VALUES 
('Carlos Alberto', 'Guevara', 'carlos.guevara@email.com', 1, 4),
('María José', 'Martínez', 'mjose.martinez@email.com', 1, 1),
('Ana Sofía', 'Rivas', 'ana.rivas@trabajo.com', 0, 2);

-- Insertar Teléfonos de prueba vinculados a los contactos
INSERT INTO Telefonos (ContactoID, Numero, TipoTelefono) 
VALUES 
(1, '7890-1234', 'Móvil'),
(1, '2234-5678', 'Casa'),
(2, '7123-9876', 'Móvil'),
(3, '7543-2109', 'Móvil'),
(3, '2255-8899', 'Trabajo');
GO
