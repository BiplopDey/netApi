using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain;
using WebApplication2.DTO;
using WebApplication2.Application;
using WebApplication2.Domain.Repository;
using WebApplication2.Infrastructure.Repository;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private OrderService orderService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            orderService = new OrderService(new InFileOrderRepository());
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
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
        public string PostCookie(CookieOrderRequestDTO order)
        {
            int items = order.OrderLines.Count;
            orderService.createOrder(order);
            return "The size is "+ items;
        }
    }
}