using System;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests
{ 
    [DataContract]
    public class ExecuteFraudAnalysisRequest
    {
        public ExecuteFraudAnalysisRequest(string correlationId, string name, string cPF, string dDD, string cellphone)
        {
            CorrelationId = correlationId;
            Name = name;
            CPF = cPF;
            DDD = dDD;
            Cellphone = cellphone;
        }

        [DataMember]
        public string CorrelationId { get; private set; }

        [DataMember]
        public string Name{
            get;
            private set;
        }

        [DataMember]
        public string CPF { get; private set; }

        [DataMember]
        public string DDD { get; private set; }

        [DataMember]
        public string Cellphone { get; private set; }
         
    }
}

