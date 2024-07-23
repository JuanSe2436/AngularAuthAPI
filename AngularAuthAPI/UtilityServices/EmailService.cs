using System;
using AngularAuthAPI.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace AngularAuthAPI.UtilityServices
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration configuration) 
        {
            _config = configuration;
        }
        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            var from = _config["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("Let Program", from));
            emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(emailModel.Content)
            };

            using(var client = new SmtpClient()) 
            {
                try
                {
                    var correo = _config["EmailSettings:From"];
                    var password = _config["EmailSettings:Password"];

                    client.Connect(_config["EmailSettings:SmtpServer"], 465, true);
                    client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
