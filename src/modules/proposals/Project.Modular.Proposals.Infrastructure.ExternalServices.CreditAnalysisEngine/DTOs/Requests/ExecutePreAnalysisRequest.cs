using System;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests
{
    [DataContract]
    public class ExecutePreAnalysisRequest
    { 
        public ExecutePreAnalysisRequest(
            string name,
            string cpf,
            string ddd,
            string cellphone,
            string cnpj
        )
        {
            Name = name;
            CPF = cpf;
            DDD = ddd;
            Cellphone = cellphone;
            CNPJ = cnpj;
        }

        [DataMember]
        public string CorrelationId { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string CPF { get; private set; }

        [DataMember]
        public string DDD { get; private set; }

        [DataMember]
        public string Cellphone { get; private set; }

        [DataMember]
        public string CNPJ { get; private set; }
    }
}

