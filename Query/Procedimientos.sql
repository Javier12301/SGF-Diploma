use FarmaciaDatos
Go


SELECT * FROM Proveedor

-- Seleccionar Usuario y el nombre de grupo
SELECT U.UsuarioID, U.NombreUsuario, U.Contraseña, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU, G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG
FROM Usuario U
INNER JOIN Grupo G ON U.GrupoID = G.GrupoID
WHERE U.NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = 'Admin'

-- Seleccionar Producto, nombre de proveedor y categoria correspondiente
SELECT 
    P.ProductoID, 
    P.CodigoBarras, 
    P.Nombre, 
    C.Nombre AS Categoria, 
    Pr.RazonSocial AS Proveedor, 
    P.PrecioCompra, 
    P.PrecioVenta, 
    COALESCE(P.NumeroLote, '-') AS NumeroLote, 
    CASE 
        WHEN P.FechaVencimiento IS NULL THEN '-'
        ELSE CONVERT(VARCHAR, P.FechaVencimiento, 23)
    END AS FechaVencimiento,
    P.Refrigerado, 
    P.BajoReceta, 
    P.Stock, 
    P.CantidadMinima, 
    P.TipoProducto, 
    P.Estado 
FROM 
    dbo.Producto P
    INNER JOIN dbo.Categoria C ON P.CategoriaID = C.CategoriaID
    INNER JOIN dbo.Proveedor Pr ON P.ProveedorID = Pr.ProveedorID;


-- Permite Categoría existentes en la base de datos productos.
SELECT DISTINCT
    CategoriaID,
    (SELECT TOP 1 Nombre FROM Categoria WHERE CategoriaID = P.CategoriaID) AS Categoria
FROM
    Producto P;

-- Comprobar si una Categoría tiene productos
DECLARE @categoriaID int = 1
SELECT COUNT(P.ProductoID) AS Cantidad
FROM Categoria C
LEFT JOIN Producto P ON C.CategoriaID = P.CategoriaID
WHERE C.CategoriaID = @categoriaID;
GO


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

-- Filtrar Auditoria
DECLARE @FiltroUsuario NVARCHAR(255) = 'Todos'; 
DECLARE @FiltroMovimiento NVARCHAR(255) = 'Alta'; 
DECLARE @FiltroBuscar NVARCHAR(255) = 'Todo'; 
DECLARE @Buscar NVARCHAR(255) = ''; 
DECLARE @FechaInicio DATE = '2022-01-09'; 
DECLARE @FechaFin DATE = '2024 /01 /15'; 

SELECT *
FROM Auditoria
WHERE
    (
        (@FiltroUsuario = 'Todos' OR NombreUsuario = @FiltroUsuario)
    )
    AND
    (
        (@FiltroMovimiento = 'Todos' OR Movimiento = @FiltroMovimiento)
    )
    AND
    (
        (
            @FiltroBuscar = 'Todo' AND 
            (
                NombreUsuario LIKE '%' + @Buscar + '%' OR
                Movimiento LIKE '%' + @Buscar + '%' OR
                Descripcion LIKE '%' + @Buscar + '%'
            )
        )
        OR
        (
            @FiltroBuscar = 'Nombre Usuario' AND NombreUsuario LIKE '%' + @Buscar + '%'
        )
        OR
        (
            @FiltroBuscar = 'Movimiento' AND Movimiento LIKE '%' + @Buscar + '%'
        )
        OR
        (
            @FiltroBuscar = 'Descripcion' AND Descripcion LIKE '%' + @Buscar + '%'
        )
    )
    AND
    (
        (@FechaInicio IS NULL OR FechayHora >= @FechaInicio)
        AND
        (@FechaFin IS NULL OR FechayHora <= @FechaFin)
    );


-- Filtrar Categoria
DECLARE @Buscar NVARCHAR(255) = 'Categoría';
DECLARE @FiltroEstado NVARCHAR(50) = 'Activo';

SELECT 
    CategoriaID, 
    Nombre, 
    Descripcion, 
    Estado
FROM 
    Categoria
WHERE 
    CategoriaID > 0
    AND (
        @FiltroEstado = 'Todos' 
        OR (Estado = 1 AND @FiltroEstado = 'Activo') 
        OR (Estado = 0 AND @FiltroEstado = 'Inactivo')
    )
    AND (
        @Buscar IS NULL 
        OR Nombre LIKE '%' + @Buscar + '%'
        OR Descripcion LIKE '%' + @Buscar + '%'
    );
GO

