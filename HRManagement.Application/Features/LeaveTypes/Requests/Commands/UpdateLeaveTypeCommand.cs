using AutoMapper;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
