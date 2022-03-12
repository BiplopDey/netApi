using WebApplication2.Domain;
using Xunit;

namespace TestProject1
{
    public class DomainUnitTest
    {
        [Fact]
        public void Test1()
        {
            var cookie = new Cookie(1,2.3);
           // cookie.Price = 23;
            
            Assert.Equal(cookie.price, 2.3 );
        }
    }
}