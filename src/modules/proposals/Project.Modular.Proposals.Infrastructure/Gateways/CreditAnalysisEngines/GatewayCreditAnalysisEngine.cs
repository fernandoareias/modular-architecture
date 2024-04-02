using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.Interfaces;
using Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines.DTOs.Responses;
using Atividade02.Proposals.Infrastructure.Gateways.Interfaces;

namespace Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines
{
    public class GatewayCreditAnalysisEngine : IGatewayCreditAnalysisEngine
    {
        private readonly ICreditAnalysisEngineServices _creditAnalysisEngineServices;

        public GatewayCreditAnalysisEngine(ICreditAnalysisEngineServices creditAnalysisEngineServices)
        {
            _creditAnalysisEngineServices = creditAnalysisEngineServices;
        }

        public async Task<ExecuteFormalizationResponseDTO> ExecuteFormalization(Proposal proposal)
        {

            var proponentRequest = new ExecuteFormalizationRequest.ExecuteFormalizationProponenteRequest(
                proposal.Proponent.Cellphone.DDD,
                proposal.Proponent.Cellphone.Number,
                proposal.Proponent.Name.Value,
                proposal.Proponent.CPF.Number);

            var storeRequest = new ExecuteFormalizationRequest.ExecuteFormalizationStoreRequest(proposal.Store.Name, proposal.Store.CNPJ);

            var request = new ExecuteFormalizationRequest(
                proposal.Status.ToString(),
                proponentRequest,
                storeRequest,
                proposal.AggregateId
            );

            var response = await _creditAnalysisEngineServices.ExecuteFormalization(request);

            if (response is null) return null!;

            return new ExecuteFormalizationResponseDTO(
                response.ExternalId,
                response.Result
            );
        }

        public async Task<ExecuteFraudAnalysisResponseDTO> ExecuteFraudAnalysis(Proposal proposal)
        { // 

            var request = new ExecuteFraudAnalysisRequest(
               proposal.AggregateId,
               proposal.Proponent.Name.Value,
               proposal.Proponent.CPF.Number,
               proposal.Proponent.Cellphone.DDD,
               proposal.Proponent.Cellphone.Number
           );

            var response = await _creditAnalysisEngineServices.ExecuteFraudAnalysis(request);

            if (response is null) return null;

            return new ExecuteFraudAnalysisResponseDTO(
                response.ExternalId,
                response.Result
            );
        }

        public async Task<ExecutePreAnalysisResponseDTO> ExecutePreAnalysis(Proposal proposal)
        {

            var request = new ExecutePreAnalysisRequest(
                proposal.Proponent.Name.Value,
                proposal.Proponent.CPF.Number,
                proposal.Proponent.Cellphone.DDD,
                proposal.Proponent.Cellphone.Number,
                null
            );

            var response = await _creditAnalysisEngineServices.ExecutePreAnalysis(request);

            if (response is null) return null;

            return new ExecutePreAnalysisResponseDTO(
                response.ExternalId,
                response.Result,
                response?.CreditLimit
            );
        }
    }
}

