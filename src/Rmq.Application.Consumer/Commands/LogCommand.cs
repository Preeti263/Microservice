using MediatR;
using System;
using System.Transactions;
using Rmq.Application.Producer.TransactionDTO;

namespace Rmq.Application.Consumer.Commands
{
    public class LogCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public TransactionDetails TransactionDetails { get; set; }
    }
}
