
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQClient.Library;
using System.Text;
using System.Threading.Channels;

namespace Receiver.API.Services
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private readonly RabbitMQConnector rabbitConnector;
        private readonly ILogger<ConsumeRabbitMQHostedService> logger;

        public ConsumeRabbitMQHostedService(RabbitMQConnector rabbitConnector, ILogger<ConsumeRabbitMQHostedService> logger)
        {
            this.rabbitConnector = rabbitConnector;
            this.logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var queueName = rabbitConnector.Channel.QueueDeclare().QueueName;
            rabbitConnector.Channel.QueueBind(queueName, exchange: "logs", routingKey: string.Empty);
            var consumer = new EventingBasicConsumer(rabbitConnector.Channel);
            consumer.Received += (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                logger.LogInformation($"Gelen mesaj:{message}");
            };

            rabbitConnector.Channel.BasicConsume(queue: rabbitConnector.Channel.CurrentQueue,
                         autoAck: true,
                         consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
