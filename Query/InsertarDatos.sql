use FarmaciaDatos
go

INSERT INTO Usuario(UsuarioID, NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, Estado)
VALUES (1, 'Admin', 'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 'admin', 'admin', 'admin@gmail.com', 12345678, 1);
go

SELECT * FROM Usuario;

SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = 'admin' OR Email COLLATE SQL_Latin1_General_CP1_CS_AS = 'admin@gmail.com'