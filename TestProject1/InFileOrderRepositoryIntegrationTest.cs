using WebApplication2.Domain;
using Xunit;
using System.Collections.Generic;
using WebApplication2.Infrastructure.Repository;

namespace TestProject1
{
    public class InFileRepositoryIntegrationTest
    {
        [Fact]
        public void itCanSaveOrders()
        {
            InFileOrderRepository.SaveAll(new List<Order>() 
            {
                generateOrder(1), generateOrder(2)
            });

            Assert.True(new InFileOrderRepository().All().Count == 2);
        }

        private Order generateOrder(int id)
        {
            var appleCookie = new Cookie(1+id, "apple", 2.3);
            var chocCookie = new Cookie(2+id, "chocolate", 3.7);
            var orderLines = new List<OrderLine>()
                {
                    new OrderLine(appleCookie, 10),
                    new OrderLine(chocCookie, 10)
                };

            
            return new Order(new Client(1+id, "Foo"), orderLines);
        }
    }
    

}