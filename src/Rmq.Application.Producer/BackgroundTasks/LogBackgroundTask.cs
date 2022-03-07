using Microsoft.Extensions.Hosting;
using Rmq.Application.Producer.IntegrationEvents;
using Rmq.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Rmq.Application.Producer.TransactionDTO;

namespace Rmq.Application.BackgroundTasks
{
    public class LogBackgroundTask : BackgroundService
    {
        private readonly IRabbitMqProducer<LogIntegrationEvent> _producer;

        public LogBackgroundTask(IRabbitMqProducer<LogIntegrationEvent> producer) => _producer = producer;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var @event = new LogIntegrationEvent
                {
                    Id = Guid.NewGuid(),
                    Message = $"Hello! Message generated at {DateTime.Now.ToString("O")}",
                    TransactionDetails = new TransactionDetails{TransactionId = "T123", CardType = "Visa",TransactionAmount = "23",MerchantID = "123"}
                    

                };

                _producer.Publish(@event);
                await Task.Delay(2000, stoppingToken);
            }

            await Task.CompletedTask;
        }
    }
}
