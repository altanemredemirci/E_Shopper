using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_WebUI.Identity
{
    public class Role:IdentityRole
    {
        public string Description { get; set; }

        public Role()
        {

        }

        public Role( string rolename, string description)
        {
            this.Description = description;
        }
    }
}