-- Filtrar Producto
DECLARE @FiltroBuscar NVARCHAR(50) = 'Todos';
DECLARE @Buscar NVARCHAR(255) = '';
DECLARE @FiltroTipoProducto NVARCHAR(50) = 'Todos';
DECLARE @FiltroCategoria NVARCHAR(50) = 'Todos';
DECLARE @FiltroEstado NVARCHAR(50) = 'Activo';
DECLARE @FechaDesde DATE = NULL;
DECLARE @FechaHasta DATE = NULL;

SELECT 
    P.ProductoID, 
    P.CodigoBarras, 
    P.Nombre, 
    C.Nombre AS Categoria, 
    Pr.RazonSocial AS Proveedor, 
    P.PrecioCompra, 
    P.PrecioVenta, 
    COALESCE(P.NumeroLote, '-') AS NumeroLote, 
    CASE 
        WHEN P.FechaVencimiento IS NULL THEN '-'
        ELSE CONVERT(VARCHAR, P.FechaVencimiento, 23)
    END AS FechaVencimiento,
    P.Refrigerado, 
    P.BajoReceta, 
    P.Stock, 
    P.CantidadMinima, 
    P.TipoProducto, 
    P.Estado 
FROM 
    dbo.Producto P
    INNER JOIN dbo.Categoria C ON P.CategoriaID = C.CategoriaID
    INNER JOIN dbo.Proveedor Pr ON P.ProveedorID = Pr.ProveedorID
WHERE
    (
        (@FiltroBuscar = 'Todo' AND (
            P.CodigoBarras LIKE '%' + @Buscar + '%' OR
            P.Nombre LIKE '%' + @Buscar + '%' OR
            Pr.RazonSocial LIKE '%' + @Buscar + '%' OR
            P.NumeroLote LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscar = 'Código' AND P.CodigoBarras LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Nombre' AND P.Nombre LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Proveedor' AND Pr.RazonSocial LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Lote' AND P.NumeroLote LIKE '%' + @Buscar + '%')
    )
    AND (@FiltroTipoProducto = 'Todos' OR P.TipoProducto = @FiltroTipoProducto)
    AND (@FiltroCategoria = 'Todos' OR C.Nombre = @FiltroCategoria)
    AND (
        @FiltroEstado = 'Todos' OR 
        (P.Estado = 1 AND @FiltroEstado = 'Activo') OR 
        (P.Estado = 0 AND @FiltroEstado = 'Inactivo')
    )
    AND (
        (@FechaDesde IS NULL OR P.FechaVencimiento >= @FechaDesde)
        AND (@FechaHasta IS NULL OR P.FechaVencimiento <= @FechaHasta)
    );
GO

-- Filtrar Proveedores
-- FILTRAR PROVEEDOR
DECLARE @FiltroBuscar NVARCHAR(50) = 'Todo';
DECLARE @Buscar NVARCHAR(255) = '';
DECLARE @FiltroEstado NVARCHAR(50) = 'Activo';
DECLARE @FiltroTipoDocumento NVARCHAR(50) = 'CUIT';

SELECT 
    Proveedor.ProveedorID, 
    Proveedor.RazonSocial, 
    Proveedor.TipoDocumento, 
    Proveedor.Documento, 
    Proveedor.Direccion, 
    Proveedor.TelefonoProveedor, 
    Proveedor.Correo, 
    Proveedor.Estado
FROM 
    Proveedor
WHERE
    Proveedor.ProveedorID > 0 -- Agregamos la nueva condición
    AND (
        (@FiltroBuscar = 'Todo' AND (
            Proveedor.RazonSocial LIKE '%' + @Buscar + '%' OR
            Proveedor.Documento LIKE '%' + @Buscar + '%' OR
            Proveedor.Direccion LIKE '%' + @Buscar + '%' OR
            Proveedor.TelefonoProveedor LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscar = 'Razón social' AND Proveedor.RazonSocial LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Documento' AND Proveedor.Documento LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Dirección' AND Proveedor.Direccion LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Teléfono' AND Proveedor.TelefonoProveedor LIKE '%' + @Buscar + '%')
    )
    AND (@FiltroTipoDocumento = 'Todos' OR Proveedor.TipoDocumento = @FiltroTipoDocumento)
    AND (
        @FiltroEstado = 'Todos' OR 
        (Proveedor.Estado = 1 AND @FiltroEstado = 'Activo') OR 
        (Proveedor.Estado = 0 AND @FiltroEstado = 'Inactivo')
    )
GO

DELETE Proveedor
WHERE ProveedorID = 5







SELECT DISTINCT Movimiento, NombreUsuario FROM Auditoria

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



