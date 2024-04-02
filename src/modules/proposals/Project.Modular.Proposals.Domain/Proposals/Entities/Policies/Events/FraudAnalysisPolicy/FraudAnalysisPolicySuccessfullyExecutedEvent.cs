using System;
using Atividade02.Core.Common.CQRS;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events
{ 
    [DataContract]
    public class FraudAnalysisPolicySuccessfullyExecutedEvent : Event
    {
        public FraudAnalysisPolicySuccessfullyExecutedEvent(string proposalId, string policyId)
            : base("proposals", "policy-fraud-analysis-executed-successfull")
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

