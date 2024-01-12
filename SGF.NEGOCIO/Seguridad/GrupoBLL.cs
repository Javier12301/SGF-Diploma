using SGF.DATOS.Seguridad;
using SGF.MODELO;
using SGF.MODELO.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Seguridad
{
    public class GrupoBLL
    {
        // Singleton de cGrupo
        private static GrupoBLL _instancia = null;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private GrupoBLL() { }
        public static GrupoBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GrupoBLL();
                return _instancia;
            }
        }

        // Alta grupo
        public bool AltaGrupo(Grupo oGrupo)
        {
            if (oGrupo != null)
            {
                if (GrupoDAO.AltaGrupoD(oGrupo))
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", "Sistema", $"Se dio de alta con exito al grupo: {oGrupo.Nombre}");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se dio de alta con exito al grupo: {oGrupo.Nombre}");
                    }
                    return true;
                }
                else
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", "Sistema", "Error al dar de alta al grupo.");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al dar de alta al usuario.");
                    }
                    return false;
                }
            }
            else
            {
                // Excepción indicando que el objeto de usuario es nulo
                AuditoriaBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al dar de alta al usuario.");
                throw new ArgumentNullException("Se ha producido un error: el campo de usuario no puede estar vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }


        // Modificar grupo
        public bool ModificarGrupo(Grupo oGrupo)
        {
            if (oGrupo != null)
            {
                if (GrupoDAO.ModificarGrupoD(oGrupo))
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificacion", "Sistema", $"Se modifico con exito al grupo: {oGrupo.Nombre}");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificacion", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se modifico con exito al grupo: {oGrupo.Nombre}");
                    }
                    return true;
                }
                else
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificacion", "Sistema", "Error al modificar al grupo.");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificacion", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al modificar al grupo.");
                    }
                    return false;
                }
            }
            else
            {
                // Excepción indicando que el objeto de usuario es nulo
                AuditoriaBLL.RegistrarMovimiento("Modificacion", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al modificar al grupo.");
                throw new ArgumentNullException("Se ha producido un error: el campo de usuario no puede estar vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Baja grupo
        public bool BajaGrupo(Operacion operacion)
        {
            bool resultado = true;
            switch (operacion.NombreOperacion)
            {
                case "EliminarGrupo":
                    return EliminarGrupo(operacion);
                case "AsignarUsuariosSinGrupo":
                    resultado &= AsignarUsuarioSinGrupo(operacion);
                    resultado &= EliminarGrupo(operacion);
                    return resultado;
                case "EliminarGrupoYUsuarios":
                    List<int> listaUsuarioID = ListarUsuariosIDEnGrupoD(operacion.ID);
                    foreach(var usuarioID in listaUsuarioID)
                    {
                        resultado &= UsuarioBLL.ObtenerInstancia.BajaUsuario(usuarioID);
                    }
                    resultado &= EliminarGrupo(operacion);
                    return resultado;

                default:
                    throw new Exception("Ocurrió un error al intentar eliminar el grupo, contacte con el administrador del sistema si este error persiste.");
            }
        }

        public List<int> ListarUsuariosIDEnGrupoD(int grupoID)
        {
            List<int> listaUsuarioID = GrupoDAO.ListarUsuariosEnGrupoD(grupoID);
            return listaUsuarioID;
        }

        private bool AsignarUsuarioSinGrupo(Operacion operacion)
        {
            bool resultado = true;
            List<int> listaUsuarioID = ListarUsuariosIDEnGrupoD(operacion.ID);
            foreach(var usuarioID in listaUsuarioID)
            {
                resultado &= GrupoDAO.AsignarUsuarioSinGrupoD(usuarioID);
            }
            return resultado;
        }

        private bool EliminarGrupo(Operacion operacion)
        {
            int grupoID = operacion.ID;

            // Comprobar si el grupo tiene permisos asignados
            bool tienePermisos = PermisoBLL.ObtenerInstancia.GrupoTienePermisos(grupoID);

            if (tienePermisos)
            {
                // Desactivar permisos antes de eliminar el grupo
                PermisoBLL.ObtenerInstancia.DesactivarPermisos(grupoID);
            }

            // Realizar la eliminación del grupo
            bool eliminacionExitosa = GrupoDAO.BajaGrupoD(grupoID);

            if (eliminacionExitosa)
            {
                if (lSesion.UsuarioEnSesion() == null)
                {
                    AuditoriaBLL.RegistrarMovimiento("Baja", "Sistema", $"Se eliminó con éxito al grupo: {operacion.Nombre}");
                }
                else
                {
                    AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se eliminó con éxito al grupo: {operacion.Nombre}");
                }
            }
            else
            {
                if (lSesion.UsuarioEnSesion() == null)
                {
                    AuditoriaBLL.RegistrarMovimiento("Baja", "Sistema", $"Error al eliminar el grupo: {operacion.Nombre}");
                }
                else
                {
                    AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Error al eliminar el grupo: {operacion.Nombre}");
                }
            }

            return eliminacionExitosa;
        }


        // Comprobar si el grupo tiene usuarios asignados
        public bool GrupoTieneUsuarios(int grupoID)
        {
            if (grupoID > 0)
            {
                return GrupoDAO.GrupoTieneUsuariosD(grupoID);
            }
            else
            {
                throw new Exception("Ocurrió un error al comprobar si el grupo tiene usuarios asignados, contacte con el administrador del sistema si este error persiste.");
            }
        }

        // Obtener lista de grupos existentes
        public List<Grupo> ListarGrupos()
        {
            List<Grupo> gruposExistentes = GrupoDAO.ListarGruposD();
            if(gruposExistentes != null)
            {
                return gruposExistentes;
            }
            else
            {
                throw new Exception("Ocurrio un error inesperado al listar grupos, contactar con el administrador si este error persiste.");
            }
        }

        public bool ExisteGrupo(string nombreGrupo)
        {
            bool existeGrupo = GrupoDAO.ExisteGrupoD(nombreGrupo);
            return existeGrupo;
        }

        // Permisos que tiene este grupo
        public static List<Accion> ListarAccionesDisponibles(int usuarioID, Modulo descripcion)
        {
            List<Accion> acciones = new List<Accion>();
            return  acciones;
        }

        // Obtener los modulos permitido del grupo
        public List<Modulo> ObtenerModulosPermitidos(int grupoID)
        {
            List<Modulo> modulosPermitidos = GrupoDAO.ObtenerModulosPermitidosD(grupoID);
            if (modulosPermitidos != null)
            {
                return modulosPermitidos;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar obtener los permisos, contactar con el administrador si el error persiste.");
            }
        }

        public Grupo ObtenerGrupoPorID(int grupoID)
        {
            Grupo oGrupo = GrupoDAO.ObtenerGrupoPorIDD(grupoID);
            if(oGrupo != null)
            {
                return oGrupo;
            }
            else
            {
                throw new Exception("El grupo ingresado no existe, contactar con el administrador si el error persiste.");
            }
        }

        public Grupo ObtenerGrupoPorNombre(string nombre)
        {
            Grupo grupo = GrupoDAO.ObtenerGrupoNombreD(nombre);
            if(grupo != null)
            {
                return grupo;
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar obtener el grupo, contactar con el administrador si el error persiste.");
            }
        }
    }
}
