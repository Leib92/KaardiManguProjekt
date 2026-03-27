using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Dto;
using KaardiManguProject.Core.ServiceInterface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using EnvironmentT = KaardiManguProject.Data.Environment;

namespace KaardiManguProject.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;
        public EmailsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(EmailDTO dto)
        {
            var email = new MimeMessage();
            _configuration.GetSection("EmailUserName").Value = EnvironmentT.gmailusername;
            _configuration.GetSection("EmailHost").Value = EnvironmentT.smtpaddress;
            _configuration.GetSection("EmailPassword").Value = EnvironmentT.gmailpassword;

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.SendToThisAddress));
            email.Subject = dto.EmailSubject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.EmailContent,
            };
            email.Body=builder.ToMessageBody();
            using var smtp = new SmtpClient();

            smtp.Connect(_configuration.GetSection("EmailHost").Value,587,MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
