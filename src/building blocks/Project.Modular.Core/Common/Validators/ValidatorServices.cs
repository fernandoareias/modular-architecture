using System;
using FluentValidation.Results;
using Atividade02.Core.Common.Validators.Interfaces;

namespace Atividade02.Core.Common.Validators
{
    public class ValidatorServices : IValidatorServices
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public void AddError(string code, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(code, message));
        }

        public void AddError(ValidationResult validationResult)
        {
            ValidationResult.Errors.AddRange(validationResult.Errors);
        }
    }
}

