using WebApplication2.Domain;
using Xunit;
using WebApplication2.Application;
using WebApplication2.Domain.Repository;
using WebApplication2.Infrastructure.Repository;
using WebApplication2.DTO;
using System.Collections.Generic;

namespace TestProject1
{
    public class OrderServiceIntegreationTest
    {
        [Fact]
        public void itCanCreateOrder()
        {
            var inFileOrderRepository = new InFileOrderRepository()
            var orderService = new OrderService(inFileOrderRepository);

            orderService.createOrder(generateOrderRequest());

            Assert.True(inFileOrderRepository.All().Count == 3);
            Assert.True(inFileOrderRepository.All()[0].getClientId() == 1);
        }

        private List<CookieOrderRequestDTO> generateOrderRequest()
        {
            return new List<CookieOrderRequestDTO>()
            {
                new CookieOrderRequestDTO
                {
                    ClientId = 1,
                    CookieId = 1,
                    Quantity = 2
                },
                new CookieOrderRequestDTO
                {
                    ClientId = 1,
                    CookieId = 3,
                    Quantity = 3
                },
                 new CookieOrderRequestDTO
                {
                    ClientId = 1,
                    CookieId = 3,
                    Quantity = 3
                }
            };
        }
    }
}