using System;
using Atividade02.Core.Common.CQRS;
using MongoDB.Bson.Serialization.Attributes;

namespace Atividade02.Proposals.Domain.Proposals.Entities.Stores
{
    public class Store : AggregateRoot
    {
        protected Store()
        {
        }
        [BsonConstructor]
        protected Store(string name, string cnpj)
        {
            Name = name;
            CNPJ = cnpj;
        }

        //FantasyName
        [BsonElement("name")]
        public string Name
        {
            get;
            private set;
        }

        //CNPJ
        [BsonElement("cnpj")]
        public string CNPJ
        {
            get;
            private set;
        }
    }
}

