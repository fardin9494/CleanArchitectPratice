using HRManagement.Application.DTOs;
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
