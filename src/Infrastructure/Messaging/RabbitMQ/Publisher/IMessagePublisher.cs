using Core.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Messaging.RabbitMQ.Publisher
{
    public interface IMessagePublisher
    {
        Task PublishAsync(VotesDto message, string url);
    }
}
