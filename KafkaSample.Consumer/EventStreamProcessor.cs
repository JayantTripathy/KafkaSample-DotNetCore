using Confluent.Kafka;

namespace KafkaSample.Consumer
{
    public class EventStreamProcessor : BackgroundService
    {
        private readonly ILogger<EventStreamProcessor> _logger;

        public EventStreamProcessor(ILogger<EventStreamProcessor> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("test-topic");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(5));

                    if (consumeResult == null)
                    {
                        continue;
                    }
                    _logger.LogInformation($"Consumer getting message here.....");
                    _logger.LogInformation($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.Offset}'");
                }
                catch (Exception)
                {
                    // Ignore
                }
            }
            return Task.CompletedTask;
        }
    }
}
