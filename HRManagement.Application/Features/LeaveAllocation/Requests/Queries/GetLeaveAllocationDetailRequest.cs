using HRManagement.Application.DTOs.LeaveAllocationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveAllocation.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest:IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
