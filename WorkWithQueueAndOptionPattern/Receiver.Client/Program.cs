﻿// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost", UserName="guest", Password="guest", Port=5672 };

using var connection = factory.CreateConnection();
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
    //channel.QueueDeclare(queue: "my_custom_queue",
    //                     durable: false,
    //                     exclusive: false,
    //                     autoDelete: false,
    //                     arguments: null);

    var queueName = channel.QueueDeclare().QueueName;
    channel.QueueBind(queueName, exchange: "logs", routingKey: string.Empty);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(" [x] Received {0}", message);
    };
    channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);
    Console.WriteLine("Çıkış yapmak için bir tuşa basınız.");
    Console.ReadLine();


}