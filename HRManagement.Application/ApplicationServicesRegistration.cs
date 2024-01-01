using HRManagement.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using HRManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRManagement.Application.Features.LeaveTypes.Handlers.Queries;

namespace HRManagement.Application
{
    public static class ApplicationServicesRegistration
    {

        public static void AplicationServiceConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
