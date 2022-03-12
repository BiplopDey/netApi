namespace WebApplication2.Domain
{
    public class Order
    {
        private List<OrderLine> orderLines;

        public Order(List<OrderLine> orderLines)
        {
            this.orderLines = orderLines;
        }

        public double totalPrice()
        {
            double total = 0;
            foreach(OrderLine orderLine in orderLines){
                total += orderLine.totalPrice();
            }
            return total;
            // this.orderLines.Select(orderLine => orderLine.totalPrice()).Reduce(0,(acc, totalPrice) =>  acc + totalPrice);
        }
    }
}
