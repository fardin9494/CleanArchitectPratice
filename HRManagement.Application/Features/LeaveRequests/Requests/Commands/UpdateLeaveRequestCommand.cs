using HRManagement.Application.DTOs.LeaveRequestDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Commands
{
    internal class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto updateleaveRequestDto { get; set; }

        public ChangeLeaveRequestAprovealDto changeLeaveRequestAproveal { get; set; }
    }
}
