namespace WebApplication2.Domain
{
    public class OrderLine
    {
        private Cookie cookie;
        private int quantity;

        public OrderLine(Cookie cookie, int quantity)
        {
            this.cookie = cookie;
            this.quantity = quantity;
        }

        public double totalPrice()
        {
            return cookie.price * quantity;
        }
    }
}
