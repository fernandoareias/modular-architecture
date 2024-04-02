using System;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common
{
    public abstract class Policy : Entity
    { 
        protected Policy(string externalId, EPolicyStatus status, TimeSpan executionTime)
        {

            ExternalId = externalId;
            Status = status;
            ExecutionTime = executionTime;
        }

        public string ExternalId
        {
            get;
            private set;
        }

        public EPolicyStatus Status
        {
            get;
            private set;
        }

        public TimeSpan ExecutionTime
        {
            get;
            private set;
        }
    }
}

