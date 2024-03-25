using CSharp.Models;
using CSharp.Services;
using Microsoft.AspNetCore.Mvc;
namespace CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessingController : ControllerBase
    {
        private readonly IOrderService _orderService;
        //dependency inject order service
        public OrderProcessingController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            //exists. return body 
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder([FromRoute] int id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.Id)
            {
                return BadRequest();
            }

            _orderService.UpdateOrder(updatedOrder);
            //updated succesfully:return
            return Ok(updatedOrder);

        }

        [HttpPut("cancel/{id}")]
        public IActionResult CancelOrder(int id)
        {
            _orderService.CancelOrder(id);
            //if our result is successfully cancelled -> successful request

            return Ok("Order Cancelled");

        }
    }
}
