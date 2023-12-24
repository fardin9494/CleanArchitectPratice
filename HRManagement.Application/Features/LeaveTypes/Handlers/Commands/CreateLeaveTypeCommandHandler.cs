using AutoMapper;
using HRManagement.Application.DTOs.LeaveTypeDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRManagement.Application.Contract.Persistence;
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
            var validationClass = new ILeaveTypeDtoValidator();
            var ValidResual = await validationClass.ValidateAsync(request.leaveTypeDto);

            if (!ValidResual.IsValid)
            {
                throw new ValidationException(ValidResual);
            }

            var leaveTypeCommand = _mapper.Map<LeaveType>(request.leaveTypeDto);
            var leaveType = await _leaveTypeRepository.Add(leaveTypeCommand);
            return leaveType.Id;
        }
    }
}
