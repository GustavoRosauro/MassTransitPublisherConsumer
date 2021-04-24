using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasstransitExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBusControl _bus;
        public OrderController(IBusControl bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            Uri uri = new Uri("rabbitmq://localhost/ticket");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(order);
            return Ok("Success");
        }
    }
}
