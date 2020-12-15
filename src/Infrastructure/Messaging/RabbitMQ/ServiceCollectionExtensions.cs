using Infrastructure.Messaging.RabbitMQ.Options;
using Infrastructure.Messaging.RabbitMQ.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Messaging.RabbitMQ
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                       .Configure<RabbitMqOptions>(configuration.GetSection("RabbitMqOptions"))
                       .AddScoped(p => p.GetService<IOptions<RabbitMqOptions>>().Value);

            serviceCollection.AddScoped<IMessagePublisher, MessagePublisher>();

            return serviceCollection;
        }
    }
}
