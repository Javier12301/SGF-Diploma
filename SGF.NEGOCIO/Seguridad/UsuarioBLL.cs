using SGF.DATOS.Seguridad;
using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Net;
using SGF.MODELO.Seguridad;
using SGF.NEGOCIO.Seguridad;

namespace SGF.NEGOCIO
{
    public class UsuarioBLL
    {
        // Singleton de cSeguridad
        private static UsuarioBLL _instancia = null;
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        private UsuarioBLL() { }
        public static UsuarioBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new UsuarioBLL();
                return _instancia;
            }
        }

        // Alta Usuario
        public bool AltaUsuario(Usuario oUsuario)
        {
            if (oUsuario != null)
            {
                if (UsuarioDAO.AltaUsuarioD(oUsuario))
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", "Sistema", $"Se dio de alta con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se dio de alta con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    return true;
                }
                else
                {
                    if(lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Alta", "Sistema", "Error al dar de alta al usuario.");
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

        // Modificar Usuario
        public bool ModificarUsuario(Usuario oUsuario)
        {
            if (oUsuario != null)
            {
                if (UsuarioDAO.ModificarUsuarioD(oUsuario))
                {
                    // Revisar si la sesion fue iniciada, sino fue iniciada, la auditoria tiene que poner de nombre de usuario al Sistema que modifico el usuario
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificación", "Sistema", $"Se modifico con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se modifico con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    return true;
                }
                else
                {
                    if (lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificación", "Sistema", "Error al modificar el usuario.");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al modificar el usuario.");
                    }
                    return false;
                }
            }
            else
            {
                // Excepción indicando que el objeto de usuario es nulo
                AuditoriaBLL.RegistrarMovimiento("Modificación", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al modificar el usuario.");
                throw new ArgumentNullException("El objeto de usuario para modificar no puede ser nulo, contactar con el adminsitrador si el error persiste.");
            }
        }
        // Baja Usuario
        public bool BajaUsuario(int usuarioID)
        {
            // el usuarioID debe ser mayor a 0 y distinto a 1 (el usuario administrador)
            if (usuarioID > 0 && usuarioID != 1)
            {
                Usuario oUsuario = ObtenerUsuarioPorID(usuarioID);
                if (UsuarioDAO.BajaUsuarioD(usuarioID))
                {
                    if(lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Baja", "Sistema", $"Se dio de baja con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), $"Se dio de baja con éxito al usuario: {oUsuario.NombreUsuario}");
                    }
                    return true;
                }
                else
                {
                    if(lSesion.UsuarioEnSesion() == null)
                    {
                        AuditoriaBLL.RegistrarMovimiento("Baja", "Sistema", "Error al dar de baja al usuario.");
                    }
                    else
                    {
                        AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Error al dar de baja al usuario.");
                    }
                    return false;
                }
            }
            else if (usuarioID == 1)
            {
                AuditoriaBLL.RegistrarMovimiento("Baja", lSesion.UsuarioEnSesion().Usuario.ObtenerNombreUsuario(), "Se intento dar de baja al usuario Administrador.");
                throw new Exception("No se puede eliminar el usuario administrador.");
            }
            else
            {
                throw new Exception("El usuarioID ingresado es incorrecto, contactar con el administrador si el error persiste.");
            }
        }


        // Obtener tabla de Usuarios
        public List<Usuario> ListarUsuario()
        {
            List<Usuario> listaUsuarios = UsuarioDAO.ListarUsuarioD();
            if (listaUsuarios != null && listaUsuarios.Count > 0)
            {
                return listaUsuarios;
            }
            else
            {
                // Excepción indicando que no hay usuarios para listar
                throw new Exception("No hay usuarios para listar en este momento.");
            }
        }


        public bool ExisteUsuario(string nombreUsuario)
        {
            bool existeUsuario = UsuarioDAO.ExisteNombreUsuarioD(nombreUsuario);
            return existeUsuario;
        }

        public bool ExisteEmail(string email)
        {
            bool existeEmail = UsuarioDAO.ExisteEmailD(email);
            return existeEmail;
        }


        public bool ExisteUsuarioConEmail(string nombreUsuario, string email)
        {
            bool existeUsuarioMail = UsuarioDAO.ExisteUsuarioConEmailD(nombreUsuario, email);
            return existeUsuarioMail;
        }

        public Usuario ObtenerUsuarioPorID(int usuarioID)
        {
            Usuario oUsuario = UsuarioDAO.ObtenerUsuarioPorIDD(usuarioID);
            if (oUsuario != null)
            {
                return oUsuario;
            }
            else
            {
                // excepción diciendo que el usuario ingresado no existe
                throw new Exception("El usuario ingresado no existe, contactar con el administrador si el error persiste.");
            }
        }

        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            Usuario oUsuario = UsuarioDAO.ObtenerUsuarioD(nombreUsuario);
            if (oUsuario != null)
            {
                return oUsuario;
            }
            else
            {
                // excepción diciendo que el usuario ingresado no existe
                throw new Exception("El usuario ingresado no existe, contactar con el administrador si el error persiste.");
            }
        }

        public string EncriptarClave(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(str));
            string hashString = BitConverter.ToString(hashValue).Replace("-", "");
            return hashString;
        }

        public string GenerarCodigo()
        {
            var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new String(stringChars);
        }



    }
}
