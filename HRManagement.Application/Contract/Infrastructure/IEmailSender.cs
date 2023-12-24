using HRManagement.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Contract.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(Email mail);
    }
}
