using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Services;
using Atividade02.Proposals.Infrastructure.Gateways.Interfaces;

namespace Atividade02.Proposals.Domain.Services.Services
{
    public class PreAnalysisPolicyServices : IPreAnalysisPolicyServices
    {
        private readonly IGatewayCreditAnalysisEngine _gatewayCreditAnalysisEngine;

        public PreAnalysisPolicyServices(IGatewayCreditAnalysisEngine gatewayCreditAnalysisEngine)
        {
            _gatewayCreditAnalysisEngine = gatewayCreditAnalysisEngine;
        }

        public async Task<PreAnalysisPolicy> Process(Proposal aggregate)
        {
            var startTime = DateTime.Now;
            var response = await _gatewayCreditAnalysisEngine.ExecutePreAnalysis(aggregate);
            var endTime = startTime - DateTime.Now;

            if (response is null)
                return new PreAnalysisPolicy(
                    string.Empty,
                    Proposals.Entities.Policies.Common.EPolicyStatus.ERRO,
                    endTime,
                    null
                );


            return new PreAnalysisPolicy(
                response.ExternalId,
                response.Result,
                endTime,
                response.CreditLimit
            );


        }
    }
}

