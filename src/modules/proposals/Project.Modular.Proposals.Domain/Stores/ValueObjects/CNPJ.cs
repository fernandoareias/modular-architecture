using System;
using Atividade02.Core.Common.Domain;
using Atividade02.Worker.Domain.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Stores
{
    public class CNPJ : ValueObjects
    {
        public CNPJ(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new DomainException("Invalid CNPJ number");

            Number = number;
        }

        public string Number{
            get;
            private set;
        }
    }
}

