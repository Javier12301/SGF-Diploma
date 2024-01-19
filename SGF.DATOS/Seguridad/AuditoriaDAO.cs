using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
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
                    query.AppendLine("INSERT INTO Auditoria (FechayHora, Movimiento, NombreUsuario, Descripcion)");
                    query.AppendLine("VALUES (@FechayHora, @Movimiento, @NombreUsuario, @Descripcion)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@FechayHora", auditoria.FechayHora);
                        cmd.Parameters.AddWithValue("@Movimiento", auditoria.Movimiento);
                        cmd.Parameters.AddWithValue("@NombreUsuario", auditoria.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Descripcion", auditoria.Descripcion);
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
                    query.AppendLine("SELECT DISTINCT Movimiento, NombreUsuario FROM Auditoria");
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

    }
}
