using System;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies
{
    public class PreAnalysisPolicy : Policy
    {
        public PreAnalysisPolicy(string externalId, EPolicyStatus status, TimeSpan executionTime, decimal? creditLimit) : base(externalId, status, executionTime)
        {
            CreditLimit = creditLimit;
        }

        public decimal? CreditLimit {
            get;
            private set;
        }
    }
}

