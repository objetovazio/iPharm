﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }

        public virtual List<PaymentMethod> PaymentMethods { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual User User { get; set; }
    }
}
