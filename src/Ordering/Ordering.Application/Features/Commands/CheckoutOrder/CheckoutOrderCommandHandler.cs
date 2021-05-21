using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infraestructure;
using Ordering.Application.Contracts.Persistent;
using Ordering.Application.Models;
using Ordering.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.CheckoutOrder {
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int> {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger) {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken) {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully creted.");

            await SendEmail(newOrder);

            return newOrder.Id;
        }

        private async Task SendEmail(Order order) {
            var email = new Email() { To = "jorginho@riseup.net", Body = $"Order was created", Subject = "Order was created" };

            try {
                await _emailService.SendEmail(email);
            } 
            catch(Exception ex) {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail server: {ex.Message}");
            }
        }
    }
}
