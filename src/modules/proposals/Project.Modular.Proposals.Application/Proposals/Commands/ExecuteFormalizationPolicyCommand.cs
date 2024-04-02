using System;
using Atividade02.Proposals.Application.Proposals.Commands.Validators;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Proposals.Application.Proposals.Commands
{
    [DataContract]
    public class ExecuteFormalizationPolicyCommand : Command
    {
        public ExecuteFormalizationPolicyCommand(string id)
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
            return new ExecuteFormalizationPolicyCommandValidations().Validate(this).Errors.Any() is false;
        }
    }
}

