using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace RabbitMQClient.Library
{
    public class RabbitMQConnector
    {
        private readonly RabbitMQConnectionOptions _options;

        public IModel Channel { get; set; }
        public QueueDeclareOk QueueDeclareOk { get; set; }

        public RabbitMQConnector(IOptions<RabbitMQConnectionOptions> options)
        {
            _options = options.Value;
            var factory = new ConnectionFactory()
            {
                HostName = _options.Host,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password
            };

            var connection = factory.CreateConnection();

            Channel = connection.CreateModel();

            Channel.ExchangeDeclare("logs", ExchangeType.Fanout);





        }


    }
}
