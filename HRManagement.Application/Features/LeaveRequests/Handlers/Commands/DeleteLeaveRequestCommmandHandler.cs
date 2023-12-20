using AutoMapper;
using HRManagement.Application.Exception;
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
    public class DeleteLeaveRequestCommmandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommmandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        { 
            var leaveRequest = await _leaveRequestRepository.GetById(request.Id);

            if(leaveRequest == null )
            {
                throw new NotFoundException(nameof(LeaveRequest),request.Id);
            }

            await _leaveRequestRepository.Delete(leaveRequest);
        }
    }
}
