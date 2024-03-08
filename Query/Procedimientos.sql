use FarmaciaDatos
Go

-- Dashboard medicamentos por vencer
SELECT 
    ProductoID,
    CodigoBarras,
    Nombre,
    CategoriaID,
    ProveedorID,
    PrecioCompra,
    PrecioVenta,
    NumeroLote,
    FechaVencimiento,
    Refrigerado,
    BajoReceta,
    Stock,
    CantidadMinima,
    TipoProducto,
    Estado
FROM 
    Producto
WHERE 
    Estado = 1
    AND FechaVencimiento BETWEEN GETDATE() AND DATEADD(MONTH, 5, GETDATE()) 
ORDER BY 
    FechaVencimiento ASC;

	
-- Seleccionar Usuario y el nombre de grupo
SELECT U.UsuarioID, U.NombreUsuario, U.Contrase�a, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU, G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG
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


-- Permite Categor�a existentes en la base de datos productos.
SELECT DISTINCT
    CategoriaID,
    (SELECT TOP 1 Nombre FROM Categoria WHERE CategoriaID = P.CategoriaID) AS Categoria
FROM
    Producto P;

-- Comprobar si una Categor�a tiene productos
DECLARE @categoriaID int = 1
SELECT COUNT(P.ProductoID) AS Cantidad
FROM Categoria C
LEFT JOIN Producto P ON C.CategoriaID = P.CategoriaID
WHERE C.CategoriaID = @categoriaID;
GO


-- FILL USUARIO CON GRUPO
SELECT Usuario.UsuarioID, Usuario.NombreUsuario, Usuario.Contrase�a, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.DNI, Grupo.Nombre AS NombreGrupo, Usuario.Estado
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
    Usuario.Contrase�a, 
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

SELECT * FROM Auditoria WHERE AuditoriaID = 4


