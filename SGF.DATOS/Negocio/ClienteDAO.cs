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
        // Conteo de cliente
        public static int ConteoClientesD()
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Cliente");
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

        // conteo clientes activos o sea estado = true
        public static int ConteoClientesActivosD()
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Cliente WHERE Estado = 1");
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

        // Conteo clientes inactivos o sea estado = false o también dados de baja, se hará una tabla relacional Registro, buscando obtener toda las bajas de clientes

        public static int ConteoClientesInactivosYDadosDeBajaD()
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ");
                    query.AppendLine("((SELECT COUNT(*) FROM Cliente WHERE Estado = 0) +");
                    query.AppendLine("(SELECT SUM(Cantidad) FROM Registro WHERE Movimiento = 'Baja' AND Modulo = 'Clientes')) AS TotalClientesInactivosYDadosDeBaja");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        object result = cmd.ExecuteScalar();
                        if (result == DBNull.Value)
                        {
                            conteo = 0;
                        }
                        else
                        {
                            conteo = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el conteo de clientes inactivos y dados de baja, contactar con el administrador si el problema persiste.");
                }
            }
            return conteo;
        }

        // listar todo los tipos de clientes
        public static List<TipoCliente> ListarTipoClientes()
        {
            List<TipoCliente> lista = new List<TipoCliente>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM TipoCliente");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoCliente tipoCliente = new TipoCliente();
                                tipoCliente.TipoClienteID = Convert.ToInt32(reader["TipoClienteID"]);
                                tipoCliente.Descripcion = reader["Descripcion"].ToString();
                                lista.Add(tipoCliente);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la lista de tipos de clientes, contactar con el administrador si el problema persiste.");
                }
            }
            return lista;
        }

        // Alta cliente
        public static bool AltaCliente(Cliente oCliente)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Cliente (TipoDocumento, Documento, NombreCompleto, Correo, Telefono, TipoClienteID, Estado)");
                    query.AppendLine("VALUES (@TipoDocumento, @Documento, @NombreCompleto, @Correo, @Telefono, @TipoClienteID, @Estado)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@TipoDocumento", oCliente.TipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@NombreCompleto", oCliente.NombreCompleto);
                        cmd.Parameters.AddWithValue("@Correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@TipoClienteID", oCliente.TipoCliente.TipoClienteID);
                        cmd.Parameters.AddWithValue("@Estado", oCliente.Estado);
                        oContexto.Open();
                        alta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar dar de alta al cliente, contactar con el administrador si el problema persiste.");
                }
            }
            return alta;
        }


        // Modificar Cliente
        public static bool ModificarCliente(Cliente oCliente)
        {
            bool modificado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Cliente SET TipoDocumento = @TipoDocumento, Documento = @Documento, NombreCompleto = @NombreCompleto, Correo = @Correo, Telefono = @Telefono, TipoClienteID = @TipoClienteID, Estado = @Estado");
                    query.AppendLine("WHERE ClienteID = @ClienteID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", oCliente.ClienteID);
                        cmd.Parameters.AddWithValue("@TipoDocumento", oCliente.TipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@NombreCompleto", oCliente.NombreCompleto);
                        cmd.Parameters.AddWithValue("@Correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@TipoClienteID", oCliente.TipoCliente.TipoClienteID);
                        cmd.Parameters.AddWithValue("@Estado", oCliente.Estado);
                        oContexto.Open();
                        modificado = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar modificar el cliente, contactar con el administrador si el problema persiste.");
                }
            }
            return modificado;
        }



        // Baja cliente
        public static bool BajaCliente(int clienteID)
        {
            bool eliminado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Cliente WHERE ClienteID = @ClienteID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                        oContexto.Open();
                        eliminado = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar eliminar el cliente, contactar con el administrador si el problema persiste.");
                }
            }
            return eliminado;
        }

        // Listar clientes y su respectivo tipo cliente
        public static List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT C.*, TC.Descripcion AS TipoCliente");
                    query.AppendLine("FROM Cliente C");
                    query.AppendLine("INNER JOIN TipoCliente TC ON C.TipoClienteID = TC.TipoClienteID");
                    query.AppendLine("WHERE ClienteID > 0");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
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
                } catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar obtener la lista de clientes.");
                }
                return lista;
            }
        }

        public static TipoCliente ObtenerTipoClientePorDescripcion(string descripcion)
        {
            TipoCliente tipoCliente = new TipoCliente();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM TipoCliente WHERE Descripcion = @Descripcion");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipoCliente.TipoClienteID = Convert.ToInt32(reader["TipoClienteID"]);
                                tipoCliente.Descripcion = reader["Descripcion"].ToString();
                            }
                        }
                    }
                } catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el tipo de cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return tipoCliente;
        } 

        // Alta nuevo tipo cliente y retorno de ID de tipo cliente recién creado
        public static int AltaTipoCliente(string descripcion)
        {
            int tipoClienteID = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO TipoCliente (Descripcion) VALUES (@Descripcion)");
                    query.AppendLine("SELECT SCOPE_IDENTITY()");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        oContexto.Open();
                        tipoClienteID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar dar de alta el tipo de cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return tipoClienteID;
        }

        // Existe tipocliente ? usar descripción
        public static bool ExisteTipoCliente(string descripcion)
        {
            bool existe = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM TipoCliente WHERE Descripcion = @Descripcion");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        oContexto.Open();
                        existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar verificar la existencia del tipo de cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return existe;
        }

        // Existe documento Cliente, hacer verificación usando TipoDocumento y Documento
        public static bool ExisteDocumentoCliente(string tipoDocumento, string documento)
        {
            bool existe = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Cliente WHERE TipoDocumento = @TipoDocumento AND Documento = @Documento");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", documento);
                        oContexto.Open();
                        existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar verificar la existencia del documento del cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return existe;
        }

        // Obtener cliente por ID
        public static Cliente ObtenerClientePorIDD(int clienteID)
        {
            Cliente cliente = new Cliente();
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Cliente");
                    query.AppendLine("INNER JOIN TipoCliente ON Cliente.TipoClienteID = TipoCliente.TipoClienteID");
                    query.AppendLine("WHERE ClienteID = @ClienteID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                        oContexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TipoCliente tipoCliente = new TipoCliente();
                                cliente.ClienteID = Convert.ToInt32(reader["ClienteID"]);
                                cliente.TipoDocumento = reader["TipoDocumento"].ToString();
                                cliente.Documento = reader["Documento"].ToString();
                                cliente.NombreCompleto = reader["NombreCompleto"].ToString();
                                cliente.Correo = reader["Correo"].ToString();
                                cliente.Telefono = reader["Telefono"].ToString();
                                cliente.Estado = Convert.ToBoolean(reader["Estado"]);

                                tipoCliente.TipoClienteID = Convert.ToInt32(reader["TipoClienteID"]);
                                tipoCliente.Descripcion = reader["Descripcion"].ToString();
                                cliente.TipoCliente = tipoCliente;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el cliente. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return cliente;
        }

    }
}
