using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;

namespace Atividade02.Proposals.Application.Proposals.Queries
{
    [DataContract]
    public class GetListProposalByFilterQueryView : View
    {
        [DataContract]
        public class GetListProposalByFilterQueryProposalShortView
        {

            protected GetListProposalByFilterQueryProposalShortView()
            {

            }

            public GetListProposalByFilterQueryProposalShortView(Proposal proposal)
            {
                AggregateId = proposal.AggregateId;
                Code = proposal.Code;
                Status = proposal.Status.ToString();
            }


            [DataMember]
            public string AggregateId { get; private set; } = null!;

            [DataMember]
            public string Code { get; private set; } = null!;

            [DataMember]
            public string Status { get; private set; } = null!;
        }


        protected GetListProposalByFilterQueryView()
        {

        }

        public GetListProposalByFilterQueryView(List<Proposal> proposals)
        {
            Proposals = proposals.Select(c => new GetListProposalByFilterQueryProposalShortView(c)).ToArray();
        }

        [DataMember]
        public GetListProposalByFilterQueryProposalShortView[] Proposals { get; private set; }
    }
}