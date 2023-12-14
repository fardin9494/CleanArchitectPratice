using AutoMapper;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    internal class GetLEaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;

        public GetLEaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var selectedLeaveType = await _leaveTypeRepository.GetById(request.Id);
            return _mapper.Map<LeaveTypeDto>(selectedLeaveType);

        }
    }
}
