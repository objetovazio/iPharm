using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.PortalEmpresa.Models
{
    public class OrdersListViewModel
    {
        public int Key { get; set; }
        public decimal ValueOrder { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }

        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual Person Person { get; set; }
        public List<ItemOrder> ItemsOrder { get; set; }
        public virtual Review Review { get; set; }
    }
}