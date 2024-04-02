using System;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Common;
using Atividade02.Proposals.Domain.Proposals.Enums;

namespace Atividade02.Proposals.Domain.Proposals
{
    public static class ProposalValidator
    {

        public static EProposalStatus GetStatus(PreAnalysisPolicy? preAnalysis, FraudAnalysisPolicy fraudAnalysis)
        {
            if (preAnalysis?.Status == EPolicyStatus.REJECTED || fraudAnalysis.Status == EPolicyStatus.REJECTED)
                return EProposalStatus.REJECTED;

            if (preAnalysis?.Status == EPolicyStatus.DERIVED || fraudAnalysis.Status == EPolicyStatus.DERIVED)
                return EProposalStatus.DERIVED;

            if (preAnalysis?.Status == EPolicyStatus.APPROVED && fraudAnalysis.Status == EPolicyStatus.APPROVED)
                return EProposalStatus.APPROVED;

            return EProposalStatus.PROCESSING;
        }
    }
}

