using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Application.Proposals.Queries.Validators;

namespace Atividade02.Proposals.Application.Proposals.Queries
{
    [DataContract]
    public class GetProposalByAggregateIdQuery : Query
    {
        protected GetProposalByAggregateIdQuery()
        {

        }

        public GetProposalByAggregateIdQuery(string aggregateId)
        {
            AggregateId = aggregateId;
        }


        [DataMember]
        public string AggregateId { get; private set; }


        public override bool IsValid()
        {
            return new GetProposalByCodeQueryValidators().Validate(this).Errors.Any() is false;
        }
    }
}