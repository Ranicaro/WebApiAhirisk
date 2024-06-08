using System.Net.Mail;
using System.Net;
using WebApiAhirisk.Utils;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Infrastructure.Data;
using ApplicationCore.Interfaces.Configuracion.Email;
using Microsoft.EntityFrameworkCore;
using WebApiAhirisk.Models.Seguridad;

namespace WebApiAhisrisk.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly DBAhiriskV1Context _context;
        public EmailService(IConfiguration configuration, DBAhiriskV1Context context)
        {
            _context = context;
            _configuration = configuration;

        }
        public async Task<bool> SendAsync(string body, string subject, IEnumerable<string> to, TextFormat textFormat = TextFormat.Html, MimeKit.AttachmentCollection attachments = null)
        {
            try
            {
                var credential = await GetCredentialAsync();
                if (await SendAsync(body, subject, to, credential, textFormat, attachments))
                {
                    await UpdateCredentialUsages(credential.Id);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("Error en EmailService en el Metodo SendAsync ", ex);
                throw;
            }
        }
        private async Task<bool> SendAsync(string body, string subject, IEnumerable<string> destinatarios, NetworkCredential credential, TextFormat textFormat = TextFormat.Html, MimeKit.AttachmentCollection attachments = null)
        {
            try
            {
                if (destinatarios == null || !destinatarios.Any())
                {
                    await GenericUtils.Log("EmailService: Error en el service la lista de destinatarios viene vacio, que tiene el body " + body + " Subject " + subject);
                }
                TextPart bodyPart = new(textFormat) { Text = body };

                MimeMessage message = new() { Subject = subject };
                message.To.AddRange(destinatarios.Select(MailboxAddress.Parse));

                if (attachments != null)
                {
                    Multipart multipart = new("mixed");
                    multipart.Add(bodyPart);
                    //attachments.ForEach(multipart.Add);
                    //message.Body = multipart;
                    foreach (var attachment in attachments)
                    {
                        multipart.Add(attachment);
                    }
                    message.Body = multipart;
                }
                else
                {
                    message.Body = bodyPart;
                }

                // Establecer el remitente
                message.From.Add(new MailboxAddress("Ahirisk", credential.UserName));
                try
                {
                    using MailKit.Net.Smtp.SmtpClient client = new();
                    await client.ConnectAsync(_configuration["Email:Host"], _configuration.GetValue<int>("Email:Port"));
                    await client.AuthenticateAsync(credential);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    return true;
                }
                catch (Exception ex)
                {
                    await GenericUtils.Log("Error en EmailService en el envío de correos", ex);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task<EmailCredential> GetCredentialAsync(int? iIDEmailNotificacion = null)
        {
            try
            {
                var email = await _context.tblEmailNotificaciones.Where(x => x.bActivo == true && x.iIDEmailNotificacion == iIDEmailNotificacion).FirstOrDefaultAsync();
                if (email == null)
                    return new(0, _configuration["Email:Username"], _configuration["Email:Password"]);

                return new(email.iIDEmailNotificacion, email.tEmail, email.tContrasena);
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("Error en EmailService en el Metodo GetCredentialAsync", ex);
                throw;
            }
        }
        private async Task UpdateCredentialUsages(int iIDEmailNotificacion)
        {
            try
            {
                var email = await _context.tblEmailNotificaciones.Where(x => x.bActivo == true && x.iIDEmailNotificacion == iIDEmailNotificacion).FirstOrDefaultAsync();
                if (email == null)
                    return;
                email.iConteoEnvios = (email.iConteoEnvios ?? 0) + 1;
                _context.Entry(email).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await GenericUtils.Log("Error en EmailService en el Metodo UpdateCredentialUsages ", ex);
                throw;
            }
        }
        public class EmailCredential : NetworkCredential
        {
            public int Id { get; private set; }

            public EmailCredential(int id, string userName, string password) : base(userName, password)
            {
                Id = id;
            }
        }
        //---
    }
}