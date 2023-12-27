using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto  createLeaveRequest { get; set; }
    }
}
