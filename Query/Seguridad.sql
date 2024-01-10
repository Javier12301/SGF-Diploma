USE FarmaciaDatos
GO

CREATE TABLE Grupo (
    GrupoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255),
    Estado BIT
);

CREATE TABLE Usuario (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(255),
    Contraseña NVARCHAR(255),
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    Email NVARCHAR(255),
    DNI NVARCHAR(255),
    GrupoID INT,
    Estado BIT,
    FOREIGN KEY (GrupoID) REFERENCES Grupo(GrupoID)
);
-- Modulo serían las distintas ABM o sea los distintos formularios.
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
    NombreUsuario NVARCHAR(255),
    Descripcion NVARCHAR(255)
);
GO


SELECT * FROM Auditoria
SELECT * FROM Usuario

--DBCC CHECKIDENT ('Auditoria', RESEED, 1)

SELECT op.* FROM Accion op
JOIN Modulo m ON m.ModuloID = op.ModuloID
WHERE m.Descripcion = 'formVentas'

DECLARE @NombreModulo NVARCHAR(255) = 'formProductos'
DECLARE @NombreAccion NVARCHAR(255) = 'Alta'
SELECT A.*
FROM Accion A
INNER JOIN Modulo M ON A.ModuloID = M.ModuloID
WHERE M.Descripcion = @NombreModulo AND A.Descripcion = @NombreAccion;

SELECT * FROM Modulo
WHERE Descripcion = 'formVentas'

SELECT * FROM Grupo


DECLARE @grupoID int = 11
DECLARE @accionID int = 11
DECLARE @moduloID int = 3
DECLARE @permitido bit = 1
INSERT INTO Permiso (GrupoID, AccionID, Permitido) VALUES (@grupoID, @accionID, @permitido)