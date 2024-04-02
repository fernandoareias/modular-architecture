using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Domain.Proposals;

namespace Atividade02.Proposals.Application.Proposals.Commands.Views
{
    [DataContract]
    public class SendProposalCommandView : View
    {
        public SendProposalCommandView(string correlationId, string status)
        {
            CorrelationId = correlationId;
            Status = status;
        }

        [DataMember]
        public string CorrelationId
        {
            get;
            private set;
        }

        [DataMember]
        public string Status{
            get;
            private set;
        }
    }
}

