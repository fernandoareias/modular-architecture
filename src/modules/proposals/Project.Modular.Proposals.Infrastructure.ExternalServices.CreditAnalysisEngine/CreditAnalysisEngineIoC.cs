using System;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Requests;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.DTOs.Responses;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine
{
    public static class CreditAnalysisEngineIoC
    {
        public static IServiceCollection AddCreditAnalysisEngine(this IServiceCollection services)
        {
            services.AddScoped<ICreditAnalysisEngineServices, CreditAnalysisEngineServices>();
            return services;
        }
    }
}

