using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_DAL.EntityFramework
{
    public class RepositoryBase
    {
        protected static DataContext context;
        protected static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if(context == null)
            {
                lock (_lockSync)
                {
                    if(context == null)
                    {
                        context = new DataContext();
                    }
                }
            }
        }
    }
}
