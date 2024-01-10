using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class AccionDAO
    {
        public static Accion ObtenerAccionD(string NombreModulo, string NombreAccion)
        {
            Accion oAccion = new Accion();
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT A.*");
                    query.AppendLine("FROM Accion A");
                    query.AppendLine("INNER JOIN Modulo M ON A.ModuloID = M.ModuloID");
                    query.AppendLine("WHERE M.Descripcion = @NombreModulo AND A.Descripcion = @NombreAccion");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@NombreModulo", NombreModulo);
                        cmd.Parameters.AddWithValue("@NombreAccion", NombreAccion);
                        oContexto.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oAccion.AccionID = Convert.ToInt32(reader["AccionID"]);
                                oAccion.Descripcion = reader["Descripcion"].ToString();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Ocurrió un error al intentar obtener la acción. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return oAccion;
        }
    }
}
