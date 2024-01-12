use FarmaciaDatos
Go

-- Seleccionar Usuario y el nombre de grupo
SELECT U.UsuarioID, U.NombreUsuario, U.Contraseña, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU, G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG
FROM Usuario U
INNER JOIN Grupo G ON U.GrupoID = G.GrupoID
WHERE U.NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = 'Admin'


SELECT * FROM Usuario
WHERE UsuarioID = 1


-- FILL USUARIO CON GRUPO
SELECT Usuario.UsuarioID, Usuario.NombreUsuario, Usuario.Contraseña, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.DNI, Grupo.Nombre AS NombreGrupo, Usuario.Estado
FROM Usuario
INNER JOIN Grupo ON Usuario.GrupoID = Grupo.GrupoID;


--FILTROS

 -- FILTRAR USUARIO
DECLARE @FiltroBuscar NVARCHAR(50) = 'Nombre';
DECLARE @Buscar NVARCHAR(255) = 'ja';
DECLARE @FiltroGrupo NVARCHAR(50) = 'Todos';
DECLARE @FiltroEstado NVARCHAR(50) = 'Activo';

SELECT 
    Usuario.UsuarioID, 
    Usuario.NombreUsuario, 
    Usuario.Contraseña, 
    Usuario.Nombre, 
    Usuario.Apellido, 
    Usuario.Email, 
    Usuario.DNI, 
    Grupo.Nombre AS NombreGrupo, 
    Usuario.Estado
FROM 
    Usuario
INNER JOIN 
    Grupo ON Usuario.GrupoID = Grupo.GrupoID
