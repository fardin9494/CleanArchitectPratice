using AutoMapper;
using HRManagement.Application.DTOs.LeaveAllocationDtos.Validators;
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
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.CreateLeaveAllocation);

            if (!validation.IsValid) 
            {
                throw new ValidationException(validation);
            }

            var LeaveAllcationCommand = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocation);
            var LeaveAllocacation = await _leaveAllocationRepository.Add(LeaveAllcationCommand);
            return LeaveAllocacation.Id;

        }
    }
}
