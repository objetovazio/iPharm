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
        public decimal ValueOrder { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }

        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Payment> Payments { get; set; }
        public virtual Person Person { get; set; }
        public List<ItemOrder> ItemsOrder { get; set; }
        public virtual Review Review { get; set; }
    }

    public enum EnumOrderStatus
    {
        Feito = 1,
        Confirmado = 2,
        Pronto = 3,
        Enviado = 4,
        Entregue = 5
    }
}
