
namespace WebApplication2.Domain.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);

        List<Order> All();
    }
}
