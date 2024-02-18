using SGF.MODELO;
using SGF.MODELO.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class SalidaInventarioDAO
    {
        public static int ObtenerFolio()
        {
            int folio = 1;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT MAX(SalidaID) FROM SalidaInventario");
                    using(var oComando = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object resultado = oComando.ExecuteScalar();
                        if(resultado != DBNull.Value)
                        {
                            folio = Convert.ToInt32(resultado) + 1;
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el folio de salida de inventario, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return folio;
        }

        public static bool RegistrarSalidaD(SalidaInventario oSalida, DataTable DetalleSalida)
        {
            bool resultado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO SalidaInventario (UsuarioID, FechaSalida, Observaciones, Estado)");
                    query.AppendLine("OUTPUT INSERTED.SalidaID");
                    query.AppendLine("VALUES (@UsuarioID, @FechaSalida, @Observaciones, @Estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", oSalida.Usuario.UsuarioID);
                        cmd.Parameters.AddWithValue("@FechaSalida", oSalida.FechaSalida);
                        cmd.Parameters.AddWithValue("@Observaciones", oSalida.Observaciones);
                        cmd.Parameters.AddWithValue("@Estado", true);
                        oContexto.Open();
                        oSalida.SalidaID = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach(DataRow fila in DetalleSalida.Rows)
                        {
                            query.Clear();
                            query.AppendLine("INSERT INTO Detalle_Salida (SalidaID, ProductoID, Cantidad, FechaRegistro)");
                            query.AppendLine("VALUES (@SalidaID, @ProductoID, @Cantidad, @FechaRegistro)");

                            using(SqlCommand cmdDetalle = new SqlCommand(query.ToString(), oContexto))
                            {
                                cmdDetalle.Parameters.AddWithValue("@SalidaID", oSalida.SalidaID);
                                cmdDetalle.Parameters.AddWithValue("@ProductoID", fila["dgvcID"]);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", fila["dgvcCantidad"]);
                                cmdDetalle.Parameters.AddWithValue("@FechaRegistro", oSalida.FechaSalida);
                                resultado = cmdDetalle.ExecuteNonQuery() > 0;
                            }
                        }
                    }       
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar registrar la salida de inventario, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return resultado;
        }

        // Obtener SALIDA DE INVENTARIO POR ID
        public static SalidaInventario ObtenerSalidaPorIDD(int salidaID)
        {
            SalidaInventario salidaInventario = null;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM SalidaInventario WHERE SalidaID = @SalidaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@SalidaID", salidaID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                salidaInventario = new SalidaInventario();
                                salidaInventario.Usuario = new Usuario();
                                
                                salidaInventario.SalidaID = Convert.ToInt32(reader["SalidaID"]);
                                salidaInventario.Usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                salidaInventario.FechaSalida = Convert.ToDateTime(reader["FechaSalida"]);
                                salidaInventario.Observaciones = reader["Observaciones"].ToString();
                                salidaInventario.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la salida de inventario, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return salidaInventario;
        }

        // Obtener los productos por ID de salida
        public static List<int> ObtenerProductosIDPorSalidaID(int salidaID)
        {
            List<int> productosID = new List<int>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ProductoID FROM Detalle_Salida WHERE SalidaID = @SalidaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@SalidaID", salidaID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productosID.Add(Convert.ToInt32(reader["ProductoID"]));
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener los productos del detalle de salida de inventario, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return productosID;
        }

        public static int ObtenerCantidadProductosQueSalieron(int productoID, int salidaID)
        {
            int cantidad = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Cantidad FROM Detalle_Salida WHERE SalidaID = @SalidaID AND ProductoID = @ProductoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@SalidaID", salidaID);
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if(resultado != null)
                        {
                            cantidad = Convert.ToInt32(resultado);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la cantidad de productos comprados, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return cantidad;
        }

        public static bool CancelarSalidaD(int salidaID)
        {
            bool resultado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE SalidaInventario SET Estado = @Estado WHERE SalidaID = @SalidaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Estado", false);
                        cmd.Parameters.AddWithValue("@SalidaID", salidaID);
                        oContexto.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar cancelar la salida de inventario, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return resultado;
        }
    }
}
