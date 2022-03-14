using WebApplication2.DTO;
using WebApplication2.Domain;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Application
{
    public class OrderService
    {
        private readonly double MAX_AMOUNT = 200;
        private IOrderRepository orderRepository;
        private ICookieRepository cookieRepository;
        public OrderService(IOrderRepository orderRepository, ICookieRepository cookieRepository)
        {
            this.orderRepository = orderRepository;
            this.cookieRepository = cookieRepository;
        }

        public int createOrder(CookieOrderRequestDTO orderLinesRequest)
        {
            if (!ensureAllCookiesExits(orderLinesRequest.OrderLines)) return -1;
            
            List<OrderLine> orderLines = new List<OrderLine>();
            orderLinesRequest.OrderLines.ForEach(
                req => orderLines.Add(
                    new OrderLine(cookieRepository.FindById(req.CookieId), req.Quantity)));
            int orderId = generateOrderId();
            var order = new Order(orderId, new Client(orderLinesRequest.ClientId, "bar"), orderLines);

            if (!ensureTotalPriceIsUnderMasAmount(order.getTotalPrice())) return -1;
            
            orderRepository.Save(order);
            return orderId;
        }

        private bool ensureTotalPriceIsUnderMasAmount(double price)
        {
            return orderRepository.getTotalPriceAllOrders() + price <= MAX_AMOUNT;
        }

        private int generateOrderId()
        {
            return orderRepository.All().Count + 1;
        }

        private bool ensureAllCookiesExits(List<OrderLineDTO> orderLines)
        {
            foreach(OrderLineDTO orderLine in orderLines)
            {
                if (!cookieRepository.Exists(orderLine.CookieId)) return false;
                
            }
            return true;
        }

        public List<Order> getAll()
        {
            return orderRepository.All();
        }
    }
}
