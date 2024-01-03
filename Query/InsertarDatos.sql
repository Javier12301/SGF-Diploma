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

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Administrador', 1);

INSERT INTO Grupo(Nombre, Estado)
VALUES ('Gestor de inventario', 1)

select * from Grupo
-- Insertar el usuario Admin
INSERT INTO Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)
VALUES ('Admin', 'D460DFCBF4789D0B8652DBF847B15AB1B58CA70D96869EFD186F7FC08D4A7B47', 'admin', 'admin', 'javierramirez1230123@gmail.com', 12345678, 1, 1);

INSERT INTO Usuario(NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)
VALUES ('Javier12301', 'D460DFCBF4789D0B8652DBF847B15AB1B58CA70D96869EFD186F7FC08D4A7B47', 'Javi', 'Ramirez', 'javieralejandro12301@gmail.com', 12345678, 2, 1);
-- Insertar el módulo formProductos
INSERT INTO Modulo(Descripcion)
VALUES ('formVentas'),
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
VALUES ('Historial de ventas', 1),
       ('Buscar clientes', 1),
       ('Vender medicamentos', 1),
       ('Dar credito', 1),
       ('Vender producto general', 1);

-- Insertar las acciones para el módulo formProductos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Alta', 2),
       ('Modificar', 2),
       ('Baja', 2),
       ('Importar', 2),
       ('Exportar', 2);

-- Insertar las acciones para el módulo formCategorias
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Alta', 3),
       ('Modificar', 3),
       ('Baja', 3);

-- Insertar las acciones para el módulo formProveedores
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Alta', 4),
       ('Modificar', 4),
       ('Baja', 4),
       ('Importar', 4),
       ('Exportar', 4);

-- Insertar las acciones para el módulo formInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Entrada', 5),
       ('Salida', 5),
       ('Exportar', 5);

-- Insertar las acciones para el módulo formRegistros
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Generar registro', 6),
       ('Exportar', 6);

-- Insertar las acciones para el módulo formReportes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Inventario', 7),
       ('Ventas', 7),
       ('Clientes', 7);

-- Insertar las acciones para el módulo formReporteInventario
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Existencias de inventario', 8),
       ('Entradas de inventario', 8),
       ('Salidas de inventario', 8),
       ('Medicamentos por vencer', 8),
       ('Exportar', 8);

-- Insertar las acciones para el módulo formReporteVentas
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Ventas', 9),
       ('Ventas por clientes', 9),
       ('Exportar', 9);

-- Insertar las acciones para el módulo formReporteClientes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Pagos de clientes', 10),
       ('Cuentas por cobrar', 10),
       ('Exportar', 10);

-- Insertar las acciones para el módulo formAjustes
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Perfiles', 11),
       ('Datos de negocio', 11),
       ('Gestionar base de datos', 11),
       ('Otras configuraciones', 11);

-- Insertar las acciones para el módulo formPerfiles
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Usuarios', 12),
       ('Grupos', 12),
       ('Auditoria', 12),
       ('Mis datos', 12);

-- Insertar las acciones para el módulo formUsuarios
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Alta', 13),
       ('Modificar', 13),
       ('Baja', 13),
       ('Exportar', 13);

-- Insertar las acciones para el módulo formGrupos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Alta', 14),
       ('Modificar', 14),
       ('Baja', 14),
       ('Exportar', 14);

-- Insertar las acciones para el módulo formAuditoria
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Generar auditoria', 15),
       ('Exportar', 15);

-- Insertar las acciones para el módulo formMisDatos
INSERT INTO Accion(Descripcion, ModuloID)
VALUES ('Permitir acceso', 16);
GO

-- Inserta los permisos para el grupo de administradores
INSERT INTO Permiso (GrupoID, AccionID, Permitido)
SELECT 1, AccionID, 1
FROM Accion
WHERE ModuloID NOT IN 
    ((SELECT ModuloID FROM Modulo WHERE Descripcion = 'formRegistros'),
    (SELECT ModuloID FROM Modulo WHERE Descripcion = 'formReportes'));

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