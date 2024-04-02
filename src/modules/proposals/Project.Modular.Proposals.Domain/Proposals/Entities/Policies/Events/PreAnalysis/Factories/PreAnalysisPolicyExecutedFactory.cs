using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Factories
{
    public static class PreAnalysisPolicyExecutedFactory
    {
        public static Event CreateEvent(Proposal proposal, PreAnalysisPolicy policy) 
        {
            return policy.Status switch
            {
                EPolicyStatus.APPROVED => new PreAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.REJECTED => new PreAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.DERIVED => new PreAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.ERRO => new PreAnalysisPolicyErroExecutedEvent(proposal.AggregateId, policy.ExternalId),
                _ => throw new InvalidCastException(nameof(policy.Status))
            };
        }
    }
}

