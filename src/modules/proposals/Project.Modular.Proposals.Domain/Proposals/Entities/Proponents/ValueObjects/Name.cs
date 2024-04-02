using System;
using Atividade02.Core.Common.Domain;
using Atividade02.Worker.Domain.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Proponents
{
    public class Name : ValueObjects
    {
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Invalid name");

            Value = value;
        }

        protected Name()
        {
        }

        public string Value{
            get;
            private set;
        }
    }
}

