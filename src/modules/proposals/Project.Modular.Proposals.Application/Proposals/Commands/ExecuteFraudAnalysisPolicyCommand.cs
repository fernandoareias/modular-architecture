using System;
using Atividade02.Proposals.Application.Proposals.Commands.Validators;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Application.Proposals.Commands
{
    [DataContract]
    public class ExecuteFraudAnalysisPolicyCommand : Command
    {
        public ExecuteFraudAnalysisPolicyCommand(string id)
        {
            Id = id;
        }

        [DataMember]
        public string Id
        {
            get;
            private set;
        }

        public override bool IsValid()
        {
            return new ExecuteFraudAnalysisPolicyCommandValidations().Validate(this).Errors.Any() is false;
        }
    }
}

