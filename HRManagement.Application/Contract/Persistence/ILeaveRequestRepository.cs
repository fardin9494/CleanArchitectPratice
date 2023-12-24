﻿using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Contract.Persistence
{
    public interface ILeaveRequestRepository:IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRquestwithDeatailList();

        Task<LeaveRequest> GetLeaveRequestWithDetail(int  id);
        
        Task ChangeApprovalStatus(LeaveRequest selectedRequest, bool? ApprovalStatus);
    }
}
