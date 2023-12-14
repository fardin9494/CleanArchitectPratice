using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    internal class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRquestwithDeatailList();
            return _mapper.Map<List<LeaveRequestListDto>>(leaveRequest);
        }
    }
}
