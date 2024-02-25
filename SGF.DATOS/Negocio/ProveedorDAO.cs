using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class ProveedorDAO
    {

        // Conteo de proveedores
        public static int ConteoProveedoresD()
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Proveedor");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        conteo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el conteo de proveedores, contactar con el administrador si el problema persiste.");
                }
            }
            return conteo;
        }

        // Alta
        public static bool AltaProveedorD(Proveedor oProveedor)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Proveedor (RazonSocial, TipoDocumento, Documento, Direccion, TelefonoProveedor, Correo, Estado)");
                    query.AppendLine("VALUES (@RazonSocial, @TipoDocumento, @Documento, @Direccion, @TelefonoProveedor, @Correo, @Estado)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@RazonSocial", oProveedor.RazonSocial);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oProveedor.TipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", oProveedor.Documento);
                        cmd.Parameters.AddWithValue("@Direccion", oProveedor.Direccion);
                        cmd.Parameters.AddWithValue("@TelefonoProveedor", oProveedor.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", oProveedor.Correo);
                        cmd.Parameters.AddWithValue("@Estado", oProveedor.Estado);
                        oContexto.Open();
                        alta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar dar de alta al proveedor, contactar con el administrador si el problema persiste.");
                }
            }
            return alta;
        }

        // Modificar
        public static bool ModificarProveedorD(Proveedor oProveedor)
        {
            bool modificado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Proveedor SET RazonSocial = @RazonSocial, TipoDocumento = @TipoDocumento, Documento = @Documento, Direccion = @Direccion, TelefonoProveedor = @TelefonoProveedor, Correo = @Correo, Estado = @Estado");
                    query.AppendLine("WHERE ProveedorID = @ProveedorID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorID", oProveedor.ProveedorID);
                        cmd.Parameters.AddWithValue("@RazonSocial", oProveedor.RazonSocial);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oProveedor.TipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", oProveedor.Documento);
                        cmd.Parameters.AddWithValue("@Direccion", oProveedor.Direccion);
                        cmd.Parameters.AddWithValue("@TelefonoProveedor", oProveedor.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", oProveedor.Correo);
                        cmd.Parameters.AddWithValue("@Estado", oProveedor.Estado);
                        oContexto.Open();
                        modificado = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar modificar el proveedor, contactar con el administrador si el problema persiste.");
                }
            }
            return modificado;
        }

        // Eliminar
        public static bool BajaProveedorD(int proveedorID)
        {
            bool eliminado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Proveedor WHERE ProveedorID = @ProveedorID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                        oContexto.Open();
                        eliminado = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar eliminar el proveedor, contactar con el administrador si el problema persiste.");
                }
            }
            return eliminado;
        }

        // Razon social existente
        public static bool RazonSocialExistenteD(string razonSocial)
        {
            bool existe = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Proveedor WHERE RazonSocial = @RazonSocial");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);
                        oContexto.Open();
                        existe = Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar verificar si la razón social ya existe, contactar con el administrador si el problema persiste.");
                }
            }
            return existe;
        }

        // Obtener lista proveedores
        public static List<Proveedor> ListaProveedoresD()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Proveedor");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Proveedor oProveedor = new Proveedor();
                                oProveedor.ProveedorID = Convert.ToInt32(reader["ProveedorID"]);
                                oProveedor.RazonSocial = reader["RazonSocial"].ToString();
                                oProveedor.TipoDocumento = reader["TipoDocumento"].ToString();
                                oProveedor.Documento = reader["Documento"].ToString();
                                oProveedor.Direccion = reader["Direccion"].ToString();
                                oProveedor.Telefono = reader["TelefonoProveedor"].ToString();
                                oProveedor.Correo = reader["Correo"].ToString();
                                oProveedor.Estado = Convert.ToBoolean(reader["Estado"]);
                                listaProveedores.Add(oProveedor);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la lista de proveedores, contactar con el administrador si el problema persiste.");
                }
            }
            return listaProveedores;
        }

        public static bool ProveedorTieneProductosD(int proveedorID)
        {
            bool tieneProductos = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(P.ProductoID) AS Cantidad");
                    query.AppendLine("FROM Proveedor PR");
                    query.AppendLine("LEFT JOIN Producto P ON PR.ProveedorID = P.ProveedorID");
                    query.AppendLine("WHERE PR.ProveedorID = @ProveedorID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        tieneProductos = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al comprobar si el proveedor tiene productos asignados, contactar con el administrador si el problema persiste.");
                }
            }
            return tieneProductos;
        }

        // Asignar productos sin proveedor
        public static bool AsignarProductosSinProveedorD(int productoID)
        {
            bool asignado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET ProveedorID = 0");
                    query.AppendLine("WHERE ProductoID = @ProductoID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        asignado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar asignar los productos como sin proveedor. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return asignado;
        }

        // Obtener ID de todo los productos de proveedor utilizando ID
        public static List<int> ListarProductosEnProveedorD(int proveedorID)
        {
            List<int> listaID = new List<int>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ProductoID FROM Producto");
                    query.AppendLine("WHERE ProveedorID = @ProveedorID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int productoID;
                            while (reader.Read())
                            {
                                productoID = Convert.ToInt32(reader["ProductoID"]);
                                listaID.Add(productoID);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener los productos del proveedor. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return listaID;
        }



        // Proveedor por ID
        public static Proveedor ObtenerProvedorPorIDD(int proveedorID)
        {
            Proveedor oProveedor = new Proveedor();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Proveedor WHERE ProveedorID = @ProveedorID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oProveedor.ProveedorID = Convert.ToInt32(reader["ProveedorID"]);
                                oProveedor.RazonSocial = reader["RazonSocial"].ToString();
                                oProveedor.TipoDocumento = reader["TipoDocumento"].ToString();
                                oProveedor.Documento = reader["Documento"].ToString();
                                oProveedor.Direccion = reader["Direccion"].ToString();
                                oProveedor.Telefono = reader["TelefonoProveedor"].ToString();
                                oProveedor.Correo = reader["Correo"].ToString();
                                oProveedor.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el proveedor, contactar con el administrador si el problema persiste.");
                }
            }
            return oProveedor;

        }
        // Obtener por ID
    }
}
