using WebApplication2.Domain;
using Xunit;
using System.Collections.Generic;
using WebApplication2.Infrastructure.Repository;

namespace TestProject1
{
    public class InFileCookieRepositoryIntegrationTest
    {
        [Fact]
        public void itCanCreateCookies()
        {
            InFileCookieRepository.clear();
            var repository = new InFileCookieRepository();

             repository.Save(new Cookie(12,"dd",2.2));
             repository.Save(new Cookie(22, "dd", 2.2));

            Assert.True(repository.All().Count >= 2);
            InFileCookieRepository.clear();
        }

        [Fact]
        public void itCanSayExistACookie()
        {
            InFileCookieRepository.clear();
            var repository = new InFileCookieRepository();

            repository.Save(new Cookie(111, "dd", 2.2));
            repository.Save(new Cookie(222, "dd", 2.2));

            Assert.True(repository.Exists(111));
            Assert.False(repository.Exists(333));
            InFileCookieRepository.clear();
        }

        [Fact]
        public void itCanFindACookie()
        {
            InFileCookieRepository.clear();
            var repository = new InFileCookieRepository();

            repository.Save(new Cookie(111, "dd", 2.2));
            repository.Save(new Cookie(222, "dd", 2.2));

            
            Assert.True(repository.FindById(111).id == 111);
            InFileCookieRepository.clear();
        }
    }
}
    
