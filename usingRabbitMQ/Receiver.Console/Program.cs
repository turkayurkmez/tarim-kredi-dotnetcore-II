// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory() { HostName = "localhost", Port=5672 };
using var connection = await factory.CreateConnectionAsync();
using (var channel = await connection.CreateChannelAsync())
{
    await channel.QueueDeclareAsync(queue: "my-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.ReceivedAsync += Consumer_ReceivedAsync;

    channel.BasicConsumeAsync(queue: "my-queue", autoAck: true, consumer: consumer);
    Console.ReadLine();

}

async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs arg)
{
    var body = arg.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Gelen mesaj: {message}");

}