using SGF.NEGOCIO.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class ClienteDAO
    {
        // Listar clientes y su respectivo tipo cliente
        public static List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT C.*, TC.Descripcion AS TipoCliente");
                    query.AppendLine("FROM Cliente C");
                    query.AppendLine("INNER JOIN TipoCliente TC ON C.TipoClienteID = TC.TipoClienteID");
                    query.AppendLine("WHERE ClienteID > 0");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cliente cliente = new Cliente();
                                TipoCliente tipoCliente = new TipoCliente();
                                cliente.ClienteID = Convert.ToInt32(reader["ClienteID"]);
                                cliente.TipoDocumento = reader["TipoDocumento"].ToString();
                                cliente.Documento = reader["Documento"].ToString();
                                cliente.NombreCompleto = reader["NombreCompleto"].ToString();
                                cliente.Correo = reader["Correo"].ToString();
                                cliente.Telefono = reader["Telefono"].ToString();
                                cliente.Estado = Convert.ToBoolean(reader["Estado"]);
                                tipoCliente.TipoClienteID = Convert.ToInt32(reader["TipoClienteID"]);
                                tipoCliente.Descripcion = reader["TipoCliente"].ToString();
                                cliente.TipoCliente = tipoCliente;
                                lista.Add(cliente);
                            }
                        }
                    }
                }catch(Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener la lista de clientes.");
                }
                return lista;
            }
        }
    }
}
