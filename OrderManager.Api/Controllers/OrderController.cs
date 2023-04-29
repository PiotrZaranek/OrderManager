using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Application.Interface;
using OrderManager.Application.Mediator.Interface;
using OrderManager.Domain.Model;
using System.Runtime.CompilerServices;

namespace OrderManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static private IMediator _mediator;

        public OrderController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<List<Order>> Order(string? number, string? dateFrom, string? dateTo, string? code)         
        {
            List<Order> orders;

            try
            {
                orders = _mediator.Notify(number, dateFrom, dateTo, code);
            }
            catch 
            {
                return BadRequest("Something goes wrong!");    
            }

            return Ok(orders);
        }
    }
}
