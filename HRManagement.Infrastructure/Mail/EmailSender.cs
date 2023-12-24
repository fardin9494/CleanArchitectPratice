using HRManagement.Application.Contract.Infrastructure;
using HRManagement.Application.Model;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSetting _emailSetting;
        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmailAsync(Email mail)
        {
            var Client = new SendGridClient(_emailSetting.ApiKey);
            var To = new EmailAddress(mail.To);
            var From = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };

            var message = MailHelper.CreateSingleEmail(From, To,mail.Subject,mail.Body,mail.Body);
            var response =await Client.SendEmailAsync(message);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
