using EventBusRabbitMQ.Events.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Producer
{
    public class EventBusRabbitMQProcuder
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQProcuder> _logger;
        private readonly int _retryCount;
        public EventBusRabbitMQProcuder(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQProcuder> logger, int retryCount = 5)
        {
            _persistentConnection = persistentConnection;
            _logger = logger;
            _retryCount = retryCount;
        }

        public void Publish(string queueName,IEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(ex,"Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})",@event.RequestId, $"{time.TotalSeconds:n1}", ex);
                });

            using (var chanel = _persistentConnection.CreateModel())
            {
                chanel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    IBasicProperties properties = chanel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.DeliveryMode = 2;

                    chanel.ConfirmSelect();
                    chanel.BasicPublish(
                       exchange: "",
                       routingKey: queueName,
                       mandatory: true,
                       basicProperties: properties,
                       body: body);
                    chanel.WaitForConfirmsOrDie();

                    chanel.BasicAcks += (sender, eventArgs) =>
                    {
                        Console.WriteLine("Sent RabbitMQ");
                    };
                });
            }
        }

    }
}
