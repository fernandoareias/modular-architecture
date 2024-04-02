using System.Text.Json.Serialization;
using MediatR;

namespace Atividade02.Core.Common.CQRS;

public abstract class Event : Message, INotification
{ 
    protected Event(string exchange, string routerKey)
    {
        Exchange = exchange;
        RouterKey = routerKey;
    }
     

    [JsonIgnore]
    public string Exchange { get; private set; }
    [JsonIgnore]
    public string RouterKey { get; private set; }
}