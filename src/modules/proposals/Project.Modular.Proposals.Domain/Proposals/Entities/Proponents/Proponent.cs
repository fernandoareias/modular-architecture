using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities.Proponents;

namespace Atividade02.Proposals.Domain.Proposals.Entities
{
    public class Proponent : Entity
    {
        public Proponent(string name, string cpf, string ddd, string number)
        {
            Name = new Name(name);
            CPF = new CPF(cpf);
            Cellphone = new Cellphone(ddd, number);
        }

        public Name Name
        {
            get;
            private set;
        }

        public CPF CPF{
            get;
            private set;
        }

        public Cellphone Cellphone
        {
            get;
            private set;
        }
    }
}