WHERE
    (
        (@FiltroBuscar = 'Todos' AND (
            Usuario.NombreUsuario LIKE '%' + @Buscar + '%' OR
            Usuario.Nombre LIKE '%' + @Buscar + '%' OR
            Usuario.Apellido LIKE '%' + @Buscar + '%' OR
            Usuario.Email LIKE '%' + @Buscar + '%' OR
            Usuario.DNI LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscar = 'Usuario' AND Usuario.NombreUsuario LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Nombre' AND Usuario.Nombre LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Apellido' AND Usuario.Apellido LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Email' AND Usuario.Email LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'DNI' AND Usuario.DNI LIKE '%' + @Buscar + '%')
    )
    AND (@FiltroGrupo = 'Todos' OR Grupo.Nombre = @FiltroGrupo)
    AND (
        @FiltroEstado = 'Todos' OR 
        (Usuario.Estado = 1 AND @FiltroEstado = 'Activo') OR 
        (Usuario.Estado = 0 AND @FiltroEstado = 'Inactivo')
    );
GO



SELECT * FROM Modulo m
inner join Accion op on m.ModuloID = op.ModuloID






-- Cantidad de usuarios en un grupo
DECLARE @grupoID INT = 5
SELECT COUNT(U.UsuarioID) AS Cantidad
FROM Grupo G
LEFT JOIN Usuario U ON G.GrupoID = U.GrupoID
WHERE G.GrupoID = @grupoID

SELECT * FROM Usuario
-- MODULOS PERMITIDOS DEL USUARIO ID = ?
DECLARE @UsuarioID INT = 2;
SELECT DISTINCT M.* FROM Permiso p
join Grupo Gr ON Gr.GrupoID = p.GrupoID
join Accion op on op.AccionID = p.AccionID
join Modulo M on M.ModuloID = op.ModuloID
join Usuario U on U.GrupoID = p.GrupoID and p.Permitido = 1
WHERE U.UsuarioID = @UsuarioID

-- Obtener la descripcion de modulos permitidos
DECLARE @UsuarioID INT = 2;

SELECT DISTINCT M.Descripcion FROM Permiso p
join Grupo Gr ON Gr.GrupoID = p.GrupoID
join Accion op on op.AccionID = p.AccionID
join Modulo M on M.ModuloID = op.ModuloID
join Usuario U on U.GrupoID = p.GrupoID and p.Permitido = 1
WHERE U.UsuarioID = @UsuarioID

-- AccionES PERMITIDAS DEL USUARIO ID = ?
DECLARE @UsuarioID INT = 2;

SELECT op.* FROM Permiso p
join Grupo Gr ON Gr.GrupoID = p.GrupoID
join Accion op on op.AccionID = p.AccionID
join Modulo M on M.ModuloID = op.ModuloID
join Usuario U on U.GrupoID = p.GrupoID and p.Permitido = 1
WHERE U.UsuarioID = @UsuarioID

DECLARE @modulo NVARCHAR(255);
SET @modulo = 'formAjustes'; -- Aquí puedes cambiar el nombre del módulo

SELECT M.Descripcion AS Modulo, A.Descripcion AS Accion
FROM Modulo M
INNER JOIN Accion A ON M.ModuloID = A.ModuloID
WHERE M.Descripcion = @modulo;


-- ACCIONES Y MODULOS PERMITIDO PARA GRUPOS
-- MODULOS PERMITIDOS DEL GRUPO ID = ?
select * from Grupo

DECLARE @GrupoID INT = 5;

SELECT DISTINCT M.*
FROM Permiso p
JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
JOIN Accion op ON op.AccionID = p.AccionID
JOIN Modulo M ON M.ModuloID = op.ModuloID
WHERE Gr.GrupoID = @GrupoID AND p.Permitido = 1;

-- Obtener la descripcion de modulos permitidos
DECLARE @GrupoID INT = 2;

SELECT DISTINCT M.Descripcion
FROM Permiso p
JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
JOIN Accion op ON op.AccionID = p.AccionID
JOIN Modulo M ON M.ModuloID = op.ModuloID
WHERE Gr.GrupoID = @GrupoID AND p.Permitido = 1;

-- Acciones PERMITIDAS DEL GRUPO ID = ?
DECLARE @GrupoID INT = 5;

SELECT op.*
FROM Permiso p
JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
JOIN Accion op ON op.AccionID = p.AccionID
JOIN Modulo M ON M.ModuloID = op.ModuloID
WHERE Gr.GrupoID = @GrupoID AND p.Permitido = 1;

DECLARE @modulo NVARCHAR(255);
SET @modulo = 'formProductos'; -- Aquí puedes cambiar el nombre del módulo

SELECT M.Descripcion AS Modulo, A.Descripcion AS Accion
FROM Modulo M
INNER JOIN Accion A ON M.ModuloID = A.ModuloID
WHERE M.Descripcion = @modulo;


SELECT * FROM Modulo
WHERE Descripcion = 'formUsuarios'


-- 



-- Obtener los permisos 
--CREATE PROC mds_ObtenerPermisos(
--@UsuarioID int
--)
--as
--begin
--SELECT 
--    (
--        SELECT vistaMenu.NombreModulo,
--            (
--                SELECT op.Descripcion
--                FROM Permiso p
--                JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
--                JOIN Accion op ON op.AccionID = p.AccionID
--                JOIN Modulo M ON M.ModuloID = op.ModuloID
--                JOIN Usuario U ON U.GrupoID = p.GrupoID AND p.Permitido = 1
--                WHERE U.UsuarioID = us.UsuarioID AND op.ModuloID = vistaMenu.ModuloID
--                FOR XML PATH ('Accion'), TYPE
--            ) AS 'DetalleAcciones' 
--        FROM
--        (
--            SELECT DISTINCT M.* 
--            FROM Permiso p
--            JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
--            JOIN Accion op ON op.AccionID = p.AccionID
--            JOIN Modulo M ON M.ModuloID = op.ModuloID
--            JOIN Usuario U ON U.GrupoID = p.GrupoID AND p.Permitido = 1
--            WHERE U.UsuarioID = us.UsuarioID
--        ) AS vistaMenu
--        FOR XML PATH ('Modulo'), TYPE
--    ) AS 'DetalleModulo'
--FROM Usuario us
--WHERE us.UsuarioID = 1
--FOR XML PATH(''), ROOT('Permiso')
--end

--exec mds_ObtenerPermisos 1
--go