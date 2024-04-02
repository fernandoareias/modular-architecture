using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.Interfaces;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine;

public class CreditAnalysisEngineServices : ICreditAnalysisEngineServices
{
    private readonly IMessageBus _messageBus;

    public CreditAnalysisEngineServices(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task<ExecuteFormalizationResponse> ExecuteFormalization(ExecuteFormalizationRequest request)
    {
        return new ExecuteFormalizationResponse(Guid.NewGuid().ToString(), request.Status);
    }

    public async Task<ExecuteFraudAnalysisResponse> ExecuteFraudAnalysis(ExecuteFraudAnalysisRequest request)
    {
        if (request.CPF == "16421400078")
            return new ExecuteFraudAnalysisResponse(Guid.NewGuid().ToString(), "APPROVED");
        else
            return new ExecuteFraudAnalysisResponse(Guid.NewGuid().ToString(), "REJECTED");
    }

    public async Task<ExecutePreAnalysisResponse> ExecutePreAnalysis(ExecutePreAnalysisRequest request)
    {
        return new ExecutePreAnalysisResponse(Guid.NewGuid().ToString(), "APPROVED", 1200);
    }
}

