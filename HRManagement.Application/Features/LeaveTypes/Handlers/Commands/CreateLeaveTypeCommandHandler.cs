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
using HRManagement.Application.Response;
using System.Linq;

namespace HRManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validationClass = new ILeaveTypeDtoValidator();
            var ValidResual = await validationClass.ValidateAsync(request.leaveTypeDto);

            if (!ValidResual.IsValid)
            {
                response.Message = "Creation Failed";
                response.Success = false;
                response.Errors = ValidResual.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var leaveTypeCommand = _mapper.Map<LeaveType>(request.leaveTypeDto);
                var leaveType = await _leaveTypeRepository.Add(leaveTypeCommand);
                response.Message = "Operation Succedded";
                response.Success = true;
                response.Id = leaveType.Id;

            }

            
            return response;
        }
    }
}
