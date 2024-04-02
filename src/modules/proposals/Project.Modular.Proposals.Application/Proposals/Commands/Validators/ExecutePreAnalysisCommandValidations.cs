using System;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Commands.Validators
{
    public class ExecutePreAnalysisCommandValidations : AbstractValidator<ExecutePreAnalysisCommand>
    {
        public ExecutePreAnalysisCommandValidations()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();

        }
    }
}

