use FarmaciaDatos
go

INSERT INTO Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, Estado)
VALUES ('Admin', 'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 'admin', 'admin', 'admin@gmail.com', 12345678, 1);
go

SELECT * FROM Usuario;
UPDATE Usuario
SET Email = 'javierramirez1230123@gmail.com'
WHERE UsuarioID = 1;

DECLARE @nombreUsuario NVARCHAR(255) = 'admin';
DECLARE @email NVARCHAR(255) = 'javierramirez1230123@gmail.com';
SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario AND Email COLLATE SQL_Latin1_General_CP1_CS_AS = @email
SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = 'admin' OR Email COLLATE SQL_Latin1_General_CP1_CS_AS = 'admin@gmail.com'

-- Grupo Principal
SELECT * FROM Grupo

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Administrador', 1);

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Gestor de inventario', 1)

-- Grupos de prueba
INSERT INTO Grupo(Nombre, Estado)
VALUES ('Tester2', 0)

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Tester', 0)

select * from Grupo
-- Insertar el usuario Admin
INSERT INTO Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)
VALUES ('Admin', 'D460DFCBF4789D0B8652DBF847B15AB1B58CA70D96869EFD186F7FC08D4A7B47', 'admin', 'admin', 'javierramirez1230123@gmail.com', 12345678, 1, 1);

INSERT INTO Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)
VALUES ('Javier12301', 'D460DFCBF4789D0B8652DBF847B15AB1B58CA70D96869EFD186F7FC08D4A7B47', 'Javi', 'Ramirez', 'javieralejandro12301@gmail.com', 12345678, 2, 1);
-- Insertar el módulo formProductos
-- Insertar módulos
INSERT INTO Modulo(Descripcion)
VALUES 
    ('formVentas'),
    ('formClientes'),
    ('formProductos'),
    ('formCategorias'),
    ('formProveedores'),
    ('formInventario'),
    ('formRegistros'),
    ('formReportes'),
    ('formReporteInventario'),
    ('formReporteVentas'),
    ('formReporteClientes'),
    ('formAjustes'),
    ('formPerfiles'),
    ('formUsuarios'),
    ('formGrupos'),
    ('formAuditoria'),
    ('formMisDatos');

-- Insertar las acciones para el módulo formVentas
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Historial de ventas', 1),
    ('Buscar clientes', 1),
    ('Vender medicamentos', 1),
    ('Dar crédito', 1),
    ('Vender producto general', 1);

-- Insertar las acciones para el módulo formClientes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 2),
    ('Modificar', 2),
    ('Baja', 2),
    ('Importar', 2),
    ('Exportar', 2);

-- Insertar las acciones para el módulo formProductos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 3),
    ('Modificar', 3),
    ('Baja', 3),
    ('Importar', 3),
    ('Exportar', 3);

-- Insertar las acciones para el módulo formCategorias
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 4),
    ('Modificar', 4),
    ('Baja', 4);

-- Insertar las acciones para el módulo formProveedores
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 5),
    ('Modificar', 5),
    ('Baja', 5),
    ('Exportar', 5);

-- Insertar las acciones para el módulo formInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Entrada', 6),
    ('Salida', 6),
    ('Exportar', 6);

-- Insertar las acciones para el módulo formRegistros
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Generar registro', 7),
    ('Exportar', 7);

-- Insertar las acciones para el módulo formReportes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Inventario', 8),
    ('Ventas', 8),
    ('Clientes', 8);

-- Insertar las acciones para el módulo formReporteInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Existencias de inventario', 9),
    ('Entradas de inventario', 9),
    ('Salidas de inventario', 9),
    ('Medicamentos por vencer', 9),
    ('Exportar', 9);

-- Insertar las acciones para el módulo formReporteVentas
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Ventas', 10),
    ('Ventas por clientes', 10),
    ('Exportar', 10);

-- Insertar las acciones para el módulo formReporteClientes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Pagos de clientes', 11),
    ('Cuentas por cobrar', 11),
    ('Exportar', 11);

-- Insertar las acciones para el módulo formAjustes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Perfiles', 12),
    ('Datos de negocio', 12),
    ('Gestionar base de datos', 12),
    ('Otras configuraciones', 12);

-- Insertar las acciones para el módulo formPerfiles
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Usuarios', 13),
    ('Grupos', 13),
    ('Auditoria', 13),
    ('Mis datos', 13);

SELECT * FROM Modulo
WHERE Descripcion = 'formPerfiles'

select * from Accion
WHERE ModuloID = 13 

-- Insertar las acciones para el módulo formUsuarios
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 14),
    ('Modificar', 14),
    ('Baja', 14),
    ('Exportar', 14);

