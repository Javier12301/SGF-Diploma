use FarmaciaDatos
GO

-- BASE DE DATOS DE PRODUCTOS
CREATE TABLE Categoria (
    CategoriaID INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(255),
    Estado BIT DEFAULT 1,
);

SET IDENTITY_INSERT Categoria ON;
INSERT INTO Categoria (CategoriaID, Nombre, Descripcion, Estado)
VALUES (0, 'N/A', 'N/A', 0);
SET IDENTITY_INSERT Categoria OFF;
GO

CREATE TABLE Proveedor (
    ProveedorID INT IDENTITY PRIMARY KEY,
    RazonSocial VARCHAR(50),
    TipoDocumento VARCHAR(50) DEFAULT 'DNI',
    Documento VARCHAR(50),
    Direccion VARCHAR(50),
    TelefonoProveedor VARCHAR(20),
    Correo VARCHAR(50),
    Estado BIT DEFAULT 1,
);


SET IDENTITY_INSERT Proveedor ON;
INSERT INTO Proveedor (ProveedorID, RazonSocial, TipoDocumento, Documento, Direccion, TelefonoProveedor, Correo, Estado)
VALUES (0, 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 'N/A', 0);
SET IDENTITY_INSERT Proveedor OFF;
GO

CREATE TABLE Cliente (
    ClienteID INT IDENTITY PRIMARY KEY,
    TipoDocumento VARCHAR(50) DEFAULT 'DNI',
    Documento VARCHAR(50),
    NombreCompleto VARCHAR(50),
    TipoClienteID INT REFERENCES TipoCliente(TipoClienteID),
    Correo VARCHAR(50),
    Telefono VARCHAR(50),
    Estado BIT DEFAULT 1,
);
SET IDENTITY_INSERT Cliente ON;
-- Insertar para "Consumidor Final" con ClienteID igual a 0
INSERT INTO Cliente (ClienteID, TipoDocumento, Documento, NombreCompleto, TipoClienteID, Correo, Telefono, Estado)
VALUES (0, 'N/A', 'N/A', 'Consumidor Final', 1, 'N/A', 'N/A', 0);
SET IDENTITY_INSERT Cliente OFF;
GO

CREATE TABLE TipoCliente (
    TipoClienteID INT IDENTITY PRIMARY KEY,
    Descripcion VARCHAR(50)
);
INSERT INTO TipoCliente (Descripcion) VALUES ('Consumidor Final');
INSERT INTO TipoCliente (Descripcion) VALUES ('Jubilados');
GO


CREATE TABLE Producto (
    ProductoID INT IDENTITY PRIMARY KEY,
    CodigoBarras VARCHAR(50) UNIQUE,
    Nombre VARCHAR(50),
    CategoriaID INT REFERENCES Categoria(CategoriaID),
    ProveedorID INT REFERENCES Proveedor(ProveedorID),
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
GO

--Registros de movimientos en el sistema
CREATE TABLE Registro (
	RegistrosID INT IDENTITY(1,1) PRIMARY KEY,
	FechayHora DATETIME,
	Movimiento NVARCHAR(255),
	NombreUsuario NVARCHAR(255),
	Cantidad INT,
	CantidadAntes INT,
	CantidadDespues INT,
	Modulo NVARCHAR(255),
	Descripcion NVARCHAR(255)
);
GO

CREATE TABLE Compra (
    CompraID INT IDENTITY PRIMARY KEY,
    UsuarioID INT REFERENCES USUARIO(UsuarioID),
    ProveedorID INT REFERENCES PROVEEDOR(ProveedorID),
    Factura VARCHAR(50),
    FechaCompra DATETIME DEFAULT GETDATE(),
	Estado BIT
);
GO


CREATE TABLE Detalle_Compra (
    DetalleCompraID INT IDENTITY PRIMARY KEY,
    CompraID INT REFERENCES COMPRA(CompraID),
    ProductoID INT REFERENCES PRODUCTO(ProductoID),
    PrecioCompra DECIMAL(10,2) DEFAULT 0,
    Cantidad INT,
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO



CREATE TABLE Venta (
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

CREATE TABLE Detalle_Venta (
    DetalleVentaID INT IDENTITY PRIMARY KEY,
    VentaID INT REFERENCES VENTA(VentaID),
    ProductoID INT REFERENCES PRODUCTO(ProductoID),
    PrecioVenta DECIMAL(10,2),
    Cantidad INT,
    SubTotal DECIMAL(10,2),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO


CREATE TABLE Moneda(
	MonedaID INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(60),
	Simbolo VARCHAR(60),
	-- Antes o Después
	Posicion VARCHAR(20)
);
GO

CREATE TABLE Impuesto(
	ImpuestoID INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(60),
	Porcentaje DECIMAL(10,2)
);
GO

CREATE TABLE Negocio(
	NegocioID INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(60),
    TipoDocumento VARCHAR(60) DEFAULT 'DNI',
	Documento VARCHAR(60),
	Direccion VARCHAR(60),
	Telefono VARCHAR(60),
	Correo VARCHAR(60),
	Impuestos BIT,
	Logo VARBINARY(max) NULL,
    MonedaID INT FOREIGN KEY REFERENCES Moneda(MonedaID),
    ImpuestoID INT FOREIGN KEY REFERENCES Impuesto(ImpuestoID)
);
GO

SELECT * FROM Negocio
