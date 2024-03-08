use FarmaciaDatos
go

-- Grupo Principal
INSERT INTO Grupo(Nombre, Estado)
VALUES ('Administrador', 1);

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Gestor de inventario', 1)


INSERT INTO Usuario (NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)
VALUES ('Admin', 'd460dfcbf4789d0b8652dbf847b15ab1b58ca70d96869efd186f7fc08d4a7b47', 'Admin', '-', 'javierramirez1230123@gmail.com', NULL, 1, 1);

-- Insertar módulos
INSERT INTO Modulo(Descripcion)
VALUES 
    ('formVentas'),
    ('formClientes'),
    ('formProductos'),
    ('formCategorias'),
    ('formProveedores'),
    ('formInventario'),
	('formDetallesInventario'),
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
    ('Exportar', 2),
	('Imprimir', 2);

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

INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
('Imprimir', 6)

-- Insertar las acciones para el módulo formDetallesInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES
	('Imprimir', 7),
	('Cancelar', 7);

-- Insertar las acciones para el módulo formRegistros
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Generar registro', 8),
    ('Exportar', 8),
	('Baja', 8);

-- Insertar las acciones para el módulo formReportes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Inventario', 9),
    ('Ventas', 9),
    ('Clientes', 9);

-- Insertar las acciones para el módulo formReporteInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Existencias de inventario', 10),
    ('Resumen de inventario', 10),
    ('Exportar', 10),
	('Imprimir', 10),
	('Gráfico', 10);

-- Insertar las acciones para el módulo formReporteVentas
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Ventas', 11),
    ('Ventas por clientes', 11),
    ('Exportar', 11),
	('Imprimir', 11),
	('Gráfico', 11);


-- Insertar las acciones para el módulo formReporteClientes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Pagos de clientes', 12),
    ('Cuentas por cobrar', 12),
    ('Exportar', 12),
	('Imprimir', 12);


-- Insertar las acciones para el módulo formAjustes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Perfiles', 13),
    ('Datos de negocio', 13),
    ('Gestionar base de datos', 13),
    ('Otras configuraciones', 13);

-- Insertar las acciones para el módulo formPerfiles
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Usuarios', 14),
    ('Grupos', 14),
    ('Auditoria', 14),
    ('Mis datos', 14);
-- Insertar las acciones para el módulo formUsuarios
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 15),
    ('Modificar', 15),
    ('Baja', 15),
    ('Exportar', 15);

-- Insertar las acciones para el módulo formGrupos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', 16),
    ('Modificar', 16),
    ('Baja', 16),
    ('Exportar', 16);

-- Insertar las acciones para el módulo formAuditoria
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Generar auditoria', 17),
	   ('Gráfico', 17),
       ('Exportar', 17);

-- Insertar las acciones para el módulo formMisDatos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Permitir acceso', 18);
GO

-- Inserta los permisos para el grupo de administradores
INSERT INTO Permiso (GrupoID, AccionID, Permitido)
SELECT 1, AccionID, 1
FROM Accion;


-- Insertar Compra y Detalles
INSERT INTO Compra (UsuarioID, ProveedorID, Factura, Estado)
VALUES 
(1, 1, 'Boleta', 1),
(1, 2, 'Boleta', 1),
(1, 2, 'Factura', 1),
(1, 1, 'Factura', 1);

INSERT INTO Detalle_Compra (CompraID, ProductoID, PrecioCompra, Cantidad)
VALUES 
(1, 1, 10.00, 5),
(2, 2, 15.00, 4),
(3, 6, 20.00, 3),
(4, 8, 25.00, 2);

-- NEGOCIO INSERTAR DATOS
-- Insertar Monedas
INSERT INTO Moneda (Nombre, Simbolo, Posicion) VALUES ('Peso Argentino', '$', 'Antes');
INSERT INTO Moneda (Nombre, Simbolo, Posicion) VALUES ('Dólar', '$', 'Antes');
INSERT INTO Moneda (Nombre, Simbolo, Posicion) VALUES ('Euro', '€', 'Antes');
GO

-- Insertar Impuestos
INSERT INTO Impuesto (Nombre, Porcentaje) VALUES ('IVA', 21);
GO

-- Insertar datos de negocio
INSERT INTO Negocio (Nombre, TipoDocumento, Documento, Direccion, Telefono, Correo, Impuestos, MonedaID, ImpuestoID) 
VALUES ('Sistema de gestión farmacéutica', 'CUIT/CUIL', '20-44608055-6', 'Hertz 4237', '3855219032', 'javi@gmail.com', 0, 1, 1);
GO


--- --- --- ---- --- ---- FIN DE INSERCIÓN DE DATOS UTILES -- --- --- --- 



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
GO

-- NEGOCIO TESTING

-- Clientes
INSERT INTO TipoCliente (Descripcion) VALUES ('Pensionados');
INSERT INTO TipoCliente (Descripcion) VALUES ('Obrero');
INSERT INTO TipoCliente (Descripcion) VALUES ('Socio');

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES ('DNI', '12345678', 'Francisco', (SELECT TipoClienteID FROM TipoCliente WHERE Descripcion = 'Pensionados'), 'francisco@mail.com', '123456789', 1);

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES ('DNI', '23456789', 'Ernesto', (SELECT TipoClienteID FROM TipoCliente WHERE Descripcion = 'Obrero'), 'ernesto@mail.com', '234567890', 1);

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES ('DNI', '34567890', 'Marcelo', (SELECT TipoClienteID FROM TipoCliente WHERE Descripcion = 'Socio'), 'marcelo@mail.com', '345678901', 1);

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES ('DNI', '45678901', 'Roberto', 2, 'roberto@mail.com', '456789012', 1);

INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES ('DNI', '56789012', 'Franco', (SELECT TipoClienteID FROM TipoCliente WHERE Descripcion = 'Pensionados'), 'franco@mail.com', '567890123', 1);
GO

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

