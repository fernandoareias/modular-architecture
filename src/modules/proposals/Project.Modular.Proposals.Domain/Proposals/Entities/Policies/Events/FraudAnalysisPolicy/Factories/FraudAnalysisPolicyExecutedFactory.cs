using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Factories
{
    public static class FraudAnalysisPolicyExecutedFactory
    {
        public static Event CreateEvent(Proposal proposal, FraudAnalysisPolicy policy)
        {
            return policy.Status switch
            {
                EPolicyStatus.APPROVED => new FraudAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.REJECTED => new FraudAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.DERIVED => new FraudAnalysisPolicySuccessfullyExecutedEvent(proposal.AggregateId, policy.ExternalId),
                EPolicyStatus.ERRO => new FraudAnalysisPolicyErroExecutedEvent(proposal.AggregateId, policy.ExternalId),
                _ => throw new InvalidCastException(nameof(policy.Status))

            };
        }
    }
}

