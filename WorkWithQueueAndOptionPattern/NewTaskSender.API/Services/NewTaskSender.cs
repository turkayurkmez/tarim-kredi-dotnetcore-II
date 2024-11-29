using RabbitMQ.Client;
using RabbitMQClient.Library;
using System.Text;
using System.Threading.Channels;

namespace NewTaskSender.API.Services
{
    public class NewTaskSender : INewTaskSender
    {
        private readonly RabbitMQConnector _rabbitMQConnector;

        public NewTaskSender(RabbitMQConnector rabbitMQConnector)
        {
            _rabbitMQConnector = rabbitMQConnector;
        }
        public void Send(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _rabbitMQConnector.Channel.BasicPublish(exchange: "logs",
                routingKey: _rabbitMQConnector.Channel.CurrentQueue ?? string.Empty,
                basicProperties: null,
                body: body);

        }
    }
}
