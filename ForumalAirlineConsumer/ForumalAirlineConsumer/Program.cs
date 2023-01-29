using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Consuming Message from FormulaAirline Producer");

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "taufique",
    Password = "taufique", //For Prod env, I will either use UserSecrets or KV.
    VirtualHost = "/"
};
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("bookings", durable: true, exclusive: true);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    //getting the byte[]
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"New Message: {message}");
};

channel.BasicConsume("bookings", true, consumer);
Console.ReadKey();