using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public EnumPaymentMethod PaymentOption { get; set; }
        public string Description { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }

        public virtual Person Person { get; set; }
        public virtual List<Payment> Payments{ get; set;}
    }

    public enum EnumPaymentMethod
    {
        Card = 1,
        Money = 2
    }
}
