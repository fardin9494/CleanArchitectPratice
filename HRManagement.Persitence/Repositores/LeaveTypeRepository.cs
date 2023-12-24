using HRManagement.Application.Contract.Persistence;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Persitence.Repositores
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementContext _context;
        public LeaveTypeRepository(LeaveManagementContext context) : base(context)
        {
            _context = context;
        }
    }
}
