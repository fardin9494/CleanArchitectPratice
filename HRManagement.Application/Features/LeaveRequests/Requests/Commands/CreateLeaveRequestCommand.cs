﻿using HRManagement.Application.DTOs.LeaveRequestDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveRequests.Requests.Commands
{
    internal class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDto  createLeaveRequest { get; set; }
    }
}
