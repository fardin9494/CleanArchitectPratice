using AutoMapper;
using HRManagement.Application.DTOs.LeaveRequestDtos.Validators;
using HRManagement.Application.Exception;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        async Task<Unit> IRequestHandler<UpdateLeaveRequestCommand, Unit>.Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var validation = await validator.ValidateAsync(request.updateleaveRequestDto);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation);
            }

            var selectedRequest = await _leaveRequestRepository.GetById(request.Id);
            if(request.updateleaveRequestDto != null)
            {
                _mapper.Map(request.updateleaveRequestDto, selectedRequest);
                await _leaveRequestRepository.Update(selectedRequest);
                
            }
            else if(request.changeLeaveRequestAproveal != null)
            {
              await  _leaveRequestRepository.ChangeApprovalStatus(selectedRequest,request.changeLeaveRequestAproveal.IsAproved);
            }
            return Unit.Value;
        }
    }
}
