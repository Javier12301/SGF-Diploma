using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.DATOS.Seguridad
{
    public class BackupDAO
    {
        // generar backup
        public static string GenerarBackup()
        {
            string mensaje = "";
            string nombreArchivo = "SGF" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
            using(SqlConnection oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                /*BACKUP DATABASE [FarmaciaDatos] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\FarmaciaDatos.bak' WITH NOFORMAT, NOINIT,  NAME = N'FarmaciaDatos-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
*/
                query.AppendLine("BACKUP DATABASE [FarmaciaDatos] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL16.MSSQLSERVER\\MSSQL\\Backup\\" + nombreArchivo + "' WITH NOFORMAT, NOINIT,  NAME = N'SGF-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");
                try
                {
                    oContexto.Open();
                    SqlCommand cmd = new SqlCommand(query.ToString(), oContexto);
                    cmd.ExecuteNonQuery();
                    mensaje = "Backup generado con éxito";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al generar el backup: " + ex.Message;
                }
                finally
                {
                    oContexto.Close();
                }
            }
            return mensaje;
        }

        // se deberá cambiar por parametros la dirección DISK para crear un tipo explorador de archivos
        public static string RestaurarBackup(string direccion)
        {
            string mensaje = "";
            using (SqlConnection oContexto = new SqlConnection(ConexionSGF.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("USE master");
                query.AppendLine("ALTER DATABASE [FarmaciaDatos] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                query.AppendLine("RESTORE DATABASE [FarmaciaDatos] FROM  DISK = N'" + direccion + "' WITH  FILE = 1, REPLACE ,NOUNLOAD,  STATS = 5");
                query.AppendLine("ALTER DATABASE [FarmaciaDatos] SET MULTI_USER");
                try
                {
                    oContexto.Open();
                    SqlCommand cmd = new SqlCommand(query.ToString(), oContexto);
                    cmd.ExecuteNonQuery();
                    mensaje = "Backup restaurado con éxito";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al restaurar el backup: " + ex.Message;
                }
                finally
                {
                    oContexto.Close();
                }
            }
            return mensaje;
        }
    }
}
