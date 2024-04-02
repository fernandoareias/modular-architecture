using System;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;

namespace Atividade02.Proposals.Domain.Proposals.Services
{
    public interface IFraudAnalysisPolicyServices : IDomainService<FraudAnalysisPolicy, Proposal>
    { 
    }
}

