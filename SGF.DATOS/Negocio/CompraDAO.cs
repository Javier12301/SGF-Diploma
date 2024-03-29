﻿using SGF.MODELO;
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
    public class CompraDAO
    {
        // Obtener el último folio de compra o sea la ID
        public static int ObtenerFolioD()
        {
            int folio = 1; // Inicializa el folio en 1
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT MAX(CompraID) FROM Compra");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value) // Si hay compras existentes
                        {
                            folio = Convert.ToInt32(result) + 1; // Incrementa el folio
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el folio de compra, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return folio;
        }


        public static bool RegistrarCompraD(Compra oCompra, DataTable DetalleCompra)
        {
            bool resultado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Compra (UsuarioID, ProveedorID, Factura, FechaCompra, Estado)");
                    query.AppendLine("OUTPUT INSERTED.CompraID");
                    query.AppendLine("VALUES (@UsuarioID, @ProveedorID, @Factura, @FechaCompra, @Estado)");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", oCompra.usuario.UsuarioID);
                        cmd.Parameters.AddWithValue("@ProveedorID", oCompra.proveedor.ProveedorID);
                        cmd.Parameters.AddWithValue("@Factura", oCompra.TipoComprobante);
                        cmd.Parameters.AddWithValue("@FechaCompra", oCompra.FechaCompra);
                        cmd.Parameters.AddWithValue("@Estado", true);
                        oContexto.Open();
                        oCompra.CompraID = Convert.ToInt32(cmd.ExecuteScalar());

                        // Insertar detalle de compra
                        foreach (DataRow fila in DetalleCompra.Rows)
                        {
                            query.Clear();
                            query.AppendLine("INSERT INTO Detalle_Compra (CompraID, ProductoID, PrecioCompra, Cantidad, FechaRegistro)");
                            query.AppendLine("VALUES (@CompraID, @ProductoID, @PrecioCompra, @Cantidad, @FechaRegistro)");

                            using (SqlCommand cmdDetalle = new SqlCommand(query.ToString(), oContexto))
                            {
                                cmdDetalle.Parameters.AddWithValue("@CompraID", oCompra.CompraID);
                                cmdDetalle.Parameters.AddWithValue("@ProductoID", fila["dgvcID"]);
                                cmdDetalle.Parameters.AddWithValue("@PrecioCompra", fila["dgvcPrecioCompra"]);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", fila["dgvcCantidad"]);
                                cmdDetalle.Parameters.AddWithValue("@FechaRegistro", oCompra.FechaCompra);
                                resultado = cmdDetalle.ExecuteNonQuery() > 0;
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar registrar la compra, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return resultado;
        }

        // Obtener Productos por ObtenerProductosIDPorCompraID
        public static List<int> ObtenerProductosIDPorCompraID(int compraID)
        {
            List<int> productosID = new List<int>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ProductoID FROM Detalle_Compra WHERE CompraID = @CompraID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
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
                    throw new Exception("Ocurrió un error al intentar obtener los productos de la compra, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return productosID;
        }

        // Obtener cantidad de productos comprados usando ID de producto y ID de compra
        public static int ObtenerCantidadProductosComprados(int productoID, int compraID)
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Cantidad FROM Detalle_Compra WHERE CompraID = @CompraID AND ProductoID = @ProductoID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);
                        oContexto.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            cantidad = Convert.ToInt32(result);
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

        // Cancelar compra, poniendo el estado en false
        public static bool CancelarCompraD(int compraID)
        {
            bool resultado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Compra SET Estado = @Estado WHERE CompraID = @CompraID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Estado", false);
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        oContexto.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar cancelar la compra, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return resultado;
        }

        // Obtener Compra por ID
        public static Compra ObtenerCompraPorIDD(int compraID)
        {
            Compra oCompra = new Compra();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Compra WHERE CompraID = @CompraID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@CompraID", compraID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oCompra.usuario = new Usuario();
                                oCompra.proveedor = new Proveedor();

                                oCompra.CompraID = Convert.ToInt32(reader["CompraID"]);
                                oCompra.usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                oCompra.proveedor.ProveedorID = Convert.ToInt32(reader["ProveedorID"]);
                                oCompra.TipoComprobante = reader["Factura"].ToString();
                                oCompra.FechaCompra = Convert.ToDateTime(reader["FechaCompra"]);
                                oCompra.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la compra realizada, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return oCompra;
        }


        // MANEJO DE DATOS UTILIZADO EN REPORTES
        public static DataTable ListarCantidadCompradaD()
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ReporteInventario_CantidadCompradaProveedor", oContexto))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la cantidad comprada por proveedor, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return dt;
        }

        public static DataTable ListarGastoTotalD()
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ReporteInventario_GastoTotal", oContexto))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el gasto total, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return dt;
        }
        
        // FIN MANEJO DE DATOS UTILIZADO EN REPORTES
        
        // Conteo de compras realizadas con estado activo
        public static int ConteoComprasRealizadasD(int estadoCompra)
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(CompraID) FROM Compra WHERE Estado = @estadoCompra");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@estadoCompra", estadoCompra);
                        oContexto.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            conteo = Convert.ToInt32(result);
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el conteo de compras realizadas, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return conteo;
        }

        // Obtener cantidad de compras por tipo de producto
        public static int ObtenerCantidadDeComprasPorTipoProducto(string tipoProducto)
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT SUM(DC.Cantidad) ");
                    query.AppendLine("FROM Detalle_Compra DC ");
                    query.AppendLine("INNER JOIN Producto P ON DC.ProductoID = P.ProductoID ");
                    query.AppendLine("WHERE P.TipoProducto = @TipoProducto ");
                    query.AppendLine("AND DC.CompraID IN (SELECT CompraID FROM Compra WHERE Estado = 1)");
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
                    throw new Exception("Ocurrió un error al intentar obtener la cantidad de compras por tipo de producto, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return cantidad;
        }

        // Obtener ventas canceladas
        public static int ObtenerCompraCancelada()
        {
            int cantidad = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Compra WHERE Estado = 0");
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
                    throw new Exception("Error al obtener la cantidad de compras canceladas: " + ex.Message);
                }
            }
            return cantidad;
        }

        public static DataTable ObtenerComprasPorFecha(DateTime fechaInicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT YEAR(FechaCompra) AS Year, FORMAT(FechaCompra, 'MMMM', 'es-ES') AS Month, COUNT(*) AS NumeroDeCompras FROM Compra WHERE FechaCompra BETWEEN @FechaInicio AND @FechaHasta GROUP BY YEAR(FechaCompra), MONTH(FechaCompra), FORMAT(FechaCompra, 'MMMM', 'es-ES') ORDER BY Year, MONTH(FechaCompra)");
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
                    throw new Exception("Ocurrió un error al intentar obtener las compras por fecha, contacte con el administrador del sistema si este error persiste.");
                }
                return dt;
            }
        }

        public static DataTable ObtenerComprasPorDiaDeLaSemana(DateTime fechaInicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DATENAME(WEEKDAY, FechaCompra) AS DiaSemana, COUNT(*) AS NumeroDeCompras FROM Compra WHERE FechaCompra BETWEEN @FechaInicio AND @FechaHasta GROUP BY DATENAME(WEEKDAY, FechaCompra) ORDER BY CASE DATENAME(WEEKDAY, FechaCompra) WHEN 'Lunes' THEN 1 WHEN 'Martes' THEN 2 WHEN 'Miércoles' THEN 3 WHEN 'Jueves' THEN 4 WHEN 'Viernes' THEN 5 WHEN 'Sábado' THEN 6 WHEN 'Domingo' THEN 7 END");
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
                    throw new Exception("Ocurrió un error al intentar obtener las compras por día de la semana, contacte con el administrador del sistema si este error persiste.");
                }
                return dt;
            }
        }




    }
}
