using System;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Commands.Validators
{
    public class ExecuteFraudAnalysisPolicyCommandValidations : AbstractValidator<ExecuteFraudAnalysisPolicyCommand>
    {
        public ExecuteFraudAnalysisPolicyCommandValidations()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();

        }
    }
}

