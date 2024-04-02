using System;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies
{
    public class FraudAnalysisPolicy : Policy
    {
        public FraudAnalysisPolicy(string externalId, EPolicyStatus status, TimeSpan executionTime) : base(externalId, status, executionTime)
        {
        }
    }
}

