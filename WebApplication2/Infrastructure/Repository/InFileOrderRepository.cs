using WebApplication2.Domain;
using System.Collections.Generic;
using WebApplication2.Domain.Repository;

namespace WebApplication2.Infrastructure.Repository
{
    public class InFileOrderRepository : IOrderRepository
    {
        private static List<Order> orders = new List<Order>();
                
        public static void SaveAll(List<Order> orders)
        {
            this.orders = orders;
        }

        public List<Order> All()
        {
            return orders;
        }

        public void Save(Order order)
        {
            orders.Add(order);
        }
    }
}
