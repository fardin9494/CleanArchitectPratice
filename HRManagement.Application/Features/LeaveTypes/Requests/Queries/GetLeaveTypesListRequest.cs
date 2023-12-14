using HRManagement.Application.DTOs.LeaveTypeDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypesListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
