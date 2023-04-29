using OrderManager.Application.Interface;
using OrderManager.Application.Mediator.Interface;
using OrderManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Mediator.Concrete
{
    public class Mediator : IMediator
    {
        private readonly IOrderService _orderService;

        public Mediator(IOrderService orderService) => _orderService = orderService;      

        public List<Order> Notify(string number, string from, string to, string code)
        {
            return _orderService.GetOrders(number, from, to, code);
        }
    }
}
