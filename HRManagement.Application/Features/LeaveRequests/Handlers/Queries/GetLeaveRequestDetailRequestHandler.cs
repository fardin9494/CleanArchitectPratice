using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRManagement.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    internal class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailrequest, LeaveRequestDto>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailrequest request, CancellationToken cancellationToken)
        {
            var requestDetail = await _leaveRequestRepository.GetLeaveRequestWithDetail(request.Id);
            return _mapper.Map<LeaveRequestDto>(requestDetail);
        }
    }
}
