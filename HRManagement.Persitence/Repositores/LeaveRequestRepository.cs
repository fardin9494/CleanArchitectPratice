using HRManagement.Application.Persistence.Cortract;
using HRManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persitence.Repositores
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementContext _context;
        public LeaveRequestRepository(LeaveManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest selectedRequest, bool? ApprovalStatus)
        {
            selectedRequest.IsAproved = ApprovalStatus;
            _context.Entry(selectedRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetail(int id)
        {
            return await _context.LeaveRequests.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRquestwithDeatailList()
        {
            return await _context.LeaveRequests.Include(x => x.Type).ToListAsync();
        }
    }
}
