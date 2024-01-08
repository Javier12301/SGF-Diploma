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

-- 



-- Obtener los permisos 
CREATE PROC mds_ObtenerPermisos(
@UsuarioID int
)
as
begin
SELECT 
    (
        SELECT vistaMenu.NombreModulo,
            (
                SELECT op.Descripcion
                FROM Permiso p
                JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
                JOIN Accion op ON op.AccionID = p.AccionID
                JOIN Modulo M ON M.ModuloID = op.ModuloID
                JOIN Usuario U ON U.GrupoID = p.GrupoID AND p.Permitido = 1
                WHERE U.UsuarioID = us.UsuarioID AND op.ModuloID = vistaMenu.ModuloID
                FOR XML PATH ('Accion'), TYPE
            ) AS 'DetalleAcciones' 
        FROM
        (
            SELECT DISTINCT M.* 
            FROM Permiso p
            JOIN Grupo Gr ON Gr.GrupoID = p.GrupoID
            JOIN Accion op ON op.AccionID = p.AccionID
            JOIN Modulo M ON M.ModuloID = op.ModuloID
            JOIN Usuario U ON U.GrupoID = p.GrupoID AND p.Permitido = 1
            WHERE U.UsuarioID = us.UsuarioID
        ) AS vistaMenu
        FOR XML PATH ('Modulo'), TYPE
    ) AS 'DetalleModulo'
FROM Usuario us
WHERE us.UsuarioID = 1
FOR XML PATH(''), ROOT('Permiso')
end

exec mds_ObtenerPermisos 1
go