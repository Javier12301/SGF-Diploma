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
        // Alta

        // Modificar

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

        
    }
}
