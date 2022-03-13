namespace WebApplication2.Domain.Repository
{
    public interface ICookieRepository
    {
        void Save(Cookie cookie);
        bool Exists(int id);

        List<Cookie> All();
    }
}
