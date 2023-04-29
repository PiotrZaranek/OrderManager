using OrderManager.Application.Interface;
using OrderManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Service
{
    public class OrderService : IOrderService
    {
        private const string path = "C:\\temp\\file.csv";

        public List<Order> GetOrders(string number, string from, string to, string code)
        {
            var orders = GetOrdersFromFile().ToList();

            if (from != null)
            {
                orders = OrdersFromDate(orders, from);
            }

            if (to != null)
            {
                orders = OrdersToDate(orders, to);
            }

            if (code != null)
            {
                orders = OrdersConcreteClietn(orders, code);
            }

            if (number != null)
            {
                return ConcreteOrder(orders, number);
            }

            return orders;
        }     
        
        private List<Order> OrdersFromDate(List<Order> orders, string from) 
        {
            return orders.Where(o => o.OrderDate >= ConvertToDateTime(from)).ToList();            
        }

        private List<Order> OrdersToDate(List<Order> orders, string to) 
        {
            return orders.Where(o => o.OrderDate < ConvertToDateTime(to)).ToList();
        }

        private DateTime ConvertToDateTime(string str) 
        { 
            CultureInfo culture = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(str, "dd.MM.yyyy", culture);
        }

        private List<Order> OrdersConcreteClietn(List<Order> orders, string code)
        {
            return orders.Where(o => o.ClientCode == code).ToList();
        }

        private List<Order> ConcreteOrder(List<Order> orders, string number)
        {
            return orders.Where(o => o.Number == number).ToList();
        }

        private IEnumerable<Order> GetOrdersFromFile()
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Select(str => Order.FromCsvFile(str));
        }
    }


}
