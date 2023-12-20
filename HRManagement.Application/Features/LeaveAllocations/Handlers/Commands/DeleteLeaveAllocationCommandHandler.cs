using AutoMapper;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using HRManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetById(request.Id);
            if(leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation),request.Id);
            }

            await _leaveAllocationRepository.Delete(leaveAllocation);
        }
    }
}
