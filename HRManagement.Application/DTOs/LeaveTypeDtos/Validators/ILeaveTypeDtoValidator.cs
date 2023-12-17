using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveTypeDtos.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        public ILeaveTypeDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} Cant be Null")
                .MaximumLength(50).WithMessage("{PropertyName} Cant Bigest Than 50 Char");

            RuleFor(x => x.DeafultDay).NotEmpty().WithMessage("{PropertyName} Cant be Null").
                GreaterThan(0).WithMessage("{PropertyName} Has Bigest Than 0").
                LessThan(100).WithMessage("{PropertyName} Has Less Than 100");
        }
    }
}
