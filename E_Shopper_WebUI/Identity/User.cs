using E_Shopper_Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_WebUI.Identity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public User()
        {
            Addresses = new List<Address>();
        }

    }

}
