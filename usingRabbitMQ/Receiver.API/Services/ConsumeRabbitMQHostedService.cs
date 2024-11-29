
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Receiver.API.Services
{
    public class ConsumeRabbitMQHostedService(ILogger<ConsumeRabbitMQHostedService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           logger.LogInformation("Gelen mesaj işlenecek....");
            var factory = new ConnectionFactory() { HostName = "localhost", Port=5672};
            using var connection = await factory.CreateConnectionAsync();
            using (var channel = await connection.CreateChannelAsync())
            {
               await channel.QueueDeclareAsync(
                    queue: "my-queue", 
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    logger.LogInformation($"Gelen mesaj: {message}");
                    //await Task.Yield();
                };

                await channel.BasicConsumeAsync(queue: "my-queue", autoAck: true, consumer: consumer);


            }

            

        }
    }
}
