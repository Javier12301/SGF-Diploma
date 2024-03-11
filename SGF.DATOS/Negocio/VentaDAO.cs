using SGF.MODELO;
using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT MAX(VentaID) FROM Venta");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            numeroVenta = (int.Parse(resultado.ToString()) + 1).ToString("0000");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el contador de venta: " + ex.Message);
                }
            }
            return numeroVenta;
        }

        // Conteo de toda las ventas canceladas o sea Venta con estado false
        public static int ObtenerVentaCancelada()
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Venta WHERE Estado = 0");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            cantidad = Convert.ToInt32(resultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la cantidad de ventas canceladas: " + ex.Message);
                }
            }
            return cantidad;
        }

        // obtener ultima venta
        public static int ObtenerUltimaVentaD()
        {
            int ventaID = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT TOP 1 VentaID FROM Venta ORDER BY VentaID DESC");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            ventaID = Convert.ToInt32(resultado);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al obtener la ultima venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return ventaID;
        }

        // Obtener venta por id
        public static Venta ObtenerVentarPorIDD(int ventaID)
        {
            Venta oVenta = null;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select * from Venta where VentaID = @VentaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oVenta = new Venta();
                                oVenta.usuario = new Usuario();
                                oVenta.Moneda = new Moneda();
                                oVenta.VentaID = Convert.ToInt32(reader["VentaID"]);
                                oVenta.usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                oVenta.TipoComprobante = reader["TipoComprobante"].ToString();
                                oVenta.TipoDocumento = reader["TipoDocumento"].ToString();
                                oVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                                oVenta.NumeroDocumento = reader["DocumentoCliente"].ToString();
                                oVenta.NombreCliente = reader["NombreCliente"].ToString();
                                oVenta.TipoCliente = reader["TipoCliente"].ToString();
                                oVenta.Moneda.MonedaID = Convert.ToInt32(reader["MonedaID"]);
                                oVenta.MontoPagado = Convert.ToDecimal(reader["MontoPagado"]);
                                oVenta.MontoCambio = Convert.ToDecimal(reader["MontoCambio"]);
                                oVenta.Impuesto = reader["Impuesto"].ToString();
                                oVenta.MontoTotal = Convert.ToDecimal(reader["MontoTotal"]);
                                oVenta.FechaVenta = Convert.ToDateTime(reader["FechaVenta"]);
                                oVenta.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    oVenta = null;
                    throw new Exception("Error al obtener la venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
                return oVenta;
            }
        }

        public static int ObtenerCantidadProductosQueSeVendieron(int productoID, int ventaID)
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Cantidad FROM Detalle_Venta WHERE ProductoID = @ProductoID AND VentaID = @VentaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null)
                        {
                            cantidad = Convert.ToInt32(resultado);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la cantidad de productos que se vendieron, contacte con el administrador del sistema si este error persiste.");
                }
                return cantidad;
            }
        }

        public static List<int> ObtenerProductosIDPorVentaID(int ventaID)
        {
            List<int> productosID = new List<int>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ProductoID FROM Detalle_Venta WHERE VentaID = @VentaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
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
                    throw new Exception("Ocurrió un error al intentar obtener los productos del detalle de venta, contacte con el administrador del sistema si este error persiste.");
                }
                return productosID;
            }
        }

        // Registrar Venta
        public static bool RegistrarVentaD(Venta oVenta, DataTable DetalleVenta)
        {
            bool resultado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Venta (UsuarioID, TipoComprobante, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, TipoCliente, MonedaID, MontoPagado, MontoCambio, Impuesto, MontoTotal, FechaVenta, Estado)");
                    query.AppendLine("OUTPUT INSERTED.VentaID");
                    query.AppendLine("VALUES (@UsuarioID, @TipoComprobante, @TipoDocumento, @NumeroDocumento, @DocumentoCliente, @NombreCliente, @TipoCliente, @MonedaID, @MontoPagado, @MontoCambio,@Impuesto, @MontoTotal, @FechaVenta, @Estado)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", oVenta.usuario.UsuarioID);
                        cmd.Parameters.AddWithValue("@TipoComprobante", oVenta.TipoComprobante);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oVenta.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", oVenta.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@DocumentoCliente", oVenta.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@NombreCliente", oVenta.NombreCliente);
                        cmd.Parameters.AddWithValue("@TipoCliente", oVenta.TipoCliente);
                        cmd.Parameters.AddWithValue("@MonedaID", oVenta.Moneda.MonedaID);
                        cmd.Parameters.AddWithValue("@MontoPagado", oVenta.MontoPagado);
                        cmd.Parameters.AddWithValue("@MontoCambio", oVenta.MontoCambio);
                        cmd.Parameters.AddWithValue("@Impuesto", oVenta.Impuesto);
                        cmd.Parameters.AddWithValue("@MontoTotal", oVenta.MontoTotal);
                        cmd.Parameters.AddWithValue("@FechaVenta", oVenta.FechaVenta);
                        cmd.Parameters.AddWithValue("@Estado", oVenta.Estado);
                        oContexto.Open();
                        int VentaID = (int)cmd.ExecuteScalar();

                        // insertamos el detalle de la venta
                        foreach (DataRow fila in DetalleVenta.Rows)
                        {
                            query.Clear();
                            query.AppendLine("INSERT INTO Detalle_Venta (VentaID, ProductoID, PrecioVenta, Cantidad, Descuento, SubTotal, FechaRegistro)");
                            query.AppendLine("VALUES (@VentaID, @ProductoID, @PrecioVenta, @Cantidad, @Descuento, @SubTotal, @FechaRegistro)");

                            using (SqlCommand cmdDetalle = new SqlCommand(query.ToString(), oContexto))
                            {
                                cmdDetalle.Parameters.AddWithValue("@VentaID", VentaID);
                                cmdDetalle.Parameters.AddWithValue("@ProductoID", fila["dgvcID"]);
                                cmdDetalle.Parameters.AddWithValue("@PrecioVenta", fila["dgvcPrecio"]);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", fila["dgvcCantidad"]);
                                cmdDetalle.Parameters.AddWithValue("@Descuento", fila["dgvcDescuento"]);
                                cmdDetalle.Parameters.AddWithValue("@SubTotal", fila["dgvcSubTotal"]);
                                cmdDetalle.Parameters.AddWithValue("@FechaRegistro", oVenta.FechaVenta);
                                resultado = cmdDetalle.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al registrar la venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return resultado;
        }

        // Cancelar venta
        public static bool CancelarVentad(int ventaID)
        {
            bool resultado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Venta SET Estado = @Estado WHERE VentaID = @VentaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Estado", false);
                        cmd.Parameters.AddWithValue("@VentaID", ventaID);
                        oContexto.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al cancelar la venta. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return resultado;
        }

        // reporte

        // Reporte ventas realizadas por tipo producto 
        /*SELECT 
    P.CodigoBarras,
    P.Nombre AS 'Nombre de Producto',
    SUM(DV.Cantidad) AS 'Cantidad Vendida'
FROM 
    Detalle_Venta DV
    INNER JOIN Producto P ON DV.ProductoID = P.ProductoID
WHERE 
    P.TipoProducto = @TipoProducto
GROUP BY 
    P.CodigoBarras,
    P.Nombre
ORDER BY 
    'Cantidad Vendida' DESC;*/
        public static int ObtenerCantidadDeVentasPorTipoProducto(string tipoProducto)
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    // la sumatoria de cantidad de detalle de venta, debe tener en cuenta la VentaID donde su estado sea true
                    query.AppendLine("SELECT SUM(DV.Cantidad) FROM Detalle_Venta DV INNER JOIN Producto P ON DV.ProductoID = P.ProductoID WHERE P.TipoProducto = @TipoProducto AND DV.VentaID IN (SELECT VentaID FROM Venta WHERE Estado = 1)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@TipoProducto", tipoProducto);
                        oContexto.Open();
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null)
                        {
                            cantidad = Convert.ToInt32(resultado);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la cantidad de ventas por tipo de producto, contacte con el administrador del sistema si este error persiste.");
                }
                return cantidad;
            }
        }

        /*SELECT 
    YEAR(FechaVenta) AS Year,
    LEFT(FORMAT(FechaVenta, 'MMMM', 'es-ES'), 3) AS Month,
    COUNT(*) AS NumeroDeVentas
FROM 
    Venta
WHERE 
    FechaVenta BETWEEN @FechaInicio AND @FechaHasta
GROUP BY 
    YEAR(FechaVenta),
    MONTH(FechaVenta),
    LEFT(FORMAT(FechaVenta, 'MMMM', 'es-ES'), 3)
ORDER BY 
    Year,
    MONTH(FechaVenta);*/
        // venta por año, mes y semana según parametros enviados @FechaInicio y @FechaHasta
        public static DataTable ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT YEAR(FechaVenta) AS Year, FORMAT(FechaVenta, 'MMMM', 'es-ES') AS Month, COUNT(*) AS NumeroDeVentas FROM Venta WHERE FechaVenta BETWEEN @FechaInicio AND @FechaHasta GROUP BY YEAR(FechaVenta), MONTH(FechaVenta), FORMAT(FechaVenta, 'MMMM', 'es-ES') ORDER BY Year, MONTH(FechaVenta)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
                        oContexto.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener las ventas por fecha, contacte con el administrador del sistema si este error persiste.");
                }
                return dt;
            }
        }



        // venta por dia de la semana según parametros enviados @FechaInicio y @FechaHasta
        public static DataTable ObtenerVentasPorDiaDeLaSemana(DateTime fechaInicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DATENAME(WEEKDAY, FechaVenta) AS DiaSemana, COUNT(*) AS NumeroDeVentas FROM Venta WHERE FechaVenta BETWEEN @FechaInicio AND @FechaHasta GROUP BY DATENAME(WEEKDAY, FechaVenta) ORDER BY CASE DATENAME(WEEKDAY, FechaVenta) WHEN 'Lunes' THEN 1 WHEN 'Martes' THEN 2 WHEN 'Miércoles' THEN 3 WHEN 'Jueves' THEN 4 WHEN 'Viernes' THEN 5 WHEN 'Sábado' THEN 6 WHEN 'Domingo' THEN 7 END");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
                        oContexto.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener las ventas por día de la semana, contacte con el administrador del sistema si este error persiste.");
                }
                return dt;
            }
        }

         // usar esta query para obtener los tipo productos más vendidos usando @FechaInicio y @FechaHasta
        public static DataTable ObtenerTipoProductosMasVendidos(string tipoProducto, DateTime fechaInicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.Nombre, SUM(DV.Cantidad) AS NumeroDeVentas FROM Detalle_Venta DV INNER JOIN Producto P ON DV.ProductoID = P.ProductoID WHERE P.TipoProducto = @TipoProducto AND DV.FechaRegistro BETWEEN @FechaInicio AND @FechaHasta GROUP BY P.Nombre ORDER BY NumeroDeVentas DESC");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@TipoProducto", tipoProducto);
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
                        oContexto.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener los tipo productos más vendidos, contacte con el administrador del sistema si este error persiste.");
                }
                return dt;
            }
        }

        



    }
}
