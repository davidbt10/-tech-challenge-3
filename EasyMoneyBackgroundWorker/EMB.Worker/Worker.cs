using EMB.Application.Interfaces;
using EMB.Worker.Providers;
using RabbitMQ.Client.Events;
using System.Text;

namespace EMB.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IOrderProcessorService _processorService;
        private readonly RabbitMQClient _rabbitMQClient;
        private readonly string _queueName = "orders";

        public Worker(RabbitMQClient rabbitMqClient,
            IOrderProcessorService orderProcessorService, IOrderProcessorService processorService)
        {
            _rabbitMQClient = rabbitMqClient;
            _processorService = processorService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var connection = _rabbitMQClient.Connect();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: true);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();

                _processorService.ProcessPurchaseOrders(Encoding.UTF8.GetString(body));
                channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(
                queue: _queueName,
                autoAck: false,
                consumerTag: "worker",
                noLocal: true,
                exclusive: true,
                arguments: null,
                consumer: consumer
            );
            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}
