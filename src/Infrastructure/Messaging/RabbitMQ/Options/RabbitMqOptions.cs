using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Messaging.RabbitMQ.Options
{
    public class RabbitMqOptions
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
    }
}
