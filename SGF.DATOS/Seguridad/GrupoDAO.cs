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
    }
}
