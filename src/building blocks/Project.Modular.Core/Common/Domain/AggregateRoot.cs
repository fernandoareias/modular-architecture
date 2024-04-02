using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atividade02.Core.Common.CQRS;

public abstract class AggregateRoot : Entity
{
    
    protected AggregateRoot()
    {

    }
     
    [BsonElement("AggregateId")]
    public string AggregateId
    {
        get;
        protected set;
    }


    [BsonIgnore]
    private List<Event> _events = new List<Event>();
    [BsonIgnore]
    public IReadOnlyCollection<Event> Events => _events;

    public void AddEvent(Event @event)
    {
        _events.Add(@event);
    }

    public void Clear() => _events.Clear();
}