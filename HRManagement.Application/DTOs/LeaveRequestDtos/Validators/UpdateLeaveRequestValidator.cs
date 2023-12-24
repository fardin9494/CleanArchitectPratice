using FluentValidation;
using HRManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos.Validators
{
    public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestDto>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository) {

            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} Is Required");
        }
    }
}
