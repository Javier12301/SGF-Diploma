using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class ModuloDAO
    {
        public static Modulo ObtenerModuloD(string Descripcion)
        {
            Modulo oModulo = new Modulo();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * FROM Modulo");
                    query.AppendLine("WHERE Descripcion = @Descripcion");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oModulo.ModuloID = Convert.ToInt32(reader["ModuloID"]);
                                oModulo.Descripcion = reader["Descripcion"].ToString();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener el módulo. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return oModulo;
        }

        // Obtener modulos disponibles
        public static List<Modulo> ObtenerModulosDisponiblesD()
        {
            List<Modulo> modulos = new List<Modulo>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    // Se debe también tener en cuenta ModuloID
                    query.AppendLine("SELECT * FROM Modulo");
                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        oContexto.Open();

                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Modulo modulo = new Modulo();
                                modulo.ModuloID = Convert.ToInt32(reader["ModuloID"]);
                                modulo.Descripcion = reader["Descripcion"].ToString();
                                modulos.Add(modulo);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return modulos;
                }
            }
            return modulos;
        }

        public static List<Accion> ObtenerAccionesDeModuloD(string moduloDescripcion)
        {
            List<Accion> acciones = new List<Accion>();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT op.* FROM Accion op");
                    query.AppendLine("INNER JOIN Modulo m ON m.ModuloID = op.ModuloID");
                    query.AppendLine("WHERE m.Descripcion = @moduloDescripcion");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@moduloDescripcion", moduloDescripcion);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Accion accion = new Accion();
                                accion.AccionID = Convert.ToInt32(reader["AccionID"]);
                                accion.Descripcion = reader["Descripcion"].ToString();
                                acciones.Add(accion);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al obtener las acciones disponibles del módulo, si este error persiste contacte con el administrador del sistema.");
                }
            }
            return acciones;
        }
    }
}
