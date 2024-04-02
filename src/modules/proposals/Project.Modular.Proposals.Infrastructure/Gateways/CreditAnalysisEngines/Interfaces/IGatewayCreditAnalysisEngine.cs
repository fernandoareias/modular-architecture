using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses;

namespace Atividade02.Proposals.Infrastructure.Gateways.Interfaces
{
    public interface IGatewayCreditAnalysisEngine
    {
        Task<ExecutePreAnalysisResponseDTO> ExecutePreAnalysis(Proposal proposal);
        Task<ExecuteFraudAnalysisResponseDTO> ExecuteFraudAnalysis(Proposal proposal);
        Task<ExecuteFormalizationResponseDTO> ExecuteFormalization(Proposal proposal);
    }
}

