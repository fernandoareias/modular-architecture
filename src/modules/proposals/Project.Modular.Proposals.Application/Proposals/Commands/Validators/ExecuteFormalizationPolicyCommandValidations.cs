using System;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Commands.Validators
{
    public class ExecuteFormalizationPolicyCommandValidations : AbstractValidator<ExecuteFormalizationPolicyCommand>
    {
        public ExecuteFormalizationPolicyCommandValidations()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty();

        }
    }
}

