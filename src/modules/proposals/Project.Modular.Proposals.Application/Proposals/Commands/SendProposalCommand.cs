using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Application.Proposals.Commands
{ 
    [DataContract]
    public class SendProposalCommand : Command
    {
        public SendProposalCommand(Guid aggregateId, string name, string cpf, string cnpj, string ddd, string cellphone, string? notes = null)
        {
            AggregateId = aggregateId;
            Name = name;
            CPF = cpf;
            CNPJ = cnpj;
            DDD = ddd;
            Cellphone = cellphone;
            Notes = notes;
        }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string CPF { get; private set; }

        [DataMember]
        public string CNPJ { get; private set; }

        [DataMember]
        public string DDD { get; private set; }

        [DataMember]
        public string Cellphone { get; private set; }

        [DataMember]
        public string? Notes { get; private set; }

    }
}

