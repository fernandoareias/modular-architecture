using System;
using Atividade02.Core.Common.Domain;
using Atividade02.Worker.Domain.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Proponents
{
    public class CPF : ValueObjects
    {
        protected CPF()
        {

        }
        public CPF(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new DomainException("Invalid CPF");

            Number = number;
        }

        public string Number{
            get;
            private set;
        }
    }
}

