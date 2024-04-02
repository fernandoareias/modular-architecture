using System;
using System.Runtime.Serialization;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests
{
    [DataContract]
    public class ExecuteFormalizationRequest
    {
        public ExecuteFormalizationRequest(string status, ExecuteFormalizationProponenteRequest proponente, ExecuteFormalizationStoreRequest store, string correlationId)
        {
            Status = status;
            Proponente = proponente;
            Store = store;
            CorrelationId = correlationId;
        }

        [DataContract]
        public class ExecuteFormalizationProponenteRequest
        {
            public ExecuteFormalizationProponenteRequest(string dDD, string cellphone, string name, string cPF)
            {
                DDD = dDD;
                Cellphone = cellphone;
                Name = name;
                CPF = cPF;
            }

            [DataMember]
            public string DDD
            {
                get;
                private set;
            }

            [DataMember]
            public string Cellphone
            {
                get;
                private set;
            }

            [DataMember]
            public string Name
            {
                get;
                private set;
            }

            [DataMember]
            public string CPF
            {
                get;
                private set;
            }
        }

      

        public class ExecuteFormalizationStoreRequest
        {
            public ExecuteFormalizationStoreRequest(string fantasyName, string cNPJ)
            {
                FantasyName = fantasyName;
                CNPJ = cNPJ;
            }

            [DataMember]
            public string FantasyName
            {
                get;
                private set;
            }

            [DataMember]
            public string CNPJ
            {
                get;
                private set;
            }
        }


        [DataMember]
        public string CorrelationId
        {
            get;
            private set;
        }

        [DataMember]
        public string Status
        {
            get;
            private set;
        }

        public ExecuteFormalizationProponenteRequest Proponente{
            get;
            private set;
        }

        public ExecuteFormalizationStoreRequest Store
        {
            get;
            private set;
        }



    }
}

