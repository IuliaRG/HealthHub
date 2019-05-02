using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb
{
    public class PharmacySender
    {
        public void SendRequest()
        {
            //Console.WriteLine("Hello this is the sendar application");
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                RequestedHeartbeat = 60,
                Ssl =
                {
                   ServerName="localhost",

                }
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "msgKey",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                //Console.WriteLine("enter message to send:");
                var msg = "hello there";
                var body = Encoding.UTF8.GetBytes(msg);

                channel.BasicPublish(exchange: "",
                                             routingKey: "msgKey",
                                             basicProperties: null,
                                             body: body);
                //Console.WriteLine(" [x] Sent {0}", msg);
            }

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
