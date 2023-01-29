using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FormulaAirline.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessages<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "taufique",
                Password = "taufique", //For Prod env, I will either use UserSecrets or KV.
                VirtualHost = "/"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("bookings", durable: true, exclusive: true);
            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "bookings", body: body);

        }
    }
}
