using System;
using System.Runtime.Serialization;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;

namespace Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses.Common
{
    [DataContract]
    public abstract class BasePolicyResponseDTO
    {

        protected BasePolicyResponseDTO(string externalid, string result)
        {
            ExternalId = externalid;
            Result = ParserResultToEnum(result);
        }

        [DataMember]
        public string ExternalId { get; private set; }

        [DataMember]
        public EPolicyStatus Result
        {
            get;
            private set;
        }

        private EPolicyStatus ParserResultToEnum(string result)
        {
            return result switch
            {
                "APPROVED" => EPolicyStatus.APPROVED,
                "DERIVED" => EPolicyStatus.DERIVED,
                "REJECTED" => EPolicyStatus.REJECTED,
                "ERRO" => EPolicyStatus.ERRO
            };
        }

    }
}

