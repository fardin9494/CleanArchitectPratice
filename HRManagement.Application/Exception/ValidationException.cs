using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Exception
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            Errors = new List<string>();
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
