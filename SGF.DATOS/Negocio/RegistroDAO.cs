using SGF.MODELO.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class RegistroDAO
    {
        // Conteo de registros
        public static int ConteoRegistrosD()
        {
            int conteo = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT COUNT(*) FROM Registro");
                using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                {
                    oContexto.Open();
                    conteo = (int)cmd.ExecuteScalar();
                }
            }
            return conteo;
        }

        public static bool RegistrarMovimiento(Registro registro)
        {
            bool registroRealizado = false;
            try
            {
                using(var oContexto = new SqlConnection(ConexionSGF.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Registro (FechayHora, Movimiento, NombreUsuario, Cantidad, CantidadAntes, CantidadDespues, Modulo ,Descripcion)");
                    query.AppendLine("VALUES (@FechayHora, @Movimiento, @NombreUsuario, @Cantidad, @CantidadAntes, @CantidadDespues, @ModuloUsado ,@Descripcion)");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@FechayHora", registro.FechayHora);
                        cmd.Parameters.AddWithValue("@Movimiento", registro.Movimiento);
                        cmd.Parameters.AddWithValue("@NombreUsuario", registro.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Cantidad", registro.Cantidad);
                        cmd.Parameters.AddWithValue("@CantidadAntes", registro.CantidadAntes);
                        cmd.Parameters.AddWithValue("@CantidadDespues", registro.CantidadDespues);
                        cmd.Parameters.AddWithValue("@ModuloUsado", registro.ModuloUsado);
                        cmd.Parameters.AddWithValue("@Descripcion", registro.Descripcion);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        registroRealizado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return registroRealizado;
        }

        // lista de registro
        public static List<Registro> ListarRegistrosD()
        {
            List<Registro> listaRegistro = new List<Registro>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT * FROM Registro");
                using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                {
                    oContexto.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registro oRegistro = new Registro();
                            oRegistro.RegistroID = Convert.ToInt32(reader["RegistrosID"]);
                            oRegistro.FechayHora = Convert.ToDateTime(reader["FechayHora"]);
                            oRegistro.Movimiento = reader["Movimiento"].ToString();
                            oRegistro.NombreUsuario = reader["NombreUsuario"].ToString();
                            oRegistro.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            oRegistro.CantidadAntes = Convert.ToInt32(reader["CantidadAntes"]);
                            oRegistro.CantidadDespues = Convert.ToInt32(reader["CantidadDespues"]);
                            oRegistro.ModuloUsado = reader["Modulo"].ToString();
                            oRegistro.Descripcion = reader["Descripcion"].ToString();
                            listaRegistro.Add(oRegistro);
                        }
                    }
                }
                return listaRegistro;
            }
        }

        // Baja de registro por ID
        public static bool BajaRegistroD(int registroID)
        {
            bool registroEliminado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("DELETE FROM Registro WHERE RegistrosID = @RegistrosID");
                using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                {
                    cmd.Parameters.AddWithValue("@RegistrosID", registroID);
                    oContexto.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    registroEliminado = filasAfectadas > 0;
                }
            }
            return registroEliminado;
        }

    }
}
