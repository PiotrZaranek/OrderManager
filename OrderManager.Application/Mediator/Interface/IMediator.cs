using Microsoft.VisualBasic;
using OrderManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Mediator.Interface
{
    public interface IMediator
    {
        List<Order> Notify(string number, string from, string to, string code);
    }
}
