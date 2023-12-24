using HRManagement.Application.Contract.Infrastructure;
using HRManagement.Application.Model;
using HRManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection InfrastructureServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        } 
    }
}
