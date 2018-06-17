using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IFES.POO2.Ipharm.PortalAdministrativo.Models.Admin
{
    public class ListAdminViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        [Display(Name = "Nome Completo")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Ativo")]
        public bool IsActive { get; set; }
    }

    public class RegisterAdminViewModel : RegisterViewModel
    { }
}