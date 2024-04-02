using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;

namespace Atividade02.Proposals.Application.Proposals.Queries
{
    [DataContract]
    public class GetProposalByCodeQueryView : View
    {
        protected GetProposalByCodeQueryView()
        {

        }

        public GetProposalByCodeQueryView(Proposal proposal)
        {
            ProposalCode = proposal.Code;
            Status = proposal.Status.ToString();

            var preAnalysis = proposal.GetLastPreAnalysis();

            if (preAnalysis is not null)
                PreAnalysis = new GetProposalByCodeQueryPreAnalysisView(preAnalysis);

            var fraudAnalysis = proposal.GetLastFraudAnalysis();

            if (fraudAnalysis is not null)
                FraudAnalysis = new GetProposalByCodeQueryFraudAnalysisView(fraudAnalysis);

            var formalization = proposal.GetLastFormalization();

            if (formalization is not null)
                Formalization = new GetProposalByCodeQueryFormalizationView(formalization);
        }

        [DataContract]
        public class GetProposalByCodeQueryPreAnalysisView
        {
            protected GetProposalByCodeQueryPreAnalysisView()
            {

            }

            public GetProposalByCodeQueryPreAnalysisView(PreAnalysisPolicy preAnalysisPolicy)
            {
                Status = preAnalysisPolicy.Status.ToString();
                ExecutionTime = preAnalysisPolicy.ExecutionTime;
                ExecutedAt = preAnalysisPolicy.CreatedAt;
                CreditLimit = preAnalysisPolicy?.CreditLimit;
            }

            [DataMember]
            public string Status { get; private set; }

            [DataMember]
            public TimeSpan ExecutionTime { get; private set; }

            [DataMember]
            public DateTime ExecutedAt { get; private set; }

            [DataMember]
            public decimal? CreditLimit { get; private set; }
        }

        [DataContract]
        public class GetProposalByCodeQueryFraudAnalysisView
        {
            protected GetProposalByCodeQueryFraudAnalysisView()
            {

            }

            public GetProposalByCodeQueryFraudAnalysisView(FraudAnalysisPolicy fraudAnalysis)
            {
                Status = fraudAnalysis.Status.ToString();
                ExecutionTime = fraudAnalysis.ExecutionTime;
                ExecutedAt = fraudAnalysis.CreatedAt;
            }

            [DataMember]
            public string Status { get; private set; }

            [DataMember]
            public TimeSpan ExecutionTime { get; private set; }

            [DataMember]
            public DateTime ExecutedAt { get; private set; }
        }


        [DataContract]
        public class GetProposalByCodeQueryFormalizationView
        {
            protected GetProposalByCodeQueryFormalizationView()
            {

            }

            public GetProposalByCodeQueryFormalizationView(FormalizationPolicy formalizationPolicy)
            {
                Status = formalizationPolicy.Status.ToString();
                ExecutionTime = formalizationPolicy.ExecutionTime;
                ExecutedAt = formalizationPolicy.CreatedAt;
            }

            [DataMember]
            public string Status { get; private set; }

            [DataMember]
            public TimeSpan ExecutionTime { get; private set; }

            [DataMember]
            public DateTime ExecutedAt { get; private set; }
        }


        [DataMember]
        public string ProposalCode { get; private set; }

        [DataMember]
        public string Status { get; private set; }

        [DataMember]
        public GetProposalByCodeQueryPreAnalysisView PreAnalysis { get; private set; }

        [DataMember]
        public GetProposalByCodeQueryFraudAnalysisView FraudAnalysis { get; private set; }

        [DataMember]
        public GetProposalByCodeQueryFormalizationView Formalization { get; private set; }

    }
}