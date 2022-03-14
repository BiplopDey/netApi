namespace WebApplication2.Domain
{
    public class OrderLine
    {
        private int cookieId;
        private int quantity;
        private double totalPrice;

        public OrderLine(Cookie cookie, int quantity)
        {
            cookieId = cookie.id;
            this.quantity = quantity;
            totalPrice = calculateTotalPrice(cookie.price);
        }

        public OrderLine(int cookieId, int quantity, double totalPrice)
        {
            this.cookieId = cookieId;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }

        private double calculateTotalPrice(double price)
        {
            return price * quantity;
        }

        public double getTotalPrice()
        {
            return totalPrice;
        }

        public int getQuantity()
        {
            return quantity;
        }
        public int getCookieId()
        {
            return cookieId;
        }
    }
}
