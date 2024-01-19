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



        // Obtener lista proveedores
        public static List<Proveedor> ListaProveedoresD()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Proveedor");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
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

        // Obtener por ID
    }
}
