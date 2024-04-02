using System;
using System.Runtime.Serialization;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses.Common;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses
{
    [DataContract]
    public class ExecutePreAnalysisResponse : BaseExecutePolicyResponse
    {
        public ExecutePreAnalysisResponse(string externalId, string result, decimal? creditLimit = null) : base(externalId, result)
        {
            CreditLimit = creditLimit;
        }

        [DataMember]
        public decimal? CreditLimit {
            get;
            set;
        }
    }
}

