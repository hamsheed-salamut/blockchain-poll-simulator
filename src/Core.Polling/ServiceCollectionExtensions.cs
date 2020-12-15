using Core.Polling.Repositories;
using Core.Polling.UseCases.Constituency;
using Core.Polling.UseCases.Voter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Polling
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
        {
            //SQL Repos
            serviceCollection.AddScoped<IVoterRepository, VoterRepository>();
            serviceCollection.AddScoped<IPollingRepository, PollingRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddPollServices(this IServiceCollection serviceCollection)
        {
            // Services
            serviceCollection.AddScoped<IVoterService, VoterService>();
            serviceCollection.AddScoped<IConstituencyService, ConstituencyService>();
            return serviceCollection;
        }
    }
}
