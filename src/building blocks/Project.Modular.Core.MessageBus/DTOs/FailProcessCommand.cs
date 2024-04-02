

using System.Runtime.Serialization;
using Atividade02.Core.Common.CQRS;

namespace Atividade02.Core.MessageBus.DTOs
{

    [DataContract]
    public class FailProcessCommand : Command
    {
        protected FailProcessCommand()
        {

        }

        public FailProcessCommand(string originalCommand, string exception)
        {
            OriginalCommand = originalCommand;
            Exception = exception;
        }

        public string OriginalCommand { get; private set; }
        public string Exception { get; private set; }

    }

}