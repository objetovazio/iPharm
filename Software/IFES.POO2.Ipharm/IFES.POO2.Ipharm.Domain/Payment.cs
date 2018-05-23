using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdPaymentMethod { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public EnumPaymentStatus PaymentStatus { get; set; }


        public virtual Order Order { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }

    public enum EnumPaymentStatus
    {
        Aguardando = 1,
        Pago = 2,
        Negado = 3
    }
}
