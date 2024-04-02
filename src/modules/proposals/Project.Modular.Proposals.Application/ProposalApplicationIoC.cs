using System;
using Atividade02.Core.Mediator.Behaviours;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Atividade02.Proposals.Domain.Services;

namespace Atividade02.Proposals.Application
{
    public static class ProposalApplicationIoC
    {
        public static IServiceCollection AddProposalApplication(this IServiceCollection services)
        {

            services.AddFluentValidation(f => f.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ProposalApplicationIoC))));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(ProposalApplicationIoC))));
            services.AddDomainServices();

            return services;
        }
    }
}

