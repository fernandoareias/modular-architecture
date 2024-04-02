using System;
using Atividade02.Core.Common.Validators;
using Atividade02.Core.Common.Validators.Interfaces;
using Atividade02.Core.Mediator;
using Atividade02.Core.Mediator.Interfaces;
using Atividade02.Core.MessageBus.Configurations;
using Atividade02.Core.MessageBus.Services;
using Atividade02.Core.MessageBus.Services.Interfaces;
using Atividade02.Proposals.Domain.Data.Common.Interfaces;
using Atividade02.Proposals.Domain.Proposals.Repositories;
using Atividade02.Proposals.Domain.Stores.Interfaces;
using Atividade02.Proposals.Infrastructure.Data.Common.Interfaces;
using Atividade02.Proposals.Infrastructure.Data.Repositories;
using Atividade02.Proposals.Infrastructure.ExternalServices.CreditAnalysisEngine;
using Atividade02.Proposals.Infrastructure.Gateways.CreditAnalysisEngines;
using Atividade02.Proposals.Infrastructure.Gateways.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Worker.Data;

namespace Atividade02.Proposals.Infrastructure
{
    public static class ProposalsInfrastructureIoC
    {
        public static IServiceCollection AddProposalInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MessageBusConfigs>(
                    configuration.GetSection(nameof(MessageBusConfigs)));

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, MongoContext>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IGatewayCreditAnalysisEngine, GatewayCreditAnalysisEngine>();
            services.AddScoped<IValidatorServices, ValidatorServices>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddSingleton<IMessageBus, MessageBus>();
            services.AddCreditAnalysisEngine();

            return services;
        }
    }
}

