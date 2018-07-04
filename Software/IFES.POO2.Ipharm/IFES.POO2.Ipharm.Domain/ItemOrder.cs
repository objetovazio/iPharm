using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class ItemOrder
    {
        public ItemOrder() { }

        public ItemOrder(Order order, Product product)
        {
            this.Order = order;
            this.Product = product;
        }

        public int Id { get; set; }
        public decimal ItemValue { get; set; }
        public decimal ItemDescount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
