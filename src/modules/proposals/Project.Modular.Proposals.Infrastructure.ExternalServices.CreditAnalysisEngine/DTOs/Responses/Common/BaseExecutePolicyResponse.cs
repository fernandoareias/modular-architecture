using System;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses.Common
{
    [DataContract]
    public abstract class BaseExecutePolicyResponse
    {
        protected BaseExecutePolicyResponse(string externalId, string result)
        {
            ExternalId = externalId;
            Result = result;
        }

        [DataMember]
        public string ExternalId { get; set; }

        [DataMember]
        public string Result
        {
            get;
            set;
        }

    }
}

