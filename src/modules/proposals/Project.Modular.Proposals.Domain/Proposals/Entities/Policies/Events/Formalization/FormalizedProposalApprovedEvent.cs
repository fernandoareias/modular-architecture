using System;
using Atividade02.Core.Common.CQRS;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Formalization
{
    [DataContract]
    public class FormalizedProposalApprovedEvent : Event
    {
        public FormalizedProposalApprovedEvent(string proposalId, string externalId)
            : base("proposals", "formalized-proposal-approved")
        {
            if (string.IsNullOrWhiteSpace(proposalId))
                throw new ArgumentException(nameof(proposalId));

            ProposalId = proposalId;
            ExternalId = externalId;
        }

        [DataMember]
        public string ProposalId
        {
            get;
            private set;
        }

        [DataMember]
        public string ExternalId{
            get;
            private set;
        }
    }
}

