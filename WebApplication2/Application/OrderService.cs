using WebApplication2.DTO;
using WebApplication2.Domain;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Application
{
    public class OrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public int createOrder(CookieOrderRequestDTO orderLinesRequest)
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            orderLinesRequest.OrderLines.ForEach(
                req => orderLines.Add(
                    new OrderLine(new Cookie(req.CookieId, "foo", 2.2), req.Quantity)));

            orderRepository.Save(new Order(orderRepository.All().Count + 1, new Client(orderLinesRequest.ClientId, "bar"), orderLines));
            return 1;
        }

        public List<Order> getAll()
        {
            return orderRepository.All();
        }
    }
}
