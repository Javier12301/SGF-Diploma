using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class ProductoDAO
    {
        // Conteo de productos
        public static int ConteoProductosD()
        {
            int conteo = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Producto";
                    using(SqlCommand cmd = new SqlCommand(query, oContexto))
                    {
                        oContexto.Open();
                        conteo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener el conteo de productos. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return conteo;
        }

        // obtener existencias de un producto por ID
        public static int ObtenerExistenciasD(int productoID)
        {
            int existencias = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    string query = "SELECT Stock FROM Producto WHERE ProductoID = @productoID";
                    using(SqlCommand cmd = new SqlCommand(query, oContexto))
                    {
                        cmd.Parameters.AddWithValue("@productoID", productoID);
                        oContexto.Open();
                        existencias = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener las existencias del producto. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return existencias;
        }

        // Alta
        public static bool AltaProductoD(Producto oProducto)
        {
            bool alta = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Producto (CodigoBarras, Nombre, CategoriaID, ProveedorID, PrecioCompra, PrecioVenta, NumeroLote, FechaVencimiento, Refrigerado, BajoReceta, Stock, CantidadMinima, TipoProducto, Estado)");
                    query.AppendLine("VALUES (@codigoBarras, @nombre, @categoriaID, @proveedorID, @precioCompra, @precioVenta, @numeroLote, @fechaVencimiento, @refrigerado, @bajoReceta, @stock, @cantidadMinima, @tipoProducto, @estado)");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@codigoBarras", oProducto.Codigo);
                        cmd.Parameters.AddWithValue("@nombre", oProducto.Nombre);
                        // Comprobar si existe la categoría si es null se lanzará un throw exception
                        if(oProducto.Categoria == null && oProducto.Proveedor == null)
                        {
                            throw new Exception("La categoría y el proveedor ingresados no existen.");
                        }
                        if(oProducto.Categoria != null)
                        {
                            cmd.Parameters.AddWithValue("@categoriaID", oProducto.Categoria.CategoriaID);
                        }
                        else
                        {
                            throw new Exception("La categoría ingresada no existe.");
                        }
                        if(oProducto.Proveedor != null)
                        {
                            cmd.Parameters.AddWithValue("@proveedorID", oProducto.Proveedor.ProveedorID);
                        }
                        else
                        {
                            throw new Exception("El proveedor ingresado no existe.");
                        }
                        cmd.Parameters.AddWithValue("@precioCompra", oProducto.PrecioCompra);
                        cmd.Parameters.AddWithValue("@precioVenta", oProducto.PrecioVenta);
                        cmd.Parameters.AddWithValue("@numeroLote", oProducto.NumeroLote);
                        if (oProducto.FechaVencimiento.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@fechaVencimiento", oProducto.FechaVencimiento.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@fechaVencimiento", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@refrigerado", oProducto.Refrigerado);
                        cmd.Parameters.AddWithValue("@bajoReceta", oProducto.Receta);
                        cmd.Parameters.AddWithValue("@stock", oProducto.Stock);
                        cmd.Parameters.AddWithValue("@cantidadMinima", oProducto.CantidadMinima);
                        cmd.Parameters.AddWithValue("@tipoProducto", oProducto.TipoProducto);
                        cmd.Parameters.AddWithValue("@estado", oProducto.Estado);
                        oContexto.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        alta = filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return alta;
        }

        // Modificar
        public static bool ModificarProductoD(Producto producto)
        {
            bool modificado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET CodigoBarras = @codigoBarras, Nombre = @nombre, CategoriaID = @categoriaID, ProveedorID = @proveedorID, PrecioCompra = @precioCompra, PrecioVenta = @precioVenta, NumeroLote = @numeroLote, FechaVencimiento = @fechaVencimiento, Refrigerado = @refrigerado, BajoReceta = @bajoReceta, Stock = @stock, CantidadMinima = @cantidadMinima, TipoProducto = @tipoProducto, Estado = @estado");
                    query.AppendLine("WHERE ProductoID = @productoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@codigoBarras", producto.Codigo);
                        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@categoriaID", producto.Categoria.CategoriaID);
                        cmd.Parameters.AddWithValue("@proveedorID", producto.Proveedor.ProveedorID);
                        cmd.Parameters.AddWithValue("@precioCompra", producto.PrecioCompra);
                        cmd.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                        cmd.Parameters.AddWithValue("@numeroLote", producto.NumeroLote);
                        if (producto.FechaVencimiento.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@fechaVencimiento", producto.FechaVencimiento.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@fechaVencimiento", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@refrigerado", producto.Refrigerado);
                        cmd.Parameters.AddWithValue("@bajoReceta", producto.Receta);
                        cmd.Parameters.AddWithValue("@stock", producto.Stock);
                        cmd.Parameters.AddWithValue("@cantidadMinima", producto.CantidadMinima);
                        cmd.Parameters.AddWithValue("@tipoProducto", producto.TipoProducto);
                        cmd.Parameters.AddWithValue("@estado", producto.Estado);
                        cmd.Parameters.AddWithValue("@productoID", producto.ProductoID);
                        oContexto.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar modificar el producto. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return modificado;
        }

        // Baja
        public static bool BajaProductoD(int productoID)
        {
            bool baja = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Producto WHERE ProductoID = @productoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@productoID", productoID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        baja = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar eliminar el producto. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return baja;
        }

        // Obtener producto por ID
        public static Producto ObtenerProductoPorIDD(int productoID)
        {
            Producto oProducto = new Producto();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Producto");
                    query.AppendLine("WHERE ProductoID = @productoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@productoID", productoID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oProducto.ProductoID = Convert.ToInt32(reader["ProductoID"]);
                                oProducto.Codigo = reader["CodigoBarras"].ToString();
                                oProducto.Nombre = reader["Nombre"].ToString();
                                oProducto.Categoria = new Categoria();
                                oProducto.Categoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oProducto.Proveedor = new Proveedor();
                                oProducto.Proveedor.ProveedorID = Convert.ToInt32(reader["ProveedorID"]);
                                oProducto.PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]);
                                oProducto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                                oProducto.NumeroLote = reader["NumeroLote"].ToString();
                                if (reader["FechaVencimiento"] != DBNull.Value)
                                {
                                    oProducto.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]);
                                }
                                else
                                {
                                    oProducto.FechaVencimiento = null;
                                }
                                oProducto.Refrigerado = Convert.ToBoolean(reader["Refrigerado"]);
                                oProducto.Receta = Convert.ToBoolean(reader["BajoReceta"]);
                                oProducto.Stock = Convert.ToInt32(reader["Stock"]);
                                oProducto.CantidadMinima = Convert.ToInt32(reader["CantidadMinima"]);
                                oProducto.TipoProducto = reader["TipoProducto"].ToString();
                                oProducto.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el producto, contactar con el administrador si el problema persiste.");
                }
            }
            return oProducto;
        }

        // obtener producto por código
        public static Producto ObtenerProductoPorCodigoD(string codigo)
        {
            Producto oProducto = null;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Producto");
                    query.AppendLine("WHERE CodigoBarras = @codigo");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oProducto = new Producto();
                                oProducto.ProductoID = Convert.ToInt32(reader["ProductoID"]);
                                oProducto.Codigo = reader["CodigoBarras"].ToString();
                                oProducto.Nombre = reader["Nombre"].ToString();
                                oProducto.Categoria = new Categoria();
                                oProducto.Categoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oProducto.Proveedor = new Proveedor();
                                oProducto.Proveedor.ProveedorID = Convert.ToInt32(reader["ProveedorID"]);
                                oProducto.PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]);
                                oProducto.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                                oProducto.NumeroLote = reader["NumeroLote"].ToString();
                                if (reader["FechaVencimiento"] != DBNull.Value)
                                {
                                    oProducto.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]);
                                }
                                else
                                {
                                    oProducto.FechaVencimiento = null;
                                }
                                oProducto.Refrigerado = Convert.ToBoolean(reader["Refrigerado"]);
                                oProducto.Receta = Convert.ToBoolean(reader["BajoReceta"]);
                                oProducto.Stock = Convert.ToInt32(reader["Stock"]);
                                oProducto.CantidadMinima = Convert.ToInt32(reader["CantidadMinima"]);
                                oProducto.TipoProducto = reader["TipoProducto"].ToString();
                                oProducto.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el producto, contactar con el administrador si el problema persiste.");
                }
            }
            return oProducto;

        }

        public static List<Categoria> CategoriasExistentes()
        {
            List<Categoria> oLista = new List<Categoria>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT DISTINCT CategoriaID,");
                    query.AppendLine("(SELECT TOP 1 Nombre FROM Categoria WHERE CategoriaID = P.CategoriaID) AS Categoria");
                    query.AppendLine("FROM Producto P");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Categoria oCategoria = new Categoria();
                                oCategoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oCategoria.Nombre = reader["Categoria"].ToString();
                                oLista.Add(oCategoria);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return oLista;
        }

        // Existencia de código
        public static bool ExisteCodigoD(string codigo)
        {
            bool existe = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Producto WHERE CodigoBarras = @codigo");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        existe = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al verificar si existe el código, contactar con el administrador si el problema persiste.");
                }
            }
            return existe;
        }

        // Existencia de producto
        public static bool ExisteProductoD(string nombre)
        {
            bool existe = false;

            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Producto WHERE Nombre = @nombre");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        existe = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al verificar si existe el producto, contactar con el administrador si el problema persiste.");
                }
            }
            return existe;
        }
    }
}
