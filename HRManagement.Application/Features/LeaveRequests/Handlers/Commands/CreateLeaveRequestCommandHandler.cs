using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequestDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Contract.Persistence;
using HRManagement.Application.Response;
using HRManagement.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRManagement.Application.Contract.Infrastructure;
using HRManagement.Application.Model;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper
            , ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
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

            var email = new Email
            {
                To = "fardin.soltanian@gmail.com",
                Subject = "Your request is save Waiting gor response",
                Body = $"your request is from {request.createLeaveRequest.StartDate} To {request.createLeaveRequest.EndDate}"
            };
            try
            {
              await  _emailSender.SendEmailAsync(email);
            }
            catch (System.Exception)
            {

                throw;
            }


            return validationResponse;
        }
    }
}
