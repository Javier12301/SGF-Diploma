using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class PermisoDAO
    {
        public static bool AltaPermisoD(Permiso permiso)
        {
            bool alta = false;
            using(var oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("INSERT INTO Permiso (GrupoID, AccionID, Permitido) VALUES (@grupoID, @accionID, @permitido)");
                    using(SqlCommand cmd = new SqlCommand(query.ToString(), oContexto))
                    {
                        cmd.Parameters.AddWithValue("@grupoID", permiso.Grupo.GrupoID);
                        cmd.Parameters.AddWithValue("@accionID", permiso.Accion.AccionID);
                        cmd.Parameters.AddWithValue("@permitido", permiso.Permitido);
                        oContexto.Open();
                        int filaAfectada = cmd.ExecuteNonQuery();
                        alta = filaAfectada > 0;
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Se ha producido un error al intentar registrar el nuevo permiso. Por favor, vuelva a intentarlo y, si el problema persiste, póngase en contacto con el administrador del sistema.");
                }
            }
            return alta;
        }




    }
}
