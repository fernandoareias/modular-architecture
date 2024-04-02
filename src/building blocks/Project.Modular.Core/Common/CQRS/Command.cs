using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Atividade02.Core.Common.CQRS;

public abstract class Command : Message, IRequest<View>
{ 
    public virtual bool IsValid()
        => throw new NotImplementedException();
}