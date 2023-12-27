using HRManagement.Persitence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HRManagement.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LeaveManagementContext>
    {
        public LeaveManagementContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LeaveManagementContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");
            builder.UseSqlServer(connectionString);

            return new LeaveManagementContext(builder.Options);
        }
    }
}