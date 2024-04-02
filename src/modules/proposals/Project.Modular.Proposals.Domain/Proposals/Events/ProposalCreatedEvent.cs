using System;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Domain.Proposals.Events
{
    public class ProposalSentEvent : Event
    {
        public ProposalSentEvent(string id, string cpf, string cnpj)
            :
        base("proposals", "proposal-create")
        {
            Id = id;
            CPF = cpf;
            CNPJ = cnpj;
        }

        public string Id
        {
            get;
            private set;
        }

        public string CPF {
            get;
            private set;
        }

        public string CNPJ
        {
            get;
            private set;
        }

    }
}

