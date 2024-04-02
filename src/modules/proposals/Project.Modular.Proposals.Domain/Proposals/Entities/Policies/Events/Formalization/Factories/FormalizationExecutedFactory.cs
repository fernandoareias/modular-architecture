using System;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Formalization.Factories
{
    public static class FormalizationExecutedFactory
    {
        public static Event CreateEvent(Proposal proposal, FormalizationPolicy policy)
        {
            return proposal.Status switch
            {
                Enums.EProposalStatus.APPROVED => new FormalizedProposalApprovedEvent(proposal.AggregateId, policy.ExternalId),
                Enums.EProposalStatus.REJECTED => new FormalizedProposalRejectedEvent(proposal.AggregateId, policy.ExternalId),
                Enums.EProposalStatus.DERIVED => new FormalizedProposalDerivedEvent(proposal.AggregateId, policy.ExternalId),
                _ => throw new InvalidOperationException(nameof(proposal.Status))
            };
        }
    }
}

