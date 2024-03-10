using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class CategoriaDAO
    {
        // Conteo de categorías
        public static int ConteoCategoriasD()
        {
            int conteo = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Categoria");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        conteo = Convert.ToInt32(cmd.ExecuteScalar());
                        conteo--;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener el conteo de categorías, póngase en contacto con el administrador del sistema para solucionar el error.");
                }
            }
            return conteo;
        }

        // Conteo de cantidad de productos en categoría
        public static int ConteoProductosEnCategoriaD(int categoriaID)
        {
            int conteo = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Producto");
                    query.AppendLine("WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        conteo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener el conteo de productos en categoría, póngase en contacto con el administrador del sistema para solucionar el error.");
                }
            }
            return conteo;
        }

        // Alta
        public static bool AltaCategoriaD(Categoria oCategoria)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Categoria (Nombre, Descripcion, Estado)");
                    query.AppendLine("VALUES (@nombre, @descripcion, @estado)");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oCategoria.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoria.Descripcion);
                        cmd.Parameters.AddWithValue("@estado", oCategoria.Estado);
                        oContexto.Open();
                        
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        alta = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar registrar la nueva categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return alta;
        }

        // Modificar
        public static bool ModificarCategoriaD(Categoria categoria)
        {
            bool modificado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Categoria SET Nombre = @nombre, Descripcion = @descripcion, Estado = @estado");
                    query.AppendLine("WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                        cmd.Parameters.AddWithValue("@estado", categoria.Estado);
                        cmd.Parameters.AddWithValue("@categoriaID", categoria.CategoriaID);
                        oContexto.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar modificar la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return modificado;
        }

        // Baja
        public static bool BajaCategoriaD(int categoriaID)
        {
            bool baja = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Categoria WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        baja = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar eliminar la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return baja;
        }


        // Asignar productos como sin categoría
        public static bool AsignarProductosSinCategoriaD(int productoID)
        {
            bool asignado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET CategoriaID = 0");
                    query.AppendLine("WHERE ProductoID = @productoID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@productoID", productoID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        asignado = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar asignar los productos como sin categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return asignado;
        }

        // Obtener ID de todo los productos de una categoría
        public static List<int> ListarProductosEnCategoriaID(int categoriaID)
        {
            List<int> listaProductosID = new List<int>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ProductoID FROM Producto");
                    query.AppendLine("WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int productoID;
                            while (reader.Read())
                            {
                                productoID = Convert.ToInt32(reader["ProductoID"]);
                                listaProductosID.Add(productoID);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener los productos de la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
                return listaProductosID;
            }
        }

        // Habilitar todo los productos de la categoría
        public static int HabilitarProductos(int categoriaID)
        {
            int productosHabilitados = -1;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Estado = 1");
                    query.AppendLine("WHERE CategoriaID = @categoriaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        productosHabilitados = filasAfectadas;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al habilitar los productos de la categoría, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return productosHabilitados;
        }

        // Deshabilitar todo los productos de la categoría
        public static int DeshabilitarProductos(int categoriaID)
        {
            int productosDeshabilitado = -1;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Estado = 0");
                    query.AppendLine("WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        productosDeshabilitado = filasAfectadas;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al deshabilitar los productos de la categoría, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return productosDeshabilitado;
        }

        // Comprobar si la categoría tiene productos asignados
        public static bool CategoriaTieneProductosD(int categoriaID)
        {
            bool tieneProductos = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(P.ProductoID) AS Cantidad");
                    query.AppendLine("FROM Categoria C");
                    query.AppendLine("LEFT JOIN Producto P ON C.CategoriaID = P.CategoriaID");
                    query.AppendLine("WHERE C.CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        tieneProductos = count > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al comprobar si la categoría tiene productos asignados, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return tieneProductos;
        }

        // Comprobar existencia
        public static bool ExisteCategoriaD(string nombre)
        {
            bool existe = false;

            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Categoria WHERE Nombre = @nombre");
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
                    throw new Exception("Error al verificar si existe la categoría, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return existe;
        }

        // Listar Categorias
        public static List<Categoria> ListarCategoriasD()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Categoria");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Categoria oCategoria = new Categoria();
                                oCategoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oCategoria.Nombre = reader["Nombre"].ToString();
                                oCategoria.Descripcion = reader["Descripcion"].ToString();
                                oCategoria.Estado = Convert.ToBoolean(reader["Estado"]);
                                listaCategorias.Add(oCategoria);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la lista de categorías, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return listaCategorias;
        }

        // Obtener por ID
        public static Categoria ObtenerCategoriaPorIDD(int categoriaID)
        {
            Categoria oCategoria = new Categoria();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Categoria WHERE CategoriaID = @categoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@categoriaID", categoriaID);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oCategoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oCategoria.Nombre = reader["Nombre"].ToString();
                                oCategoria.Descripcion = reader["Descripcion"].ToString();
                                oCategoria.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener la categoría. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return oCategoria;
        }

        // Obtener categorías que tienen productos asignados
        public static int ConteoCategoriasConProductosD()
        {
            int conteo = 0;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(DISTINCT C.CategoriaID) FROM Categoria C");
                    query.AppendLine("LEFT JOIN Producto P ON C.CategoriaID = P.CategoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        conteo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el conteo de categorías con productos asignados, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return conteo;
        }

        // Listar categorías que tienen productos asignados
        public static List<Categoria> ListarCategoriaConProductosD()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();            
                    query.AppendLine("SELECT DISTINCT C.CategoriaID, C.Nombre, C.Descripcion, C.Estado FROM Categoria C");
                    query.AppendLine("INNER JOIN Producto P ON C.CategoriaID = P.CategoriaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Categoria oCategoria = new Categoria();
                                oCategoria.CategoriaID = Convert.ToInt32(reader["CategoriaID"]);
                                oCategoria.Nombre = reader["Nombre"].ToString();
                                oCategoria.Descripcion = reader["Descripcion"].ToString();
                                oCategoria.Estado = Convert.ToBoolean(reader["Estado"]);
                                listaCategorias.Add(oCategoria);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la lista de categorías con productos asignados, contactar con el administrador del sistema si el error persiste.");
                }
            }
            return listaCategorias;
        }
    }
}
