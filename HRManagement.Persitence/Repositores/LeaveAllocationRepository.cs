using HRManagement.Application.Contract.Persistence;
using HRManagement.Domain;

namespace HRManagement.Persitence.Repositores
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementContext _context;
        public LeaveAllocationRepository(LeaveManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
