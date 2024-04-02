using System;
using Atividade02.Proposals.Domain.Proposals.Services;
using Atividade02.Proposals.Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Atividade02.Proposals.Domain.Services
{
    public static class ProposalDomainServicesIoC
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IPreAnalysisPolicyServices, PreAnalysisPolicyServices>();
            services.AddScoped<IFraudAnalysisPolicyServices, FraudAnalysisPolicyServices>();
            services.AddScoped<IFormalizationPolicyServices, FormalizationPolicyServices>();

            return services;
        }
    }
}

