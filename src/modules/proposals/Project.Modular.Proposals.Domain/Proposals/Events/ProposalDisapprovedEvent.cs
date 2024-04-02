using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities;

namespace Atividade02.Proposals.Domain.Proposals.Events
{
    [DataContract]
    public class ProposalDisapprovedEvent : Event
    {
        protected ProposalDisapprovedEvent() : base("proposals", "proposals-disapproved")
        {
        }

        public ProposalDisapprovedEvent(Proposal proposal) : base("proposals", "proposals-disapproved")
        {
            AggregateId = proposal.AggregateId;
            Code = proposal.Code;
            Proponent = new ProposalDisapprovedProponentEvent(proposal.Proponent);
        }

        [DataContract]
        public class ProposalDisapprovedProponentEvent
        {
            protected ProposalDisapprovedProponentEvent()
            {

            }

            public ProposalDisapprovedProponentEvent(Proponent proponent)
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
        public ProposalDisapprovedProponentEvent Proponent
        {
            get;
            init;
        }
    }
}

