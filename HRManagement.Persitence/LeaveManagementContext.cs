using HRManagement.Domain;
using HRManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Persitence
{
    public class LeaveManagementContext : DbContext
    {
       

        public LeaveManagementContext(DbContextOptions<LeaveManagementContext> option) : base(option)
        {
            
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
           foreach(var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.ModificationDate = DateTime.Now;

                if(entity.State == EntityState.Added)
                {
                    entity.Entity.CreationDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
