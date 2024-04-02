using System.Text;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals.Entities;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Factories;
using Atividade02.Proposals.Domain.Proposals.Entities.Policies.Events.Formalization.Factories;
using Atividade02.Proposals.Domain.Proposals.Entities.Stores;
using Atividade02.Proposals.Domain.Proposals.Enums;
using Atividade02.Proposals.Domain.Proposals.Events;
using Atividade02.Proposals.Domain.Proposals.Services;
using MongoDB.Bson.Serialization.Attributes;

namespace Atividade02.Proposals.Domain.Proposals
{
    public class Proposal : AggregateRoot
    {
        public Proposal()
        {

        }

        public Proposal(Guid aggregateId, Proponent proponent, Store store, string? notes = null)
        {
            AggregateId = aggregateId.ToString();
            Code = GenerateCode();
            Proponent = proponent;
            Store = store;
            Notes = notes;

            AddEvent(new ProposalSentEvent(AggregateId, Proponent.CPF.Number, Store.CNPJ));
        }
        [BsonConstructor]
        protected Proposal(string code, EProposalStatus status, string? notes, Proponent proponent, Store store, List<PreAnalysisPolicy> preAnalysis, List<FraudAnalysisPolicy> fraudAnalysis, List<FormalizationPolicy> formalizations)
        {
            Code = code;
            Status = status;
            Notes = notes;
            Proponent = proponent;
            Store = store;
            PreAnalysis = preAnalysis;
            FraudAnalysis = fraudAnalysis;
            Formalizations = formalizations;
        }

        [BsonElement("Code")]
        public string Code {
            get;
            private set;
        }

        [BsonElement("Status")]
        public EProposalStatus Status
        {
            get;
            private set;
        } = EProposalStatus.PROCESSING;

        [BsonElement("Notes")]
        public string? Notes
        {
            get;
            private set;
        }

        [BsonElement("Proponent")]
        public Proponent Proponent
        {
            get;
            private set;
        }

        [BsonElement("Store")]
        public Store Store
        {
            get;
            private set;
        }

        [BsonElement("PreAnalysis")]
        public List<PreAnalysisPolicy> PreAnalysis
        {
            get;
            private set;
        } = new List<PreAnalysisPolicy>();

        [BsonElement("FraudAnalysis")]
        public List<FraudAnalysisPolicy> FraudAnalysis
        {
            get;
            private set;
        } = new List<FraudAnalysisPolicy>();

        [BsonElement("Formalizations")]
        public List<FormalizationPolicy> Formalizations
        {
            get;
            private set;
        } = new List<FormalizationPolicy>();


        private string GenerateCode()
        {
            Random random = new Random();

            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder("PP");

            char lastChar = '\0';

            for (int i = 0; i < 12; i++)
            {
                char randomChar;
                do
                {
                    randomChar = chars[random.Next(chars.Length)];
                } while (randomChar == lastChar);

                sb.Append(randomChar);
                lastChar = randomChar;
            }

            return sb.ToString();
        }

        public async Task Execute(IPreAnalysisPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            AddEvent(PreAnalysisPolicyExecutedFactory.CreateEvent(this, policy));

            PreAnalysis.Add(policy);
        }

        public async Task Execute(IFraudAnalysisPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            FraudAnalysis.Add(policy);

            AddEvent(FraudAnalysisPolicyExecutedFactory.CreateEvent(this, policy));

            ChangeStatus(ProposalValidator.GetStatus(GetLastPreAnalysis(), policy));

        }

        public async Task Execute(IFormalizationPolicyServices domainService)
        {
            var policy = await domainService.Process(this);

            if (policy is null)
                throw new NullReferenceException(nameof(policy));

            Formalizations.Add(policy);
            AddEvent(FormalizationExecutedFactory.CreateEvent(this, policy));
        }

        private void ChangeStatus(EProposalStatus status)
        {
            if (status == EProposalStatus.APPROVED)
                AddEvent(new ProposalApprovedEvent(this));
            Status = status;
        }

        public PreAnalysisPolicy? GetLastPreAnalysis()
            => PreAnalysis.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

        public FraudAnalysisPolicy? GetLastFraudAnalysis()
          => FraudAnalysis.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

        public FormalizationPolicy? GetLastFormalization()
         => Formalizations.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
    }
}

