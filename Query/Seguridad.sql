USE FarmaciaDatos
GO

CREATE TABLE Usuario (
    UsuarioID INT PRIMARY KEY,
    NombreUsuario NVARCHAR(255),
    Contraseña NVARCHAR(255),
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    Email NVARCHAR(255),
    DNI INT,
    Estado BIT
);

CREATE TABLE Permiso (
    PermisoID INT PRIMARY KEY,
    Accion NVARCHAR(255),
    Formulario NVARCHAR(255),
    Descripcion NVARCHAR(255)
);

CREATE TABLE Grupo (
    GrupoID INT PRIMARY KEY,
    Nombre NVARCHAR(255),
    Estado BIT
);

CREATE TABLE Auditoria (
    AuditoriaID INT PRIMARY KEY,
    FechayHora DATETIME,
    Movimiento NVARCHAR(255),
    NombreUsuario NVARCHAR(255),
    Descripcion NVARCHAR(255),
    Permiso NVARCHAR(255)
);

CREATE TABLE Acceso (
    AccesoID INT PRIMARY KEY,
    NombreUsuario NVARCHAR(255),
    Login NVARCHAR(255),
    FechayHoraEntrada DATETIME,
    Logout NVARCHAR(255),
    FechayHoraSalida DATETIME
);
GO