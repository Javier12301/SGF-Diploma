using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class GrupoDAO
    {

        // Alta Grupo
        public static bool AltaGrupoD(Grupo oGrupo)
        {
            bool alta = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Grupo (Nombre, Estado) VALUES (@nombre, @estado)");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oGrupo.Nombre);
                        cmd.Parameters.AddWithValue("@estado", oGrupo.Estado);
                        oContexto.Open();
                        int filaAfectada = cmd.ExecuteNonQuery();
                        alta = filaAfectada > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar registrar el nuevo grupo. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return alta;
        }

        // Modificar Grupo
        public static bool ModificarGrupoD(Grupo oGrupo)
        {
            bool modificado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Grupo SET Nombre = @nombre, Estado = @estado WHERE GrupoID = @grupoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oGrupo.Nombre);
                        cmd.Parameters.AddWithValue("@estado", oGrupo.Estado);
                        cmd.Parameters.AddWithValue("@grupoID", oGrupo.GrupoID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar modificar el grupo. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return modificado;
        }

        // Obtener lista de grupos existentes
        public static List<Grupo> ListarGruposD()
        {
            List<Grupo> oLista = new List<Grupo>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Grupo");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grupo grupo = new Grupo();
                                grupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                grupo.Nombre = reader["Nombre"].ToString();
                                grupo.Estado = Convert.ToBoolean(reader["Estado"]);
                                oLista.Add(grupo);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Error al listar los grupos, contactar con el administrador del sistema.");
                }
            }
            return oLista;
        }

        // Comprobar si grupo tiene usuarios
        public static bool GrupoTieneUsuariosD(int grupoID)
        {
            bool tieneUsuarios = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(U.UsuarioID) AS Cantidad");
                    query.AppendLine("FROM Grupo G");
                    query.AppendLine("LEFT JOIN Usuario U ON G.GrupoID = U.GrupoID");
                    query.AppendLine("WHERE G.GrupoID = @grupoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", grupoID);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        tieneUsuarios = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al comprobar si el grupo tiene usuarios, contactar con el administrador del sistema.");
                }
            }
            return tieneUsuarios;
        }

        // Existe grupo
        public static bool ExisteGrupoD(string nombreGrupo)
        {
            bool existe = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Grupo WHERE Nombre COLLATE SQL_Latin1_General_CP1_CS_AS = @nombreGrupo");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        existe = count > 0;
                    }
                }catch(Exception)
                {
                    throw new Exception("Error al verificar si existe el grupo, contactar con el administrador del sistema.");
                }
            }
            return existe;
        }

        public static List<Modulo> ObtenerModulosPermitidosD(int GrupoID)
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
                    query.AppendLine("WHERE Gr.GrupoID = @GrupoID AND p.Permitido = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@GrupoID", GrupoID);
                        oContexto.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Modulo modulo = new Modulo();
                                modulo.Descripcion = reader["Descripcion"].ToString();
                                modulo.ListaAcciones = ObtenerAccionesPermitidasD(GrupoID, modulo.Descripcion);
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

        public static List<Accion> ObtenerAccionesPermitidasD(int GrupoID, string moduloDescripcion)
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
                    query.AppendLine("WHERE Gr.GrupoID = @GrupoID AND M.Descripcion = @moduloDescripcion AND p.Permitido = 1");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@GrupoID", GrupoID);
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


        // Obtener grupo por Nombre
        public static Grupo ObtenerGrupoNombreD(string nombre)
        {
            Grupo oGrupo = new Grupo();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Grupo WHERE Nombre = @nombre");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oGrupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                oGrupo.Nombre = reader["Nombre"].ToString();
                                oGrupo.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }catch(Exception)
                {
                    throw new Exception("Error al obtener el grupo, contactar con el administrador del sistema.");
                }
            }
            return oGrupo;
        }

        public static Grupo ObtenerGrupoPorIDD(int grupoID)
        {
            Grupo oGrupo = new Grupo();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Grupo WHERE GrupoID = @grupoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", grupoID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oGrupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                oGrupo.Nombre = reader["Nombre"].ToString();
                                oGrupo.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el grupo, contactar con el administrador del sistema.");
                }
            }
            return oGrupo;
        }
    }
}