-- Insertar las acciones para el módulo formGrupos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 15),
    ('Modificar', 15),
    ('Baja', 15),
    ('Exportar', 15);

-- Insertar las acciones para el módulo formAuditoria
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Generar auditoria', 16),
       ('Exportar', 16);

-- Insertar las acciones para el módulo formMisDatos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Permitir acceso', 17);
GO

-- Inserta los permisos para el grupo de administradores
INSERT INTO Permiso (GrupoID, AccionID, Permitido)
SELECT 1, AccionID, 1
FROM Accion
WHERE ModuloID NOT IN 
    (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formRegistros')
    AND ModuloID NOT IN
    (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReportes');
-- Insertar para el grupo Empleados
-- Obtén el ID del usuario 'Javier12301'
DECLARE @UsuarioID INT;
SELECT @UsuarioID = UsuarioID FROM Usuario WHERE NombreUsuario = 'Javier12301';

-- Obtén el ID del módulo 'formProductos'
DECLARE @ModuloID INT;
SELECT @ModuloID = ModuloID FROM Modulo WHERE Descripcion = 'formProductos';

-- Inserta los permisos para las acciones 'Alta', 'Baja' y 'Exportar'
INSERT INTO Permiso (GrupoID, AccionID, Permitido)
SELECT @UsuarioID, AccionID, 1
FROM Accion
WHERE ModuloID = @ModuloID AND Descripcion IN ('Alta', 'Baja', 'Exportar');
go

-- INSERTAR DATOS PARA PRODUCTOS, CATEGORÍA Y PROVEEDOR PARA TESTEAR SISTEMA
-- Insertar Categorías
INSERT INTO Categoria (Nombre, Descripcion, Estado) VALUES
('Medicamentos', 'Categoría de medicamentos', 1),
('Productos No Médicos', 'Categoría de productos no médicos', 1);

-- Insertar Proveedores
INSERT INTO Proveedor (RazonSocial, TipoDocumento, Documento, Direccion, TelefonoProveedor, Correo, Estado) VALUES
('Farmacia XYZ', 'CUIT', '30-12345678-9', 'Calle 123', '123-456789', 'info@farmaciaxyz.com', 1),
('Distribuidora ABC', 'CUIT', '30-87654321-0', 'Avenida Principal', '987-654321', 'info@distribuidoraabc.com', 1);

INSERT INTO Proveedor (RazonSocial, TipoDocumento, Documento, Direccion, TelefonoProveedor, Correo, Estado)
VALUES 
    ('Distribuidora LBL', 'CUIT', '30-87654321-0', 'Principal', '93387-654321', 'info@distribuidoraabc.com', 1),
    ('Distribuidora XYZ', 'CUIL', '20-12345678-9', 'Centro', '91123-456789', 'info@distribuidoraxyz.com', 1),
    ('Distribuidora ABC', 'DNI', '34567890', 'Calle 123', '93555-123456', 'info@distribuidora123.com', 1),
    ('Distribuidora QWE', 'PASAPORTE', 'AB123456', 'Avenida XYZ', '94444-555555', 'info@distribuidoraqwe.com', 1),
    ('Distribuidora 123', 'CUIL', '27-98765432-1', 'Calle Principal', '97777-888888', 'info@distribuidora456.com', 1);
GO

UPDATE Proveedor
SET Estado = 0
WHERE ProveedorID = 7



-- Insertar Medicamentos
INSERT INTO Producto (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado) VALUES
('123456789012', 'Paracetamol 500mg', 1, 1, 5.00, 10.00, 'Lote123', '2024-01-01', 0, 1, 50, 10, 'Medicamentos', 1),
('987654321098', 'Ibuprofeno 400mg', 1, 2, 8.00, 15.00, 'Lote456', '2024-02-01', 0, 1, 30, 10, 'Medicamentos', 1);

-- Insertar Productos No Médicos
INSERT INTO Producto (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado) VALUES
('111222333444', 'Gaseosa Cola', 2, 2, 1.50, 3.00, 'Lote789', '2025-01-01', 0, 0, 100, 20, 'Producto no médico', 1),
('555666777888', 'Chicles Menta', 2, 1, 0.75, 1.50, 'LoteABC', '2025-02-01', 0, 0, 200, 20, 'Producto no médico', 1);
GO



INSERT INTO Producto (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado) VALUES
('333', 'Helado Menta', 2, 1, 0.75, 1.50, NULL, NULL, 0, 0, 200, 20, 'Producto no médico', 1);

INSERT INTO Producto (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado) VALUES
('55553', 'Penicilina', 3, 1, 0.75, 1.50, 'LoteAB00', '2027-01-01', 0, 0, 200, 20, 'Medicamentos', 1);
