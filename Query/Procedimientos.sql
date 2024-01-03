use FarmaciaDatos
Go

SELECT * FROM Modulo m
inner join Accion op on m.ModuloID = op.ModuloID




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