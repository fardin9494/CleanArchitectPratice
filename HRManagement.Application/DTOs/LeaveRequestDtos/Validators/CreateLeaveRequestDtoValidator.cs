using FluentValidation;
using HRManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        }
    }
}
