using HRManagement.Application.Contract.Persistence;
using HRManagement.Persitence.Repositores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persitence
{
    public static class PersitenceServiceRegistration
    {
        public static IServiceCollection PersistenceServiceConfigure(this IServiceCollection services,IConfiguration configuration)
        {
          

            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<ILeaveAllocationRepository , LeaveAllocationRepository>();
            services.AddScoped<ILeaveTypeRepository , LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository , LeaveRequestRepository>();

            services.AddDbContext<LeaveManagementContext>(x => x.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));

            return services;
        } 
    }
}
