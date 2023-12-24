using AutoMapper;
using HRManagement.Application.DTOs.LeaveAllocationDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRManagement.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    internal class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.leaveAllocationDto);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation);
            }

            var SelectedAllocation = await _leaveAllocationRepository.GetById(request.leaveAllocationDto.Id);
            _mapper.Map(request.leaveAllocationDto,SelectedAllocation);
            await _leaveAllocationRepository.Update(SelectedAllocation);
            
            return Unit.Value;
        }
    }
}
