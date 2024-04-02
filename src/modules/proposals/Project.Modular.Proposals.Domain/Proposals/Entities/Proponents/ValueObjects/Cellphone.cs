using System;
using Atividade02.Worker.Domain.Common;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Proponents
{
    public class Cellphone : ValueObjects
    {
        public Cellphone(string ddd, string number)
        {
            if (string.IsNullOrWhiteSpace(ddd))
                throw new ArgumentException(nameof(ddd));

            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException(nameof(number));

            DDD = ddd.Trim();
            Number = number.Trim();
        }

        public string DDD{
            get;
            private set;
        }

        public string Number{
            get;
            private set;
        }

        public override string ToString()
        {
            return DDD + Number;
        }
    }
}

