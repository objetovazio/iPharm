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

        public List<Order> Orders { get; set; }
        public List<Company> Companies { get; set; }
    }
}