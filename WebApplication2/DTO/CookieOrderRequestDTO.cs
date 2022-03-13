namespace WebApplication2.DTO
{
    public class CookieOrderRequestDTO
    {
        public int ClientId { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; }
    }
}
