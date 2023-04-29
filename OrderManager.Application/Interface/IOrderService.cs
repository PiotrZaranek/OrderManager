using OrderManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Interface
{
    public interface IOrderService
    {
        List<Order> GetOrders(string number, string from, string to, string code);
    }
}
