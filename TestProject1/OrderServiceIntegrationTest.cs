using WebApplication2.Domain;
using Xunit;
using WebApplication2.Application;
using WebApplication2.Domain.Repository;
using WebApplication2.Infrastructure.Repository;
using WebApplication2.DTO;
using System.Collections.Generic;
using System;

namespace TestProject1
{
    public class OrderServiceIntegreationTest
    {
        [Fact]
        public void itCanCreateOrder()
        {
            InFileOrderRepository.clear();

            var inFileOrderRepository = new InFileOrderRepository();
            var orderService = new OrderService(inFileOrderRepository, new InFileCookieRepository());

            int i = orderService.createOrder(generateOrderRequest());
            orderService.createOrder(generateOrderRequest());

            Assert.True(i == 1);
            Assert.True(inFileOrderRepository.All().Count == 2);
            Assert.True(inFileOrderRepository.All()[0].getClientId() == 1);

            InFileOrderRepository.clear();
        }

        [Fact]
        public void itCantCreateOrderWithWrongId()
        {
            InFileOrderRepository.clear();

            var inFileOrderRepository = new InFileOrderRepository();
            var orderService = new OrderService(inFileOrderRepository, new InFileCookieRepository());

            int orderId = orderService.createOrder(generateInvalidOrderRequest());

            Assert.True(orderId == -1);
            Assert.True(inFileOrderRepository.All().Count == 0);

            InFileOrderRepository.clear();
        }

        [Fact]
        public void itCanGetAllOrders()
        {
            InFileOrderRepository.clear();
            var inFileOrderRepository = new InFileOrderRepository();
            var orderService = new OrderService(inFileOrderRepository, new InFileCookieRepository());
            int i = orderService.createOrder(generateOrderRequest());
            orderService.createOrder(generateOrderRequest());

            Assert.True(i == 1);
            Assert.True(orderService.getAll().Count == 2);
            Assert.True(orderService.getAll()[0].getClientId() == 1);

            InFileOrderRepository.clear();
        }

        [Fact]
        public void itCantOrderIfTheTotalAumountSurpases200()
        {
            InFileOrderRepository.clear();
            var inFileOrderRepository = new InFileOrderRepository();
            var orderService = new OrderService(inFileOrderRepository, new InFileCookieRepository());
            
            orderService.createOrder(generateOrderRequest());
            orderService.createOrder(generateOrderRequest());
            orderService.createOrder(generateOrderRequest());

            Assert.True(orderService.getAll().Count == 2);
            InFileOrderRepository.clear();
        }

        private CookieOrderRequestDTO generateOrderRequest()
        {
            return new CookieOrderRequestDTO()
            {
                ClientId = 1,
                OrderLines = new List<OrderLineDTO>()
                {
                    new OrderLineDTO
                    {
                        CookieId = 1,
                        Quantity = 10
                    },
                    new OrderLineDTO
                    {
                        CookieId = 2,
                        Quantity = 10
                    },
                    new OrderLineDTO
                    {
                        CookieId = 3,
                        Quantity = 10
                    }
                }  
            };
        }
        private CookieOrderRequestDTO generateInvalidOrderRequest()
        {
            return new CookieOrderRequestDTO()
            {
                ClientId = 1,
                OrderLines = new List<OrderLineDTO>()
                {
                    new OrderLineDTO
                    {
                        CookieId = 10,
                        Quantity = 2
                    },
                    new OrderLineDTO
                    {
                        CookieId = 2,
                        Quantity = 2
                    },
                    new OrderLineDTO
                    {
                        CookieId = 3,
                        Quantity = 4
                    }
                }
            };
        }
    }
}