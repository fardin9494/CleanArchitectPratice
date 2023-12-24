using FluentValidation;
using HRManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveAllocationDtos.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(x => x.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.Period).GreaterThan(DateTime.Now.Year).WithMessage("{PropertyName} most less than {ComparisonValue}");
            RuleFor(x => x.LeaveTypeId).NotEmpty().
                MustAsync(async (id, token) =>await _leaveTypeRepository.IsExist(id)).WithMessage("{PropertyName} Is not Defind In Types");
        }
    }
}
