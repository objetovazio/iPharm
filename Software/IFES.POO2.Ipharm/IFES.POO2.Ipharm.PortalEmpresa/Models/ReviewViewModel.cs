using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.PortalEmpresa.Models
{
    public class ReviewListViewModel
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string ReviewDetails { get; set; }

        public virtual Company Company { get; set; }
        public virtual Order Order { get; set; }
    }
}