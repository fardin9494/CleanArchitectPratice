using HRManagement.Application.DTOs.LeaveRequestDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Queries
{
    internal class GetLeaveRequestDetailrequest:IRequest<LeaveRequestDto>
    {
        public int Id { get; set;}
    }
}
