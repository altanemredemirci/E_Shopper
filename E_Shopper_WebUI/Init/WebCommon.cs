using E_Shopper_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shopper_WebUI.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}