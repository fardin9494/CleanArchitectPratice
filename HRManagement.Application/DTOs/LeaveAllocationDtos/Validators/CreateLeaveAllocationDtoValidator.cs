using FluentValidation;
using HRManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveAllocationDtos.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository) 
        { 
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
        }
    }
}
