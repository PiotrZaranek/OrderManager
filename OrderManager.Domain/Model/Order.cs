using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain.Model
{
    public class Order
    {
        public string Number { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
        public double Value { get; set; }

        public static Order FromCsvFile(string csvString)
        {
            string[] values = csvString.Split(",");
            CultureInfo provider = CultureInfo.CurrentCulture;

            return new Order()
            {
                Number = values[0],
                ClientCode = values[1],
                ClientName = values[2],
                OrderDate = DateTime.ParseExact(values[3], "dd.MM.yyyy", provider),
                ShipmentDate = DateTime.ParseExact(values[4], "dd.MM.yyyy", provider),
                Quantity = int.Parse(values[5]),
                Confirmed = Convert.ToBoolean(Int32.Parse(values[6])),
                Value = double.Parse(values[7], CultureInfo.InvariantCulture)
            };
        }        
    }
}
