using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Atividade02.Core.Common.CQRS
{
    public class QueryList : IRequest<List<View>>
    {
        public virtual bool IsValid()
          => throw new NotImplementedException();
    }
}