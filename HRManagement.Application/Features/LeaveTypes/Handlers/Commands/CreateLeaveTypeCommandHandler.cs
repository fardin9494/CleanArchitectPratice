using AutoMapper;
using HRManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using HRManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeCommand = _mapper.Map<LeaveType>(request.leaveTypeDto);
            var leaveType = await _leaveTypeRepository.Add(leaveTypeCommand);
            return leaveType.Id;
        }
    }
}
