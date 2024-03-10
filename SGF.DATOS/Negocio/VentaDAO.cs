using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class VentaDAO
    {
        // Contador de numero de venta si es 0000 poner como 0001
        public static string ContadorDeVenta()
        {
            string numeroVenta = "0001";
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT MAX(VentaID) FROM Venta");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if(resultado != DBNull.Value)
                        {
                            numeroVenta = (int.Parse(resultado.ToString()) + 1).ToString("0000");
                        }
                    }
                }catch(Exception ex)
                {
                    throw new Exception("Error al obtener el contador de venta: " + ex.Message);
                }
            }
            return numeroVenta;
        }
    }
}
