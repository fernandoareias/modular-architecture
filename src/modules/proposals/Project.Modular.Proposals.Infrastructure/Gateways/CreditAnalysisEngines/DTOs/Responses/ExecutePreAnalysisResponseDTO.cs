using System;
using System.Runtime.Serialization;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;
using Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses.Common;

namespace Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses
{
    public class ExecutePreAnalysisResponseDTO : BasePolicyResponseDTO
    {
        public ExecutePreAnalysisResponseDTO(
            string externalid,
            string result,
            decimal? creditLimit
        ) : base(externalid, result)
        {
            CreditLimit = creditLimit;
        }

        public decimal? CreditLimit
        {
            get;
            set;
        }

       
    }
}

