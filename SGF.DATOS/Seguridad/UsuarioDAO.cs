using SGF.MODELO;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SGF.DATOS.Seguridad
{
    public class UsuarioDAO
    {

        // ALTA USUARIO
        public static bool AltaUsuarioD(Usuario usuario)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Usuario (NombreUsuario, Contraseña, Nombre, Apellido, Email, DNI, GrupoID, Estado)");
                    query.AppendLine("VALUES (@nombreUsuario, @contraseña, @nombre, @apellido, @email,");
                    query.AppendLine("@dni, @grupoID, @estado)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@dni", usuario.DNI);
                        cmd.Parameters.AddWithValue("@grupoID", usuario.Grupo.GrupoID);
                        cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        alta = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar registrar el nuevo usuario. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return alta;
        }

        // Modificar Usuario
        public static bool ModificarUsuarioD(Usuario usuario)
        {
            bool modificado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Usuario SET NombreUsuario = @nombreUsuario, Contraseña = @contraseña, Nombre = @nombre, Apellido = @apellido, Email = @email,");
                    query.AppendLine("DNI = @dni, GrupoID = @grupoID, Estado = @estado WHERE UsuarioID = @usuarioID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@contraseña", usuario.Contraseña);
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@dni", usuario.DNI);
                        cmd.Parameters.AddWithValue("@grupoID", usuario.Grupo.GrupoID);
                        cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                        cmd.Parameters.AddWithValue("@usuarioID", usuario.UsuarioID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar modificar el usuario. Por favor, vuelva a intentarlo y, si el problema persiste, pónganse en contacto con el administrador del sistema.");
                }
            }
            return modificado;
        }


        // BAJA USUARIO
        public static bool BajaUsuarioD(int usuarioID)
        {
            bool baja = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Usuario WHERE UsuarioID = @usuarioID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@usuarioID", usuarioID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        baja = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar eliminar el usuario. Por favor, vuelva a intentarlo y si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return baja;
        }

        // Listar
        public static List<Usuario> ListarUsuarioD()
        {
            List<Usuario> oLista = new List<Usuario>();
            try
            {
                using (var oContexto = new SqlConnection(ConexionSGF.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Usuario");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        // Abrimos la conexión
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.Email = reader["Email"].ToString();
                                usuario.DNI = reader["DNI"].ToString();
                                // estado es un bit 1 o 0
                                usuario.Estado = Convert.ToBoolean(reader["Estado"]);
                                oLista.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                oLista = null;
            }
            return oLista;
        }


        // Comprobar si existe un usuario en el sistema
        public static bool ExisteNombreUsuarioD(string nombreUsuario)
        {
            bool existe = false;

            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    // Query sensible a mayúsculas y minúsculas
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        // Abrimos la conexión
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        // si retorna mayor a 0 es porque existe
                        existe = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al verificar si existe el usuario, contactar con el administrador del sistema.");
                }
            }

            return existe;
        }

        // Comprobar si existe un email en el sistema
        public static bool ExisteEmailD(string email)
        {
            bool existe = false;
            using(var oConteexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Usuario WHERE Email COLLATE SQL_Latin1_General_CP1_CS_AS = @email");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oConteexto))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        oConteexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        // si retorna mayor a 0 es porque existe
                        existe = count > 0;
                    }

                }
                catch (Exception)
                {
                    return existe;
                }
            }
            return existe;
        }


        // Comprobar si el usuario ingresado tiene el email ingresado
        public static bool ExisteUsuarioConEmailD(string nombreUsuario, string email)
        {
            bool existe = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Usuario");
                    query.AppendLine("WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario");
                    query.AppendLine("AND Email COLLATE SQL_Latin1_General_CP1_CS_AS = @email");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        cmd.Parameters.AddWithValue("@email", email);
                        oContexto.Open();
                        int count = (int)cmd.ExecuteScalar();
                        existe = (count > 0);
                    }
                }
                catch (Exception)
                {
                    return existe;
                }
            }
            return existe;
        }


        // Obtener un usuario
        public static Usuario ObtenerUsuarioD(string nombreUsuario)
        {
            Usuario usuario = null;

            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT U.UsuarioID, U.NombreUsuario, U.Contraseña, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU,");
                    query.AppendLine("G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG");
                    query.AppendLine("FROM Usuario U");
                    query.AppendLine("INNER JOIN Grupo G ON U.GrupoID = G.GrupoID");
                    query.AppendLine("WHERE U.NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        oContexto.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Nombre = reader["NombreU"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.Email = reader["Email"].ToString();
                                usuario.DNI = reader["DNI"].ToString();
                                usuario.Estado = Convert.ToBoolean(reader["EstadoU"]);

                                Grupo grupo = new Grupo();
                                grupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                grupo.Nombre = reader["NombreG"].ToString();
                                grupo.Estado = Convert.ToBoolean(reader["EstadoG"]);

                                usuario.Grupo = grupo;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el usuario, contactar con el administrador del sistema.");
                }
            }

            return usuario;
        }

        // Obtener usuario por ID
        public static Usuario ObtenerUsuarioPorIDD(int usuarioID)
        {
            Usuario oUsuario = new Usuario();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT U.UsuarioID, U.NombreUsuario, U.Contraseña, U.Nombre AS NombreU, U.Apellido, U.Email, U.DNI, U.GrupoID, U.Estado AS EstadoU,");
                    query.AppendLine("G.GrupoID, G.Nombre AS NombreG, G.Estado AS EstadoG");
                    query.AppendLine("FROM Usuario U");
                    query.AppendLine("INNER JOIN Grupo G ON U.GrupoID = G.GrupoID");
                    query.AppendLine("WHERE U.UsuarioID = @usuarioID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@usuarioID", usuarioID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oUsuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                oUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                oUsuario.Contraseña = reader["Contraseña"].ToString();
                                oUsuario.Nombre = reader["NombreU"].ToString();
                                oUsuario.Apellido = reader["Apellido"].ToString();
                                oUsuario.Email = reader["Email"].ToString();
                                oUsuario.DNI = reader["DNI"].ToString();
                                oUsuario.Estado = Convert.ToBoolean(reader["EstadoU"]);

                                Grupo grupo = new Grupo();
                                grupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                grupo.Nombre = reader["NombreG"].ToString();
                                grupo.Estado = Convert.ToBoolean(reader["EstadoG"]);

                                oUsuario.Grupo = grupo;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el usuario, contactar con el administrador del sistema.");
                }
            }
            return oUsuario;
        }

    }

}
