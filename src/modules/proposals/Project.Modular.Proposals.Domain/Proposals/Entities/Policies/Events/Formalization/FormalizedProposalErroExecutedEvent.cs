using System;
using Atividade02.Core.Common.CQRS;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Formalization
{
    [DataContract]
    public class FormalizedProposalErroExecutedEvent : Event
    {
        public FormalizedProposalErroExecutedEvent(string proposalId, string externalId)
            : base("proposals-erro", "formalized-proposal-erro")
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

