using System;
using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;
using Atividade02.Proposals.Application.Proposals.Commands.Validators;

namespace Atividade02.Proposals.Application.Proposals.Commands
{
    [DataContract]
    public class ExecutePreAnalysisCommand : Command
    {
        public ExecutePreAnalysisCommand(string id)
        {
            Id = id;
        }

        [DataMember]
        public string Id{
            get;
            private set;
        }

        public override bool IsValid()
        {
            return new ExecutePreAnalysisCommandValidations().Validate(this).Errors.Any() is false;
        }
    }
}

