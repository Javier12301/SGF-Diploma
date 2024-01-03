use FarmaciaDatos
GO

-- BASE DE DATOS DE PRODUCTOS

CREATE TABLE CATEGORIA (
    CategoriaID INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(255),
    Estado BIT DEFAULT 1,
);

SET IDENTITY_INSERT CATEGORIA ON;
INSERT INTO CATEGORIA (CategoriaID, Nombre, Descripcion, Estado)
VALUES (0, 'N/A', 'N/A', 1);
SET IDENTITY_INSERT CATEGORIA OFF;
GO

CREATE TABLE PROVEEDOR (
    ProveedorID INT IDENTITY PRIMARY KEY,
    RazonSocial VARCHAR(50),
    TipoDocumento VARCHAR(50) DEFAULT 'DNI',
    Documento VARCHAR(50),
    Direccion VARCHAR(50),
    TelefonoProveedor VARCHAR(20),
    Correo VARCHAR(50),
    Estado BIT DEFAULT 1,
);

SET IDENTITY_INSERT PROVEEDOR ON;
INSERT INTO PROVEEDOR (ProveedorID, RazonSocial, TipoDocumento, Documento, Direccion, TelefonoProveedor, Correo, Estado)
VALUES (0, 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 1);
SET IDENTITY_INSERT PROVEEDOR OFF;
GO

CREATE TABLE CLIENTE (
    ClienteID INT IDENTITY PRIMARY KEY,
    TipoDocumento VARCHAR(50) DEFAULT 'DNI',
    Documento VARCHAR(50),
    NombreCompleto VARCHAR(50),
    TipoClienteID INT REFERENCES TipoCliente(TipoClienteID),
    Correo VARCHAR(50),
    Telefono VARCHAR(50),
    Estado BIT DEFAULT 1,
);
SET IDENTITY_INSERT CLIENTE ON;
-- Insertar para "Consumidor Final" con ClienteID igual a 0
INSERT INTO CLIENTE (ClienteID, TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES (0, 'N/A', 'N/A', 'Consumidor Final', 1, 'N/A', 'N/A', 1);
SET IDENTITY_INSERT CLIENTE OFF;
GO

CREATE TABLE TipoCliente (
    TipoClienteID INT IDENTITY PRIMARY KEY,
    Descripcion VARCHAR(50)
);
INSERT INTO TipoCliente (Descripcion) VALUES ('Consumidor Final');
INSERT INTO TipoCliente (Descripcion) VALUES ('Jubilados');
GO

CREATE TABLE PRODUCTO (
    ProductoID INT IDENTITY PRIMARY KEY,
    CodigoBarras VARCHAR(50) UNIQUE,
    Nombre VARCHAR(50),
    CategoriaID INT REFERENCES CATEGORIA(CategoriaID),
    ProveedorID INT REFERENCES PROVEEDOR(ProveedorID),
    PrecioCompra DECIMAL(10,2),
    PrecioVenta DECIMAL(10,2),
    NumeroLote VARCHAR(50),
    FechaVencimiento DATE, 
    Refrigerado BIT, 
    BajoReceta BIT,
    Stock INT DEFAULT 0,
    CantidadMinima INT,
    TipoProducto VARCHAR(20),
    Estado BIT
);
SET IDENTITY_INSERT CLIENTE ON;
INSERT INTO PRODUCTO (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado)
VALUES ('N/A', 'N/A', 0, 0, 0.0, 0.0, 'N/A', NULL, 0, 0, 0, 0, 'N/A', 1);
SET IDENTITY_INSERT CLIENTE OFF;
GO

-- Compras / Entrada de Inventario
CREATE TABLE COMPRA (
    CompraID INT IDENTITY PRIMARY KEY,
    UsuarioID INT REFERENCES USUARIO(UsuarioID),
    ProveedorID INT REFERENCES PROVEEDOR(ProveedorID),
    TipoDocumento VARCHAR(50),
    NumeroDocumento VARCHAR(50),
    MontoTotal DECIMAL(10,2),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE DETALLE_COMPRA (
    DetalleCompraID INT IDENTITY PRIMARY KEY,
    CompraID INT REFERENCES COMPRA(CompraID),
    ProductoID INT REFERENCES PRODUCTO(ProductoID),
    PrecioCompra DECIMAL(10,2) DEFAULT 0,
    PrecioVenta DECIMAL(10,2) DEFAULT 0,
    Cantidad INT,
    MontoTotal DECIMAL(10,2),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE VENTA (
    VentaID INT IDENTITY PRIMARY KEY,
    UsuarioID INT REFERENCES Usuario(UsuarioID),
    TipoDocumento VARCHAR(50),
    NumeroDocumento VARCHAR(50),
    DocumentoCliente VARCHAR(50),
    NombreCliente VARCHAR(100),
    MontoPago DECIMAL(10,2),
    MontoCambio DECIMAL(10,2),
    MontoTotal DECIMAL(10,2),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE DETALLE_VENTA (
    DetalleVentaID INT IDENTITY PRIMARY KEY,
    VentaID INT REFERENCES VENTA(VentaID),
    ProductoID INT REFERENCES PRODUCTO(ProductoID),
    PrecioVenta DECIMAL(10,2),
    Cantidad INT,
    SubTotal DECIMAL(10,2),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

