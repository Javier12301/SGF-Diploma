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
    DNI INT,
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


SELECT U.UsuarioID, U.NombreUsuario, U.Contraseña, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU, G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG
FROM Usuario U
INNER JOIN Grupo G ON U.GrupoID = G.GrupoID
WHERE U.NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = 'Admin'
