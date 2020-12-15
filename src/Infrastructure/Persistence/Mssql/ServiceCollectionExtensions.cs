using Infrastructure.Persistence.Mssql.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Mssql
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMsSql(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                       .Configure<MsSqlDbOptions>(configuration.GetSection("MssqlDbOptions"))
                       .AddScoped(p => p.GetService<IOptions<MsSqlDbOptions>>().Value);

            return serviceCollection;
        }
    }
}
