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
            InFileOrderRepository.clear();
            var repository = new InFileOrderRepository();

            repository.Save(generateOrder(1));
            repository.Save(generateOrder(2));

            Assert.True(repository.All().Count == 2);
            Assert.True(repository.All()[0].getClientId() == 2);
            InFileOrderRepository.clear();
        }

        [Fact]
        public void itCanComputeAllOrdersPrice()
        {
            InFileOrderRepository.clear();
            var repository = new InFileOrderRepository();

            repository.Save(generateOrder(1));
            repository.Save(generateOrder(2));

            Assert.True(repository.getTotalPriceAllOrders() == 120.0);
            InFileOrderRepository.clear();
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

            
            return new Order(1, new Client(1+id, "Foo"), orderLines);
        }
    }
    

}