using AutoMapper;
using HRManagement.Application.DTOs.LeaveAllocationDtos;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    { 
        public CreateLeaveAllocationDto CreateLeaveAllocation { get; set; }
    }
}
