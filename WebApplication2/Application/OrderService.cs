using WebApplication2.DTO;
using WebApplication2.Domain;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Application
{
    public class OrderService
    {
        private IOrderRepository orderRepository;
        private ICookieRepository cookieRepository;
        public OrderService(IOrderRepository orderRepository, ICookieRepository cookieRepository)
        {
            this.orderRepository = orderRepository;
            this.cookieRepository = cookieRepository;
        }

        public int createOrder(CookieOrderRequestDTO orderLinesRequest)
        {
            if (!ensureAllCookiesExits(orderLinesRequest.OrderLines))
            {
                return -1;
            } 

            List<OrderLine> orderLines = new List<OrderLine>();
            orderLinesRequest.OrderLines.ForEach(
                req => orderLines.Add(
                    new OrderLine(cookieRepository.FindById(req.CookieId), req.Quantity)));

            int orderId = orderRepository.All().Count + 1;
            orderRepository.Save(new Order(orderId, new Client(orderLinesRequest.ClientId, "bar"), orderLines));
            return orderId;
        }

        private bool ensureAllCookiesExits(List<OrderLineDTO> orderLines)
        {
            foreach(OrderLineDTO orderLine in orderLines)
            {
                if (!cookieRepository.Exists(orderLine.CookieId))
                {
                    return false;
                }
            }
            return true;
        }

        public List<Order> getAll()
        {
            return orderRepository.All();
        }
    }
}
