using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Person : User
    {
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
