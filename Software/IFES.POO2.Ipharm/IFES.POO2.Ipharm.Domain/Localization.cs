using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFES.POO2.Ipharm.Domain
{
    public class Localization
    {
        public Localization()
        {
            
        }

        public Localization(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        
        public virtual User User { get; set; }
    }
}
