using FluentValidation;
using HRManagement.Application.Persistence.Cortract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<IleaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

       

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("{PropertyName} most bigger {ComparisonValue}");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("{PropertyName} most less than {ComparisonValue}");
            
            RuleFor(x => x.LeaveTypeId)
                .MustAsync(async (id,token) => await  _leaveTypeRepository.IsExist(id))
                .WithMessage("{PropertyName} Is Not in TypeId")
                .GreaterThan(0).WithMessage("{PropertyName} Is not Null");

        }
    }
}
