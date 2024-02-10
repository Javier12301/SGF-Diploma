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
                                cmdDetalle.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
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
    }
}
