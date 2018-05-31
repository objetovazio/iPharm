using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Company 
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }

        public User User { get; set; }
        public virtual List<Product> Products { get; set; } 
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
