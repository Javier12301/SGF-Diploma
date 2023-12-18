using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class D_Usuario
    {

        // Listar
        public List<Usuario> ListarUsuarioD()
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
                                usuario.DNI = Convert.ToInt32(reader["DNI"]);
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


        // Comprobar si existe un usuario
        public bool ExisteUsuarioD(string nombreUsuario)
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
                    return existe;
                }
            }

            return existe;
        }

        // Comprobar si existe usuario y email ingresado
        public bool Existe_Usuario_MailD(string nombreUsuario, string email)
        {
            bool existe = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario OR Email COLLATE SQL_Latin1_General_CP1_CS_AS = @email");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        cmd.Parameters.AddWithValue("@email", email);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
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

        // Obtener un usuario
        public Usuario ObtenerUsuarioD(string nombreUsuario)
        {
            Usuario usuario = null;

            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.Email = reader["Email"].ToString();
                                usuario.DNI = Convert.ToInt32(reader["DNI"]);
                                usuario.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // Manejar excepción
                }
            }

            return usuario;
        }




    }

}
