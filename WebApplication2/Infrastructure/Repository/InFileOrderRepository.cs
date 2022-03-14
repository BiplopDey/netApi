using WebApplication2.Domain;
using System.Collections.Generic;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Infrastructure.Repository
{
    public class InFileOrderRepository : IOrderRepository
    {
        public static List<Order> orders = new List<Order>();
        
        public static void clear()
        {
            orders = new List<Order>();
        }
        public List<Order> All()
        {
            return orders;
        }

        public void Save(Order order)
        {
            orders.Add(order);
        }

        public double getTotalPriceAllOrders()
        {
            double total = 0;
            foreach (Order order in orders)
            {
                total += order.getTotalPrice();
            }
            return total;
        }

    }
}
