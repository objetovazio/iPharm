using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public Guid IdUser { get; set; }
        public string Street_Name { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CEP { get; set; }
        public string Details { get; set; }


        public virtual User User { get; set; }
    }
}
