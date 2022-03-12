using WebApplication2.Domain;
using Xunit;

namespace TestProject1
{
    public class DomainUnitTest
    {
        [Fact]
        public void itCanCreateCookie()
        {
            var cookie = new Cookie(1,"apple",2.3);
           
            Assert.Equal(cookie.id, 1);
            Assert.Equal(cookie.name, "apple");
            Assert.Equal(cookie.price, 2.3 );
        }
    }

    public class OderLineUnitTest
    {
        public void itCanGetTotalPrice()
        {
            var appleCookie = new Cookie(1, "apple", 2.3);
            var orderLine = new OrderLine(appleCookie, 10);

            var sut = orderLine.totalPrice();

            Assert.Equal(sut, 23.0);

        }
    }
    public class OderUnitTest
    {
        public void Test1()
        {
            var appleCookie = new Cookie(1, "apple", 2.3);
            var chocCookie = new Cookie(1, "chocolate", 3.7);

            Assert.True(true);
        }
    }

}