using AutoMapper;
using HRManagement.Application.DTOs.LeaveTypeDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var valoidation =await validator.ValidateAsync(request.leaveTypeDto);

            if (!valoidation.IsValid)
            {
                throw new ValidationException(valoidation);
            }

            var selectedType =await _leaveTypeRepository.GetById(request.leaveTypeDto.Id);
            _mapper.Map(request.leaveTypeDto, selectedType);
            await _leaveTypeRepository.Update(selectedType);
            return Unit.Value;
        }
    }
}
