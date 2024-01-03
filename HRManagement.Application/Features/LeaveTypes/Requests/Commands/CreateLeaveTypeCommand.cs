using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
       public CreateLeaveTypeDto leaveTypeDto {  get; set; }
    }
}
