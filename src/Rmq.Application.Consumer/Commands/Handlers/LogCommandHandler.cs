using System;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WorkingWithMongoDB.WebAPI.Models;
using WorkingWithMongoDB.WebAPI.Services;

namespace Rmq.Application.Consumer.Commands.Handlers
{
    public class LogCommandHandler : IRequestHandler<LogCommand>
    {
        private readonly ILogger<LogCommandHandler> _logger;
        private readonly CustomerService _customerService;

        public LogCommandHandler(ILogger<LogCommandHandler> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;

        }
        

        public Task<Unit> Handle(LogCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---- Received message: {Message} ----", request.Message);
           
            var transaction = new Customer();
            transaction.TransactionId= request.TransactionDetails.TransactionId;
            transaction.TransactionAmount = request.TransactionDetails.TransactionAmount;
            transaction.MerchantID = request.TransactionDetails.MerchantID;
            transaction.CardType = request.TransactionDetails.CardType;

           _customerService.CreateAsync(transaction);
            return Task.FromResult(Unit.Value);
        }
    }
}
