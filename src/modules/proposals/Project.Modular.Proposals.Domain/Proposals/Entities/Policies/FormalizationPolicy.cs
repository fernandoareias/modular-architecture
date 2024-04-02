using System;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies
{
    public class FormalizationPolicy : Policy
    {
        public FormalizationPolicy(string externalId, EPolicyStatus status, TimeSpan executionTime) : base(externalId, status, executionTime)
        {
        }
    }
}

