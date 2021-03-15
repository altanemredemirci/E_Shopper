using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_WebUI.Identity
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext() : base("DataContext")
        {

        }
    }
}
