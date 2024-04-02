using System;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.Interfaces
{
    public interface ICreditAnalysisEngineServices
    {
        Task<ExecutePreAnalysisResponse> ExecutePreAnalysis(ExecutePreAnalysisRequest request);
        Task<ExecuteFraudAnalysisResponse> ExecuteFraudAnalysis(ExecuteFraudAnalysisRequest request);
        Task<ExecuteFormalizationResponse> ExecuteFormalization(ExecuteFormalizationRequest request);
    }
}

