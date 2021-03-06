﻿using System;
using System.Collections.Generic;

namespace IFES.POO2.Ipharm.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdministrator { get; set; }

        public virtual Localization Localization { get; set; }
        public virtual List<Address> Addresses { get; set; }

        public virtual Person Person { get; set; }
        public virtual Company Company { get; set; }
    }
}
