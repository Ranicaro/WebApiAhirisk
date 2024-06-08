using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;

namespace ApplicationCore.Interfaces.Configuracion.Email
{
    public interface IEmailService
    {
        public Task<bool> SendAsync(string body, string subject, IEnumerable<string> receivers, TextFormat textFormat, MimeKit.AttachmentCollection attachments = null);

    }
}