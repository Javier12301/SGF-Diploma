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

namespace SGF.NEGOCIO
{
    public class UsuarioBLL
    {
        // Singleton de cSeguridad
        private static UsuarioBLL _instancia = null;
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
            bool existeUsuario = UsuarioDAO.ExisteUsuarioD(nombreUsuario);
            if (existeUsuario)
            {
                return true;
            }
            else
            {
                // Excepción indicando que el usuario no existe
                throw new Exception("El usuario ingresado no existe.");
            }
        }


        public bool Existe_Usuario_Mail(string nombreUsuario, string email)
        {
            bool existeUsuarioMail = UsuarioDAO.ExisteUsuarioMailD(nombreUsuario, email);
            if (existeUsuarioMail)
            {
                return true;
            }
            else
            {
                // Excepción indicando que el usuario o el correo electrónico no existen
                throw new Exception("Usuario y/o correo electrónico ingresados no existen.");
            }
        }


        public Usuario ObtenerUsuario(string nombreUsuario)
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

        public bool ModificarUsuario(Usuario oUsuario)
        {
            if (oUsuario != null)
            {
                return UsuarioDAO.ModificarUsuarioD(oUsuario);
            }
            else
            {
                // Excepción indicando que el objeto de usuario es nulo
                throw new ArgumentNullException("El objeto de usuario para modificar no puede ser nulo, contactar con el adminsitrador si el error persiste.");
            }
        }

    }
}
