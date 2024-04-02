using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Modular.API.Configurations
{
    public static class ApiConfigurations
    {
        public static void ApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddHostedService<ProposalSentEventWorker>();
            services.AddHostedService<ProposalCreatedEventWorker>();
            services.AddHostedService<PreAnalysisPolicySuccessfullyExecutedEventWorker>();
            services.AddHostedService<FraudAnalysisPolicySuccessfullyExecutedEventWorker>();

            ApiInjection(services, configuration);
        }

        public static void UseApiConfiguration(this WebApplication app, IConfiguration configuration)
        {
            app.UseLogs(configuration);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        private static void AppsettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #if PORTADOR || PORTADOR_DEBUG
                configuration.AddJsonFile("appsettings.Portador.json");
            #elif PROPOSALS || PROPOSALS_DEBUG
                configuration.AddJsonFile("appsettings.Proposals.json");
            #elif CREDIT_CARD || CREDIT_CARD_DEBUG
                configuration.AddJsonFile("appsettings.CreditCard.json"); 
            #endif
        }
        private static void ApiInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProposalInfrastructure(configuration);
            services.AddProposalApplication();
        }
    }
}