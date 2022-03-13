namespace WebApplication2.Domain
{
    public class Order
    {
        private List<OrderLine> orderLines;
        private int clientId;
        private double totalPrice;

        public Order(Client client, List<OrderLine> orderLines)
        {
            clientId = client.id;
            this.orderLines = orderLines;

            totalPrice = calculateTotalPrice();
        }

        public double calculateTotalPrice()
        {
            double total = 0;
            foreach(OrderLine orderLine in orderLines){
                total += orderLine.getTotalPrice();
            }
            return total;
            // this.orderLines.Select(orderLine => orderLine.totalPrice()).Reduce(0,(acc, totalPrice) =>  acc + totalPrice);
        }

        public double getTotalPrice()
        {
            return totalPrice;
        }

        public double getClientId()
        {
            return clientId;
        }

        /*
        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Order))
                return false;
            
            return this.id == ((Dog)obj).id;
        }
        */
    }
}
