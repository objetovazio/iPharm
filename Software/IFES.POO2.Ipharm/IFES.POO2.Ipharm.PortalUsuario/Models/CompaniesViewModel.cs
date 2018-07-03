using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using IFES.POO2.Ipharm.Domain;

namespace IFES.POO2.Ipharm.PortalUsuario.Models
{
    public class CompanyListViewModel
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }

        public User User { get; set; }
        public List<Product> Products { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Order> Orders { get; set; }

        public GeoCoordinate UserCoordinate { get; set; }

        public GeoCoordinate ShopCoordinate
        {
            get { return new GeoCoordinate(User.Localization.Latitude, User.Localization.Longitude); }
        }

        public string GetDistance
        {
            get
            {
                return UserCoordinate.GetDistanceTo(ShopCoordinate).ToString("##,#") + " KM";
            }
        }
    }
}