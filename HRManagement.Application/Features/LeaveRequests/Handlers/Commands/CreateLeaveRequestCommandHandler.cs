using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequestDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using HRManagement.Application.Response;
using HRManagement.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper
            , ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validationResponse = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.createLeaveRequest);

            if (!validation.IsValid)
            {
                //throw new ValidationException(validation);
                validationResponse.Success = false;
                validationResponse.Message = "Create Request Faild";
                validationResponse.Errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var LeaveRequestCommand = _mapper.Map<LeaveRequest>(request.createLeaveRequest);
            var LeaveRequest = await _leaveRequestRepository.Add(LeaveRequestCommand);
            validationResponse.Success = true;
            validationResponse.Message = "Create Request Succeded";
            validationResponse.Id = LeaveRequest.Id;
            
            return validationResponse;
        }
    }
}
