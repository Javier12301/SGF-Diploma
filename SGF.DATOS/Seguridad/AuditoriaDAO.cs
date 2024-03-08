using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class AuditoriaDAO
    {
        public static bool RegistrarMovimiento(Auditoria auditoria)
        {
            try
            {
                // Registramos la auditoria
                using (var oContexto = new SqlConnection(ConexionSGF.cadena))
                {
                    // En esta lógica se creara cualquier movimiento del usuario
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Auditoria (FechayHora, Movimiento, Modulo, NombreUsuario, Descripcion, Detalles)");
                    query.AppendLine("VALUES (@FechayHora, @Movimiento, @Modulo, @NombreUsuario, @Descripcion, @Detalles)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@FechayHora", auditoria.FechayHora);
                        cmd.Parameters.AddWithValue("@Movimiento", auditoria.Movimiento);
                        cmd.Parameters.AddWithValue("@Modulo", auditoria.Modulo);
                        cmd.Parameters.AddWithValue("@NombreUsuario", auditoria.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Descripcion", auditoria.Descripcion);
                        // si auditoria.Detalles es null, se asignará un valor por defecto "-"
                        if (auditoria.Detalles == null)
                        {
                            cmd.Parameters.AddWithValue("@Detalles", "-");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Detalles", auditoria.Detalles);
                        }
                        oContexto.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public static List<Auditoria> ObtenerListaAuditoriaD()
        {
            List<Auditoria> oLista = new List<Auditoria>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DISTINCT Movimiento, NombreUsuario, Modulo FROM Auditoria");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Auditoria auditoria = new Auditoria();
                                auditoria.Movimiento = reader["Movimiento"].ToString();
                                auditoria.NombreUsuario = reader["NombreUsuario"].ToString();
                                auditoria.Modulo = reader["Modulo"].ToString();
                                oLista.Add(auditoria);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al generar la Auditoria, por favor contacte al administrador para solucionar este error.");
                }
            }
            return oLista;
        }

        public static DataTable ObtenerMovimientosD(string usuario, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT Movimiento, COUNT(*) as Cantidad FROM Auditoria WHERE ");
                query.AppendLine("(@FiltroUsuario = 'Todos' OR NombreUsuario = @FiltroUsuario) AND ");
                query.AppendLine("(@FechaInicio IS NULL OR FechayHora >= @FechaInicio) AND ");
                query.AppendLine("(@FechaFin IS NULL OR FechayHora <= @FechaFin) ");
                query.AppendLine("GROUP BY Movimiento ORDER BY Cantidad DESC");
                using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                {
                    cmd.Parameters.AddWithValue("@FiltroUsuario", usuario);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    oContexto.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static Auditoria ObtenerAuditoriaIDD(int auditoriaID)
        {
            Auditoria auditoria = new Auditoria();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Auditoria WHERE AuditoriaID = @AuditoriaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@AuditoriaID", auditoriaID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                auditoria.AuditoriaID = Convert.ToInt32(reader["AuditoriaID"]);
                                auditoria.FechayHora = Convert.ToDateTime(reader["FechayHora"]);
                                auditoria.Movimiento = reader["Movimiento"].ToString();
                                auditoria.Modulo = reader["Modulo"].ToString();
                                auditoria.NombreUsuario = reader["NombreUsuario"].ToString();
                                auditoria.Descripcion = reader["Descripcion"].ToString();
                                auditoria.Detalles = reader["Detalles"].ToString();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener la auditoría, por favor contacte al administrador para solucionar este error.");
                }
            }
            return auditoria;
        }
    }
}
