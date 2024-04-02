namespace Atividade02.Core.Common.CQRS;

public interface IDomainService<TResult, TAggregate> where TAggregate : AggregateRoot
{
    Task<TResult> Process(TAggregate aggregate) ;
}