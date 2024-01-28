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
    }
}
