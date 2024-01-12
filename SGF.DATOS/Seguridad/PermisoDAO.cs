using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class PermisoDAO
    {
        public static bool AltaPermisoD(Permiso permiso)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Permiso (GrupoID, AccionID, Permitido) VALUES (@grupoID, @accionID, @permitido)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", permiso.Grupo.GrupoID);
                        cmd.Parameters.AddWithValue("@accionID", permiso.Accion.AccionID);
                        cmd.Parameters.AddWithValue("@permitido", permiso.Permitido);
                        oContexto.Open();
                        int filaAfectada = cmd.ExecuteNonQuery();
                        alta = filaAfectada > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar registrar el nuevo permiso. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return alta;
        }

        public static List<Permiso> ObtenerListaPermisosActivosD(int grupoID)
        {
            List<Permiso> permisosActivos = new List<Permiso>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.PermisoID, P.GrupoID, P.AccionID, P.Permitido, A.ModuloID FROM Permiso P");
                    query.AppendLine("JOIN Accion A ON P.AccionID = A.AccionID");
                    query.AppendLine("WHERE P.GrupoID = @grupoID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", grupoID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Permiso permiso = new Permiso();
                                Grupo grupo = new Grupo();
                                grupo.GrupoID = Convert.ToInt32(reader["GrupoID"]);
                                permiso.Grupo = grupo;
                                Accion accion = new Accion();
                                accion.AccionID = Convert.ToInt32(reader["AccionID"]);
                                permiso.Accion = accion;
                                permiso.Permitido = Convert.ToBoolean(reader["Permitido"]);
                                Modulo modulo = new Modulo();
                                modulo.ModuloID = Convert.ToInt32(reader["ModuloID"]);
                                permiso.Modulo = modulo;
                                permisosActivos.Add(permiso);
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener los permisos activos. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return permisosActivos;
        }

        public static bool DesactivarPermisosD(int grupoID)
        {
            bool desactivado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Permiso");
                    query.AppendLine("WHERE GrupoID = @grupoID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("grupoID", grupoID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        desactivado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar desactivar los permisos. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return desactivado;
        }

        public static bool GrupoTienePermisosD(int grupoID)
        {
            bool tienePermisos = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) AS Permisos");
                    query.AppendLine("FROM Permiso");
                    query.AppendLine("WHERE GrupoID = @grupoID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("grupoID", grupoID);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        tienePermisos = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar comprobar si el grupo tiene permisos asignados. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return tienePermisos;
        }


        public static bool EstadoPermisoD(Permiso oPermiso)
        {
            bool estado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) AS Permitido");
                    query.AppendLine("FROM Permiso");
                    query.AppendLine("WHERE GrupoID = @grupoID AND AccionID = @accionID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", oPermiso.Grupo.GrupoID);
                        cmd.Parameters.AddWithValue("@accionID", oPermiso.Accion.AccionID);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        estado = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener el estado del permiso. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return estado;
        }



    }
}
