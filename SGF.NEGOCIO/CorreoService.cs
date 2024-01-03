using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO
{
    public class CorreoService
    {
        private readonly string smtpServer = "smtp.outlook.com";
        private readonly int smtpPort = 587;
        private readonly string emailFrom = ConfigurationManager.AppSettings["Email"];
        private readonly string emailPassword = ConfigurationManager.AppSettings["Contraseña"];

        public bool EnviarMail(string nombreUsuario, string email, string claveGenerada)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    StringBuilder htmlBuilder = new StringBuilder();
                    htmlBuilder.AppendLine("<h2 style='color:#4d8bd0'>Sistema Gestión Farmacéutica</h2>");
                    htmlBuilder.AppendLine("<h1>Confirmación de correo electrónico</h1>");
                    htmlBuilder.AppendLine($"<p><b>Tu nombre de usuario es: </b>{nombreUsuario}</p>");
                    htmlBuilder.AppendLine($"<p><b>Tu clave generada es: </b>{claveGenerada}</p>");
                    htmlBuilder.AppendLine("<p>Si no reconoces esta actividad, por favor ignórala.</p>");
                    htmlBuilder.AppendLine("Gracias.");

                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(email);
                    mail.Subject = "Recuperar contraseña - Sistema de Gestión Farmacéutica";
                    mail.Body = htmlBuilder.ToString();
                    mail.IsBodyHtml = true;

                    smtp.Credentials = new NetworkCredential(emailFrom, emailPassword);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception )
            {
                // Manejar otras excepciones aquí
                return false;
            }
        }
    }
}
