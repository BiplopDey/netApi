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
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private OrderService orderService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            orderService = new OrderService(new InFileOrderRepository());
        }
        /*
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        */
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<OrderResponseDTO> Get()
        {
            var orders = orderService.getAll();
            
            return Enumerable.Range(0, orders.Count-1).Select(index => new OrderResponseDTO
            {
                OderId = index,
                ClientId = orders[index].getClientId(),
                TotalPrice = orders[index].getTotalPrice()
            })
            .ToArray();
        }

        [HttpPost]
        public string PostCookie(List<CookieOrderRequestDTO> order)
        {
            int items = order.Count;
            orderService.createOrder(order);
            return "The size is "+ items;
        }
    }
}