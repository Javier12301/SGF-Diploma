using SGF.MODELO.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Negocio
{
    public class NegocioDAO
    {
        // Conteo de monedas
        public static int ConteoMonedas()
        {
            int conteo = 0;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Moneda");
                    using (var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        conteo = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el conteo de monedas, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return conteo;
        }

        // Comprobar existencia de moneda
        public static bool ExisteMonedaD(string nombre)
        {
            bool existe = false;

            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) FROM Moneda WHERE Nombre = @Nombre");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        oContexto.Open();
                        int conteo = Convert.ToInt32(cmd.ExecuteScalar());
                        existe = conteo > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Error al verificar si existe la moneda, contactar con el administrador del sistema si este error persiste.");
                }
            }
            return existe;
        }

        // Obtener lista de monedas para autocompletar textbox
        public static List<Moneda> ObtenerMonedasDisponibles()
        {
            List<Moneda> listaMonedas = new List<Moneda>();
            using (var oContxto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT * FROM Moneda");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContxto))
                    {
                        oContxto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Moneda oMoneda = new Moneda();
                                oMoneda.MonedaID = Convert.ToInt32(reader["MonedaID"]);
                                oMoneda.Nombre = reader["Nombre"].ToString();
                                oMoneda.Simbolo = reader["Simbolo"].ToString();
                                oMoneda.Posicion = reader["Posicion"].ToString();
                                listaMonedas.Add(oMoneda);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener las monedas, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return listaMonedas;
        }

        // Alta Moneda
        public static bool AltaMonedaD(Moneda oMoneda)
        {
            bool alta = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Moneda (Nombre, Simbolo, Posicion) VALUES (@Nombre, @Simbolo, @Posicion)");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oMoneda.Nombre);
                        cmd.Parameters.AddWithValue("@Simbolo", oMoneda.Simbolo);
                        cmd.Parameters.AddWithValue("@Posicion", oMoneda.Posicion);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        alta = filasAfectadas > 0;
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrion un error al dar de alta la moneda, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return alta;
        }

        // Modificar Moneda
        public static bool ModificarMonedaD(Moneda oMoneda)
        {
            bool modificacion = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Moneda SET Nombre = @Nombre, Simbolo = @Simbolo, Posicion = @Posicion WHERE MonedaID = @MonedaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", oMoneda.Nombre);
                        cmd.Parameters.AddWithValue("@Simbolo", oMoneda.Simbolo);
                        cmd.Parameters.AddWithValue("@Posicion", oMoneda.Posicion);
                        cmd.Parameters.AddWithValue("@MonedaID", oMoneda.MonedaID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificacion = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al modificar la moneda, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return modificacion;
        }

        // Baja Moneda
        public static bool BajaMonedaD(int monedaID)
        {
            bool baja = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("DELETE FROM Moneda WHERE MonedaID = @MonedaID");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@MonedaID", monedaID);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        baja = filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al dar de baja la moneda, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return baja;
        }       

        // Obtener Moneda por ID
        public static Moneda ObtenerMonedaPorIDD(int monedaID)
        {
            Moneda oMoneda = new Moneda();
            using (var Ocontexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Moneda WHERE MonedaID = @MonedaID");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), Ocontexto))
                    {
                        cmd.Parameters.AddWithValue("@MonedaID", monedaID);
                        Ocontexto.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oMoneda.MonedaID = Convert.ToInt32(reader["MonedaID"]);
                                oMoneda.Nombre = reader["Nombre"].ToString();
                                oMoneda.Simbolo = reader["Simbolo"].ToString();
                                oMoneda.Posicion = reader["Posicion"].ToString();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener la moneda, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return oMoneda;
        }

        // Obtener moneda por nombre
        public static Moneda ObtenerMonedaPorNombre(string nombre)
        {
            Moneda oMoneda = new Moneda();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Moneda WHERE Nombre = @Nombre");
                    using(var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oMoneda.MonedaID = Convert.ToInt32(reader["MonedaID"]);
                                oMoneda.Nombre = reader["Nombre"].ToString();
                                oMoneda.Simbolo = reader["Simbolo"].ToString();
                                oMoneda.Posicion = reader["Posicion"].ToString();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener la moneda, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return oMoneda;
        }

        // Obtener Impuesto por ID
        public static Impuesto ObtenerImpuestoPorIDD(int impuestoID)
        {
            Impuesto oImpuesto = new Impuesto();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Impuesto");
                    // No existen más impuesto, si el usuario desea cambiar solo se modificará los datos
                    query.AppendLine("WHERE ImpuestoID = 1");
                    using(var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oImpuesto.ImpuestoID = Convert.ToInt32(reader["ImpuestoID"]);
                                oImpuesto.Nombre = reader["Nombre"].ToString();
                                oImpuesto.Porcentaje = Convert.ToDecimal(reader["Porcentaje"]);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener el impuesto, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return oImpuesto;
        }

        // Modificar impuesto
        public static bool ModificarImpuestoD(Impuesto impuesto)
        {
            bool modificado = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Impuesto SET Nombre = @Nombre, Porcentaje = @Porcentaje WHERE ImpuestoID = @ImpuestoID");
                    using(var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", impuesto.Nombre);
                        cmd.Parameters.AddWithValue("@Porcentaje", impuesto.Porcentaje);
                        // No existen más impuesto, si el usuario desea cambiar solo se modificará los datos
                        cmd.Parameters.AddWithValue("@ImpuestoID", 1);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al modificar el impuesto, contacte con el administrador del sistema si este error persiste.");
                }
            }
            return modificado;
        }

        // Negocio
        
        // Obtener datos del negocio
        public static NegocioModelo ObtenerDatosDelNegocioD()
        {
            NegocioModelo oNegocio = new NegocioModelo();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Negocio");
                    // Solo se leerá la primera ya que solo se tiene un negocio
                    query.AppendLine("WHERE NegocioID = 1");
                    using(var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();
                        using(var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oNegocio.NegocioID = Convert.ToInt32(reader["NegocioID"]);
                                oNegocio.Nombre = reader["Nombre"].ToString();
                                oNegocio.TipoDocumento = reader["TipoDocumento"].ToString();
                                oNegocio.Documento = reader["Documento"].ToString();
                                oNegocio.Direccion = reader["Direccion"].ToString();
                                oNegocio.Telefono = reader["Telefono"].ToString();
                                oNegocio.Correo = reader["Correo"].ToString();
                                oNegocio.Impuestos = Convert.ToBoolean(reader["Impuestos"]);
                                if (reader["Logo"] != DBNull.Value)
                                {
                                    oNegocio.Logo = (byte[])reader["Logo"];
                                }
                                
                                oNegocio.Moneda = new Moneda();
                                oNegocio.Moneda.MonedaID = Convert.ToInt32(reader["MonedaID"]);

                                oNegocio.Impuesto = new Impuesto();
                                oNegocio.Impuesto.ImpuestoID = Convert.ToInt32(reader["ImpuestoID"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return oNegocio;
        }

        // Modificar datos del negocio
        public static bool ModificarNegocioD(NegocioModelo negocio)
        {
            bool modificado = false;
            using (var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Negocio SET Nombre = @Nombre, TipoDocumento = @TipoDocumento, Documento = @Documento, Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo, Impuestos = @Impuestos, Logo = @Logo, MonedaID = @MonedaID, ImpuestoID = @ImpuestoID WHERE NegocioID = @NegocioID");
                    using (var cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", negocio.Nombre);
                        cmd.Parameters.AddWithValue("@TipoDocumento", negocio.TipoDocumento);
                        cmd.Parameters.AddWithValue("@Documento", negocio.Documento);
                        cmd.Parameters.AddWithValue("@Direccion", negocio.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", negocio.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", negocio.Correo);
                        cmd.Parameters.AddWithValue("@Impuestos", negocio.Impuestos);
                        if (negocio.Logo != null)
                        {
                            cmd.Parameters.AddWithValue("@Logo", negocio.Logo);
                        }
                        else
                        {
                            cmd.Parameters.Add("@Logo", SqlDbType.VarBinary, -1);
                            cmd.Parameters["@Logo"].Value = DBNull.Value;
                        }
                        cmd.Parameters.AddWithValue("@MonedaID", negocio.Moneda.MonedaID);
                        cmd.Parameters.AddWithValue("@ImpuestoID", negocio.Impuesto != null ? negocio.Impuesto.ImpuestoID : 1); // Impuesto por defecto es 1
                        cmd.Parameters.AddWithValue("@NegocioID", 1);
                        oContexto.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        modificado = filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return modificado;
        }

    }
}
