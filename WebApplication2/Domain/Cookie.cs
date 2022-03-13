namespace WebApplication2.Domain
{
    public class Cookie
    {
        public int id;
        public string name;
        public double price; 

        public Cookie(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }       
    }
}
