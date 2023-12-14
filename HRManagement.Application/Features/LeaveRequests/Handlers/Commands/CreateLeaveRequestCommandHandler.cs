using AutoMapper;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using HRManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var LeaveRequestCommand = _mapper.Map<LeaveRequest>(request.createLeaveRequest);
            var LeaveRequest = await _leaveRequestRepository.Add(LeaveRequestCommand);
            return LeaveRequest.Id;
        }
    }
}
