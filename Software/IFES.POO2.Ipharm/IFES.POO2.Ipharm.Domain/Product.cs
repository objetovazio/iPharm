using System;
using System.Collections.Generic;

namespace IFES.POO2.Ipharm.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public bool HasControl { get; set; }

        public virtual List<ItemOrder> ItemOrders { get; set; }
        public virtual Company Company { get; set; }
    }
}