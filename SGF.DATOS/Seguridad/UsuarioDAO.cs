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
        public static bool ExisteUsuarioD(string nombreUsuario)
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
        public static bool ExisteUsuarioMailD(string nombreUsuario, string email)
        {
            bool existe = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Usuario WHERE NombreUsuario COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreUsuario AND Email COLLATE SQL_Latin1_General_CP1_CS_AS = @email");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
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
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Nombre = reader["NombreU"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.Email = reader["Email"].ToString();
                                usuario.DNI = Convert.ToInt32(reader["DNI"]);
                                usuario.Estado = Convert.ToBoolean(reader["EstadoU"]);

                                Grupo grupo = new Grupo();
                                grupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                grupo.Descripcion = reader["NombreG"].ToString();
                                grupo.Estado = Convert.ToBoolean(reader["EstadoG"]);

                                usuario.Grupo = grupo;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return usuario;
                }
            }

            return usuario;
        }



        public static List<Modulo> ObtenerModulosPermitidosD(int UsuarioID)
        {
            List<Modulo> modulos = new List<Modulo>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DISTINCT M.Descripcion FROM Permiso p");
                    query.AppendLine("join Grupo Gr ON Gr.GrupoID = p.GrupoID");
                    query.AppendLine("join Accion op on op.AccionID = p.AccionID");
                    query.AppendLine("join Modulo M on M.ModuloID = op.ModuloID");
                    query.AppendLine("join Usuario U on U.GrupoID = p.GrupoID and p.Permitido = 1");
                    query.AppendLine("WHERE U.UsuarioID = @UsuarioID");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                        oContexto.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Modulo modulo = new Modulo();
                                modulo.Descripcion = reader["Descripcion"].ToString();
                                modulo.ListaAcciones = ObtenerAccionesPermitidasD(UsuarioID, modulo.Descripcion);
                                modulos.Add(modulo);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return modulos;
                }
            }
            return modulos;
        }

        public static List<Accion> ObtenerAccionesPermitidasD(int UsuarioID, string moduloDescripcion)
        {
            List<Accion> acciones = new List<Accion>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT op.* FROM Permiso p");
                    query.AppendLine("join Grupo Gr ON Gr.GrupoID = p.GrupoID");
                    query.AppendLine("join Accion op on op.AccionID = p.AccionID");
                    query.AppendLine("join Modulo M on M.ModuloID = op.ModuloID");
                    query.AppendLine("join Usuario U on U.GrupoID = p.GrupoID and p.Permitido = 1");
                    query.AppendLine("WHERE U.UsuarioID = @UsuarioID AND M.Descripcion = @moduloDescripcion");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                        cmd.Parameters.AddWithValue("@moduloDescripcion", moduloDescripcion);
                        oContexto.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Accion accion = new Accion();
                                accion.AccionID = Convert.ToInt32(reader["AccionID"]);
                                accion.Descripcion = reader["Descripcion"].ToString();
                                acciones.Add(accion);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return acciones;
                }
            }
            return acciones;
        }


        //public static List<Modulo> ObtenerPermisosD(int UsuarioID)
        //{

        //    List<Modulo> Permisos = new List<Modulo>();

        //    using (SqlConnection cadena = new SqlConnection(ConexionSGF.cadena))
        //    {
        //        try
        //        {
        //            using (SqlCommand cmd = new SqlCommand("mds_ObtenerPermisos", cadena))
        //            {
        //                cmd.Parameters.AddWithValue("UsuarioID", UsuarioID);
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cadena.Open();


        //                XmlReader leerXML = cmd.ExecuteXmlReader();

        //                while (leerXML.Read())
        //                {

        //                    XDocument doc = XDocument.Load(leerXML);

        //                    if (doc.Element("Permiso") != null)
        //                    {

        //                        Permisos = doc.Element("Permiso").Element("DetalleModulo") == null ? new List<Modulo>() :

        //                                   (from modulo in doc.Element("Permiso").Element("DetalleModulo").Elements("Modulo")
        //                                    select new Modulo()
        //                                    {
        //                                        NombreModulo = modulo.Element("NombreModulo").Value,
        //                                        ListaOpciones = modulo.Element("DetalleOpciones") == null ? new List<Opciones>() :
        //                                        (from opciones in modulo.Element("DetalleOpciones").Elements("Opcion")
        //                                         select new Opciones()
        //                                         {
        //                                             NombreOpcion = opciones.Element("NombreOpcion").Value
        //                                         }
        //                                        ).ToList()
        //                                    }).ToList();
        //                    }
        //                }
        //            }
        //        }
        //        catch(Exception)
        //        {
        //            Permisos = null;
        //        }
        //    }

        //    return Permisos;
        //}

        // Modificar Usuario
        public static bool ModificarUsuarioD(Usuario oUsuario)
        {
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    // Query separada por linea para que no sea tan larga
                    query.AppendLine("UPDATE Usuario SET");
                    query.AppendLine("NombreUsuario = @nombreUsuario, Contraseña = @contraseña,");
                    query.AppendLine("Nombre = @nombre, Apellido = @apellido, Email = @email,");
                    query.AppendLine("DNI = @dni, Estado = @estado");
                    query.AppendLine("WHERE UsuarioID = @usuarioID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario", oUsuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@contraseña", oUsuario.Contraseña);
                        cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
                        cmd.Parameters.AddWithValue("@email", oUsuario.Email);
                        cmd.Parameters.AddWithValue("@dni", oUsuario.DNI);
                        cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                        cmd.Parameters.AddWithValue("@usuarioID", oUsuario.UsuarioID);
                        oContexto.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }




    }

}
