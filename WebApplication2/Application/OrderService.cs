﻿using WebApplication2.DTO;
using WebApplication2.Domain;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Application
{
    public class OrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public int createOrder(List<CookieOrderRequestDTO> orderLinesRequest)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            orderLinesRequest.ForEach(
                req => orderLines.Add(
                    new OrderLine(new Cookie(req.CookieId, "foo", 2.2), req.Quantity)));

            orderRepository.Save(new Order(new Client(orderLinesRequest[0].ClientId, "bar"), orderLines));
            return 1;
        }
    }
}
