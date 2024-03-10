USE FarmaciaDatos
GO

CREATE TABLE Grupo (
    GrupoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    Estado BIT
);
SET IDENTITY_INSERT Grupo ON;
-- Estante default
INSERT INTO Grupo (GrupoID, Nombre, Estado)
VALUES (0, 'N/A', 0);
SET IDENTITY_INSERT Grupo OFF;
GO


CREATE TABLE Usuario (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(255),
    Contrase�a NVARCHAR(255),
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    Email NVARCHAR(255),
    DNI NVARCHAR(255),
    GrupoID INT,
    Estado BIT,
    FOREIGN KEY (GrupoID) REFERENCES Grupo(GrupoID)
);
-- Modulo ser�an las distintas ABM o sea los distintos formularios.
CREATE TABLE Modulo (
    ModuloID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255)
);


CREATE TABLE Accion (
    AccionID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(255),
    ModuloID INT,
    FOREIGN KEY (ModuloID) REFERENCES Modulo(ModuloID)
);

CREATE TABLE Permiso (
    PermisoID INT IDENTITY(1,1) PRIMARY KEY,
    GrupoID INT,
    AccionID INT,
    FOREIGN KEY (GrupoID) REFERENCES Grupo(GrupoID),
    FOREIGN KEY (AccionID) REFERENCES Accion(AccionID),
    Permitido BIT
);

CREATE TABLE Auditoria (
    AuditoriaID INT IDENTITY(1,1) PRIMARY KEY,
    FechayHora DATETIME,
    Movimiento NVARCHAR(255),
	Modulo NVARCHAR(255),
    NombreUsuario NVARCHAR(255),
    Descripcion NVARCHAR(255),
	Detalles VARCHAR(MAX)
);
GO


DECLARE @moduloDescripcion VARCHAR(50) = 'formCategorias'
SELECT op.* FROM Accion op
INNER JOIN Modulo m ON m.ModuloID = op.ModuloID
WHERE m.Descripcion = @moduloDescripcion



INSERT INTO Auditoria (FechayHora, Movimiento, Modulo, NombreUsuario, Descripcion, Detalles)
VALUES (@FechayHora, @Movimiento, @Modulo, @NombreUsuario, @Descripcion, @Detalles);

-- Modulos
DECLARE @GrupoID INT = 6
SELECT DISTINCT M.Descripcion FROM Permiso p
join Grupo Gr ON Gr.GrupoID = p.GrupoID
join Accion op on op.AccionID = p.AccionID
join Modulo M on M.ModuloID = op.ModuloID
WHERE Gr.GrupoID = @GrupoID AND p.Permitido = 1
go
-- Acciones correspondientes
DECLARE @GrupoID INT = 6
declare @moduloDescripcion NVARCHAR(255) = 'formUsuarios'

SELECT op.* FROM Permiso p
join Grupo Gr ON Gr.GrupoID = p.GrupoID
join Accion op on op.AccionID = p.AccionID
join Modulo M on M.ModuloID = op.ModuloID
WHERE Gr.GrupoID = @GrupoID AND M.Descripcion = @moduloDescripcion AND p.Permitido = 1
GO

CREATE TABLE Compra (
    CompraID INT IDENTITY PRIMARY KEY,
    UsuarioID INT REFERENCES Usuario(UsuarioID),
    ProveedorID INT REFERENCES Proveedor(ProveedorID),
    Factura VARCHAR(50),
    FechaCompra DATETIME DEFAULT GETDATE(),
	Estado BIT
);
GO

CREATE TABLE Detalle_Compra (
    DetalleCompraID INT IDENTITY PRIMARY KEY,
    CompraID INT REFERENCES Compra(CompraID),
    ProductoID INT REFERENCES Producto(ProductoID),
    PrecioCompra DECIMAL(10,2) DEFAULT 0,
    Cantidad INT,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO