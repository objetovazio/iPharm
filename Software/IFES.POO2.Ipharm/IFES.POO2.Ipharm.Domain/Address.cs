using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Address
    {
        public int Id;
        public string Street_Name;
        public string Neighborhood;
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CEP { get; set; }
        public string Details { get; set; }
        public User User { get; set; }

    }
}
