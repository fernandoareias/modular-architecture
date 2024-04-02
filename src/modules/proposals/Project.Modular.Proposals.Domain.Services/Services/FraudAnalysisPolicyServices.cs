using System;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Services;
using Atividade02.Proposals.Infrastructure.Gateways.Interfaces;

namespace Atividade02.Proposals.Domain.Services.Services
{
    public class FraudAnalysisPolicyServices : IFraudAnalysisPolicyServices
    {
        private readonly IGatewayCreditAnalysisEngine _gatewayCreditAnalysisEngine;

        public FraudAnalysisPolicyServices(IGatewayCreditAnalysisEngine gatewayCreditAnalysisEngine)
        {
            _gatewayCreditAnalysisEngine = gatewayCreditAnalysisEngine;
        }


        public async Task<FraudAnalysisPolicy> Process(Proposal aggregate)
        {
            var startTime = DateTime.Now;
            var response = await _gatewayCreditAnalysisEngine.ExecuteFraudAnalysis(aggregate);
            var endTime = startTime - DateTime.Now;

            if (response is null)
                return new FraudAnalysisPolicy(
                    string.Empty,
                    Proposals.Entities.Policies.Common.EPolicyStatus.ERRO,
                    endTime 
                );


            return new FraudAnalysisPolicy(
                response.ExternalId,
                response.Result,
                endTime 
            );

        }
    }
}

