using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Queries.Validators
{
    public class GetListProposalByFilterQueryValidators : AbstractValidator<GetListProposalByFilterQuery>
    {
        public GetListProposalByFilterQueryValidators()
        {
            RuleFor(c => c.CPF)
                .MaximumLength(11)
                .NotNull()
                .NotEmpty()
                .When(x => string.IsNullOrWhiteSpace(x.CNPJ));

            RuleFor(c => c.CNPJ)
              .MaximumLength(14)
              .NotNull()
              .NotEmpty()
              .When(x => string.IsNullOrWhiteSpace(x.CPF));

        }
    }
}