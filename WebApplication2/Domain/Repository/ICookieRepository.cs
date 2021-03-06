namespace WebApplication2.Domain.Repository
{
    public interface ICookieRepository
    {
        void Save(Cookie cookie);
        bool Exists(int id);
        Cookie FindById(int id);
        List<Cookie> All();
    }
}