DECLARE @FiltroUsuario NVARCHAR(255) = 'Todos'; 
DECLARE @FiltroMovimiento NVARCHAR(255) = 'Todos'; 
DECLARE @FiltroModulo NVARCHAR(255) = 'Productos ';
DECLARE @FiltroBuscar NVARCHAR(255) = 'Todo'; 
DECLARE @Buscar NVARCHAR(255) = ''; 
DECLARE @FechaInicio DATE = '2022/01/09'; 
DECLARE @FechaFin DATE = '2024/03/15'; 

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
        (@FiltroModulo = 'Todos' OR Modulo = @FiltroModulo)
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
DECLARE @Buscar NVARCHAR(255) = 'Categor�a';
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
        OR (@FiltroBuscar = 'C�digo' AND P.CodigoBarras LIKE '%' + @Buscar + '%')
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
    Proveedor.ProveedorID > 0 -- Agregamos la nueva condici�n
    AND (
        (@FiltroBuscar = 'Todo' AND (
            Proveedor.RazonSocial LIKE '%' + @Buscar + '%' OR
            Proveedor.Documento LIKE '%' + @Buscar + '%' OR
            Proveedor.Direccion LIKE '%' + @Buscar + '%' OR
            Proveedor.TelefonoProveedor LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscar = 'Raz�n social' AND Proveedor.RazonSocial LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Documento' AND Proveedor.Documento LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Direcci�n' AND Proveedor.Direccion LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscar = 'Tel�fono' AND Proveedor.TelefonoProveedor LIKE '%' + @Buscar + '%')
    )
    AND (@FiltroTipoDocumento = 'Todos' OR Proveedor.TipoDocumento = @FiltroTipoDocumento)
    AND (
        @FiltroEstado = 'Todos' OR 
        (Proveedor.Estado = 1 AND @FiltroEstado = 'Activo') OR 
        (Proveedor.Estado = 0 AND @FiltroEstado = 'Inactivo')
    )
GO

-- Fill Detalle_Compra
SELECT DC.*, P.RazonSocial AS NombreProveedor
FROM Detalle_Compra DC
JOIN Compra C ON DC.CompraID = C.CompraID
JOIN Proveedor P ON C.ProveedorID = P.ProveedorID;

-- Filtrar Compra
DECLARE @Buscar VARCHAR(50) = 'far'; -- Reemplaza 'ValorABuscar' con el valor que est�s buscando

SELECT DC.*, P.RazonSocial AS NombreProveedor
FROM Detalle_Compra DC
JOIN Compra C ON DC.CompraID = C.CompraID
JOIN Proveedor P ON C.ProveedorID = P.ProveedorID
WHERE P.RazonSocial LIKE '%' + @Buscar + '%'

-- Filtro Detalle_Compra
DECLARE @FiltroCompraID INT = 1; -- Reemplaza 1 con el ID de compra que est�s buscando

SELECT 
    P.CodigoBarras,
    P.Nombre AS 'Nombre de Producto',
    DC.Cantidad AS 'Cantidad Comprada',
    DC.PrecioCompra AS 'Precio de Compra',
    DC.Cantidad * DC.PrecioCompra AS 'Sub Total'
FROM 
    Detalle_Compra DC
    INNER JOIN Producto P ON DC.ProductoID = P.ProductoID
WHERE 
    DC.CompraID = @FiltroCompraID;


SELECT Cantidad FROM Detalle_Compra WHERE CompraID = 1 AND ProductoID = 2

-- Tabla Compra
DECLARE @FiltroBuscar VARCHAR(50) = '';
DECLARE @FiltroEstado VARCHAR(50) = 'Cancelado';
SELECT 
    C.CompraID, 
    Pr.RazonSocial AS Proveedor, 
    C.Factura, 
    C.FechaCompra, 
    SUM(DC.Cantidad) AS CantidadTotalProductos, 
    SUM(DC.Cantidad * DC.PrecioCompra) AS PrecioTotal
FROM 
    Compra C
    INNER JOIN Proveedor Pr ON C.ProveedorID = Pr.ProveedorID
    INNER JOIN Detalle_Compra DC ON C.CompraID = DC.CompraID
WHERE 
    Pr.RazonSocial LIKE '%' + @FiltroBuscar + '%'
    AND (
        @FiltroEstado = 'Todos' OR 
        (C.Estado = 1 AND @FiltroEstado = 'Activo') OR 
        (C.Estado = 0 AND @FiltroEstado = 'Cancelado')
    )
GROUP BY 
    C.CompraID, 
    Pr.RazonSocial, 
    C.Factura,
    C.FechaCompra;

-- Filtro Moneda
DECLARE @FiltroBuscar VARCHAR(60) = ''
SELECT * FROM Moneda
    WHERE Nombre LIKE '%' + @FiltroBuscar + '%';


-- Filtro Salida
DECLARE @FechaInicio DATETIME, @FechaFinal DATETIME;

-- Aqu� puedes establecer las fechas que desees para tus variables
SET @FechaInicio = '2024-02-15';
SET @FechaFinal = '2025-02-20';

SELECT 
    S.SalidaID, 
    U.Nombre AS Usuario, 
    S.FechaSalida, 
    SUM(DS.Cantidad) AS CantidadTotalProductos, 
    S.Observaciones
FROM 
    SalidaInventario S
    INNER JOIN Usuario U ON S.UsuarioID = U.UsuarioID
    INNER JOIN Detalle_Salida DS ON S.SalidaID = DS.SalidaID
WHERE 
    (@FechaInicio IS NULL OR S.FechaSalida >= @FechaInicio)
    AND (@FechaFinal IS NULL OR S.FechaSalida <= @FechaFinal)
GROUP BY 
    S.SalidaID, 
    U.Nombre, 
    S.FechaSalida,
    S.Observaciones;

DECLARE @SalidaID INT, @FiltroBuscarPor VARCHAR(10), @Buscar VARCHAR(50);
SET @SalidaID = 1; 
SET @FiltroBuscarPor = 'C�digo'; -- 
SET @Buscar = ''; 

SELECT 
    DS.DetalleSalidaID,
    P.CodigoBarras,
    P.Nombre AS NombreProducto,
    Pr.RazonSocial AS Proveedor,
    C.Nombre AS Categoria,
    DS.Cantidad
FROM 
    Detalle_Salida DS
    INNER JOIN Producto P ON DS.ProductoID = P.ProductoID
    INNER JOIN Proveedor Pr ON P.ProveedorID = Pr.ProveedorID
    INNER JOIN Categoria C ON P.CategoriaID = C.CategoriaID
WHERE 
    DS.SalidaID = @SalidaID
    AND (
        @FiltroBuscarPor = 'Todo' AND (
            P.CodigoBarras LIKE '%' + @Buscar + '%' OR
            P.Nombre LIKE '%' + @Buscar + '%' OR
            Pr.RazonSocial LIKE '%' + @Buscar + '%' OR
            C.Nombre LIKE '%' + @Buscar + '%'
        )
		OR (@FiltroBuscarPor = 'C�digo' AND P.CodigoBarras LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Nombre' AND P.Nombre LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Proveedor' AND Pr.RazonSocial LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Categor�a' AND C.Nombre LIKE '%' + @Buscar + '%')
    );



-- Filtro de Registro
SELECT 
    R.RegistrosID, 
    R.FechayHora, 
    R.Movimiento, 
    R.NombreUsuario, 
    R.Cantidad, 
    R.CantidadAntes, 
    R.CantidadDespues, 
    R.Modulo, 
    R.Descripcion 
FROM 
    dbo.Registro R
WHERE
    (
        (@FiltroBuscarPor = 'Todo' AND (
            R.Movimiento LIKE '%' + @Buscar + '%' OR
            R.NombreUsuario LIKE '%' + @Buscar + '%' OR
            R.Modulo LIKE '%' + @Buscar + '%' OR
            R.Descripcion LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscarPor = 'M�dulo' AND R.Modulo LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Descripci�n' AND R.Descripcion LIKE '%' + @Buscar + '%')
    )
    AND (@FiltroMovimiento = 'Todos' OR R.Movimiento = @FiltroMovimiento)
    AND (@FiltroUsuario = 'Todos' OR R.NombreUsuario = @FiltroUsuario)
    AND (
        (@FechaDesde IS NULL OR R.FechayHora >= @FechaDesde)
        AND (@FechaHasta IS NULL OR R.FechayHora <= @FechaHasta)
    );

	s




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
SET @modulo = 'formAjustes'; -- Aqu� puedes cambiar el nombre del m�dulo

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
SET @modulo = 'formProductos'; -- Aqu� puedes cambiar el nombre del m�dulo

SELECT M.Descripcion AS Modulo, A.Descripcion AS Accion
FROM Modulo M
INNER JOIN Accion A ON M.ModuloID = A.ModuloID
WHERE M.Descripcion = @modulo;


SELECT * FROM Modulo
WHERE Descripcion = 'formUsuarios';

-- REPORTES
-- Productos con Mayor Cantidad
SELECT TOP (@Filas)
    Producto.ProductoID,
    Producto.CodigoBarras AS Codigo,
    Producto.NumeroLote AS Lote,
    Categoria.Nombre AS Categoria,
    Proveedor.RazonSocial AS Proveedor,
    Producto.Nombre, 
    Producto.Stock AS Cantidad,
    Producto.CantidadMinima
FROM 
    Producto
INNER JOIN
    Categoria ON Producto.CategoriaID = Categoria.CategoriaID
INNER JOIN
    Proveedor ON Producto.ProveedorID = Proveedor.ProveedorID
ORDER BY 
    Cantidad DESC;

-- Productos m�s comprados
SELECT 
    Producto.Nombre,
    SUM(Detalle_Compra.Cantidad) AS CantidadComprada
FROM 
    Producto
INNER JOIN
    Detalle_Compra ON Producto.ProductoID = Detalle_Compra.ProductoID
GROUP BY 
    Producto.Nombre;


DECLARE @FiltroUsuario NVARCHAR(255) = 'Javier12301'; -- Reemplaza 'Todos' con el nombre de usuario que quieras filtrar
DECLARE @FechaInicio DATE = '2022-01-09'; 
DECLARE @FechaFin DATE = '2024-02-20'; 

SELECT
    Movimiento,
    COUNT(*) as Cantidad
FROM 
    Auditoria
WHERE
    (
        (@FiltroUsuario = 'Todos' OR NombreUsuario = @FiltroUsuario)
    )
    AND
    (
        (@FechaInicio IS NULL OR FechayHora >= @FechaInicio)
        AND
        (@FechaFin IS NULL OR FechayHora <= @FechaFin)
    )
GROUP BY 
    Movimiento
ORDER BY 
    Cantidad DESC;


-- Clientes Filtros
DECLARE @FiltroBuscarPor NVARCHAR(255) = 'Todos';
DECLARE @Buscar NVARCHAR(255) = '';
DECLARE @TipoDocumento NVARCHAR(50) = 'Todos';
DECLARE @Estado NVARCHAR(50) = 'Todos';
DECLARE @TipoCliente NVARCHAR(50) = 'Todos';

SELECT C.*, TC.Descripcion AS TipoCliente
FROM Cliente C
INNER JOIN TipoCliente TC ON C.TipoClienteID = TC.TipoClienteID
WHERE
    (
        (@FiltroBuscarPor = 'Todos' AND 
        (
            C.NombreCompleto LIKE '%' + @Buscar + '%' OR
            C.Documento LIKE '%' + @Buscar + '%' OR
            C.Correo LIKE '%' + @Buscar + '%' OR
            C.Telefono LIKE '%' + @Buscar + '%'
        ))
        OR (@FiltroBuscarPor = 'Nombre' AND C.NombreCompleto LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Documento' AND C.Documento LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Correo' AND C.Correo LIKE '%' + @Buscar + '%')
        OR (@FiltroBuscarPor = 'Telefono' AND C.Telefono LIKE '%' + @Buscar + '%')
    )
    AND (@TipoDocumento = 'Todos' OR C.TipoDocumento = @TipoDocumento)
    AND (@Estado = 'Todos' OR (C.Estado = 1 AND @Estado = 'Activo') OR (C.Estado = 0 AND @Estado = 'Inactivo'))
    AND (@TipoCliente = 'Todos' OR TC.Descripcion = @TipoCliente);
