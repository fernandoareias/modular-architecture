using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events
{
    [DataContract]
    public class PreAnalysisPolicyErroExecutedEvent : Event
    {
        public PreAnalysisPolicyErroExecutedEvent(string proposalId, string policyId)
            : base("proposals-erro", "policy-preanalysis-executed-erro")
        {
            if (string.IsNullOrWhiteSpace(proposalId))
                throw new ArgumentException(nameof(proposalId));

            if (string.IsNullOrWhiteSpace(policyId))
                throw new ArgumentException(nameof(policyId));


            ProposalId = proposalId;
            PolicyId = policyId;
        }

        [DataMember]
        public string ProposalId
        {
            get;
            private set;
        }

        [DataMember]
        public string PolicyId
        {
            get;
            private set;
        }
    }
}

