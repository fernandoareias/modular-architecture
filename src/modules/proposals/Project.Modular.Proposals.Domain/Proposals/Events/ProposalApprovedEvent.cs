using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities;

namespace Atividade02.Proposals.Domain.Proposals.Events
{
    [DataContract]
    public class ProposalApprovedEvent : Event
    {
        protected ProposalApprovedEvent() : base("proposals", "proposals-approved")
        {
        }

        public ProposalApprovedEvent(Proposal proposal) : base("proposals", "proposals-approved")
        {
            AggregateId = proposal.AggregateId;
            Code = proposal.Code;
            Proponent = new ProposalApprovedProponentEvent(proposal.Proponent);
        }

        [DataContract]
        public class ProposalApprovedProponentEvent
        {
            protected ProposalApprovedProponentEvent()
            {

            }

            public ProposalApprovedProponentEvent(Proponent proponent)
            {
                Name = proponent.Name.Value;
                CPF = proponent.CPF.Number;
                DDD = proponent.Cellphone.DDD;
                CellphoneNumber = proponent.Cellphone.Number;
            }

            [DataMember]
            public string Name{
                get;
                init;
            }

            [DataMember]
            public string CPF{
                get;
                init;
            }

            [DataMember]
            public string DDD{
                get;
                init;
            }

            [DataMember]
            public string CellphoneNumber{
                get;
                init;
            }
        }

        [DataMember]
        public string AggregateId{
            get;
            init;
        }

        [DataMember]
        public string Code{
            get;
            init;
        }

        [DataMember]
        public ProposalApprovedProponentEvent Proponent
        {
            get;
            init;
        }
    }
}

