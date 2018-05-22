using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public double Value_Total { get; set; }
        public List<Payment> Payments { get; set; }
        public Company company { get; set; }
        public Person Person { get; set; }
        public List<Product> Products { get; set; }
        public Review Review { get; set; }
    }
}
