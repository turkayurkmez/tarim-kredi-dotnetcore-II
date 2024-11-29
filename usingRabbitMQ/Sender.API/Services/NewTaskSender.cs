using RabbitMQ.Client;
using System.Text;

namespace Sender.API.Services
{
    public class NewTaskSender : INewTaskSender
    {

        private readonly string queueName;
        private readonly ILogger<NewTaskSender> logger;
        public NewTaskSender(string queueName, ILogger<NewTaskSender> logger)
        {
            this.queueName = queueName;
            this.logger = logger;
        }
        public async Task SendNewTask(string message)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };
            using var connection = await connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                body:body
                );

            logger.LogInformation($"Giden mesaj: {message}");


                 
        }
    }
}
