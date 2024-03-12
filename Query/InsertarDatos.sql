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
    ('formReporteResumenTotal'),
    ('formAjustes'),
    ('formPerfiles'),
    ('formUsuarios'),
    ('formGrupos'),
    ('formAuditoria'),
    ('formMisDatos');

	select * from Accion
	where ModuloID = 11

-- Insertar las acciones para el módulo formVentas
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Historial', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formVentas')),
    ('Buscar clientes', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formVentas')),
    ('Detalles', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formVentas')),
    ('Cobrar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formVentas'));

-- Insertar las acciones para el módulo formClientes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes')),
    ('Importar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes')),
    ('Imprimir', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formClientes'));

-- Insertar las acciones para el módulo formProductos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProductos')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProductos')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProductos')),
    ('Importar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProductos')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProductos'));

-- Insertar las acciones para el módulo formCategorias
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formCategorias')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formCategorias')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formCategorias'));

-- Insertar las acciones para el módulo formProveedores
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProveedores')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProveedores')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProveedores')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formProveedores'));

-- Insertar las acciones para el módulo formInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Entrada', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formInventario')),
    ('Salida', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formInventario')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formInventario')),
    ('Imprimir', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formInventario'));

-- Insertar las acciones para el módulo formDetallesInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES
    ('Imprimir', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formDetallesInventario')),
    ('Cancelar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formDetallesInventario'));

-- Insertar las acciones para el módulo formRegistros
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Generar registro', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formRegistros')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formRegistros')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formRegistros'));

-- Insertar las acciones para el módulo formReportes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Inventario', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReportes')),
    ('Resumen total', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReportes')),
    ('Clientes', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReportes'));

select * from accion
where ModuloID = 9

update Accion
set Descripcion = 'Resumen total'
where AccionID = 33

select * from Modulo

-- Insertar las acciones para el módulo formReporteInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Existencias de inventario', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteInventario')),
    ('Resumen de inventario', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteInventario')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteInventario')),
    ('Imprimir', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteInventario')),
    ('Gráfico', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteInventario'));

-- INSERTAR ACCIONES PARA MODULO formReporteResumenTotal
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Permitir acceso', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteResumenTotal')),
    ('Imprimir', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReporteResumenTotal'));

-- Insertar las acciones para el módulo formAjustes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Perfiles', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAjustes')),
    ('Datos de negocio', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAjustes')),
    ('Gestionar base de datos', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAjustes')),
    ('Otras configuraciones', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAjustes'));

-- Insertar las acciones para el módulo formPerfiles
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Usuarios', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formPerfiles')),
    ('Grupos', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formPerfiles')),
    ('Auditoria', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formPerfiles')),
    ('Mis datos', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formPerfiles'));

-- Insertar las acciones para el módulo formUsuarios
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formUsuarios')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formUsuarios')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formUsuarios')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formUsuarios'));

-- Insertar las acciones para el módulo formGrupos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Alta', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formGrupos')),
    ('Modificar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formGrupos')),
    ('Baja', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formGrupos')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formGrupos'));

-- Insertar las acciones para el módulo formAuditoria
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Generar auditoria', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAuditoria')),
    ('Gráfico', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAuditoria')),
    ('Exportar', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAuditoria')),

	INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
	    ('Detalles', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formAuditoria'));



-- Insertar las acciones para el módulo formMisDatos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES 
    ('Permitir acceso', (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formMisDatos'));


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


CREATE TABLE Compra (
    CompraID INT IDENTITY PRIMARY KEY,
    UsuarioID INT REFERENCES Usuario(UsuarioID),
    ProveedorID INT REFERENCES Proveedor(ProveedorID),
    Factura VARCHAR(50),
    FechaCompra DATETIME DEFAULT GETDATE(),
	Estado BIT
);
GO

CREATE TABLE Detalle_Compra (
    DetalleCompraID INT IDENTITY PRIMARY KEY,
    CompraID INT REFERENCES Compra(CompraID),
    ProductoID INT REFERENCES Producto(ProductoID),
    PrecioCompra DECIMAL(10,2) DEFAULT 0,
    Cantidad INT,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO