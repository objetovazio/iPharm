using System;
using System.Collections.Generic;

namespace IFES.POO2.Ipharm.Domain
{
    public class User
    {
        public Guid Id;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Boolean IsActive { get; set; }

        public Localization Localization { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
