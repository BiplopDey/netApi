namespace WebApplication2.Domain
{
    public class Order
    {
        private int id;
        private List<OrderLine> orderLines;
        private int clientId;
        private double totalPrice;

        public Order(int id, Client client, List<OrderLine> orderLines)
        {
            this.id = id;
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

        public int getClientId()
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
