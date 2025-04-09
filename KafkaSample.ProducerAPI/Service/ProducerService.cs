using Confluent.Kafka;

namespace KafkaSample.Producer.Service
{
    public class ProducerService
    {
        private readonly ILogger<ProducerService> _logger;

        public ProducerService(ILogger<ProducerService> logger)
        {
            _logger = logger;
        }

        public async Task ProduceAsync(CancellationToken cancellationToken)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var deliveryResult = await producer.ProduceAsync(topic: "test-topic",
                    new Message<Null, string>
                    {
                        Value = $"Hello, Kafka Producer Test By JT - {DateTime.UtcNow}"
                    },
                    cancellationToken);

                _logger.LogInformation($"This message is Delivered to {deliveryResult.Value}, Offset: {deliveryResult.Offset}");
            }
            catch (ProduceException<Null, string> e)
            {
                _logger.LogError($"Delivery failed: {e.Error.Reason}");
            }

            producer.Flush(cancellationToken);
        }
    }
}
