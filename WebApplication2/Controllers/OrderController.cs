using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using WebApplication2.Domain;
using WebApplication2.DTO;
using WebApplication2.Application;
using WebApplication2.Domain.Repository;
using WebApplication2.Infrastructure.Repository;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController()
        {
            orderService = new OrderService(new InFileOrderRepository(), new InFileCookieRepository());
        } 

        [HttpGet]
        public IEnumerable<OrderResponseDTO> Get()
        {
            var orders = orderService.getAll();

            return orders.Select(order => new OrderResponseDTO
            {
                OderId = order.getId(),
                ClientId = order.getClientId(),
                TotalPrice = order.getTotalPrice()
            });
        }
         
        [HttpPost]
        public string Post(CookieOrderRequestDTO order)
        {
            int orderId = orderService.createOrder(order);
            if (orderId < 0) return "Cookie Not Fount or surpases the monthly cap";
            return "Your order id: " + orderId;
        }
    }
}
