using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Atividade02.Proposals.Application.Proposals.Queries.Validators
{
    public class GetProposalByCodeQueryValidators : AbstractValidator<GetProposalByAggregateIdQuery>
    {
        public GetProposalByCodeQueryValidators()
        {
            RuleFor(c => c.AggregateId)
                .MaximumLength(36)
                .NotNull()
                .NotEmpty();
        }
    }
}