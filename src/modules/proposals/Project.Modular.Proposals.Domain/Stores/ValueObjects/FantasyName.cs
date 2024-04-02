using System;
using Atividade02.Core.Common.Domain;
using Atividade02.Worker.Domain.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Stores
{
    public class FantasyName : ValueObjects
    {
        public FantasyName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Invalid name");

            Value = value;
        }

        protected FantasyName()
        {
        }

        public string Value
        {
            get;
            private set;
        }
    }
}

