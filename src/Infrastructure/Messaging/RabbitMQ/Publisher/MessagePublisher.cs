using Core.Common.Dto;
using Infrastructure.Messaging.RabbitMQ.Publisher;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.RabbitMQ
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IBus _bus;

        public MessagePublisher(
            IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishAsync(VotesDto message, string url)
        {
            Uri uri = new Uri(url);
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(message);
        }
    }
}
