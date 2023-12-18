using SGF.DATOS.Seguridad;
using SGF.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace SGF.NEGOCIO
{
    public class N_Usuario
    {
        // Testearemos el sistema, haremos una instancia del contexto de la base de datos

        // Singleton de cSeguridad
        private static N_Usuario _instancia = null;
        private N_Usuario() { }
        public static N_Usuario ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new N_Usuario();
                return _instancia;
            }
        }
        D_Usuario D_Usuario = new D_Usuario();

        // Obtener tabla de Usuarios
        public List<Usuario> ListarUsuario()
        {
            return D_Usuario.ListarUsuarioD();
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            return D_Usuario.ExisteUsuarioD(nombreUsuario);
        }

        public bool Existe_Usuario_Mail(string nombreUsuario, string email)
        {
            return D_Usuario.Existe_Usuario_MailD(nombreUsuario, email);
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            return D_Usuario.ObtenerUsuarioD(nombreUsuario);
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
            var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = caracteres[random.Next(stringChars.Length)];
            }
            return new String(stringChars);
        }

        // Enviar mail para recuperar contraseña
        public bool EnviarMail(string nombreUsuario, string email, string claveGenerada)
        {
            try
            {
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.AppendLine("<h2 style='color:#4d8bd0'>Sistema Gestión Farmacéutica</h2>");
                htmlBuilder.AppendLine("<h1>Confirmación de correo electrónico</h1>");
                htmlBuilder.AppendLine("<p><b>Tu nombre de usuario es: </b></p>");
                htmlBuilder.AppendLine(nombreUsuario);
                htmlBuilder.AppendLine("<p><b>Tu clave generada es: </b></p>");
                htmlBuilder.AppendLine(claveGenerada);
                htmlBuilder.AppendLine("<p>Si no reconoces esta actividad, por favor ignórala.</p>");
                htmlBuilder.AppendLine("Gracias.");
                // Crear el correo
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("javierramirez1230123@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Recuperar contraseña - Sistema de Gestión Farmacéutica";
                mail.Body = htmlBuilder.ToString();
                mail.IsBodyHtml = true;

                // Configurar cliente SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("")
            }

        }
    }
}
