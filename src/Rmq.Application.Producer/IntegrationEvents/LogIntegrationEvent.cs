using System;
using Rmq.Application.Producer.TransactionDTO;

namespace Rmq.Application.Producer.IntegrationEvents
{
    public class LogIntegrationEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public TransactionDetails TransactionDetails { get; set; }
    }
}
