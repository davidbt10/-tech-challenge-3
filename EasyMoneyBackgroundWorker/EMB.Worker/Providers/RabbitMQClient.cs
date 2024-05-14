using RabbitMQ.Client;

namespace EMB.Worker.Providers
{
    public class RabbitMQClient
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;

        public RabbitMQClient(string connectionString)
        {
            _connectionFactory = new ConnectionFactory();
            _connectionFactory.Uri = new Uri(connectionString);
        }

        public IConnection Connect()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = _connectionFactory.CreateConnection();
            }
            return _connection;
        }
    }
}
