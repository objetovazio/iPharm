using System;

namespace IFES.POO2.Ipharm.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string ReviewDetails { get; set; }

        public virtual Company Company { get; set; }
        public virtual Order Order { get; set; }
    }
}