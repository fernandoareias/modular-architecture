using System;
using Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses.Common;

namespace Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses
{
    public class ExecuteFormalizationResponseDTO : BasePolicyResponseDTO
    {
        public ExecuteFormalizationResponseDTO(
            string externalid,
            string result
        )
            :
        base(externalid, result)
        {
        }
    }
}

