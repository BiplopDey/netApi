using WebApplication2.Domain;
using Xunit;
using System.Collections.Generic;

namespace TestProject1
{
    public class DomainUnitTest
    {
        [Fact]
        public void itCanCreateCookie()
        {
            var cookie = new Cookie(1, "apple", 2.3);

            Assert.True(cookie.id == 1);
            Assert.True(cookie.name == "apple");
            Assert.True(cookie.price == 2.3);
        } 
    }
    
    public class OderLineUnitTest
    {
        [Fact]
        public void itCanGetTotalPrice()
        {
            var appleCookie = new Cookie(1, "apple", 2.3);
            var orderLine = new OrderLine(appleCookie, 10);

            var sut = orderLine.totalPrice();

            Assert.True(sut == 23.0);

        }
    }
    
    public class OderUnitTest
    {
        [Fact]
        public void itCanGetTotalPrice()
        {
            var appleCookie = new Cookie(1, "apple", 2.3);
            var chocCookie = new Cookie(1, "chocolate", 3.7);
            var orderLines = new List<OrderLine>()
                { 
                    new OrderLine(appleCookie, 10),
                    new OrderLine(chocCookie, 10)
                };
            
            var order = new Order(new Client(1,"Foo") , orderLines);
            
            Assert.True(order.totalPrice() == 60.0);
        }
    }
    

}