using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class BackupBLL
    {
        public static string GenerarBackup()
        {
            return SGF.DATOS.Seguridad.BackupDAO.GenerarBackup();
        }

        public static string RestaurarBackup(string direccion)
        {
            return SGF.DATOS.Seguridad.BackupDAO.RestaurarBackup(direccion);
        }
    }
}
