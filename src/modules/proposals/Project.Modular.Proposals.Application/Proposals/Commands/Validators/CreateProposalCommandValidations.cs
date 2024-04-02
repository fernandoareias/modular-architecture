using System;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Commands.Validators
{
    public class CreateProposalCommandValidations : AbstractValidator<CreateProposalCommand>
    {
        public CreateProposalCommandValidations()
        {
            RuleFor(c => c.Name)
                .MaximumLength(125)
                .NotNull()
                .NotEmpty()
                .Must(c => c.Split(" ").Length >= 2);

            RuleFor(c => c.CPF)
                .Length(11)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.CNPJ)
                .Length(14)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.DDD)
                .MaximumLength(2)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Cellphone)
                .MaximumLength(125)
                .NotNull()
                .NotEmpty();
        }
    }
}

